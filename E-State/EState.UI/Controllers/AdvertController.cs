using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EState.UI.Controllers
{
    public class AdvertController : Controller
    {
        ImagesService im;
        AdvertService advert;
        public AdvertController(ImagesService im, AdvertService advert)
        {
            this.im = im;
            this.advert = advert;
        }
        public IActionResult Details(int id)
        {
            var details = advert.GetById(id);

            var image = im.List(x=>x.AdvertId == id);
            ViewBag.imgs = image;

            return View(details);
        }
    }
}
