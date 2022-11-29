using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ITI.ElectroDev.Presentation.Models
{
    public class CategoryCreateModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "حقل العنوان مطلوب")]
        [MaxLength(200, ErrorMessage = "لا يزيد عن 200")]
        [MinLength(4, ErrorMessage = "Must Be More Than Or Equals 4 Chars.")]
        public string Name { get; set; }
    }
}
