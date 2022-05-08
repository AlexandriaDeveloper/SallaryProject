using API.DTOs;
using Core;
using Core.Interfaces;

namespace API.Controllers
{
    public class DepartmentController : BaseController<Department, DepartmentDto>
    {
        public DepartmentController(IUOW uow) : base(uow)
        {
        }
    }
}