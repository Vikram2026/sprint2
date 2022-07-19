using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class TblFlight
    {
        public int Id { get; set; }
        public int? FlightNo { get; set; }
        public string Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Days { get; set; }
        public string Instrument { get; set; }
        public string BussinessSeats { get; set; }
        public string NonBussinessSeats { get; set; }
        public int? TicketCost { get; set; }
        public int? Rows { get; set; }
        public int? Meal { get; set; }
        public string Logo { get; set; }
        public int? IsActive { get; set; }
    }
}
