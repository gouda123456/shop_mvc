using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop_mvc.Models
{
    public class item
    {
        [Key]
        public int Id { get; set; }
        [Required,Length(2,50,ErrorMessage ="wrong name for item")]
        public string Name { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int contity { get; set; } = 1;

        public byte[]? img { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }

        public string db_img
        {
            get
            {
                if(img != null)
                {
                    string base64 = Convert.ToBase64String(img,0,img.Length);
                    return "data:image/*;base64,";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        catagory c { get; set; }

    }
}
