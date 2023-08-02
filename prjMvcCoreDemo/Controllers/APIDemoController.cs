using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMvcCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIDemoController : ControllerBase
    {
        // GET: api/<APIDemoController>
        [HttpGet]
        public IEnumerable<TProduct> Get()
        {
            DbDemoContext ctx = new DbDemoContext();
            var datas = from p in ctx.TProducts
                        select p;
            foreach (var data in datas)
            {
                data.FCost = 0;
                if (data.FQty > 300)
                    data.FQty = 100;
            }
            return datas;
        }

        // GET api/<APIDemoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIDemoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIDemoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIDemoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
