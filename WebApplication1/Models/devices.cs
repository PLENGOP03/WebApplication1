using System.ComponentModel.DataAnnotations; // key
using System.ComponentModel.DataAnnotations.Schema; // Auto increment


namespace WebApplication1.Models
{
    public class devices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Auto increment
        public int id { get; set; }

        public string Title { get; set; }

        public string Processor { get; set; }

        public float Price { get; set; }
       
        public int Menufacturer_id { get; set; }

    }
}
