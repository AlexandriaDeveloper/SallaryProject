#nullable disable

using System;

namespace Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();

        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public Guid CreatedBy { get; set; }
    }
}
