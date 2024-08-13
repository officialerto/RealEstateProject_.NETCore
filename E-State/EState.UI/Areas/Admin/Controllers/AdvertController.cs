using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller
    {
        AdvertService advertService;
        CityService cityService;
        DistrictService districtService;
        NeighborhoodService neighborhoodService;
        SituationService situationService;
        TypeService typeService;

        public AdvertController(AdvertService advertService, CityService cityService, DistrictService districtService, NeighborhoodService neighborhoodService, SituationService situationService, TypeService typeService)
        {
            this.advertService = advertService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.neighborhoodService = neighborhoodService;
            this.situationService = situationService;
            this.typeService = typeService;
        }

        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("Id");

            var list = advertService.List(x => x.Status == true && x.UserAdminId == id);

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public List<City> CityGet()
        {
            List<City> cities = cityService.List(x=>x.Status == true);
            return cities;
        }

        public List<Situation> SituationGet()
        {
            List<Situation> situation = situationService.List(x => x.Status == true);
            return situation;
        }

        public IActionResult DistrictGet(int id) 
        {
            List<District> districtlist = districtService.List(x=>x.Status == true && x.CityId == id);

            ViewBag.district = new SelectList(districtlist, "DistrictId", "DistrictName");

            return PartialView("DistrictPartial");
        }

        public IActionResult TypeGet(int id)
        {
            List<EntityLayer.Entities.Type> typelist = typeService.List(x => x.Status == true && x.SituationId == id);

            ViewBag.type = new SelectList(typelist, "TypeId", "TypeName");

            return PartialView("TypePartial");
        }

        public IActionResult NeighborhoodGet(int id)
        {
            List<Neighborhood> neighlist = neighborhoodService.List(x => x.Status == true && x.DistrictId == id);

            ViewBag.district = new SelectList(neighlist, "NeighborhoodId", "NeighborhoodName");

            return PartialView("NeighborhoodPartial");
        }


        public void DropDown()
        {
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");
        }

    }
}
