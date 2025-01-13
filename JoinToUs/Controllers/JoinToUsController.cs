using JoinToUs.Application.EntitiesDto.CreateUser;
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
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            await joinToUsService.Create(createUserDto);
            return RedirectToAction(nameof(Create));
        }
    }
}
