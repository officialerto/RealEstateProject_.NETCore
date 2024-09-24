using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EState.UI.Controllers
{
    public class AdvertController : Controller
    {
        ImagesService im;
        AdvertService advert;
        CityService cityService;
        DistrictService districtService;
        NeighborhoodService neighborhoodService;
        SituationService situationService;
        TypeService typeService;

        public AdvertController(ImagesService im, AdvertService advert, CityService cityService, DistrictService districtService, NeighborhoodService neighborhoodService, SituationService situationService, TypeService typeService)
        {
            this.im = im;
            this.advert = advert;
            this.cityService = cityService;
            this.districtService = districtService;
            this.neighborhoodService = neighborhoodService;
            this.situationService = situationService;
            this.typeService = typeService;
        }
        public IActionResult Details(int id)
        {
            var details = advert.GetById(id);

            var image = im.List(x=>x.AdvertId == id);
            ViewBag.imgs = image;

            return View(details);
        }

        public IActionResult AdvertRent()
        {
            DropDown();
            var rent = advert.List(x => x.Type.Situation.SituationName == "Kiralık");

            var image = im.List(x=>x.Status == true);
            ViewBag.imgs = image;

            return View(rent);
        }

        public IActionResult AdvertSale()
        {
            DropDown();
            var rent = advert.List(x => x.Type.Situation.SituationName == "Satılık");

            var image = im.List(x => x.Status == true);
            ViewBag.imgs = image;

            return View(rent);
        }

        public IActionResult Create()
        {
            return View();
        }

        public List<City> CityGet()
        {
            List<City> cities = cityService.List(x => x.Status == true);
            return cities;
        }
        public List<Situation> SituationGet()
        {
            List<Situation> situation = situationService.List(x => x.Status == true);
            return situation;
        }

        public void DropDown()
        {
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.situations = new SelectList(SituationGet(), "SituationId", "SituationName");

            List<SelectListItem> value1 = (from i in districtService.List(X => X.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.DistrictName,
                                               Value = i.DistrictId.ToString()
                                           }).ToList();
            ViewBag.district = value1;

            List<SelectListItem> value2 = (from i in neighborhoodService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.NeighborhoodName,
                                               Value = i.NeighborhoodId.ToString()
                                           }).ToList();
            ViewBag.neighbourhood = value2;
            List<SelectListItem> value3 = (from i in typeService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.TypeName,
                                               Value = i.TypeId.ToString()
                                           }).ToList();
            ViewBag.type = value3;

            List<SelectListItem> value4 = (from i in situationService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.SituationName,
                                               Value = i.SituationId.ToString()
                                           }).ToList();
            ViewBag.situation = value4;
        }

    }
}
