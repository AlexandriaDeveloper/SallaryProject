using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Helper;
using Core;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.Params;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    public class EmployeeController : BaseController<Employee, EmployeeDto>
    {

        public EmployeeController(IUOW uow) : base(uow)
        {
        }


        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<EmployeeDto>>> Get([FromQuery] EmployeeParam param1)
        {
            var spec = new EmployeeSpecification(param1);

            List<Employee> result = await this._uow.Repository<Employee>().GetAllAsync(spec);
            var resultToRetun = result.EvaluateModelToDto<List<Employee>, List<EmployeeDto>>();

            Pagination<EmployeeDto> empsToReturn = new Pagination<EmployeeDto>(param1.PageIndex, param1.PageSize, result.Count, resultToRetun);
            GetParam(param1);
            return Ok(resultToRetun);
        }
        protected Param GetParam(Param param)
        {
            return param;
        }
    }
}
