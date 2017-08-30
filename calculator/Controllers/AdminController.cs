using calculator.Models;
using calculator.Models.MyViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace calculator.Controllers
{
    public class AdminController : Controller
    {
        poligraphContext db = new poligraphContext();
        public ActionResult ViewPercentTaxProf()
        {
            return View(db.PercenTaxProfits);
        }
        [HttpGet]
        public ActionResult EditPercentTaxProf(int? id)
        {
            PercenTaxProfit ptp = db.PercenTaxProfits.Find(id);
            if (ptp != null)
            {
                return View(ptp);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditPercentTaxProf(PercenTaxProfit ptp)
        {
            db.Entry(ptp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }



        public ActionResult EditView()
        {
            return View();
        }
        public ActionResult ViewBigovka()
        {
            return View(db.Bigovkas);
        }
        [HttpGet]
        public ActionResult CreateBigovka()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBigovka(Bigovka bigovka)
        {
            if (ModelState.IsValid)
            {

                var exist = (from b in db.Bigovkas where b.TypeBigovki == bigovka.TypeBigovki select b).Count();
                if (exist == 0)
                {
                    db.Bigovkas.Add(bigovka);
                    db.SaveChanges();
                    return RedirectToAction("EditView");
                }
                ModelState.AddModelError("", "Такие данные уже существуют в базе");
            }

            return View();

        }
        [HttpGet]
        public ActionResult EditBigovka(int? id)
        {
            Bigovka bigovka = db.Bigovkas.Find(id);
            if (bigovka != null)
            {
                return View(bigovka);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBigovka(Bigovka bigovka)
        {
            db.Entry(bigovka).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }
        public ActionResult DeleteBigovka(int id)
        {
            Bigovka b = db.Bigovkas.Find(id);
            if (b != null)
            {
                db.Bigovkas.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("EditView");
        }

        public ActionResult ViewFaltsovka()
        {
            return View(db.Faltsovkas);
        }
        [HttpGet]
        public ActionResult CreateFaltsovka()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFaltsovka(Faltsovka faltsovka)
        {
            if (ModelState.IsValid)
            {

                var exist = (from b in db.Faltsovkas where b.TypeFaltsovki == faltsovka.TypeFaltsovki select b).Count();
                if (exist == 0)
                {
                    db.Faltsovkas.Add(faltsovka);
                    db.SaveChanges();
                    return RedirectToAction("EditView");
                }
                ModelState.AddModelError("", "Такие данные уже существуют в базе");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditFaltsovka(int? id)
        {
            Faltsovka faltsovka = db.Faltsovkas.Find(id);
            if (faltsovka != null)
            {
                return View(faltsovka);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditFaltsovka(Faltsovka faltsovka)
        {
            db.Entry(faltsovka).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }
        public ActionResult DeleteFaltsovka(int id)
        {
            Faltsovka b = db.Faltsovkas.Find(id);
            if (b != null)
            {
                db.Faltsovkas.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("EditView");
        }


        public ActionResult ViewRoundAngle()
        {
            return View(db.RoundAngles);
        }
        [HttpGet]
        public ActionResult CreateRoundAngle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoundAngle(RoundAngle roundAngle)
        {

            if (ModelState.IsValid)
            {

                var exist = (from b in db.RoundAngles where b.TypeRoundAngle == roundAngle.TypeRoundAngle select b).Count();
                if (exist == 0)
                {
                    db.RoundAngles.Add(roundAngle);
                    db.SaveChanges();
                    return RedirectToAction("EditView");
                }
                ModelState.AddModelError("", "Такие данные уже существуют в базе");
            }
            return View();

        }
        [HttpGet]
        public ActionResult EditRoundAngle(int? id)
        {
            RoundAngle roundAngle = db.RoundAngles.Find(id);
            if (roundAngle != null)
            {
                return View(roundAngle);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditRoundAngle(RoundAngle roundAngle)
        {
            db.Entry(roundAngle).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }
        public ActionResult DeleteRoundAngle(int id)
        {
            RoundAngle b = db.RoundAngles.Find(id);
            if (b != null)
            {
                db.RoundAngles.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("EditView");
        }


        public ActionResult ViewCostLamin()
        {
            var сostLamin = (from cs in db.CostLaminations
                             join fp in db.FormatProducts on cs.FormatPaperId equals fp.IdFormatProduct
                             join ds in db.DensityLamins on cs.DensityLamId equals ds.IdLam
                             join tl in db.TypeLaminations on ds.TypeLamId equals tl.IdTypeLam
                             select new ViewCostLam
                             {
                                 id = cs.IdcostLam,
                                 costLam = cs.CostLam,
                                 formatPaper = fp.Format,
                                 densityLam = ds.DensityLam,
                                 typeLam = tl.TypeLam

                             });
            return View(сostLamin);

        }
        [HttpGet]
        public ActionResult CreateCostLamin()
        {
            SelectList formatProduct = new SelectList(db.FormatProducts.Where(c => c.IdFormatProduct > 2), "IdFormatProduct", "Format");
            ViewBag.FormatProduct = formatProduct;
            ViewBag.TypeLamination = new SelectList(db.TypeLaminations, "IdTypeLam", "TypeLam");
            //    ViewBag.DensLam = new SelectList(db.DensityLamins, "IdLam", "DensityLam");
            return View();
        }
        //public ActionResult GetDensityLams(int id)
        //{
        //    return PartialView(db.DensityLamins.Where(o => o.TypeLamId == id).ToList());
        //}
        [HttpPost]
        public ActionResult CreateCostLamin(SendDoubleCost costLamin, int IdFormatProduct, int IdTypeLam, int DensLam)
        {

            int idLam = 0;
            var existLam = (from b in db.DensityLamins where b.TypeLamId == IdTypeLam && b.DensityLam == DensLam select b).Count();
            if (existLam == 0)
            {
                DensityLamin denslam = new DensityLamin();
                denslam.TypeLamId = IdTypeLam;
                denslam.DensityLam = DensLam;
                db.DensityLamins.Add(denslam);
                db.SaveChanges();
                CostLamination costLaminat = new CostLamination();
                double cost = costLamin.cost;
                if (cost < 0)
                {
                    cost = 0;
                }
                else { }
                costLaminat.CostLam = cost;
                costLaminat.DensityLamId = denslam.IdLam;
                costLaminat.FormatPaperId = IdFormatProduct;
                db.CostLaminations.Add(costLaminat);
                db.SaveChanges();
                return RedirectToAction("EditView");
            }
            else
            {
                var takeIdLam = (from b in db.DensityLamins where b.TypeLamId == IdTypeLam && b.DensityLam == DensLam select b.IdLam);
                foreach (var ord in takeIdLam)
                {
                    idLam = ord;
                }
                var existFormatLam = (from b in db.CostLaminations where b.FormatPaperId == IdFormatProduct && b.DensityLamId == idLam select b).Count();
                if (existFormatLam == 0)
                {
                    CostLamination costLaminat = new CostLamination();
                    double cost = costLamin.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    else { }
                    costLaminat.CostLam = cost;
                    costLaminat.DensityLamId = idLam;
                    costLaminat.FormatPaperId = IdFormatProduct;
                    db.CostLaminations.Add(costLaminat);
                    db.SaveChanges();
                    return RedirectToAction("ViewCostLamin");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DeleteCostLamin(int id)
        {

            CostLamination b = db.CostLaminations.Find(id);

            if (b != null)
            {
                    db.CostLaminations.Remove(b);
                    db.SaveChanges();
            }
            return RedirectToAction("EditView");
        }


        [HttpGet]
        public ActionResult EditCostLamin(int? id)
        {
            CostLamination CostLamin = db.CostLaminations.Find(id);
            if (CostLamin != null)
            {
                return View(CostLamin);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditCostLamin(CostLamination CostLamin)
        {
            db.Entry(CostLamin).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }


        public ActionResult HistView()
        {
            return View();
        }
        public ActionResult HistViewCostLamin()
        {
            var HistBuyLamin = (from h in db.HistoryBuyLams
                                join fp in db.FormatProducts on h.FormatPaperId equals fp.IdFormatProduct
                                join ds in db.DensityLamins on h.DensityLamId equals ds.IdLam
                                join tl in db.TypeLaminations on ds.TypeLamId equals tl.IdTypeLam
                                select new ViewHistLamBuy
                                {
                                    id = h.Id,
                                    CostOnePage = h.CostOnePage,
                                    formatPaper = fp.Format,
                                    densityLam = ds.DensityLam,
                                    typeLam = tl.TypeLam,
                                    QuantityList = h.QuantityList,
                                    Date = h.Date
                                });
            return View(HistBuyLamin);

        }
        [HttpGet]
        public ActionResult HistCreateCostLamin()
        {
            SelectList formatProduct = new SelectList(db.FormatProducts.Where(c => c.IdFormatProduct > 2), "IdFormatProduct", "Format");
            ViewBag.FormatProduct = formatProduct;
            ViewBag.TypeLamination = new SelectList(db.TypeLaminations, "IdTypeLam", "TypeLam");
            return View();
        }
        [HttpPost]
        public ActionResult HistCreateCostLamin(SendDoubleCost costLamin, int quantity, int IdFormatProduct, int IdTypeLam, int DensLam)
        {
            int idLam = 0;
            var existLam = (from b in db.DensityLamins where b.TypeLamId == IdTypeLam && b.DensityLam == DensLam select b).Count();
            if (existLam == 0)
            {
                DensityLamin denslam = new DensityLamin();
                denslam.TypeLamId = IdTypeLam;
                denslam.DensityLam = DensLam;
                db.DensityLamins.Add(denslam);
                db.SaveChanges();
                CostLamination costLaminat = new CostLamination();
                double cost = costLamin.cost;
                if (cost < 0)
                {
                    cost = 0;
                }
                else { }
                costLaminat.CostLam = cost;
                idLam = denslam.IdLam;
                costLaminat.DensityLamId = denslam.IdLam;
                costLaminat.FormatPaperId = IdFormatProduct;
                db.CostLaminations.Add(costLaminat);
                db.SaveChanges();
            }
            else
            {
                var takeIdLam = (from b in db.DensityLamins where b.TypeLamId == IdTypeLam && b.DensityLam == DensLam select b.IdLam);
                foreach (var ord in takeIdLam)
                {
                    idLam = ord;
                }
                var existFormatLam = (from b in db.CostLaminations where b.FormatPaperId == IdFormatProduct && b.DensityLamId == idLam select b).Count();
                if (existFormatLam == 0)
                {
                    CostLamination costLaminat = new CostLamination();
                    double cost = costLamin.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    else { }
                    costLaminat.CostLam = cost;
                    costLaminat.DensityLamId = idLam;
                    costLaminat.FormatPaperId = IdFormatProduct;
                    db.CostLaminations.Add(costLaminat);
                    db.SaveChanges();
                }
                else
                {
                    int id = 0;
                    var TakeExistCostLam = (from b in db.CostLaminations where b.FormatPaperId == IdFormatProduct && b.DensityLamId == idLam select b.IdcostLam);
                    foreach (var ord in TakeExistCostLam)
                    {

                        id = ord;
                    }
                    CostLamination cl = db.CostLaminations.Find(id);
                    double cost = costLamin.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    cl.CostLam = cost;

                    db.Entry(cl).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            HistoryBuyLam h = new HistoryBuyLam();
            h.Date = DateTime.Now;
            h.FormatPaperId = IdFormatProduct;
            h.DensityLamId = idLam;
            h.QuantityList = quantity;

            double costLam = costLamin.cost;
            if (costLam < 0)
            {
                costLam = 0;
            }
            h.CostOnePage = costLam;

            db.HistoryBuyLams.Add(h);
            db.SaveChanges();



            return RedirectToAction("EditView");

        }
        [HttpGet]
        public ActionResult HistEditCostLamin(int? id)
        {
            HistoryBuyLam hl = db.HistoryBuyLams.Find(id);
            if (hl != null)
            {
                return View(hl);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult HistEditCostLamin(HistoryBuyLam hl)
        {

            int id=0;
            var TakeExistCostLam = (from b in db.CostLaminations where b.FormatPaperId == hl.FormatPaperId && b.DensityLamId == hl.DensityLamId select b.IdcostLam);
            foreach (var ord in TakeExistCostLam)
            {

                id = ord;
            }
            CostLamination cl = db.CostLaminations.Find(id);
            cl.CostLam = hl.CostOnePage;
            db.Entry(cl).State = EntityState.Modified;
            db.SaveChanges();

            db.Entry(hl).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }


        public ActionResult HistViewCostPages()
        {
            var HistсostPages = (from cp in db.HistoryBuyPages
                             join dp in db.Densities on cp.IdDensityPage equals dp.IdDensity
                             join tp in db.TypePapers on dp.IdTypePapers equals tp.IdTypePapers
                             join fp in db.FormatProducts on tp.IdFormatPaper equals fp.IdFormatProduct
                             select new ViewHistBuyPage
                             {
                                 id = cp.Id,
                                 CostOnePage = cp.CostOnePage,
                                 formatPaper = fp.Format,
                                 densityPaper = dp.Value,
                                 typePaper = tp.Name,
                                 QuantityList = cp.QuantityList,
                                 Date = cp.Date
                             });
            return View(HistсostPages);
        }
        [HttpGet]
        public ActionResult HistCreateCostPages()
        {
            SelectList formatProduct = new SelectList(db.FormatProducts, "IdFormatProduct", "Format");
            ViewBag.FormatProduct = formatProduct;
            SelectList typePaper = new SelectList(db.TypePapers, "IdTypePapers", "Name");
            ViewBag.TypePapers = typePaper;
            ViewBag.Densities = new SelectList(db.Densities, "IdDensity", "Value");
            return View();
        }
        [HttpPost]
        public ActionResult HistCreateCostPages( SendDoubleCost costpap,int quantity,int IdFormatProduct, string TypePap, int DensPap)
        {
            int idTypePap = 0;
            int IdDens = 0;
            var existTypePap = (from b in db.TypePapers where b.Name == TypePap && b.IdFormatPaper == IdFormatProduct select b).Count();
            if (existTypePap == 0)
            {
                TypePaper tp = new TypePaper();
                tp.IdFormatPaper = IdFormatProduct;
                tp.Name = TypePap;
                db.TypePapers.Add(tp);
                db.SaveChanges();
                Density dp = new Density();
                dp.IdTypePapers = tp.IdTypePapers;
                dp.Value = DensPap;
                db.Densities.Add(dp);
                db.SaveChanges();
                CostPage cp = new CostPage();
                IdDens = dp.IdDensity;
                cp.IdDensitiesPage = dp.IdDensity;
                double cost = costpap.cost;
                if (cost < 0)
                {
                    cost = 0;
                }
                cp.CostPaper = cost;
                db.CostPages.Add(cp);
                db.SaveChanges();
            }
            else
            {
                var takeTypePap = (from b in db.TypePapers where b.Name == TypePap && b.IdFormatPaper == IdFormatProduct select b.IdTypePapers);
                foreach (var ord in takeTypePap)
                {
                    idTypePap = ord;
                }
                var existDensPap = (from b in db.Densities where b.IdTypePapers == idTypePap && b.Value == DensPap select b).Count();
                if (existDensPap == 0)
                {
                    Density dp = new Density();
                    dp.IdTypePapers = idTypePap;
                    dp.Value = DensPap;
                    db.Densities.Add(dp);
                    db.SaveChanges();

                    CostPage cp = new CostPage();
                    IdDens = dp.IdDensity;
                    cp.IdDensitiesPage = dp.IdDensity;
                    double cost = costpap.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    cp.CostPaper = cost;
                    db.CostPages.Add(cp);
                    db.SaveChanges();
                }
                else
                {
                    int id = 0;
                    var TakeExistDensPap = (from b in db.Densities where b.IdTypePapers == idTypePap && b.Value == DensPap select b.IdDensity);
                    foreach (var ord in TakeExistDensPap)
                    {
                        IdDens = ord;
                    }
                    var TakeExistCostPap = (from b in db.CostPages where b.IdDensitiesPage == IdDens select b.IdCostPages);
                    foreach (var o in TakeExistCostPap)
                    {
                        id = o;
                    }
                    CostPage cp = db.CostPages.Find(id);
                    double cost = costpap.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    cp.CostPaper = cost;
                    db.Entry(cp).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            HistoryBuyPage hp = new HistoryBuyPage();
            hp.IdDensityPage = IdDens;
            hp.QuantityList = quantity;
            hp.Date = DateTime.Now;

            CostPage cpage = new CostPage();
            double cpages = costpap.cost;
            if (cpages < 0)
            {
                cpages = 0;
            }
            hp.CostOnePage = cpages;
            db.HistoryBuyPages.Add(hp);
            db.SaveChanges();
            return RedirectToAction("EditView");
        }

        [HttpGet]
        public ActionResult HistEditCostPage(int? id)
        {
            HistoryBuyPage hl = db.HistoryBuyPages.Find(id);
            if (hl != null)
            {
                return View(hl);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult HistEditCostPage(HistoryBuyPage hl)
        {

            int id = 0;
            var TakeExistCostPage = (from b in db.CostPages where b.IdDensitiesPage==hl.IdDensityPage select b.IdCostPages);
            foreach (var ord in TakeExistCostPage)
            {

                id = ord;
            }
            CostPage cl = db.CostPages.Find(id);
            cl.CostPaper = hl.CostOnePage;
            db.Entry(cl).State = EntityState.Modified;
            db.SaveChanges();

            db.Entry(hl).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }














        public ActionResult ViewCostPages()
        {
            var сostPages = (from cp in db.CostPages
                             join dp in db.Densities on cp.IdDensitiesPage equals dp.IdDensity
                             join tp in db.TypePapers on dp.IdTypePapers equals tp.IdTypePapers
                             join fp in db.FormatProducts on tp.IdFormatPaper equals fp.IdFormatProduct
                             select new ViewCostPage
                             {
                                 id = cp.IdCostPages,
                                 costPage = cp.CostPaper,
                                 formatPaper = fp.Format,
                                 densityPaper = dp.Value,
                                 typePaper = tp.Name

                             });
            return View(сostPages);
        }
        [HttpGet]
        public ActionResult CreateCostPages()
        {
            SelectList formatProduct = new SelectList(db.FormatProducts, "IdFormatProduct", "Format");
            ViewBag.FormatProduct = formatProduct;
            SelectList typePaper = new SelectList(db.TypePapers, "IdTypePapers", "Name");
            ViewBag.TypePapers = typePaper;
            ViewBag.Densities = new SelectList(db.Densities, "IdDensity", "Value");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCostPages(int IdFormatProduct, string TypePap, int DensPap, SendDoubleCost costLamin)
        {


            int idTypePap = 0;
            var existTypePap = (from b in db.TypePapers where b.Name == TypePap && b.IdFormatPaper == IdFormatProduct select b).Count();
            if (existTypePap == 0)
            {
                TypePaper tp = new TypePaper();
                tp.IdFormatPaper = IdFormatProduct;
                tp.Name = TypePap;
                db.TypePapers.Add(tp);
                db.SaveChanges();
                Density dp = new Density();
                dp.IdTypePapers = tp.IdTypePapers;
                dp.Value = DensPap;
                db.Densities.Add(dp);
                db.SaveChanges();

                CostPage cp = new CostPage();
                cp.IdDensitiesPage = dp.IdDensity;
                double cost = costLamin.cost;
                if (cost < 0)
                {
                    cost = 0;
                }
                else { }
                cp.CostPaper = cost;
                db.CostPages.Add(cp);
                db.SaveChanges();

                return RedirectToAction("EditView");
            }
            else
            {
                var takeTypePap = (from b in db.TypePapers where b.Name == TypePap && b.IdFormatPaper == IdFormatProduct select b.IdTypePapers);
                foreach (var ord in takeTypePap)
                {
                    idTypePap = ord;
                }
                var existDensPap = (from b in db.Densities where b.IdTypePapers == idTypePap && b.Value == DensPap select b).Count();
                if (existDensPap == 0)
                {
                    Density dp = new Density();
                    dp.IdTypePapers = idTypePap;
                    dp.Value = DensPap;
                    db.Densities.Add(dp);
                    db.SaveChanges();

                    CostPage cp = new CostPage();
                    cp.IdDensitiesPage = dp.IdDensity;
                    double cost = costLamin.cost;
                    if (cost < 0)
                    {
                        cost = 0;
                    }
                    else { }
                    cp.CostPaper = cost;
                    db.CostPages.Add(cp);
                    db.SaveChanges();
                    return RedirectToAction("ViewCostPages");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult DeleteCostPages(int id)
        {

            CostPage b = db.CostPages.Find(id);
            Density d = db.Densities.Find(b.IdDensitiesPage);
            if (d != null)
            {
                var coutUseIdTyePap = (from q in db.Densities where q.IdTypePapers == d.IdTypePapers select q.IdTypePapers).Count();
                if (coutUseIdTyePap == 1)
                {
                    TypePaper t = db.TypePapers.Find(d.IdTypePapers);
                    db.TypePapers.Remove(t);
                    db.Densities.Remove(d);
                    db.CostPages.Remove(b);
                    db.SaveChanges();
                }
                else
                {
                    db.Densities.Remove(d);
                    db.CostPages.Remove(b);
                    db.SaveChanges();

                }
            }
            return RedirectToAction("EditView");



        }

        [HttpGet]
        public ActionResult EditCostPages(int? id)
        {
            CostPage cp = db.CostPages.Find(id);
            if (cp != null)
            {
                return View(cp);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditCostPages(CostPage cp)
        {
            db.Entry(cp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }

        public ActionResult ViewCostToner()
        {
            var сostTon = (from cp in db.PriceToners
                           join fp in db.FormatProducts on cp.FormatId equals fp.IdFormatProduct
                           join c in db.Colours on cp.ColourId equals c.IdColour
                           select new ViewPriceToner
                           {
                               id = cp.IdPriceToner,
                               formatPaper = fp.Format,
                               colour = c.Name,
                               costToner = cp.CostToner
                           });
            return View(сostTon);
        }



        public ActionResult ViewCostTonerTest()
        {
            int copyA4 = 10000;
            double costTon = 2000;
            double price = costTon / copyA4;
            ViewBag.price = price;
            ViewBag.copyA4 = copyA4;
            ViewBag.costTon = costTon;



            var costToners = (from cp in db.PriceToners select cp).ToList();
            foreach (var ct in costToners)
            {
                if (ct.FormatId == 10 || ct.FormatId == 11)
                {
                    if (ct.ColourId == 1)
                    {

                        ct.CostToner = price;

                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price * 5;
                    }
                }
                else if (ct.FormatId == 8 || ct.FormatId == 9)
                {

                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price * 2;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price * 4;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price * 4 * 2;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price * 8 * 2;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price * 5 * 2;
                    }
                }
                else if (ct.FormatId == 2)
                {

                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price / 10;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price / 10 * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price / 10 * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price / 10 * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price / 10 * 5;
                    }
                }
                else if (ct.FormatId == 1)
                {
                    ;
                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price / 12;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price / 12 * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price / 12 * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price / 12 * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price / 12 * 5;
                    }
                }

            }
            return View(costToners);
        }


        [HttpGet]
        public ActionResult EditCostToner()
        {

            return View();

        }
        [HttpPost]
        public ActionResult EditCostToner(double costTon, double copyA4)
        {
            double price = costTon / copyA4;

            var costToners = (from cp in db.PriceToners select cp).ToList();
            //PriceToner costToners = new PriceToner();
            foreach (var ct in costToners)
            {
                if (ct.FormatId == 10 || ct.FormatId == 11)
                {
                    if (ct.ColourId == 1)
                    {

                        ct.CostToner = price;

                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price * 5;
                    }
                }
                else if (ct.FormatId == 8 || ct.FormatId == 9)
                {

                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price * 2;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price * 4;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price * 4 * 2;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price * 8 * 2;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price * 5 * 2;
                    }
                }
                else if (ct.FormatId == 2)
                {

                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price / 10;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price / 10 * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price / 10 * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price / 10 * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price / 10 * 5;
                    }
                }
                else if (ct.FormatId == 1)
                {
                    ;
                    if (ct.ColourId == 1)
                    {
                        ct.CostToner = price / 12;
                    }
                    if (ct.ColourId == 2)
                    {
                        ct.CostToner = price / 12 * 2;
                    }
                    if (ct.ColourId == 7)
                    {
                        ct.CostToner = price / 12 * 4;
                    }
                    if (ct.ColourId == 8)
                    {
                        ct.CostToner = price / 12 * 8;
                    }
                    if (ct.ColourId == 9)
                    {
                        ct.CostToner = price / 12 * 5;
                    }
                }

            }
            db.SaveChanges();
            return RedirectToAction("EditView");
        }
        public ActionResult ViewOders()
        {
            var lookOderAll = (from o in db.Orders
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
            return View(lookOderAll);
        }
        public ActionResult EditStatusOder(int? id)
        {
            Order o = db.Orders.Find(id);
            if (o != null)
            {
                ViewBag.StatusOrder = new SelectList(db.StatusOrders, "IdStatusOrder", "Status");
                return View(o);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditStatusOder(Order o)
        {
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }

        public ActionResult DetailsOrder(int? id)
        {
            int TakeIdUser = 0;
            var takeUserId = from o in db.LinqUserOrders where o.IdOrder == id select o.IdUser;
            foreach (var uId in takeUserId)
            {
                TakeIdUser = uId;
            }
            User u = db.Users.Find(TakeIdUser);
            if (u != null)
            {
                return View(u);
            }
            return HttpNotFound();
        }







        public ActionResult ViewCharLamMach()
        {
            var CharLamMach = (from cp in db.CharacterLaminMachines
                               join fp in db.FormatProducts on cp.IdFormatList equals fp.IdFormatProduct
                               select new ViewCharLam
                           {
                               id = cp.Id,
                               formatPaper = fp.Format,
                               QuantityListInMinute = cp.QuantityListInMinute
                           });
            return View(CharLamMach);

        }
        public ActionResult EditCharLamMach(int? id)
        {
            CharacterLaminMachine o = db.CharacterLaminMachines.Find(id);
            if (o != null)
            {
                return View(o);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult EditCharLamMach(CharacterLaminMachine o)
        {
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }
        public ActionResult ViewCharPrintMach()
        {
            return View(db.CharacterPrintMachines);
        }
        public ActionResult EditCharPrintMach(int? id)
        {
            CharacterPrintMachine o = db.CharacterPrintMachines.Find(id);
            return View(o);
        }
        [HttpPost]
        public ActionResult EditCharPrintMach(CharacterPrintMachine o)
        {
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }


        public ActionResult ViewCostOwner()
        {
            return View(db.CostOfOwners);
        }
        public ActionResult EditCostOwner(int? id)
        {
            CostOfOwner o = db.CostOfOwners.Find(id);
            return View(o);
        }
        [HttpPost]
        public ActionResult EditCostOwner(CostOfOwner o)
        {
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditView");
        }

    }
}

