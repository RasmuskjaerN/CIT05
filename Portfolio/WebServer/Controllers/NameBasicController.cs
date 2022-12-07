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


        private const int MaxPageSize = 25;

        public NameBasicController(IDataService dataService, IMapper mapper, LinkGenerator generator)
        {
            _dataService = dataService;
            _mapper = mapper;
            _generator = generator;
        }

        [HttpGet("{nconst}", Name = nameof(GetName))]
        public IActionResult GetName( string nconst)
        {
            var name = _dataService.GetName(nconst);

            if (name == null)
            {
                return NotFound();
            }
            var model = NameCreateModel(name);

            return Ok(model);
        }

        [HttpGet(Name = nameof(GetNames))]
        [Route("{page}&{pageSize}")]
        public IActionResult GetNames(int page = 0, int pagesize = 10)
        {
            var names = _dataService.GetNamesList(page, pagesize).Select(x => NameCreateListModel(x));
            var total = _dataService.GetNamesListCount();
            return Ok(Paging(page, pagesize, total, names));
        }

        private NameBasicListModel NameCreateListModel(nameBasic nconst)
        {
            var model = _mapper.Map<NameBasicListModel>(nconst);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetName), new { nconst.Nconst });
            return model;
        }

        private NameBasicModel NameCreateModel(nameBasic nconst)
        {
            var model = _mapper.Map<NameBasicModel>(nconst);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetName), new { nconst.Nconst });
            return model;
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
