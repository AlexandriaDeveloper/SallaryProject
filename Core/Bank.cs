#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Bank : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public int? MaxLength { get; set; }
        public Guid? BankId { get; set; } = null;

        public ICollection<Bank> Branches { get; set; }
  
        public Bank ParentBank { get; set; }
    }


}
