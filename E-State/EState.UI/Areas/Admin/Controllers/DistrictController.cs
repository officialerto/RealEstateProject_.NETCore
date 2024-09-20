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
    public class DistrictController : Controller
    {
        DistrictService districtService;
        CityService cityService;

        public DistrictController(DistrictService districtService, CityService cityService)
        {
            this.districtService = districtService;
            this.cityService = cityService;
        }

        public IActionResult Index()
        {
            var list = districtService.List(x => x.Status == true);

            return View(list);
        }

        public IActionResult Create()
        {
            DropDown();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(District data)
        {
            DistrictValidation validationRules = new DistrictValidation();
            ValidationResult result = new ValidationResult();

            if (result.IsValid)
            {
                districtService.Add(data);

                TempData["Success"] = "Semt ekleme başarıyla gerçekleşti";
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

        public IActionResult Delete(int id)
        {
            var district = districtService.GetById(id);

            districtService.Delete(district);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            DropDown();
            var update = districtService.GetById(id);

            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(District data)
        {
            DistrictValidation validationRules = new DistrictValidation();
            ValidationResult result = new ValidationResult();

            if (result.IsValid)
            {
                districtService.Update(data);

                TempData["Update"] = "Semt güncelleme başarıyla gerçekleşti";
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
            List<SelectListItem> value = (from i in cityService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CityName,
                                              Value = i.CityId.ToString()
                                          }).ToList();
            ViewBag.cities = value;
        }

    }
}
