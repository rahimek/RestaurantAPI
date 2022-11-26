using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI3.Authorization
{
    public class MinimumTwoRestaurantsRequirement : IAuthorizationRequirement
    {
        public int MinimumRestaurants { get; }

        public MinimumTwoRestaurantsRequirement(int minimumRestaurants)
        {
            MinimumRestaurants = minimumRestaurants;
        }
    }
}
