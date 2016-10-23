using System;
using System.Linq;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Builders
{
    public class BookViewingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookViewingViewModel Build(int propertyId)
        {
            var property = _context.Properties.First(p => p.Id == propertyId);

            return new BookViewingViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                Appointment = DateTime.Today
            };
        }
    }
}