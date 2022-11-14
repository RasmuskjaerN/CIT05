using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public CategoriesController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
            _dataService = dataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetAkaTypes))]
        public IActionResult GetAkaTypes()
        {
            var categories = 
                _dataService.GetAkaTypes().Select(x => CreateAkaTypeModel(x));
            return Ok(categories);
        }

        private object CreateAkaTypeModel(akaType x)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = nameof(GetAkaType))]
        public IActionResult GetAkaType(string id)
        {
            var akaType = _dataService.GetAkaType(id);

            if (akaType == null)
            {
                return NotFound();
            }

            var model = CreateAkaTypeModel(akaType);

            return Ok(model);

        }

        

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
                HttpContext,
                nameof(GetAkaTypes), new { page, pageSize });
        }

        
    }
}
