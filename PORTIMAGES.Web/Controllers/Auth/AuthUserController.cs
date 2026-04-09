using MediatR; 
using Microsoft.AspNetCore.Mvc;
using PORTIMAGES.Application.Auth.AuthEmployee.Interfaces;
using PORTIMAGES.Application.Auth.AuthUser.Commands; 
namespace PORTIMAGES.Web.Controllers.Auth
{ 
    public class AuthUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAuthRepository _authService; 
        public AuthUserController(IMediator mediator, IAuthRepository authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpGet]
        [Route("Login", Name = "UserLogin")]
        [Route("AuthUser/Login")]
        public IActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                await _authService.SignInAsync(new()
                {
                    ID = result.UserID,
                    Name = result.Name,
                    Email = result.Email,
                    RoleName = result.RoleName,
                    Action = result.Action,
                    Controller = result.Controller,
                    Scheme=result.Scheme
                });               
                return RedirectToAction(result.Action, result.Controller);
            }
            ModelState.AddModelError("", result.Message);
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Logout")] 
        [Route("AuthUser/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync("UserScheme");
            return RedirectToRoute("UserLogin");
        }

    }
}
