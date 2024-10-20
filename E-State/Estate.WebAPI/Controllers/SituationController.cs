using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estate.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituationController : ControllerBase
    {
        SituationService situationService;

        public SituationController(SituationService situationService)
        {
            this.situationService = situationService;
        }

        [HttpGet]
        public IActionResult GetSituation()
        {
            var list = situationService.List(x => x.Status == true);

            if (list == null)
            {
                return BadRequest();
            }

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneSituation(int id)
        {
            var getsituation = situationService.GetById(id);

            if (getsituation == null)
            {
                return BadRequest();
            }

            return Ok(getsituation);
        }

        [HttpPost]
        public IActionResult CreateSituation(Situation data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            situationService.Add(data);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSituation(int id)
        {
            var delete = situationService.GetById(id);
            situationService.Delete(delete);
            return Ok(delete);
        }

        [HttpPut]
        public IActionResult UpdateSituation(Situation data)
        {
            situationService.Update(data);
            return Ok(data);
        }
    }
}
