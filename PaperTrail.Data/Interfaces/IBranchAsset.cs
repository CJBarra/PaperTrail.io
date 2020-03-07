using System;
using System.Collections.Generic;
using PaperTrail.Data.Models;

namespace PaperTrail.Data.Interfaces
{
    public interface IBranchAsset
    {
        IEnumerable<BranchAsset> GetAll();
        BranchAsset GetById(int id);

        void Add(BranchAsset newAsset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);

        BranchOffice GetCurrentLocation(int id);

    }
}