#nullable disable

using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class EmployeeBankPersonalAccount : BaseEntity
    {
        public Guid BankBranchId { get; set; }
        public Guid EmployeeId { get; set; }
        [StringLength(22)]
        public string AccountNumber { get; set; }
        public Employee Employee { get; set; }
    }


}
