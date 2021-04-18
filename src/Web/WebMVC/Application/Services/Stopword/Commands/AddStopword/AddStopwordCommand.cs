using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Stopword;

namespace WebMVC.Application.Services.Stopword.Commands.AddStopword
{
    public class AddStopwordCommand : IRequest
    {
        public string Stopword { get; set; }
    }

    public class AddStopwordCommandhandler : IRequestHandler<AddStopwordCommand>
    {
        private readonly IStopwordService _stopwordService;
        public AddStopwordCommandhandler(IStopwordService stopwordService)
        {
            _stopwordService = stopwordService;
        }
        public async Task<Unit> Handle(AddStopwordCommand request, CancellationToken cancellationToken)
        {
            await _stopwordService.CreateStopword(new Models.Response.Stopword { Name = request.Stopword, Active = true });

            return Unit.Value;
        }
    }
}
