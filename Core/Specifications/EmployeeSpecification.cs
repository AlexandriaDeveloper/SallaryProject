using Core.Specifications.Params;

namespace Core.Specifications
{
    public class EmployeeSpecification : Specifications<Employee>
    {
        public EmployeeSpecification(EmployeeParam empParam)
        {
            if (!string.IsNullOrEmpty(empParam.Name))
                AddCriteries(x => x.EmployeeName.StartsWith(empParam.Name));


            if (empParam.IsPaginationEnable)
            {
                ApplyPagination(empParam.PageSize * (empParam.PageIndex - 1), empParam.PageSize);
            }
        }
    }
}