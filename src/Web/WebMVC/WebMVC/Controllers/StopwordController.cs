using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Application.Services.Stopword.Commands.AddStopword;
using WebMVC.Application.Services.Stopword.Commands.DeleteStopword;
using WebMVC.Application.Services.Stopword.Queries.GetStopword;

namespace WebMVC.Controllers
{
    public class StopwordController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public StopwordController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAsync()
        {
            var stopwordData = await _mediator.Send(new GetStopwordQuery());
            return Ok(stopwordData);
        }

        public async Task<IActionResult> DeleteAsync(string id)
        {
            var stopwordData = await _mediator.Send(new DeleteStopwordCommand() { Id = id });
            return Ok();
        }

        public async Task<IActionResult> AddAsync(string stopword)
        {
            var stopwordData = await _mediator.Send(new AddStopwordCommand() { Stopword = stopword });
            return Ok();
        }
    }
}
