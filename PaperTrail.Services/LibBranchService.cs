using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaperTrail.Data.Interfaces;
using PaperTrail.Data.Models;
using PaperTrail.Persistence;

namespace PaperTrail.Services
{
    public class LibBranchService : IBranchOffice
    {
        private DataContext _context;

        public LibBranchService(DataContext context)
        {
            _context = context;
        }

        public void Add(BranchOffice newBranch)
        {
            _context.Add(newBranch);
            _context.SaveChanges();
        }

        public BranchOffice Get(int branchId)
        {
            return GetAll().FirstOrDefault(b => b.Id == branchId);
        }

        public IEnumerable<BranchOffice> GetAll()
        {
            return _context.BranchOffices
                .Include(b => b.Patrons)
                .Include(b => b.BranchAssets);
        }

        public IEnumerable<BranchAsset> GetAssets(int branchId)
        {
            return _context.BranchOffices
                .Include(x => x.BranchAssets)
                .FirstOrDefault(x => x.Id == branchId)
                .BranchAssets;
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var hours = _context.BranchHours
                .Where(h => h.Branch.Id == branchId);

            return DataHelpers.SimplifyBusinessHours(hours);
        }

        public IEnumerable<Patron> GetPatrons(int branchId)
        {
            return _context.BranchOffices
                .Include(x => x.Patrons)
                .FirstOrDefault(x => x.Id == branchId)
                .Patrons;
        }

        public bool IsBranchOpen(int branchId)
        {
            var currentTimeHour = DateTime.Now.Hour;
            var currentDayOfWeek = (int)DateTime.Now.DayOfWeek + 1;
            var hours = _context.BranchHours.Where(h => h.Branch.Id == branchId);
            var daysHours = hours.FirstOrDefault(h => h.DayOfWeek == currentDayOfWeek);

            var isOpen = currentTimeHour < daysHours.ClosedHours
                 && currentTimeHour > daysHours.OpenHours;
            
            return isOpen;
        }
    }
}