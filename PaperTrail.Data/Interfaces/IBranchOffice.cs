using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Data.Interfaces
{
    public interface IBranchOffice
    {
         IEnumerable<BranchOffice> GetAll();
         IEnumerable<Patron> GetPatrons(int branchId);
         IEnumerable<BranchAsset> GetAssets(int branchId);
         IEnumerable<string> GetBranchHours(int branchId);
         BranchOffice Get(int branchId);
         void Add(BranchOffice newBranch);
         bool IsBranchOpen(int branchId);
    }
}