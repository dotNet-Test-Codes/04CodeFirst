using System.ComponentModel.DataAnnotations;

namespace _04CodeFirst.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
