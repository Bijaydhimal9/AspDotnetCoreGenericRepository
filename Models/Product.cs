using System;

namespace AspDotnetCoreGenericRepository.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime CreateAt { get; set; }  = DateTime.Now;

        public ApplicationUser ApplicationUser { get; set;}

        public string ApplicationUserId { get; set; }
    }
}