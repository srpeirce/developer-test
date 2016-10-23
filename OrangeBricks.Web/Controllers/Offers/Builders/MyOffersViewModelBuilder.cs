using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            var acceptedOffers = _context.Offers.Where(o => o.BuyerUserId == buyerId && o.Status == OfferStatus.Accepted)
                        .Join(_context.Properties, o => o.PropertyId, p => p.Id,
                            (offer, property) =>
                                new MyOfferViewModel
                                {
                                    Amount = offer.Amount,
                                    PropertyType = property.PropertyType,
                                    StreetName = property.StreetName
                                }).ToList();

            return new MyOffersViewModel()
            {
                AcceptedOffers = acceptedOffers
            };
        }
    }
}