using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Category
    {
        [Key]
        public int fldslno { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Name")]        
        public string fldName { get; set; }


        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Value should enter from range 1-100")]
        public int fldDisplayOrder { get; set; }
    }
}
