using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        CityService cityService;

        public CityController(CityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult Index()
        {
            var list = cityService.List(x => x.Status == true);

            return View(list);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City data)
        {
            CityValidation validationRules = new CityValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                cityService.Add(data);

                TempData["Success"] = "Şehir ekleme başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var city = cityService.GetById(id);
            cityService.Delete(city);

            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var update = cityService.GetById(id);

            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(City data)
        {
            CityValidation validationRules = new CityValidation();
            ValidationResult result = validationRules.Validate(data);

            var list = cityService.GetById(data.CityId);

            if (result.IsValid)
            {
                cityService.Update(data);

                TempData["Update"] = "Şehir güncelleme başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(data);
        }


    }
}
