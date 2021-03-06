﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Operation.BusinessFactory;

using PickC.Services.DTO;
using PickCApi.Core;

namespace PickCApi.Areas.Operation.Controllers
{
    [RoutePrefix("api/operation/search")]
    [ApiAuthFilter]
    public class SearchController : ApiBase
    {
        [HttpPost]
        [Route("currentbooking")]
        public IHttpActionResult CurrentBookingSearch(BookingDTO bookingDTO)
        {
            try
            {
                var bookingResult = new SearchBO().SearchBookings(
                    bookingDTO.BookingNo, bookingDTO.BookingDate,
                    bookingDTO.VehicleGroup, bookingDTO.VehicleType,
                    bookingDTO.CustomerName, bookingDTO.VehicleNumber);

                return Ok(bookingResult);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("bookingbydate")]
        public IHttpActionResult BookingByDate(BookingSearchDTO booking)
        {
            try
            {
                var bookingresult = new SearchBO().BookingByDate(booking.dates.fromDate,booking.dates.toDate);
                return Ok(bookingresult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
