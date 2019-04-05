using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shopy.Admin.ViewModels
{
    public class ProductViewModel
    {
        //TODO: image size validation

        public Guid Uid { get; set; }

        [Required]
        [Display(Name = "Caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "999999999")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Sizes")]
        public IEnumerable<string> Sizes { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Main")]
        public ImageViewModel Image1 { get; set; }

        [Display(Name = "Optional")]
        public ImageViewModel Image2 { get; set; }

        [Display(Name = "Optional")]
        public ImageViewModel Image3 { get; set; }

        public IEnumerable<SelectListItem> BrandsSelectList { get; set; }

        public MultiSelectList SelectedSizesML { get; set; }
    }
}