using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Shopy.Admin.ViewModels
{
    public class ProductViewModel
    {
        //TODO: product images

        public Guid Uid { get; set; }

        [Required]
        [Display(Name = "Caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        private static string[] brands = new[] {
            "Puma",
            "Addiddas",
            "Nike",
            "Champion",
            "Rebook"};

        private static string[] sizes = new[] {
            "S",
            "M",
            "L",
            "XL",
            "XXL"};

        public static IEnumerable<SelectListItem> Sizes = CreatSelectListItem(sizes);
        public static IEnumerable<SelectListItem> Brands = CreatSelectListItem(brands);

        private static IEnumerable<SelectListItem> CreatSelectListItem(string[] data)
        {
            return data.Select(d => new SelectListItem()
            {
                Text = d,
                Value = d
            });
        }
    }
}