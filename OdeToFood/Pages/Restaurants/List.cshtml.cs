using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config; // using this we can get the appsettings message
        private readonly IRestaurantData _restaurantData;

        public string Msg { get; set; }
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this._config = config;
            this._restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
            Msg = "Hello World";
            Message = _config["Message"];
        }
    }
}
