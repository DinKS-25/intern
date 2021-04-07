using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Core
{
    public class Book
    {
        [Required, Range(0, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(100),Required]
        public string  Name { get; set; }

        [Required,MaxLength(255)]
        public string  Description { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
