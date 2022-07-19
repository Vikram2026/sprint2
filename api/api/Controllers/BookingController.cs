using api.Interfaces;
using api.Models;
using api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        FlightBookingContext db;
        public BookingController(FlightBookingContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<TblBookDetail> GetFlights()
        {
            return db.TblBookDetails;
        }
        [HttpPost]
        public string Post([FromBody] TblBookDetail bookdetail)
        {
            db.TblBookDetails.Add(bookdetail);
            db.SaveChanges();
            return "success";
        }
        [HttpDelete]
        public string Delete([FromBody] int Id)
        {
            var bookdetail = db.TblBookDetails.Where(x => x.Id == Id).FirstOrDefault();
            if (bookdetail != null)
            {
                db.TblBookDetails.Remove(bookdetail);
                db.SaveChanges();
                return "Success";
            }

            return "Fail";
        }
        [HttpPut]
        public string Put([FromBody] TblBookDetail tblsample)
        {
            var tblsampleObj = db.TblBookDetails.Where(x => x.Id == tblsample.Id);
            if (tblsampleObj != null)
            {
                db.TblBookDetails.Update(tblsample);
                db.SaveChanges();
                return "Success";
            }

            return "Fail";
        }

    }
}
