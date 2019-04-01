﻿using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Shopy.Admin.ViewModels
{
    public class ProductViewModel
    {
        //TODO: product images
        //TODO: image size validation

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
        public SizeType Size { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public BrandType Brand { get; set; }

        public HttpPostedFileBase Image1 { get; set; }

        public HttpPostedFileBase Image2 { get; set; }

        public HttpPostedFileBase Image3 { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        public IEnumerable<SelectListItem> Sizes { get; set; }
    }
}