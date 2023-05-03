using System.ComponentModel.DataAnnotations; // key
using System.ComponentModel.DataAnnotations.Schema; // Auto increment



namespace WebApplication1.Models
{
    public class menufacturers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto increment
        public int id { get; set; }

        public string Title { get; set; }
    }
}
