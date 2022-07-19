using flightApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flightApi.Controllers
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
        public IEnumerable<TblBookdetail> GetFlights()
        {
            return db.TblBookdetails;
        }
        [HttpPost]
        public string Post([FromBody] TblBookdetail bookdetail)
        {
            db.TblBookdetails.Add(bookdetail);
            db.SaveChanges();
            return "success";
        }
        [HttpDelete]
        public string Delete([FromBody] int Id)
        {
            var bookdetail = db.TblBookdetails.Where(x => x.Id == Id).FirstOrDefault();
            if (bookdetail != null)
            {
                db.TblBookdetails.Remove(bookdetail);
                db.SaveChanges();
                return "Success";
            }

            return "Fail";
        }
        [HttpPut]
        public string Put([FromBody] TblBookdetail tblsample)
        {
            var tblsampleObj = db.TblBookdetails.Where(x => x.Id == tblsample.Id);
            if (tblsampleObj != null)
            {
                db.TblBookdetails.Update(tblsample);
                db.SaveChanges();
                return "Success";
            }

            return "Fail";
        }

    }
}