using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PORTIMAGES.Application.Admin.Commands;
using PORTIMAGES.Application.Admin.Queries;
using PORTIMAGES.Common.Helpers;
using System.Security.Claims;

namespace PORTIMAGES.Web.Controllers.Admin
{   
    [Authorize(Roles = "Admin,Staff")]
    [Authorize(AuthenticationSchemes = "StaffScheme")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        #region Employee Master
        public IActionResult EmployeeMaster()
        { 
            return View();
        }
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand request)
        {
            request.CreatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(request);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var response = await _mediator.Send(new GetEmployeeListQuery());
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int ID)
        {
            var response = await _mediator.Send(new GetEmployeeByIdQuery(ID));
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand request)
        {
            request.UpdatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(request);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeCommand request)
        {
            request.DeletedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(request);
            return Json(result);
        }
         
        #endregion
    }
}
