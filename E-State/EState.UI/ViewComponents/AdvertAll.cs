using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagedList;

namespace Estate.UI.ViewComponents
{
    public class AdvertAll : ViewComponent
    {
        ImagesService im;
        AdvertService advert;
        public AdvertAll(ImagesService im, AdvertService advert)
        {
            this.im = im;
            this.advert = advert;
        }
        public IViewComponentResult Invoke(int page = 1)
        {
            var list = advert.List(x => x.Status == true).ToPagedList(page, 3);
            var images = im.List(x => x.Status == true);
            ViewBag.imgs = images;
            return View(list);
        }

    }
}
