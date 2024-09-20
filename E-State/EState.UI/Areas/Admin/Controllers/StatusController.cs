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
    public class StatusController : Controller
    {
        SituationService situationService;

        public StatusController(SituationService situationService)
        {
            this.situationService = situationService;
        }

        public IActionResult Index()
        {
            var list = situationService.List();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Situation data)
        {
            SituationValidation validationRules = new SituationValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {

                situationService.Add(data);

                TempData["Success"] = "Başarıyla eklendi!";
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

        public IActionResult Delete(int id)
        {

            var status = situationService.GetById(id);
            situationService.Delete(status);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var status = situationService.GetById(id);

            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Situation data)
        {
            SituationValidation validationRules = new SituationValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {

                situationService.Update(data);

                TempData["Update"] = "Başarıyla güncellendi!";
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
