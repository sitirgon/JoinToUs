using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Application.JoinToUs.Command.CreateUserCommand;
using JoinToUs.Application.JoinToUs.Queries.GetAllUsers;
using JoinToUs.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoinToUsController.MVC
{
    public class JoinToUsController : Controller
    {
        private readonly IMediator mediator;
        public JoinToUsController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var users = await mediator.Send(new GetAllUsersQuery());
            return View(users);
        }
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
