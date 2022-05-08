using Core;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SallaryContext context) : base(context)
        {

        }
    }
}