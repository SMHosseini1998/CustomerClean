using CustomerClean.Application.Services.Services.Command.CreateServices;
using CustomerClean.Application.Services.Services.Command.DeleteServices;
using CustomerClean.Application.Services.Services.Command.EditeServices;
using CustomerClean.Application.Services.Services.Query.GetAll;
using CustomerClean.Application.Services.Services.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace CustomerClean.Controllers
{
    public class ServicesController : BaseController
    {
        [HttpGet]
        [Route("/Services/GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var model = new GetAllServicesQuery();
            var Res = await Mediator.Send(model);
            return Ok(Res);
        }
        public async Task<IActionResult> Index()
        {
            var model = new GetAllServicesQuery();
            var Res = await Mediator.Send(model);
            return View(Res);
        }
        public async Task<IActionResult> EditeServices(int id)
        {
            var model = new GetIdQuery { Id = id };
            var Res = await Mediator.Send(model);
            
            return View(Res);
        }

        [Route("/Services/EditeServices")]
        [HttpPost]
        public async Task<IActionResult> EditeServices(EditeServicesCommand editeServicesCommand)
        {
            bool result = await Mediator.Send(editeServicesCommand);
            if (result) 
                return RedirectToAction("Index");
            TempData["ErrorDelete"] = true;
            return RedirectToAction("Index");

        }
        public IActionResult CreateServices()
        {
            return View();
        }

        [Route("/Services/AddServices")]
        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServicesCommand createServicesCommand)
        {
            var result = await Mediator.Send(createServicesCommand);
            return RedirectToAction("Index");
        }

        [Route("/DeleteServices/{id?}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            var model = new DeleteServicesCommand { Id = id };
            var result = await Mediator.Send(model);
            if (result)
                return RedirectToAction("Index");
            TempData["ErrorDelete"] = true;
            return RedirectToAction("Index");
        }

    }
}
