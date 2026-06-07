using Microsoft.AspNetCore.Mvc;
using TestAsp.Data;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public RecordsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetRecords()
        {
            var records = this.dbContext.Records.ToList();
            return Ok(records);
        }

        [HttpPost]
        public IActionResult CreateRecord([FromBody] RecordItem item)
        {
            this.dbContext.Records.Add(item);
            this.dbContext.SaveChanges();
            return Ok(item);
        }
    }
}