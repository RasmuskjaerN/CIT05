using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/products")]
    public class AkaAttributesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxPageSize = 25;

        public AkaAttributesController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
            _dataService = dataService;
            _generator = generator;
            _mapper = mapper;
        }

        /*[HttpGet(Name = nameof(GetAkaAttributes))]
        public IActionResult GetAkaAttributes(int page = 0, int pageSize = 10)
        {
            var products =
                    _dataService.GetAkaAttributes(page, pageSize).Select(x => CreateAkaAttributeListModel(x));
            var total = _dataService.GetNumberOfAttributes();
            return Ok(Paging(page, pageSize, total, products));
            return no;
        }*/




        //[HttpGet]
        //public IActionResult GetAkaAttributes(string? search = null)
        //{
        //    if (string.IsNullOrEmpty(search))
        //    {
        //        var products =
        //            _dataService.GetAkaAttributes().Select(x => CreateAkaAttributeListModel(x));
        //        return Ok(products);
        //    }

        //    var data = _dataService.GetProductByName(search);
        //    return Ok(data);
        //}


        /*[HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = CreateProductModel(product);

            return Ok(model);

        }*/

        /*private ProductListModel CreateAkaAttributeListModel(AkaAttribute product)
        {
            var model = _mapper.Map<ProductListModel>(product);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id });
            return model;
        }*/

        /*private ProductModel CreateProductModel(AkaAttribute product)
        {
            var model = _mapper.Map<ProductModel>(product);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id });
            model.Category.Url = _generator.GetUriByName(HttpContext, nameof(CategoriesController.GetAkaType), new { product.Category.Id});
            return model;
        }*/

       /* private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
                HttpContext,
                nameof(GetAkaAttributes), new { page, pageSize });
        }

        private object Paging<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

            //if (pageSize > MaxPageSize)
            //{
            //    pageSize = MaxPageSize;
            //}

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
        }*/
    }
}
