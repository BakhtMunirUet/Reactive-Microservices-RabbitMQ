 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMemoryReportStorage _memoryReportStorage;

        public ReportsController(IMemoryReportStorage memoryReportStorage)
        {
            _memoryReportStorage = memoryReportStorage;
        }


        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return _memoryReportStorage.Get();
        }

      
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

     
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
