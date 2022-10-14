using System.ComponentModel.DataAnnotations;

namespace dapper_db.DTOs
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public bool? Status { get; set; }
    }
}
