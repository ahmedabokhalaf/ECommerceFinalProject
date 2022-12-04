using ITI.ElectroDev.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI.ElectroDev.Presentation
{
    public class ProductCreateModel
    {

        

        public int id { set; get;  }

        [StringLength(250)]
        [Required(ErrorMessage = "هذا الحقل مطلوب *")]
        [MaxLength(255, ErrorMessage = "لا يزيد عن 255 حرف *")]
        [MinLength(6, ErrorMessage = "لا يقل عن 4 حروف *")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب *")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 255 حرف *")]
        [ MinLength(10, ErrorMessage = "لا يقل عن 4 حروف *")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب *")]
        [Display(Name="Price")]

        public int Price { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب *")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required, Display(Name = "Please Upload Some Images")]
        public List<IFormFile> Images { get; set; }

        [Display(Name = "Brand")]
        [Required]
        public int BrandId { get; set; }


    }

}

