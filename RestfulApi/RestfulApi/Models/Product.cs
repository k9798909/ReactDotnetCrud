using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Nullable<int> Proid { get; set; }
        public string? Proname { get; set; }
        public int Proprice { get; set; }
        public int Proqty { get; set; }
    }
}
