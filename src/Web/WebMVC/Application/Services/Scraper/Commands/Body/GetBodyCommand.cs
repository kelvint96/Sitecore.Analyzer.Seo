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

namespace WebMVC.Application.Services.Scraper.Commands.Body
{
    public class GetBodyCommand : IRequest<BodyData>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetBodyCommandHandler : IRequestHandler<GetBodyCommand, BodyData>
    {
        private readonly IScraperService _scraperService;
        public GetBodyCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public async Task<BodyData> Handle(GetBodyCommand request, CancellationToken cancellationToken)
        {
            var bodyData = await _scraperService.GetBodyData(request.Text, request.ScrapeType);
            return bodyData;
        }
    }
}
