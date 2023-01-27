using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using posBackend.EF.Const;
using posBackend.EF.DTOS;
using posBackend.EF.Models;
using posBackend.EF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Products.GetAll());
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return BadRequest("Product Not Found");
            }
            var product = await _unitOfWork.Products.GetByID((int)id);
            var productUnits = await _unitOfWork.ProductUnits.GetListByCondition(p => p.ProductID == id);
            ProductDTO productDTO = new ProductDTO();
            _mapper.Map(product, productDTO);
            _mapper.Map(productUnits, productDTO.productUnits);
            return Ok(productDTO);
        }

        [HttpGet("index")]
        public async Task<IActionResult> Seacrh(string search, [FromQuery] SearchSettings searchSettings)
        {
            var query = await _unitOfWork.Products.Search(p => p.IsActive);
            if (!string.IsNullOrEmpty(search))
            {
                query = await _unitOfWork.Products.Search(p =>
                 p.ProductName.Contains(search) ||
                 p.Category.CategoryName.Contains(search) ||
                 p.Description.Contains(search), searchSettings.Skip, searchSettings.Take
                 );

            }

            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var newProduct = await _unitOfWork.Products.Add(_mapper.Map<Product>(productDTO));
                _unitOfWork.Complete();

                var productUnits = await _unitOfWork.ProductUnits
                    .AddRange(_mapper.Map<IEnumerable<ProductUnit>>(productDTO.productUnits));
                foreach (var item in productUnits)
                {
                    item.ProductID = newProduct.ID;
                }
                _unitOfWork.Complete();

                return Ok(newProduct);
            }
            return BadRequest("Missing Data");
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {

            if (ModelState.IsValid)
            {
                var product = await _unitOfWork.Products.GetByID(productDTO.ID);
                _unitOfWork.Products.Update(_mapper.Map(productDTO, product));
                var productUnits = await _unitOfWork.ProductUnits.GetListByCondition(p => p.ProductID == productDTO.ID);
                foreach (var item in productDTO.productUnits)
                {
                    if (item.index == 0)
                    {
                        var productUnit = _mapper.Map<ProductUnit>(item);
                        productUnit.ProductID = product.ID;
                        await _unitOfWork.ProductUnits.Add(productUnit);
                    }
                    else
                    {
                        _unitOfWork.ProductUnits.Update(_mapper.Map<ProductUnit>(item));
                    }
                }


                foreach (var item in productUnits)
                {
                    var productUnit = productDTO.productUnits
                        .FirstOrDefault(a => a.index == item.index);

                    if (productUnit == null)
                    {
                        try
                        {
                            _unitOfWork.ProductUnits.Delete(item);
                        }
                        catch (Exception e)
                        {

                            return BadRequest(e.Message);
                        }

                    }

                }
                _unitOfWork.Complete();
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Products.GetByID(id);
            var productUnits = await _unitOfWork.ProductUnits.GetListByCondition(p => p.ProductID == id);
            try
            {
                _unitOfWork.ProductUnits.DeleteRange(productUnits);
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Item has related data");
            }
        }
    }
}
