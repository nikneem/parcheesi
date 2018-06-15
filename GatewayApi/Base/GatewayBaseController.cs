using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexMaster.Parcheesi.GatewayApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayBaseController : ControllerBase
    {

        protected virtual HttpClient GetSecureClient(string service)
        {
            var client = new HttpClient {BaseAddress = new Uri($"http://{service}")};
            foreach (var header in Request.Headers)
            {
                if (header.Key.ToLower() == "authorization" || header.Key.ToLower() == "content-type") 
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value.FirstOrDefault());
                }
            }
            return client;
        }

    }
}