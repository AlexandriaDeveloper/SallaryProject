#nullable disable

namespace Core.Specifications
{
    public interface IParam
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }

    public class Param : IParam
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }



    }

    public class EmployeeParam : Param { }
}