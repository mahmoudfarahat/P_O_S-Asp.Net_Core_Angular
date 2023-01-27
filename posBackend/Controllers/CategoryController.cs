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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Categories.GetAll());
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category Not Found");
            }
            return Ok(await _unitOfWork.Categories.GetByID((int)id));
        }

        [HttpGet("index")]
        public async Task<IActionResult> Seacrh(string search, [FromQuery] SearchSettings searchSettings)
        {
            var query = await _unitOfWork.Categories.Search(p => p.IsActive, searchSettings.Skip, searchSettings.Take);
            if (!string.IsNullOrEmpty(search))
            {
                 query = await _unitOfWork.Categories.Search(p =>
                 p.CategoryName.Contains(search) ||
                 p.Notes.Contains(search),
                 searchSettings.Skip, searchSettings.Take
                 );
            }

            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var newCategory = await _unitOfWork.Categories.Add(_mapper.Map<Category>(categoryDTO));
                _unitOfWork.Complete();
                return Ok(newCategory);
            }
            return BadRequest("Missing Data");
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {

            if (ModelState.IsValid)
            {
                var category = await _unitOfWork.Categories.GetByID(categoryDTO.ID);
                _unitOfWork.Categories.Update(_mapper.Map(categoryDTO, category));
                _unitOfWork.Complete();
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _unitOfWork.Categories.GetByID(id);

            try
            {
                _unitOfWork.Categories.Delete(category);
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
