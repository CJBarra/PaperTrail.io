using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PaperTrail.Web.Models.Branch
{
    public class BranchIndexModel
    {
        public IEnumerable<BranchDetailModel> Branches {get;set;}
    }

}