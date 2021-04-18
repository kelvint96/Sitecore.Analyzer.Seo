using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Stopword;

namespace WebMVC.Application.Services.Stopword.Commands.DeleteStopword
{
    public class DeleteStopwordCommand : IRequest
    {
        public string Id { get; set; }
    }

    public class DeleteStopwordCommandHandler : IRequestHandler<DeleteStopwordCommand>
    {
        private readonly IStopwordService _stopwordService;
        public DeleteStopwordCommandHandler(IStopwordService stopwordService)
        {
            _stopwordService = stopwordService;
        }
        public async Task<Unit> Handle(DeleteStopwordCommand request, CancellationToken cancellationToken)
        {
            await _stopwordService.DeleteStopword(request.Id);

            return Unit.Value;
        }
    }
}
