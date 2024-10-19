using BusinessLayer.Abstract;
using EntityLayer.Entities;
using EState.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System.Diagnostics;

namespace EState.UI.Controllers
{
    public class HomeController : Controller
    {

        AdvertService advertService;
        CityService cityService;
        DistrictService districtService;
        NeighborhoodService neighborhoodService;
        SituationService situationService;
        TypeService typeService;
        ImagesService imageService;


        public HomeController(ImagesService imageService, AdvertService advertService, CityService cityService, DistrictService districtService, NeighborhoodService neighborhoodService, SituationService situationService, TypeService typeService)
        {
            this.advertService = advertService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.neighborhoodService = neighborhoodService;
            this.situationService = situationService;
            this.typeService = typeService;
            this.imageService = imageService;

        }
        public IActionResult Index(int page = 1)
        {
            DropDown();
            var list = advertService.List(x => x.Status == true).ToPagedList(page, 3);
            var images = imageService.List(x => x.Status == true);
            ViewBag.imgs = images;
            return View(list);
        }

        // ------------------ GOOGLE RECAPTCHA ------------------

        //public IActionResult Form()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<bool> CheckCaptcha()
        //{
        //    var postData = new List<KeyValuePair<string, string>>();
        //    {
        //        new KeyValuePair<string, string>("secret", "6LfnnFkqAAAAANdFWY44qOq4d6JT0ftwGlv527jj"),
        //        new KeyValuePair<string, string>("response", HttpContext.Request.Form["google-recaptcha-response"])
        //    };

        //    var client = new HttpClient();

        //    var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));

        //    var object = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
        //}

        public IActionResult Filter(int min, int max, int cityid, int typeid, int neighborhoodid, int districtid, int situtationid)
        {
            DropDown();
            var imagelist = imageService.List(x => x.Status == true);
            ViewBag.imagelist = imagelist;
            var filter = advertService.List(x => x.Price >= min && x.Price <= max && x.CityId == cityid && x.TypeId == typeid && x.NeighborhoodId == neighborhoodid && x.DistrictId == districtid && x.SituationId == situtationid);
            return View(filter);
        }
        public PartialViewResult PartialFiltre()
        {
            DropDown();
            return PartialView();
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
        public IActionResult DistrictGet(int CityId)
        {
            List<District> districtlist = districtService.List(X => X.Status == true && X.CityId == CityId);


            ViewBag.district = new SelectList(districtlist, "DistrictId", "DistrictName");
            return PartialView("DistrictPartial");
        }

        public PartialViewResult DistrictPartial()
        {
            return PartialView();
        }

        public PartialViewResult TypePartial()
        {
            return PartialView();
        }

        public PartialViewResult NeighborhoodPartial()
        {
            return PartialView();
        }
        public IActionResult TypeGet(int SituationId)
        {
            List<EntityLayer.Entities.Type> typelist = typeService.List(X => X.Status == true && X.SituationId == SituationId);

            ViewBag.type = new SelectList(typelist, "TypeId", "TypeName");
            return PartialView("TypePartial");
        }
        public IActionResult NeighborhoodGet(int DistrictId)
        {
            List<Neighborhood> neighlist = neighborhoodService.List(X => X.Status == true && X.DistrictId == DistrictId);

            ViewBag.neigh = new SelectList(neighlist, "NeighborhoodId", "NeighborhoodName");
            return PartialView("NeighborhoodPartial");
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
            ViewBag.neighborhood = value2;
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}

