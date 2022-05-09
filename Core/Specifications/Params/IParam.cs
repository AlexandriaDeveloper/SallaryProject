#nullable disable

namespace Core.Specifications
{
    public interface IParam
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }
}