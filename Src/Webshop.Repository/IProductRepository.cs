using System.Collections.Generic;
using Webshop.Model;

namespace Webshop.Repository
{
    /// <summary>
    /// Interface to manage the Products collection.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all existing products.
        /// </summary>
        /// <returns>List of all existing products.</returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Gets a Product by its Id.
        /// </summary>
        /// <param name="id">Product's unique identifier.</param>
        /// <returns>The product mapping the passed-in Id.</returns>
        Product GetById(int id);

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        bool Create(Product product);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        bool Update(Product product);

        /// <summary>
        /// Deletes a product by its Id.
        /// </summary>
        /// <param name="id">Id of the produc to be deleted.</param>
        void Delete(int id);
    }
}