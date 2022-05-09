namespace Core.Specifications.Params
{

    public interface IEmployeeParam : IParam
    {
        public string Name { get; set; }
    }
    public class EmployeeParam : Param, IParam
    {
        public string Name { get; set; }
    }

    public class TestParam : Param
    {
        public string Name { get; set; }
    }

}