using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaperTrail.Data.Interfaces;
using PaperTrail.Data.Models;
using PaperTrail.Persistence;

namespace PaperTrail.Services
{
    public class BranchAssetService : IBranchAsset
    {
        private DataContext _context;

        public BranchAssetService(DataContext context)
        {
            _context = context;
        }
        public void Add(BranchAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<BranchAsset> GetAll()
        {
            return _context.BranchAssets
                .Include(a => a.Status)
                .Include(a => a.Location);
        }

        public BranchAsset GetById(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);
        }

        public BranchOffice GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetType(int id)
        {
            var book = _context.BranchAssets.OfType<Book>().Where(x => x.Id == id);
            return book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.BranchAssets.OfType<Book>()
                .Where(a => a.Id == id).Any();
            var isVideo = _context.BranchAssets.OfType<Video>()
                .Where(a => a.Id == id).Any();

            return isBook ? _context.Books.FirstOrDefault(x => x.Id == id).Author
                : _context.Videos.FirstOrDefault(x => x.Id == id).Director
                ?? "Unknown context type returned.";
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(x => x.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(x => x.Id == id)
                    .DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(x => x.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(x => x.Id == id).ISBN.ToString();
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.BranchAssets
                .FirstOrDefault(a => a.Id == id).Title;
        }

    }
}
