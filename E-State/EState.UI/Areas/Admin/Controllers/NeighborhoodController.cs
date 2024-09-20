using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NeighborhoodController : Controller
    {
        NeighborhoodService neighborhoodService;
        DistrictService districtService;

        public NeighborhoodController(NeighborhoodService neighborhoodService, DistrictService districtService)
        {
            this.neighborhoodService = neighborhoodService;
            this.districtService = districtService;
        }

        public IActionResult Index()
        {
            var list = neighborhoodService.List(x => x.Status == true);

            return View(list);
        }

        public IActionResult Delete(int id)
        {
            var neigh = neighborhoodService.GetById(id);
            neighborhoodService.Delete(neigh);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            DropDown();

            return View();
        }

        public IActionResult Update(int id)
        {
            DropDown();
            var neigh = neighborhoodService.GetById(id);
            return View(neigh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Neighborhood data)
        {
            NeighborhoodValidation validationRules = new NeighborhoodValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                neighborhoodService.Update(data);
                TempData["Update"] = "Mahalle ekleme işlemi başarıyla gerçekleşti.";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Neighborhood data)
        {
            NeighborhoodValidation validationRules = new NeighborhoodValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                neighborhoodService.Add(data);
                TempData["Success"] = "Mahalle ekleme işlemi başarıyla gerçekleşti.";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            DropDown();
            return View();
        }

        public void DropDown()
        {
            List<SelectListItem> value = (from i in districtService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DistrictName,
                                              Value = i.DistrictId.ToString()
                                          }).ToList();
            ViewBag.district = value;
        }
    }
}
