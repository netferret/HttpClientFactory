using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HttpFactoryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IHttpClientFactory _httpFactory { get; set; }
        public IHttpService _httpService { get; private set; }

        public ValuesController(IHttpClientFactory httpFactory, IHttpService httpService)
        {
            _httpFactory = httpFactory;
            _httpService = httpService;
        }
        // GET api/values
        
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {

            try
            {
                var t = Task.Run(() => {
                    return _httpService.CallAPIAsync();
                });

                TimeSpan ts = TimeSpan.FromMilliseconds(100);

                if (!t.Wait(ts))
                    return "TIMED OUT";

                return t.Result;
            }
            catch (Exception ex)
            {
                return ex.InnerException;
            }

            return "NO RESPONSE";
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
