using DataLayer.Domain;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/attributes")]
    public class AttributeController : ControllerBase
    {
        /*private IDataService _dataService = new DataService();

        [HttpGet]
        public IActionResult Get()
        {
            var attributes = _dataService.GetAkaAttributes();
            return Ok(attributes);
        }

        [HttpGet("tconst")]
        public IActionResult GetAkaAttribute(string tconst)
        {
            var attribute = _dataService.GetAkaAttribute(tconst);

            if (attribute == null)
            {
                return NotFound();
            }
            var model = new AkaAttributeModel
            {
                Url = "http://localhost:5001/api/attributes" + attribute.Tconst,
                Ordering = attribute.Ordering,
                Attribute = attribute.Attribute
            };
            return Ok(model);
        }*/
    }
}
