using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Map.Controllers
{
    public class NeighborhoodController : Controller
    {
        NeighborhoodManager neighborhoodManager = new NeighborhoodManager(new EfNeighborhoodDal());
        [HttpGet]
        public ActionResult NeighborhoodAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NeighborhoodAdd(Neighborhood neighborhood)
        {
            NeighborhoodValidator neighborhoodValidator = new NeighborhoodValidator();
            ValidationResult results = neighborhoodValidator.Validate(neighborhood);
            if (results.IsValid)
            {
                neighborhoodManager.NeighborhoodAdd(neighborhood);
                return RedirectToAction("Index", "Map");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult NeighborhoodGetList()
        {
            var neighborhoodValues = neighborhoodManager.GetList();
            return View(neighborhoodValues);
        }
        [HttpGet]
        public ActionResult NeighborhoodEdit(int id)
        {
            var neighborhoodValue = neighborhoodManager.NeighborhoodGetById(id);
         
            return View(neighborhoodValue);
        }
        [HttpPost]
        public ActionResult NeighborhoodEdit(Neighborhood neighborhood)
        {
            neighborhoodManager.NeighborhoodUpdate(neighborhood);
            return RedirectToAction("NeighborhoodGetList");
        }
        public ActionResult NeighborhoodDelete(int id)
        {
            var deleteValue = neighborhoodManager.NeighborhoodGetById(id);
            neighborhoodManager.NeighborhoodDelete(deleteValue);
            return RedirectToAction("NeighborhoodGetList");
        }
    }
}