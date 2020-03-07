using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaperTrail.Data.Interfaces;
using PaperTrail.Web.Models.Catalog;

namespace PaperTrail.Web.Controllers
{
    public class CatalogController : Controller
    {
        private IBranchAsset _context;

        public CatalogController(IBranchAsset context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contextModels = _context.GetAll();
            var listingResult = contextModels.Select(result => new CatalogIndexListings
            {
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                AuthorOrDirector = _context.GetAuthorOrDirector(result.Id),
                DeweyCallNumber = _context.GetDeweyIndex(result.Id),
                Title = result.Title,
                Type = _context.GetType(result.Id)
            });

            var model = new CatalogIndex()
            {
                Indexes = listingResult
            };

            return View(model);
        }
    }
}