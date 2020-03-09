namespace PaperTrail.Web.Models.CheckoutModels
{
    public class CheckoutModel
    {
        public string PatronCardId { get; set; }
        public string Title { get; set; }
        public int ItemId { get; set; }
        public string ImageUrl { get; set; }
        public int ReservationCount { get; set; }
        public bool IsCheckedOut { get; set; }

    }
}