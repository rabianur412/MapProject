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
    public class GateController:Controller
    {
        GateManager gateManager = new GateManager(new EfGateDal());
        NeighborhoodManager neighborhoodManager = new NeighborhoodManager(new EfNeighborhoodDal());
        [HttpGet]
        public ActionResult GateAdd()
        {
            List<SelectListItem> valueNeighborhood = (from x in neighborhoodManager.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.NeighborhoodName,
                                                          Value = x.NeighborhoodId.ToString()
                                                      }).ToList();
            ViewBag.vnn = valueNeighborhood;

            return View();
        }
        [HttpPost]
        public ActionResult GateAdd(Gate gate)
        {
            GateValidator gateValidator = new GateValidator();
            ValidationResult results = gateValidator.Validate(gate);
            if (results.IsValid)
            {

                gateManager.GateAdd(gate);
                return RedirectToAction("Index", "Map");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult GateGetList()
        {
            var gateValues = gateManager.GetList();
            return View(gateValues);
        }
        [HttpGet]
        public ActionResult GateEdit(int id)
        {
            List<SelectListItem> valueNeighborhood = (from x in neighborhoodManager.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.NeighborhoodName,
                                                          Value = x.NeighborhoodId.ToString()
                                                      }).ToList();
            ViewBag.vnn = valueNeighborhood;
            var gateValue = gateManager.GateGetById(id);
            return View(gateValue);
        }
        [HttpPost]
        public ActionResult GateEdit(Gate gate)
        {   
                gateManager.GateUpdate(gate);
                return RedirectToAction("GateGetList");
        }
        public ActionResult GateDelete(int id)
        {
            var deleteValue = gateManager.GateGetById(id);
            gateManager.GateDelete(deleteValue);
            return RedirectToAction("GateGetList");
        }
    }
}