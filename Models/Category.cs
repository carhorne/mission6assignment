using System.ComponentModel.DataAnnotations;

namespace mission6assignment.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
