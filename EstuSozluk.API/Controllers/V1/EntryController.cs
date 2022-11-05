using EstuSozluk.API.Models.RequestObjects;
using EstuSozluk.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EstuSozluk.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IEntryService _EntryService;

        public EntryController(IConfiguration configuration, IEntryService EntryService)
        {
            _configuration = configuration;
            _EntryService = EntryService;

        }

        [HttpPost]
        [Route("get")]
        public object GetUserEntries([FromBody] GetEntriesByUserNameDTO UserName)
        {
            return _EntryService.GetAllEntriesByUserName(UserName.UserName);
        }


    }
}
