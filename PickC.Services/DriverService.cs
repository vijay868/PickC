﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using Master.Contract;
using PickC.Services.DTO;


namespace PickC.Services
{
    public class DriverService : Service
    {
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public DriverService(string token, string mobileNo) : base(token, mobileNo)
        {

        }
        public async Task<List<Driver>> DriversListAsync()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "master/driver/list";

            return await Task.Run(() =>
            {
                return ServiceResponse<List<Driver>>(client.Execute<List<Driver>>(request));
            });
        }

        public async Task<string> SaveDriverAsync(Driver driver)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "master/driver/save";
            request.AddJsonBody(driver);

            return await Task.Run(() =>
            {
                return ServiceResponse(client.Execute(request));
            });
        }

        public async Task<Driver> DriverInfoAsync(string driverID)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "master/driver/{driverID}";
            request.AddParameter("driverID", driverID, ParameterType.UrlSegment);

            return await Task.Run(() =>
            {
                return ServiceResponse<Driver>(client.Execute<Driver>(request));
            });
        }

        public async Task<string> DeleteDriverAsync(string driverID)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.DELETE;
            request.Resource = "master/driver/{driverID}";
            request.AddParameter("driverID", driverID, ParameterType.UrlSegment);

            return await Task.Run(() =>
            {
                return ServiceResponse(client.Execute(request));
            });
        }

        public async Task<DriverLookupDTO> LookUpDataAsync()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "master/driver/lookupdata";

            return await Task.Run(() =>
            {
                return ServiceResponse<DriverLookupDTO>(client.Execute<DriverLookupDTO>(request));
            });

        }


        //public async Task<DriverDTO> GetDriversList()
        //{
        //    IRestClient client = new RestClient(ApiBaseUrl);
        //    var request = p_request;
        //    request.Method = Method.GET;
        //    request.Resource = "master/driver/getdriverlist";

        //    return await Task.Run(() => {
        //        return ServiceResponse.
        //    }
        //    );
        //}
    }
}