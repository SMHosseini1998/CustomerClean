using CustomerClean.Application.Services.Citys.Query.GetAll;
using CustomerClean.Application.Services.Province.Query.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace CustomerClean.Controllers
{
    public class CityController : BaseController
    {
        [HttpGet]
        [Route("/City/GetAllProvince")]
        public async Task<IActionResult> Index()
        {
            var model = new GetAllProvinceQuery();
            var Res = await Mediator.Send(model);
            return Ok(Res);
        }
        [HttpGet]
        [Route("/City/GetAllCity/{id?}")]
        public async Task<IActionResult> Index(int id)
        {
            var model = new GetAllCityQuery { Id=id};
            var Res = await Mediator.Send(model);
            return Ok(Res);
        }
    }
}
