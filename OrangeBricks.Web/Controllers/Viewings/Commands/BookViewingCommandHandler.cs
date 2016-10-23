using System;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {
            var viewing = new Viewing
            {
                Appointment = command.Appointment,
                PropertyId = command.PropertyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BuyerUserId = command.BuyerUserId
            };

            _context.Viewings.Add(viewing);
            
            _context.SaveChanges();
        }
    }
}