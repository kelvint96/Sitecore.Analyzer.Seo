using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Scraper;
using WebMVC.Application.Services.Scraper.Models.Response;
using WebMVC.Domain.Enums;

namespace WebMVC.Application.Services.Scraper.Commands.Link
{
    public class GetLinkCommand : IRequest<LinkData>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetLinkCommandHandler : IRequestHandler<GetLinkCommand, LinkData>
    {
        private readonly IScraperService _scraperService;
        public GetLinkCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public Task<LinkData> Handle(GetLinkCommand request, CancellationToken cancellationToken)
        {
            var bodyData = _scraperService.GetLinkData(request.Text, request.ScrapeType);
            return bodyData;
        }
    }
}
