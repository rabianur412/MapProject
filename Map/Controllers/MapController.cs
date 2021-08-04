using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Map.Controllers
{
    public class MapController : Controller
    {
        NeighborhoodManager neighborhoodManager = new NeighborhoodManager(new EfNeighborhoodDal());
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Polygon(int id)
        {
            var cordinateid = neighborhoodManager.NeighborhoodGetById(id);
            ViewBag.nn = cordinateid.NeighborhoodName;
            ViewBag.ci = cordinateid.NeighborhoodCoordinate;
            return View();

        }
       
    }
}