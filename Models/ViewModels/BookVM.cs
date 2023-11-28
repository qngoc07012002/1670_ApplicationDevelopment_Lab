using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _1670_ApplicationDevelopment_Lab.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MyCategories { get; set; }


    }
}
