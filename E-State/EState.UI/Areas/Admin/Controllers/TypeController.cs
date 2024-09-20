using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TypeController : Controller
    {
        TypeService typeService;
        SituationService situationService;

        public TypeController(TypeService typeService, SituationService situationService)
        {
            this.typeService = typeService;
            this.situationService = situationService;
        }

        public IActionResult Index()
        {
            var list = typeService.List();

            return View(list);
        }

        public IActionResult Create()
        {
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EntityLayer.Entities.Type data)
        {
            TypeValidation validationRules = new TypeValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                typeService.Add(data);
                TempData["Success"] = "Tip ekleme işlemi başarıyla gerçekleşti.";
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
            var type = typeService.GetById(id);
            typeService.Delete(type);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var type = typeService.GetById(id);
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EntityLayer.Entities.Type data)
        {
            TypeValidation validationRules = new TypeValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid)
            {
                typeService.Update(data);
                TempData["Update"] = "Tip güncelleme işlemi başarıyla gerçekleşti.";
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
            List<SelectListItem> value = (from i in situationService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SituationName,
                                              Value = i.SituationId.ToString()
                                          }).ToList();

            ViewBag.status = value;
        }
    }
}
