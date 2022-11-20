using System;
using System.Linq;
using EstuSozluk.API.Models;
using EstuSozluk.API.Models.Dtos;
using EstuSozluk.API.Models.Mappers;
using EstuSozluk.API.Repositories;
using EstuSozluk.API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EstuSozluk.API.Controllers.V1
{
    [ApiController]
    public class EntryController : ControllerBase
    {
        // GET
        private IConfiguration _configuration;
        private IEntryService _entryService;
        private EstuSozlukContext _estuSozlukContext;


        public EntryController(IConfiguration configuration, IEntryService entryService, EstuSozlukContext estuSozlukContext)
        {
            _configuration = configuration;
            _entryService = entryService;
            _estuSozlukContext = estuSozlukContext;
        }
        [Route("api/[controller]")]
        [HttpPost]
        [Authorize]
        public IActionResult AddNewEntry([FromBody] EntryDto entry)
        {
            Console.WriteLine("----->" + entry.userid);
          
          return Ok(_entryService.AddEntry(entry));
        }

        [Route("api/[controller]/{entryid}")]
        [HttpGet]
        public IActionResult GetEntryById(int entryid)
        {
            Console.WriteLine("------------------>>>>>>" + _estuSozlukContext.Entries.Select(e => e.content));
            Console.WriteLine("------------------>>>>>>" +_estuSozlukContext.Users);
            return Ok(_entryService.GetEntryById(entryid));
        }
    }
}