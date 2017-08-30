using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using calculator.Models;
using System.Data.Linq;
using System.Data;
using calculator.Models.MyViewModel;

namespace calculator.Controllers
{
    public class HomeController : Controller
    {
        poligraphContext db = new poligraphContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Indexpart(int idTypePapers)
        {
            //ViewBag.TypePapers = new SelectList(db.TypePapers, "IdTypePapers", "Name");

            return PartialView(idTypePapers);
        }
       
        public ActionResult Calculator()
        {
            SelectList formatProduct = new SelectList(db.FormatProducts.Where(c => c.IdFormatProduct > 2), "IdFormatProduct", "Format");
            ViewBag.FormatProductsList = formatProduct;
            SelectList typePaper = new SelectList(db.TypePapers, "IdTypePapers", "Name");
            ViewBag.TypePapers = typePaper;
            ViewBag.Densities = new SelectList(db.Densities, "IdDensity", "Value");
            ViewBag.Colours = new SelectList(db.Colours, "IdColour", "Name");
            ViewBag.Bigovkas = new SelectList(db.Bigovkas, "IdBigovki", "TypeBigovki");
            ViewBag.DensityLamins = new SelectList(db.DensityLamins, "IdLam", "DensityLam");
            ViewBag.Faltsovki = new SelectList(db.Faltsovkas, "IdFaltsovki", "TypeFaltsovki");
            ViewBag.RoundAngles = new SelectList(db.RoundAngles, "IdRoundAngle", "TypeRoundAngle");
            ViewBag.TypeLaminations = new SelectList(db.TypeLaminations, "IdTypeLam", "TypeLam");


            ViewBag.FormatProductsVisits = new SelectList(db.FormatProducts.Where(c => c.IdFormatProduct < 3), "IdFormatProduct", "Format");
            ViewBag.TypePapersVisits = new SelectList(db.TypePapers, "IdTypePapers", "Name");
            ViewBag.DensitiesVisits = new SelectList(db.Densities, "IdDensity", "Value");
            ViewBag.ColoursVisits = new SelectList(db.Colours, "IdColour", "Name");
            ViewBag.TypeLaminationsVisits = new SelectList(db.TypeLaminations, "IdTypeLam", "TypeLam");
            ViewBag.DensityLaminsVisits = new SelectList(db.DensityLamins, "IdLam", "DensityLam");
            ViewBag.RoundAnglesVisits = new SelectList(db.RoundAngles, "IdRoundAngle", "TypeRoundAngle");

 
            var usr = Session["user"] as calculator.Models.User;
            if (usr != null)
            {
                ViewBag.user = true;
            }
            return View();

        }

        public ActionResult GetTypePapersVisits(int id)
        {
            return PartialView(db.TypePapers.Where(c => c.IdFormatPaper == id).ToList());
        }
        public ActionResult GetDensityPapersVisits(int id)
        {
            return PartialView(db.Densities.Where(o => o.IdTypePapers == id).ToList());
        }
        public ActionResult GetDensityLamsVisits(int id)
        {
            return PartialView(db.DensityLamins.Where(o => o.TypeLamId == id).ToList());
        }
        public ActionResult GetTypePapers(int id)
        {
            return PartialView(db.TypePapers.Where(c => c.IdFormatPaper == id).ToList());
        }
        public ActionResult GetDensityPapers(int id)
        {
            return PartialView(db.Densities.Where(o => o.IdTypePapers == id).ToList());
        }
        public ActionResult GetDensityLams(int id)
        {
            return PartialView(db.DensityLamins.Where(o => o.TypeLamId == id).ToList());
        }

        double costPaperVisit, costTonerVisit, costLaminVisit, costTimePintVisit, costAddServVisit;
        double quantityListForVisits;
        double CostHour, timePrint, timeLam, CostTimePrint, CostTimeLam;


        int idUser;
        [HttpPost]

        public ActionResult cosеtVistCard(int quantityVisits, int idFormat, int idPapeVisits,
            int idDensityVisits, int idColour, int idTypeLamVisits, int idLamVisits,
               int makeOrderVisit, int idRoundAngle)
        {

            if (idFormat == 1)
            {
                quantityListForVisits = (double)Math.Ceiling((decimal)quantityVisits / 12);
            }
            else if (idFormat == 2)
            {
                quantityListForVisits = (double)Math.Ceiling((decimal)quantityVisits / 10);
            }

            var takePaperVisit = from b in db.CostPages where b.IdDensitiesPage == idDensityVisits select b.CostPaper;
            foreach (var ord in takePaperVisit)
            {
                costPaperVisit = ord;
            }

            var takecostTonerVisit = from q in db.PriceToners where q.FormatId == idFormat && q.ColourId == idColour select q.CostToner;
            foreach (var ord2 in takecostTonerVisit)
            {
                costTonerVisit = ord2;
            }

            var takeCostLaminVisit = from q in db.CostLaminations where q.FormatPaperId == 10 && q.DensityLamId == idLamVisits select q.CostLam;
            foreach (var ord in takeCostLaminVisit)
            {
                costLaminVisit = ord;
            }

            var takeCostHour = from q in db.CostOfOwners select q;
            foreach (var w in takeCostHour)
            {
                int sumUpCostOwn = w.Rent + w.ReturnInvestision + w.Salary + w.CostOwnMachine + w.GeneralProdSpend;
                CostHour = sumUpCostOwn / w.TimeWorkingInMonth;
            }

            var takeSpeedPrint = from b in db.CharacterPrintMachines select b;
            foreach (var s in takeSpeedPrint)
            {
                timePrint = (double)quantityListForVisits / (double)s.QuantityListInMinute;
            }
            timePrint *= 50;
            if (idColour == 1 || idColour == 7)
            {
                CostTimePrint = CostHour / 60 * timePrint;
            }
            else
            {
                timePrint *= 2;
                CostTimePrint = CostHour / 60 * timePrint;
            }
            
            if (costLaminVisit != 0)
            {
                var takeSpeedLamin = from b in db.CharacterLaminMachines where b.IdFormatList == 10 select b;
                foreach (var s in takeSpeedLamin)
                {
                    timeLam = (double)quantityListForVisits / (double)s.QuantityListInMinute;
                }
                if (idTypeLamVisits == 1 || idTypeLamVisits == 2)
                {
                    CostTimeLam = CostHour / 60 * timeLam;
                }
                else
                {
                    timeLam *= 2;
                    CostTimeLam = CostHour / 60 * timeLam;

                }
            }
            else
            {
                CostTimeLam = 0;
                timeLam = 0;
            }




            ViewBag.CostTimeLam = CostTimeLam;
            ViewBag.timeLam = timeLam;


            ViewBag.CostTimePrint = CostTimePrint;
            ViewBag.CostHour = CostHour;
            ViewBag.timePrint = timePrint;






            var takeCostAddServVisit = from q in db.RoundAngles where q.IdRoundAngle == idRoundAngle select q.CostRoundAngle;
            foreach (var ord in takeCostAddServVisit)
            {
                costAddServVisit += ord;
            }
            double costVisit = costTonerVisit * quantityVisits + costPaperVisit * quantityListForVisits +
                 costLaminVisit * quantityListForVisits + costAddServVisit * quantityVisits;
            costVisit += CostTimePrint;
            costVisit += CostTimeLam;




            var takePercentTP = from q in db.PercenTaxProfits select q;
            foreach (var ord in takePercentTP)
            {
                costVisit = (costVisit * ord.Profit) / 100 + costVisit;
                costVisit = (costVisit * ord.Tax) / 100 + costVisit;
                
            }

            costVisit = (double)Math.Round(costVisit, 2);
            costVisit = Math.Round(costVisit / 0.05) * 0.05;
            if (makeOrderVisit == 1)
            {
                Order orderVisit = new Order
                {
                    IdFormatProduct = idFormat,

                    IdTypePapers = idPapeVisits,
                    IdDensity = idDensityVisits,
                    IdColour = idColour,
                    quantity = quantityVisits,
                    IdTypeLam = idTypeLamVisits,
                    IdDensityLam = idLamVisits,
                    IdRoundAngle = idRoundAngle,
                    IdBigovki = 0,
                    IdFaltsovki = 0,
                    CostOrger = costVisit,
                };
                orderVisit.DataOrderMake = DateTime.Now;
                orderVisit.IdStatusOrder = 1;
                db.Orders.Add(orderVisit);
                db.SaveChanges();

                var w = Session["UserId"];
                idUser = Int32.Parse((string)w);
                LinqUserOrder lincUO = new LinqUserOrder();
                lincUO.IdUser = idUser;
                lincUO.IdOrder = orderVisit.IdOrder;
                db.LinqUserOrders.Add(lincUO);
                db.SaveChanges();

                ViewBag.makeOrder = makeOrderVisit;
            }


            ViewBag.costTonerVisit = costTonerVisit * quantityVisits;
            ViewBag.costPaperVisit = costPaperVisit * quantityListForVisits;
            ViewBag.costLaminVisit = costLaminVisit * quantityListForVisits;
            ViewBag.costAddServVisit = costAddServVisit * quantityVisits;
            ViewBag.quantityListForVisits = quantityListForVisits;
            ViewBag.quantityVisits = quantityVisits;
            ViewBag.costVisit = costVisit;


            return PartialView();
        }

        double CostPaper, costToner, costLamin, costAddServ;

        [HttpPost]

        public ActionResult costLeaflets(int idFormat, int idPape, int idDensity, int idColour, int idTypeLam, int idLam, int quantityLeaflets,
            int idBigovki, int idFaltsovki, int idRoundAngle, int makeOrderlist)
        {
            var takeCostHour = from q in db.CostOfOwners select q;
            foreach (var w in takeCostHour)
            {
                int sumUpCostOwn = w.Rent + w.ReturnInvestision + w.Salary + w.CostOwnMachine + w.GeneralProdSpend;
                CostHour = sumUpCostOwn / w.TimeWorkingInMonth;
            }

            var takeSpeedPrint = from b in db.CharacterPrintMachines select b;
             foreach (var s in takeSpeedPrint)
            {
                timePrint = (double)quantityLeaflets /(double)s.QuantityListInMinute;
            }
             if (idColour == 1 || idColour == 7)
             {
                 CostTimePrint = CostHour / 60 * timePrint;
             }
             else
             {
                 timePrint *= 2;
                 CostTimePrint = CostHour / 60 * timePrint;
          
             }

             var takeCostLamin = from q in db.CostLaminations where q.FormatPaperId == idFormat && q.DensityLamId == idLam select q.CostLam;
             foreach (var ord in takeCostLamin)
             {
                 costLamin = ord;
             }
             if (costLamin != 0)
             {
                 var takeSpeedLamin = from b in db.CharacterLaminMachines where b.IdFormatList == idFormat select b;
                 foreach (var s in takeSpeedLamin)
                 {
                     timeLam = (double)quantityLeaflets / (double)s.QuantityListInMinute;
                 }
                 if (idTypeLam == 1 || idTypeLam == 2)
                 {
                     CostTimeLam = CostHour / 60 * timeLam;
                 }
                 else
                 {
                     timeLam *= 2;
                     CostTimeLam = CostHour / 60 * timeLam;

                 }
             }
             else
             {
                 CostTimeLam = 0;
                 timeLam = 0;
             }




             ViewBag.CostTimeLam = CostTimeLam;
             ViewBag.timeLam = timeLam;


             ViewBag.CostTimePrint = CostTimePrint;
             ViewBag.CostHour = CostHour;
             ViewBag.timePrint = timePrint;



            var takeCostPaper = from b in db.CostPages where b.IdDensitiesPage == idDensity select b.CostPaper;
            foreach (var ord in takeCostPaper)
            {
                CostPaper = ord;
            }

            var takeCostToner = from q in db.PriceToners where q.FormatId == idFormat && q.ColourId == idColour select q.CostToner;
            foreach (var ord2 in takeCostToner)
            {
                costToner = ord2;
            }
            var takeCostBigovka = from q in db.Bigovkas where q.IdBigovki == idBigovki select q.CostBigovki;
            foreach (var ord in takeCostBigovka)
            {
                costAddServ += ord;
            } var takeCostFaltsovka = from q in db.Faltsovkas where q.IdFaltsovki == idFaltsovki select q.CostFaltsovki;
            foreach (var ord in takeCostFaltsovka)
            {
                costAddServ += ord;
            } var takeCostRoundAngle = from q in db.RoundAngles where q.IdRoundAngle == idRoundAngle select q.CostRoundAngle;
            foreach (var ord in takeCostRoundAngle)
            {
                costAddServ += ord;
            }

            double costLeaflets = costToner * quantityLeaflets + CostPaper * quantityLeaflets
    + costLamin * quantityLeaflets + costAddServ * quantityLeaflets;
          
            costLeaflets += CostTimePrint;
            costLeaflets += CostTimeLam;

            ViewBag.all=costLeaflets;
            var takePercentTP = from q in db.PercenTaxProfits select q;
            foreach (var ord in takePercentTP)
            {
                costLeaflets = (costLeaflets * ord.Profit) / 100 + costLeaflets;
                costLeaflets = (costLeaflets * ord.Tax) / 100 + costLeaflets;

            }

            costLeaflets = (double)Math.Round(costLeaflets, 2);
            costLeaflets = Math.Round(costLeaflets / 0.05) * 0.05;
            if (makeOrderlist == 1)
            {
                Order ordertLeaflets = new Order
                {
                    IdFormatProduct = idFormat,
                    IdTypePapers = idPape,
                    IdDensity = idDensity,
                    IdColour = idColour,
                    quantity = quantityLeaflets,
                    IdTypeLam = idTypeLam,
                    IdDensityLam = idLam,
                    IdRoundAngle = idRoundAngle,
                    IdBigovki = idBigovki,
                    IdFaltsovki = idFaltsovki,
                    CostOrger = costLeaflets,
                };

                ordertLeaflets.DataOrderMake = DateTime.Now;
                ordertLeaflets.IdStatusOrder = 1;
                db.Orders.Add(ordertLeaflets);
                db.SaveChanges();

                var w = Session["UserId"];
                idUser = Int32.Parse((string)w);
                LinqUserOrder lincUO = new LinqUserOrder();
                lincUO.IdUser = idUser;
                lincUO.IdOrder = ordertLeaflets.IdOrder;
                db.LinqUserOrders.Add(lincUO);
                db.SaveChanges();
            }

            ViewBag.makeOrderlist = makeOrderlist;
            ViewBag.costToner = costToner * quantityLeaflets;
            ViewBag.CostPaper = CostPaper * quantityLeaflets;
            ViewBag.costLamin = costLamin * quantityLeaflets;
            ViewBag.costAddServ = costAddServ * quantityLeaflets;

            ViewBag.CostList = costLeaflets;



           
            return PartialView();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.IdPaper = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }
        int IdUserTake = 0;
        public ActionResult Basket()
        {
            var w = Session["UserId"];
            IdUserTake = Int32.Parse((string)w);
            var lookOder = (
                 from uo in db.LinqUserOrders
                 where uo.IdUser == IdUserTake
                 join o in db.Orders on uo.IdOrder equals o.IdOrder
                 join fp in db.FormatProducts on o.IdFormatProduct equals fp.IdFormatProduct
                 join tp in db.TypePapers on o.IdTypePapers equals tp.IdTypePapers
                 join dp in db.Densities on o.IdDensity equals dp.IdDensity
                 join c in db.Colours on o.IdColour equals c.IdColour
                 join tl in db.TypeLaminations on o.IdTypeLam equals tl.IdTypeLam into tllist
                 from tl in tllist.DefaultIfEmpty()
                 join ds in db.DensityLamins on o.IdDensityLam equals ds.IdLam into dsllist
                 from ds in dsllist.DefaultIfEmpty()
                 join b in db.Bigovkas on o.IdBigovki equals b.IdBigovki into bllist
                 from b in bllist.DefaultIfEmpty()
                 join f in db.Faltsovkas on o.IdFaltsovki equals f.IdFaltsovki into fllist
                 from f in fllist.DefaultIfEmpty()
                 join ro in db.RoundAngles on o.IdRoundAngle equals ro.IdRoundAngle into rollist
                 from ro in rollist.DefaultIfEmpty()
                 join so in db.StatusOrders on o.IdStatusOrder equals so.IdStatusOrder into sollist
                 from so in sollist.DefaultIfEmpty()
                 select new ViewOrder
                 {
                     id = o.IdOrder,
                     quantity = o.quantity,
                     costOrder = o.CostOrger,
                     formatPaper = fp.Format,
                     typePaper = tp.Name,
                     densityPaper = dp.Value,
                     colour = c.Name,
                     densityLam = ds == null ? 0 : ds.DensityLam,
                     typeLam = tl == null ? String.Empty : tl.TypeLam,
                     bigovka = b == null ? String.Empty : b.TypeBigovki,
                     faltsovka = f == null ? String.Empty : f.TypeFaltsovki,
                     bigovroudAngleka = ro == null ? String.Empty : ro.TypeRoundAngle,
                     dataOrderMake = o.DataOrderMake,
                     status = so.Status
                 }).OrderBy(u => u.status).ThenByDescending(u => u.dataOrderMake);
                      return View(lookOder);
        }
        public ActionResult DeleteOrderInBasket(int id)
        {
            Order o = db.Orders.Find(id);
            if (o != null)
            {
                db.Orders.Remove(o);
                db.SaveChanges();
            }
            return RedirectToAction("Basket");
        }


    }
}
