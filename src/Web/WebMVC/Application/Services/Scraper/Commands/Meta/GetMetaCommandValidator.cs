using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Domain.Enums;

namespace WebMVC.Application.Services.Scraper.Commands.Meta
{
    public class GetMetaCommandValidator : AbstractValidator<GetMetaCommand>
    {
        public GetMetaCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(v => v.ScrapeType).NotEmpty();
            RuleFor(v => v.Text).NotEmpty()
                .Must((o, text) => { return BeValidUrl(text, o.ScrapeType); }).WithMessage("Invalid URL string. Please enter a valid URL.");
        }

        public bool BeValidUrl(string text, string scrapeType)
        {
            if (scrapeType.Equals(ScrapeTypes.Link.Name))
            {
                Uri uri;
                return Uri.TryCreate(text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            }
            return true;
        }
    }
}
