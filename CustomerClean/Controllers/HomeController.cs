using CustomerClean.Application.Services.Customer.Command.CreateCustomer;
using CustomerClean.Application.Services.Customer.Command.DeleteCustomer;
using CustomerClean.Application.Services.Customer.Command.EditeCustomer;
using CustomerClean.Application.Services.Customer.Query.GetAll;
using CustomerClean.Application.Services.Customer.Query.GetById;
using CustomerClean.Application.Services.Services.Query.GetId;
using CustomerClean.Domain.Models.DataTable;
using Microsoft.AspNetCore.Mvc;

namespace CustomerClean.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllCustomerQuery { Page=1,};
            var response = await Mediator.Send(query);

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Index(GetAllCustomerQuery getAllCustomerQuery)
        {
            var result = await Mediator.Send(getAllCustomerQuery);
            ViewBag.Search=getAllCustomerQuery.Search;
            return View(result);
        }


        public async Task<IActionResult> ShowCustomer(int id)
        {
            var model = new GetCustomerByIdQuery { Id = id };
            var Res = await Mediator.Send(model);
            return View(Res);
        }
        public async Task<IActionResult> EditeCustomer(int id)
        {
            var model = new GetCustomerByIdQuery { Id = id };
            var Res = await Mediator.Send(model);
            return View(Res);
        }

        [Route("/Home/EditeCustomer")]
        [HttpPost]
        public async Task<IActionResult> EditeCustomer(EditeCustomerCommand editeCustomerCommand)
        {
            var result = await Mediator.Send(editeCustomerCommand);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateCustomer()
        {
            var model = new GetIdQuery { };
            var Res = await Mediator.Send(model);

            ViewBag.Sys_Id = "LS-30-" + Res;
            return View();
        }

        [Route("/Home/AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand createCustomerCommand)
        {
            var result = await Mediator.Send(createCustomerCommand);
            return RedirectToAction("Index");
        }

        [Route("/DeleteCustomer/{id?}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var model = new DeleteCustomerCommand { Id = id };
            var Res = await Mediator.Send(model);
            return RedirectToAction("Index");
        }


    }
}