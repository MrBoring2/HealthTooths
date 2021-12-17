using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTeeth.Services
{
    public class APIService
    {
        public readonly string apiConnection = "http://localhost:5556/";
        public APIService()
        {

        }
        public async Task<IRestResponse> SendGetRequest(IRestRequest request)
        {
            return await UserService.Instance.restClient.ExecuteAsync(request);
        }
    }
}
