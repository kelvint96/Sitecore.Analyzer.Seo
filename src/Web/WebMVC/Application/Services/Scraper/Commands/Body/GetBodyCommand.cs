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

namespace WebMVC.Application.Services.Scraper.Commands.Body
{
    public class GetBodyCommand : IRequest<BodyDto>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetBodyCommandHandler : IRequestHandler<GetBodyCommand, BodyDto>
    {
        private readonly IScraperService _scraperService;
        public GetBodyCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public async Task<BodyDto> Handle(GetBodyCommand request, CancellationToken cancellationToken)
        {
            var bodyData = await _scraperService.GetBodyData(request.Text, request.ScrapeType);

            BodyDto dto = new();
            dto.Body = bodyData.Body;
            dto.OccurenceList = bodyData.BodyOccurence.Select((value, index) => new OccurenceDto { No = index + 1, Word = value.Key, Occurence = value.Value }).ToList();

            return dto;
        }
    }
}
