using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class TblBookDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Meal { get; set; }
        public int? SeatNo { get; set; }
    }
}
