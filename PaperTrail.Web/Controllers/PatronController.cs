using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaperTrail.Data.Interfaces;
using PaperTrail.Data.Models;
using PaperTrail.Web.Models.Patron;

namespace PaperTrail.Web.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;
        public PatronController(IPatron patron)
        {
            _patron = patron;
        }

        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();

            var patronModels = allPatrons.Select(x => new PatronDetailModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PatronCardId = x.PatronCard.Id,
                OverdueFees = x.PatronCard.Fees,
                LocalBranchOffice = x.LocalBranchOffice.Name
            }).ToList();

            var model = new PatronIndexModel()
            {
                Patrons = patronModels
            };

            return View(model);
        }


        public IActionResult Detail(int patronId){
            var x = _patron.Get(patronId);

            var model = new PatronDetailModel{
                FirstName = x.FirstName,
                LastName = x.LastName,
                MemberSince = x.PatronCard.Created,
                Phone = x.PhoneNumber,
                PatronCardId = x.PatronCard.Id,
                OverdueFees = x.PatronCard.Fees,
                LocalBranchOffice = x.LocalBranchOffice.Name,
                ItemCheckedOut = _patron
                    .GetPatronCheckouts(patronId)
                    .ToList() ?? new System.Collections.Generic.List<Checkout>(),
                CheckoutHistory = _patron.GetCheckoutHistory(patronId),
                Holds = _patron.GetHolds(patronId)
            };

            return View(model);
        }

    }
}