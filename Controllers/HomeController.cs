using Products;
using System.Linq;
using System.Web.Mvc;

public class HomeController : Controller
{
    private ProductEntities  db = new ProductEntities();

    public ActionResult Index(string searchString)
    {
        var products = db.Products.Include("Category").AsQueryable();

        // If search string is not empty, filter
        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p =>
                p.ProductName.Contains(searchString) ||
                p.Category.CategoryName.Contains(searchString));
        }

        // Execute query
        return View(products.ToList());
    }
}
