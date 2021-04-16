﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScraper.API.Entities;
using WebScraper.API.Interfaces.Stopwords;

namespace WebScraper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopwordsController : ControllerBase
    {
        private readonly IStopwordsRepository _stopwordsRepository;

        public StopwordsController(IStopwordsRepository stopwordsRepository)
        {
            _stopwordsRepository = stopwordsRepository ?? throw new ArgumentNullException(nameof(stopwordsRepository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Stopwords>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Stopwords>>> GetStopwords()
        {
            var stopwords = await _stopwordsRepository.GetStopwords();
            return stopwords;
        }

        [HttpGet("{id:length(24)}", Name = "GetStopwordById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Stopwords), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Stopwords>> GetStopwordById(string id)
        {
            var stopword = await _stopwordsRepository.GetStopwordById(id);
            if (stopword == null)
            {
                return NotFound();
            }
            return Ok(stopword);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Stopwords), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Stopwords>> CreateStopword([FromBody] Stopwords stopword)
        {
            if (string.IsNullOrEmpty(stopword.Id)) stopword.Id = ObjectId.GenerateNewId().ToString();

            await _stopwordsRepository.CreateStopword(stopword);

            return CreatedAtRoute("GetStopwordById", new { id = stopword.Id }, stopword);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Stopwords), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStopword([FromBody] Stopwords stopword)
        {
            return Ok(await _stopwordsRepository.UpdateStopwords(stopword));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Stopwords), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteStopwordById(string id)
        {
            return Ok(await _stopwordsRepository.DeleteStopwords(id));
        }
    }
}
