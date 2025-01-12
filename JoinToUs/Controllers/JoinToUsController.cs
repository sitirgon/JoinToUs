using JoinToUs.Application.EntitiesDto;
using JoinToUs.Application.Services;
using JoinToUs.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace JoinToUsController.MVC
{
    public class JoinToUsController : Controller
    {
        private readonly IJoinToUsService joinToUsService;
        public JoinToUsController(IJoinToUsService joinToUsService) 
        {
            this.joinToUsService = joinToUsService;
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsersDto user, PasswordDto password)
        {
            await joinToUsService.Create(user, password);
            return RedirectToAction(nameof(Create));
        }
    }
}
