using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class DepartmentDto
    {
        public Guid Id { get; set; } = new Guid();

        [MaxLength(30, ErrorMessage = "لا يمكن ان يزيد اسم القسم عن 30 حرف")]
        [MinLength(3, ErrorMessage = "لا يمكن ان يقل  اسم القسم عن 3 حرف")]
        [Required]
        public string Name { get; set; }
    }

}