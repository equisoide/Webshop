using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Model;

namespace Webshop.Repository.MemoryStorage
{
    /// <summary>
    /// Implementation of the IProductRepository interface by using Memory Storage.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets all existing products.
        /// </summary>
        /// <returns>List of all existing products.</returns>
        public IEnumerable<Product> GetAll()
        {
            var products = (List<Product>)HttpContext.Current.Session["Products"];

            if (products == null)
            {
                products = new List<Product>();
                HttpContext.Current.Session["Products"] = products;
            }

            return products;
        }

        /// <summary>
        /// Gets a Product by its Id.
        /// </summary>
        /// <param name="id">Product's unique identifier.</param>
        /// <returns>The product mapping the passed-in Id.</returns>
        public Product GetById(int id)
        {
            var products = (List<Product>)GetAll();

            var product = products
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return product;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        public bool Create(Product product)
        {
            var products = (List<Product>)GetAll();

            var isDuplicated = products.Where(
                    p => p.Name == product.Name).Any();

            if (!isDuplicated)
            {
                products.Add(new Product
                {
                    Id = products.Any() ? products.Max(p => p.Id) + 1 : 1,
                    Name = product.Name,
                    Price = product.Price
                });
            }

            return !isDuplicated;
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        public bool Update(Product product)
        {
            var products = (List<Product>)GetAll();

            var isDuplicated = products.Where(
                    p => p.Id != product.Id && p.Name == product.Name).Any();

            if (!isDuplicated)
            {
                var record = GetById(product.Id);

                if (record == null)
                {
                    throw new Exception(string.Format(
                        "The product with id {0} does not exists", product.Id
                    ));
                }

                record.Name = product.Name;
                record.Price = product.Price;
            }

            return !isDuplicated;
        }

        /// <summary>
        /// Deletes a product by its Id.
        /// </summary>
        /// <param name="id">Id of the produc to be deleted.</param>
        public void Delete(int id)
        {
            var products = (List<Product>)GetAll();
            var product = GetById(id);

            if (product == null)
            {
                throw new Exception(string.Format(
                    "The product with id {0} does not exists", id
                ));
            }

            products.Remove(product);
        }
    }
}