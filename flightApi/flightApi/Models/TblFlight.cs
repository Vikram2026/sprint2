using System;
using System.Collections.Generic;

#nullable disable

namespace flightApi.Models
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
        public string BusinessSeats { get; set; }
        public string NonBusinessSeats { get; set; }
        public int? TicketCost { get; set; }
        public int? Rows { get; set; }
        public string Meal { get; set; }
        public string Logo { get; set; }
        public int? IsActive { get; set; }
    }
}
