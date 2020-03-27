using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaperTrail.Data.Interfaces;
using PaperTrail.Web.Models.Branch;

namespace PaperTrail.Web.Controllers
{
    public class BranchController : Controller
    {
        private IBranchOffice _branch;

        public BranchController(IBranchOffice branch)
        {
            _branch = branch;
        }
        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(branch => new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                IsOpen = _branch.IsBranchOpen(branch.Id),
                NumberOfAssets = _branch.GetAssets(branch.Id).Count(),
                NumberOfPatrons = _branch.GetPatrons(branch.Id).Count(),

            });

            var model = new BranchIndexModel()
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Description = branch.Description,
                Telephone = branch.Telephone,
                IsOpen = _branch.IsBranchOpen(id),
                OpenDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfAssets = _branch.GetAssets(id).Count(),
                NumberOfPatrons = _branch.GetPatrons(id).Count(),
                TotalAssetValue = _branch.GetAssets(id).Sum(a => a.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branch.GetBranchHours(id),
            };

            return View(model);
        }
    }
}