using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Helper;
using Core;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    public class EmployeeController : BaseController<Employee, EmployeeDto>
    {

        public EmployeeController(IUOW uow) : base(uow)
        {
        }

    }
}
