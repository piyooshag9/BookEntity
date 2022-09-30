using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntity.Models
{
    public class BookCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}
