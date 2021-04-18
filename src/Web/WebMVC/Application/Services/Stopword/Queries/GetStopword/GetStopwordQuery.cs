using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Stopword;
using StopwordResponse = WebMVC.Application.Services.Stopword.Models.Response.Stopword;

namespace WebMVC.Application.Services.Stopword.Queries.GetStopword
{
    public class GetStopwordQuery : IRequest<List<StopwordResponse>>
    {
    }

    public class GetStopwordQueryHandler : IRequestHandler<GetStopwordQuery, List<StopwordResponse>>
    {
        private readonly IStopwordService _stopwordService;
        public GetStopwordQueryHandler(IStopwordService stopwordService)
        {
            _stopwordService = stopwordService;
        }

        public async Task<List<StopwordResponse>> Handle(GetStopwordQuery request, CancellationToken cancellationToken)
        {
            var stopwords = await _stopwordService.GetStopwords();
            return stopwords;
        }
    }
}
