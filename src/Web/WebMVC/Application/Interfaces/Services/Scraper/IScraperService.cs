using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Services.Scraper.Models.Response;

namespace WebMVC.Application.Interfaces.Services.Scraper
{
    public interface IScraperService
    {
        Task<BodyData> GetBodyData(string text, string scrapeType);
        Task<LinkData> GetLinkData(string text, string scrapeType);
        Task<MetaData> GetMetaData(string text, string scrapeType);
    }
}
