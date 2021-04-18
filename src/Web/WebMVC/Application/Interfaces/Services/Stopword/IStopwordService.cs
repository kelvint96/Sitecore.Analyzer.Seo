using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopwordModel = WebMVC.Application.Services.Stopword.Models.Response.Stopword;

namespace WebMVC.Application.Interfaces.Services.Stopword
{
    public interface IStopwordService
    {
        Task<List<StopwordModel>> GetStopwords();
        Task<StopwordModel> GetStopwordById(string id);
        Task CreateStopword(StopwordModel stopword);
        Task UpdateStopword(StopwordModel stopword);
        Task DeleteStopword(string id);
    }
}
