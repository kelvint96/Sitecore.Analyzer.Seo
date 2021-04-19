using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Application.Services.Scraper.Commands.Body;
using WebMVC.Application.Services.Scraper.Commands.Link;
using WebMVC.Application.Services.Scraper.Commands.Meta;
using WebMVC.Domain.Enums;
using WebMVC.Models;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new AnalyzeFormViewModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SiteData(AnalyzeFormViewModel model)
        {
            if (model.ScrapeType.Equals(ScrapeTypes.Text.Name)) model.isMetaSelected = false;
            return PartialView("_ScrapedData", model);
        }

        public async Task<IActionResult> BodyDataAsync(string text, string scrapeType)
        {
            var bodyData = await _mediator.Send(new GetBodyCommand() {Text = text, ScrapeType = scrapeType });
            return PartialView("_BodyAnalysis", bodyData);
        }

        public async Task<IActionResult> MetaDataAsync(string text, string scrapeType)
        {
            var bodyData = await _mediator.Send(new GetMetaCommand() { Text = text, ScrapeType = scrapeType });
            return PartialView("_MetaAnalysis", bodyData);
        }

        public async Task<IActionResult> LinkDataAsync(string text, string scrapeType)
        {
            var bodyData = await _mediator.Send(new GetLinkCommand() { Text = text, ScrapeType = scrapeType });
            return PartialView("_LinkAnalysis", bodyData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
