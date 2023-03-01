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
    public class UnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Units.GetAll());
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return BadRequest("Unit Not Found");
            }
            return Ok(await _unitOfWork.Units.GetByID((int)id));
        }

        [HttpGet("index")]
        public async Task<IActionResult> Seacrh(string search , [FromQuery] SearchSettings searchSettings)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            var query = await _unitOfWork.Units.Search(p => (
                               p.UnitName.Contains(search) ||
                               p.Notes.Contains(search)), searchSettings.Skip, searchSettings.Take, null, "ASC"

                               );

            return Ok( new { data = query  , TotalCount = query.Count()});

        }

        [HttpPost]
        public async Task<IActionResult> Create(UnitDTO unitDTO)
        {
            if (ModelState.IsValid)
            {
                var newUnit = await _unitOfWork.Units.Add(_mapper.Map<Unit>(unitDTO));
                _unitOfWork.Complete();
                return Ok(newUnit);
            }
            return BadRequest("Missing Data");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UnitDTO unitDTO)
        {

            if (ModelState.IsValid)
            {
                var unit = await _unitOfWork.Units.GetByID(unitDTO.ID);
                _unitOfWork.Units.Update(_mapper.Map(unitDTO, unit));
                _unitOfWork.Complete();
                return Ok(unit);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var unit = await _unitOfWork.Units.GetByID(id);

            try
            {
                _unitOfWork.Units.Delete(unit);
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
