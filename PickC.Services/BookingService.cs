﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using System.Configuration;
using System.Net;

using RestSharp;
using Operation.Contract;
using PickC.Services.DTO;

namespace PickC.Services
{
    public class BookingService : Service
    {
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public BookingService(string token, string mobileNo): base(token, mobileNo)
        {

        }
        public async Task<List<Booking>> GetBookingsByMobileNoAsync()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "operation/booking/list/{mobileNo}";
            request.AddParameter("mobileNo", p_mobileNo, ParameterType.UrlSegment);

            return ServiceResponse(
                await client.ExecuteTaskAsync<List<Booking>>(request));
        }

        public async Task<SaveBookingDTO> SaveBookingAsync(Booking booking)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "operation/booking/save";
            request.AddParameter("mobileNo", p_mobileNo, ParameterType.UrlSegment);            
            request.AddJsonBody(booking);

            return ServiceResponse(
                await client.ExecuteTaskAsync<SaveBookingDTO>(request));
        }
    }
}