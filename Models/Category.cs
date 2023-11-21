using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _1670_ApplicationDevelopment_Lab.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        
        public Category() { }
        
  

        
    }
}
