using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using FunctionAppNetSix.Models;
using FunctionAppNetSix.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionAppNetSix
{
    public class ShoppingCartApi
    {
        private readonly ILogger _logger;

        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartApi(ILoggerFactory loggerFactory, IShoppingCartService cartService)
        {
            _logger = loggerFactory.CreateLogger<ShoppingCartApi>();
            _shoppingCartService = cartService;
        }

        [Function("GetShoppingCartItems")]
        public HttpResponseData GetShoppingCartItems([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="shoppingcartitems")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a GET Itemsrequest.");

            var okResponse = req.CreateResponse(HttpStatusCode.OK);
            okResponse.WriteAsJsonAsync(_shoppingCartService.GetAll());

            return okResponse;
        }

        [Function("GetShoppingCartItem")]
        public HttpResponseData GetShoppingCartItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "shoppingcartitems/{id}")] HttpRequestData req, int id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a GET Item request.");

            var okResponse = req.CreateResponse(HttpStatusCode.OK);
            okResponse.WriteAsJsonAsync(_shoppingCartService.getById(id));

            return okResponse;
        }

        [Function("PostShoppingCartItem")]
        public HttpResponseData PostShoppingCartItem([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "postshoppingcartitem")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a POST request.");

            string reqData = new StreamReader(req.Body).ReadToEnd();

            ShoppingCartItem cartItem = JsonConvert.DeserializeObject<ShoppingCartItem>(reqData);
            
            var okResponse = req.CreateResponse(HttpStatusCode.OK);
            okResponse.WriteAsJsonAsync(cartItem);

            return okResponse;
        }
    }
}
