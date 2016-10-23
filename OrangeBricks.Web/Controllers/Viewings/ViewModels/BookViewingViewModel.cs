using System;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class BookViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public DateTime Appointment { get; set; }
        public int PropertyId { get; set; }
    }
}