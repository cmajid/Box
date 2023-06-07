using System;
using System.ComponentModel.DataAnnotations;

namespace Box.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; protected set; }
    }
}

