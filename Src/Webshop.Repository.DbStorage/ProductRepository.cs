using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Webshop.Repository.DbStorage.EntityFramework;

namespace Webshop.Repository.DbStorage
{
    /// <summary>
    /// Implementation of the IProductRepository interface by using Entity Framework.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets all existing products.
        /// </summary>
        /// <returns>List of all existing products.</returns>
        public IEnumerable<Model.Product> GetAll()
        {
            using (var db = new WebshopEntities())
            {
                return db.Products
                    .Select(p => new Model.Product
                    {
                        Id = p.Id,
                        Price = p.Price,
                        Name = p.Name
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Gets a Product by its Id.
        /// </summary>
        /// <param name="id">Product's unique identifier.</param>
        /// <returns>The product mapping the passed-in Id.</returns>
        public Model.Product GetById(int id)
        {
            using (var db = new WebshopEntities())
            {
                return db.Products
                    .Where(p => p.Id == id)
                    .Select(p => new Model.Product
                    {
                        Id = p.Id,
                        Price = p.Price,
                        Name = p.Name
                    })
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        public bool Create(Model.Product product)
        {
            using (var db = new WebshopEntities())
            {
                var isDuplicated = db.Products.Where(
                    p => p.Name == product.Name).Any();

                if (!isDuplicated)
                {
                    db.Products.Add(new Product
                    {
                        Name = product.Name,
                        Price = product.Price
                    });

                    db.SaveChanges();
                }

                return !isDuplicated;
            }
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        /// <returns>If a product with the same name already exists, returns false,
        /// otherwise, returns true to indicate success.</returns>
        public bool Update(Model.Product product)
        {
            using (var db = new WebshopEntities())
            {
                var isDuplicated = db.Products.Where(
                    p => p.Id != product.Id && p.Name == product.Name).Any();

                if (!isDuplicated)
                {
                    var record = db.Products.Where(
                        p => p.Id == product.Id).FirstOrDefault();

                    if (record == null)
                    {
                        throw new Exception(string.Format(
                            "The product with id {0} does not exists", product.Id
                        ));
                    }

                    record.Name = product.Name;
                    record.Price = product.Price;

                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return !isDuplicated;
            }
        }

        /// <summary>
        /// Deletes a product by its Id.
        /// </summary>
        /// <param name="id">Id of the produc to be deleted.</param>
        public void Delete(int id)
        {
            using (var db = new WebshopEntities())
            {
                var product = db.Products.Find(id);

                if (product == null)
                {
                    throw new Exception(string.Format(
                        "The product with id {0} does not exists", id
                    ));
                }

                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}