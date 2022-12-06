using System.Reflection.Emit;
using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/names")]
    public class NameBasicController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;
        private readonly int MaxPageSize;

        public NameBasicController(IDataService dataService, IMapper mapper, LinkGenerator generator)
        {
            _dataService = dataService;
            _mapper = mapper;
            _generator = generator;
        }

        private NameBasicModel NameCreateModel(nameBasic nconst)
        {
            var model = _mapper.Map<NameBasicModel>(nconst);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetNames), new { nconst.Nconst });
            return model;
        }


        [HttpGet(Name = nameof(GetNames))]
        [Route("{page}/{pagesize}")]
        public IActionResult GetNames([FromRoute] int page = 0, int pagesize = 10)
        {
            var names = _dataService.GetNamesList(page, pagesize).Select(x => NameCreateModel(x));
            var total = names.Count();
            return Ok(Paging(page, pagesize, total, names));
        }

        [HttpGet("{nconst}", Name = nameof(GetName))]
        public IActionResult GetName([FromRoute] string nconst)
        {
            var Nconst = _dataService.GetName(nconst);

            if (Nconst == null)
            {
                return NotFound();
            }

            return Ok(Nconst);
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(HttpContext, nameof(GetNames), new { page, pageSize });
        }
        private object Paging<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

            var pages = (int)Math.Ceiling((double)total / (double)pageSize)
                ;

            var first = total > 0
                ? CreateLink(0, pageSize)
                : null;

            var prev = page > 0
                ? CreateLink(page - 1, pageSize)
                : null;

            var current = CreateLink(page, pageSize);

            var next = page < pages - 1
                ? CreateLink(page + 1, pageSize)
                : null;

            var result = new
            {
                first,
                prev,
                next,
                current,
                total,
                pages,
                items
            };
            return result;
        }
    }
}
