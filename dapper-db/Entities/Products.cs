using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dapper_db.Entities
{
    public partial class Products
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        public bool? Status { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; }
    }
}
