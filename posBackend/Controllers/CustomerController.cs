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
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Customers.GetAll());
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return BadRequest("Customer Not Found");
            }
            return Ok(await _unitOfWork.Customers.GetByID((int)id));
        }

        [HttpGet("index")]
        public async Task<IActionResult> Seacrh(string search, [FromQuery] SearchSettings searchSettings)
        {
            var query = await _unitOfWork.Customers.Search(p => p.IsActive);
            if (!string.IsNullOrEmpty(search))
            {
                query = await _unitOfWork.Customers.Search(p =>
                     p.CustomerName.Contains(search) ||
                     p.CustomerAddress.Contains(search) ||
                     p.Phone1.Contains(search) ||
                     p.Phone2.Contains(search) ||
                     p.RegisterNumber.Contains(search) ||
                     p.CustomerEmail.Contains(search),
                    searchSettings.Skip, searchSettings.Take
                     );
            }

            return Ok(query);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = await _unitOfWork.Customers.Add(_mapper.Map<Customer>(customerDTO));
                _unitOfWork.Complete();
                return Ok(newCustomer);
            }
            return BadRequest("Missing Data");
        }
        [HttpPut]
        public async Task<IActionResult> Update(CustomerDTO customerDTO)
        {

            if (ModelState.IsValid)
            {
                var Customer = await _unitOfWork.Customers.GetByID(customerDTO.ID);
                _unitOfWork.Customers.Update(_mapper.Map(customerDTO, Customer));
                _unitOfWork.Complete();
                return Ok(Customer);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var Customer = await _unitOfWork.Customers.GetByID(id);

            try
            {
                _unitOfWork.Customers.Delete(Customer);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Customer has related data");
            }
        }
    }
}
