using System.Collections.Generic;
using OrangeBricks.Web.Controllers.Property.ViewModels;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class MyOffersViewModel
    {
        public IEnumerable<MyOfferViewModel> AcceptedOffers { get; set; }
    }

    public class MyOfferViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public int Amount { get; set; }
    }
}