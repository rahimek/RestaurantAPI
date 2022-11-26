using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;
using RestaurantAPI3.Entites;
using RestaurantAPI3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI3.Authorization
{
    public class MinimumTwoRestaurantsRequirementHandler : AuthorizationHandler<MinimumTwoRestaurantsRequirement>
    {
        private readonly RestaurantDBContext _dbContext;

        public MinimumTwoRestaurantsRequirementHandler(RestaurantDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumTwoRestaurantsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdRestaurantsCount = _dbContext
                .Restaurants
                .Count(r => r.CreatedById == userId);

            if(createdRestaurantsCount >= requirement.MinimumRestaurants)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
