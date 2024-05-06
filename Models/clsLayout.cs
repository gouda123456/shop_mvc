using System.ComponentModel.DataAnnotations;

namespace shop_mvc.Models
{
    public class clsLayout
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
