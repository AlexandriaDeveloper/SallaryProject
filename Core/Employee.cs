#nullable disable

using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Employee : BaseEntity
    {
        [StringLength(100, ErrorMessage = "لا يمكن ادخال اكثر من 100 حرف ")]
        [Required(ErrorMessage = "من فضلك قم بإدخال الأسم")]
        public string EmployeeName { get; set; }
        [StringLength(14, ErrorMessage = "يجب ادخال 14 رقم")]
        public string NationalId { get; set; }
        [StringLength(6)]
        public string TegaraCode { get; set; }
        [StringLength(6)]
        public string TabCode { get; set; }
        public Guid? DepartmentId { get; set; }

        public EmployeeBankPersonalAccount PersonalAccount { get; set; }

    }
}
