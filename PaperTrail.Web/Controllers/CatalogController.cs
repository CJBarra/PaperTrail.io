using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaperTrail.Data.Interfaces;
using PaperTrail.Web.Models.Catalog;
using PaperTrail.Web.Models.CheckoutModels;

namespace PaperTrail.Web.Controllers
{
    public class CatalogController : Controller
    {
        private IBranchAsset _context;
        private ICheckout _checkout;

        public CatalogController(IBranchAsset context, ICheckout checkout)
        {
            _context = context;
            _checkout = checkout;
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

        public IActionResult Detail(int id)
        {
            var context = _context.GetById(id);

            var currentReservations = _checkout.GetCurrentReservations(id)
                .Select(res => new CatalogIndexReservation
                {
                    ReservationPlaced = _checkout.GetCurrentReservationPlaced(res.Id),
                    PatronName = _checkout.GetCurrentReservationPatronName(res.Id)
                });

            var model = new CatalogIndexDetail
            {
                IndexId = id,
                Title = context.Title,
                Year = context.Year,
                Cost = context.Cost,
                Status = context.Status.Name,
                ImageUrl = context.ImageUrl,
                AuthorOrDirector = _context.GetAuthorOrDirector(id),
                CurrentLocation = _context.GetCurrentLocation(id).Name,
                DeweyCallNumber = _context.GetDeweyIndex(id),
                ISBN = _context.GetIsbn(id),
                LatestCheckout = _checkout.GetLatestCheckout(id),
                PatronName = _checkout.GetCurrentCheckoutPatron(id),
                CurrentReservations = currentReservations,
                CheckoutHistory = _checkout.GetCheckoutHistory(id)
            };

            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var item = _context.GetById(id);

            var model = new CheckoutModel
            {
                ItemId = id,
                ImageUrl = item.ImageUrl,
                Title = item.Title,
                PatronCardId = "",
                IsCheckedOut = _checkout.IsCheckedOut(id)
            };
            return View(model);
        }


    }
}