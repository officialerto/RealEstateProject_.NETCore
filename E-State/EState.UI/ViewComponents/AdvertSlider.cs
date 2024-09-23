using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EState.UI.ViewComponents
{
    public class AdvertSlider : ViewComponent
    {
        ImagesService imagesService;

        public AdvertSlider(ImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        public IViewComponentResult Invoke()
        {
            var list = imagesService.List(x=>x.Status == true);

            return View(list);
        }
    }
}
