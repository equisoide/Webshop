using System.ComponentModel.DataAnnotations;

namespace Webshop.Model
{
    /// <summary>
    /// Entity model for the Products catalog.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The product's unique identifier (auto-increment value).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The product's name. This name is unique into the Products collection.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The product's price.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Negative numbers are not allowed")]
        public decimal Price { get; set; }
    }
}