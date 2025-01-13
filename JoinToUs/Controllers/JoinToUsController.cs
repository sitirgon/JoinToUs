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

        public async Task<IActionResult> Index()
        {
            var users = joinToUsService.GetAll();
            return View(users);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDto);
            }
            await joinToUsService.Create(createUserDto);
            return RedirectToAction(nameof(Create));
        }
    }
}
