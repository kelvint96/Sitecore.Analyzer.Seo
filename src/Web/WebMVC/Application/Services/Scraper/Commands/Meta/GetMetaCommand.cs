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

namespace WebMVC.Application.Services.Scraper.Commands.Meta
{
    public class GetMetaCommand : IRequest<MetaDto>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetMetaCommandHandler : IRequestHandler<GetMetaCommand, MetaDto>
    {
        private readonly IScraperService _scraperService;
        public GetMetaCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public async Task<MetaDto> Handle(GetMetaCommand request, CancellationToken cancellationToken)
        {
            var metaData = await _scraperService.GetMetaData(request.Text, request.ScrapeType);

            MetaDto dto = new();
            dto.Metas = metaData.Metas;
            dto.OccurenceList = metaData.MetaOccurences.Select((value, index) => new OccurenceDto { No = index + 1, Word = value.Key, Occurence = value.Value }).ToList();

            return dto;
        }
    }
}
