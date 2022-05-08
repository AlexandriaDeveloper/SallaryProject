using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; } = new Guid();
        [MaxLength(100, ErrorMessage = "لا يمكن ادخال اكثر من 100 حرف ")]
        [MinLength(5, ErrorMessage = "لا يمكن ادخال أقل من 100 حرف ")]
        [Required(ErrorMessage = "من فضلك قم بإدخال الأسم")]
        public string EmployeeName { get; set; }
        [MaxLength(14, ErrorMessage = "لا يمكنك ادخال أكثر 14 رقم")]
        [MinLength(14, ErrorMessage = "لا يمكنك ادخال اقل 14 رقم")]
        public string NationalId { get; set; }
        [StringLength(6)]
        public string TegaraCode { get; set; }
        [StringLength(6)]
        public string TabCode { get; set; }
        public Guid? DepartmentId { get; set; }
    }

}