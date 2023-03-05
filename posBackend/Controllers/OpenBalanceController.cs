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
    public class OpenBalanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OpenBalanceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.OpenBalances.GetAll());
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetByID(int? id)
        {
            if (id == null)
            {
                return BadRequest("OpenBalance Not Found");
            }
            var OpenBalance = await _unitOfWork.OpenBalances.GetByID((int)id);
            var OpenBalanceDt = await _unitOfWork.OpenBalancesDt.GetListByCondition(p => p.OpenBalanceId == id);
            OpenBalanceDTO _OpenBalanceDTO = new OpenBalanceDTO();
            _mapper.Map(OpenBalance, _OpenBalanceDTO);
            _mapper.Map(OpenBalanceDt, _OpenBalanceDTO.OpenBalancesDt);
            return Ok(_OpenBalanceDTO);
        }
        [HttpGet("index")]
        public async Task<IActionResult> Seacrh(string search, [FromQuery] SearchSettings searchSettings)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            var query = await _unitOfWork.OpenBalances.Search(o => (
                               o.DocNumber.Contains(search) ||
                               o.OpenBalanceDate.Equals(search) ||
                               o.store.StoreName.Contains(search) ||
                               o.Note.Contains(search)), searchSettings.Skip, searchSettings.Take, null, "ASC"
                               );

            return Ok(new { data = query, TotalCount = query.Count() });
        }
        [HttpPost]
        public async Task<IActionResult> Create(OpenBalanceDTO OpenBalanceDTO)
        {
            if (ModelState.IsValid)
            {
                if (OpenBalanceDTO.storeId != 1)
                {
                    return BadRequest("StoreId Must Be 1");
                }
                
                var newOpenBalance = await _unitOfWork.OpenBalances.Add(_mapper.Map<OpenBalance>(OpenBalanceDTO));
                _unitOfWork.Complete();

                var NewOpenbalanceDT = await _unitOfWork.OpenBalancesDt
                    .AddRange(_mapper.Map<IEnumerable<OpenBalanceDt>>(OpenBalanceDTO.OpenBalancesDt));
                foreach (var item in NewOpenbalanceDT)
                {
                    item.OpenBalanceId = newOpenBalance.ID;
                }
                _unitOfWork.Complete();

                return Ok(newOpenBalance);
            }
            return BadRequest("Missing Data");
        }
        [HttpPut]
        public async Task<IActionResult> Update(OpenBalanceDTO openBalanceDTO)
        {

            if (ModelState.IsValid)
            {
                var OpenBalance = await _unitOfWork.OpenBalances.GetByID(openBalanceDTO.ID);
                _unitOfWork.OpenBalances.Update(_mapper.Map(openBalanceDTO, OpenBalance));
                var OpenBalancesDt = await _unitOfWork.OpenBalancesDt.GetListByCondition(o => o.OpenBalanceId == openBalanceDTO.ID);
                foreach (var item in openBalanceDTO.OpenBalancesDt)
                {
                    if (item.ID == 0)
                    {
                        var OpenBalanceDt = _mapper.Map<OpenBalanceDt>(item);
                        OpenBalanceDt.OpenBalanceId = OpenBalance.ID;
                        await _unitOfWork.OpenBalancesDt.Add(OpenBalanceDt);
                    }
                    else
                    {
                        _unitOfWork.OpenBalancesDt.Update(_mapper.Map<OpenBalanceDt>(item));
                    }
                }


                foreach (var item in OpenBalancesDt)
                {
                    var openBalancesDtDto = openBalanceDTO.OpenBalancesDt
                        .FirstOrDefault(o => o.ID == item.ID);

                    if (openBalancesDtDto == null)
                    {
                        try
                        {
                            _unitOfWork.OpenBalancesDt.Delete(item);
                        }
                        catch (Exception e)
                        {

                            return BadRequest(e.Message);
                        }

                    }

                }
                _unitOfWork.Complete();
                return Ok(OpenBalance);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var openBalances = await _unitOfWork.OpenBalances.GetByID(id);
            var openBalancesDt = await _unitOfWork.OpenBalancesDt.GetListByCondition(o => o.OpenBalanceId == id);
            try
            {
                _unitOfWork.OpenBalancesDt.DeleteRange(openBalancesDt);
                _unitOfWork.OpenBalances.Delete(openBalances);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Missing Data");
            }
        }

    }
}
