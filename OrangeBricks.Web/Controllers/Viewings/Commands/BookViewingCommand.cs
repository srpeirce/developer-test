using System;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class BookViewingCommand
    {
        public int PropertyId { get; set; }

        public DateTime Appointment { get; set; }

        public string BuyerUserId { get; set; }
    }
}