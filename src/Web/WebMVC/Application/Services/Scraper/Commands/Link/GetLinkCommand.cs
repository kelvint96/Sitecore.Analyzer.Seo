using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Scraper;
using WebMVC.Application.Services.Scraper.Models.Dto;
using WebMVC.Application.Services.Scraper.Models.Response;
using WebMVC.Domain.Enums;

namespace WebMVC.Application.Services.Scraper.Commands.Link
{
    public class GetLinkCommand : IRequest<LinkDto>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetLinkCommandHandler : IRequestHandler<GetLinkCommand, LinkDto>
    {
        private readonly IScraperService _scraperService;
        public GetLinkCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public async Task<LinkDto> Handle(GetLinkCommand request, CancellationToken cancellationToken)
        {
            var linkData = await _scraperService.GetLinkData(request.Text, request.ScrapeType);

            LinkDto dto = new();
            dto.Links = linkData.Links;
            dto.OccurenceList = linkData.Links.Select((value, index) => new OccurenceDto { No = index + 1, Word = value }).ToList();

            return dto;
        }
    }
}
