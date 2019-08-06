using System.ComponentModel.DataAnnotations;

namespace AspDotnetCoreGenericRepository.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string IsEdit { get; set; }  = "false";
    }
}