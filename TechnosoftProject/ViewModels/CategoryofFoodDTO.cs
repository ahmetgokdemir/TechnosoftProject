﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Project.ENTITIES.Enums;

namespace Technosoft_Project.ViewModels
{
    public class CategoryofFoodDTO
    {
        public short ID { get; set; }

        [Required(ErrorMessage = "Kategori ismi gereklidir.")]
        [Display(Name = "Kategori Adı")]
        [MaxLength(30, ErrorMessage = "Kategori en fazla 30 karakterli olmalıdır.")]
        public string CategoryName_of_Foods { get; set; }


        // sonra yoruma al... !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // sonra yoruma al... !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // sonra yoruma al... !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [Display(Name = "Kategori Resmi")]
        public string? CategoryofFoodPicture { get; set; }

        [Display(Name = "Durum")]
        [Required(ErrorMessage = "Kategori durumunu giriniz.")]
        public ExistentStatus? ExistentStatus { get; set; } // Aktif, Pasif
    }
}
