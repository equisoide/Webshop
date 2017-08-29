using System.Net;
using System.Web.Mvc;
using Webshop.Repository;

namespace Webshop.Web.Controllers
{
    /// <summary>
    /// Controller to manage the Products collection.
    /// </summary>
    public class ProductsController : Controller
    {
        /// <summary>
        /// Gets a reference to the current Repository. There are two types
        /// of repository the user can set: DbStorage and MemoryStorage. By
        /// default, the repositoy is set to DbStorage.
        /// </summary>
        private IProductRepository Repository
        {
            get
            {
                var repository = (IProductRepository)Session["Repository"];

                if (repository == null)
                {
                    repository = new Repository.DbStorage.ProductRepository();
                    Session["Repository"] = repository;
                }

                return repository;
                
            }
            set
            {
                Session["Repository"] = value;
            }
        }

        /// <summary>
        /// Displays the list of all products.
        /// </summary>
        /// <example>GET: Products</example>
        /// <returns>View with the list of all products.</returns>
        public ActionResult Index()
        {
            var products = Repository.GetAll();
            return View(products);
        }

        /// <summary>
        /// Shows the view to create a new product.
        /// </summary>
        /// <example>GET: Products/Create</example>
        /// <returns>View to create a new product.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the passed-in product into the repository.
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <example>POST: Products/Create</example>
        /// <returns>If the product was successfully creeated, redirects the
        /// user to the list of products, otherwhise, an error is prompted.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price")] Model.Product product)
        {
            if (ModelState.IsValid)
            {
                var isCreated = Repository.Create(product);

                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This product name already exists");
                }
            }

            return View(product);
        }

        /// <summary>
        /// Shows the view to edit an existing product.
        /// </summary>
        /// <example>GET: Products/Edit/5</example>
        /// <returns>View to edit an existing product.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = Repository.GetById(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Updates the passed-in product into the repository.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        /// <example>POST: Products/Edit/5</example>
        /// <returns>If the product was successfully updated, redirects the
        /// user to the list of products, otherwhise, an error is prompted.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] Model.Product product)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = Repository.Update(product);

                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "This product name already exists");
                }
            }

            return View(product);
        }

        /// <summary>
        /// Shows the view to delete an existing product.
        /// </summary>
        /// <example>GET: Products/Delete/5</example>
        /// <returns>View to delete an existing product.</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = Repository.GetById(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Deletes the passed-in product into the repository.
        /// </summary>
        /// <param name="product">The product to be deleted.</param>
        /// <example>POST: Products/Delete/5</example>
        /// <returns>If the product was successfully deleted, redirects the
        /// user to the list of products, otherwhise, an error is prompted.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Sets the current repository to the MemoryStorage.
        /// </summary>
        /// <example>GET: Products/UseMemoryStorage</example>
        /// <returns>View with the list of all products.</returns>
        public ActionResult UseMemoryStorage()
        {
            Repository = new Repository.MemoryStorage.ProductRepository();

            return RedirectToAction("Index", "Products");
        }

        /// <summary>
        /// Sets the current repository to the DbStorage.
        /// </summary>
        /// <example>GET: Products/UseDatabaseStorage</example>
        /// <returns>View with the list of all products.</returns>
        public ActionResult UseDatabaseStorage()
        {
            Repository = new Repository.DbStorage.ProductRepository();

            return RedirectToAction("Index", "Products");
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged
        /// resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
