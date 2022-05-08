#nullable disable

using System;

namespace Core
{
    public class EmployeePayment
    {
        public Guid EmployeeId { get; set; }
        public Payment Payment { get; set; }
    }
}
