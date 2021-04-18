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

namespace WebMVC.Application.Services.Scraper.Commands.Meta
{
    public class GetMetaCommand : IRequest<MetaData>
    {
        public string Text { get; set; }
        public string ScrapeType { get; set; }
    }

    public class GetMetaCommandHandler : IRequestHandler<GetMetaCommand, MetaData>
    {
        private readonly IScraperService _scraperService;
        public GetMetaCommandHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        public Task<MetaData> Handle(GetMetaCommand request, CancellationToken cancellationToken)
        {
            var bodyData = _scraperService.GetMetaData(request.Text, request.ScrapeType);
            return bodyData;
        }
    }
}
