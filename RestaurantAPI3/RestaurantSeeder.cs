using RestaurantAPI3.Entites;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI3
{
    public class RestaurantSeeder
    {
        private RestaurantDBContext _dbContext;

        public RestaurantSeeder(RestaurantDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description = "zwykłe śmieciowe jedzenie",
                    ContactEmail = "mcdonalds@wp.pl",
                    ContactNumber = "112",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Frytki",
                            Price = 5
                        },
                        new Dish()
                        {
                            Name = "Hamburger",
                            Price= 7.5M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Białystok",
                        Street = "Lawendowa",
                        PostalCode = "15-642"
                    }
                },
                new Restaurant()
                {
                    Name = "Pizzeria u Romana",
                    Category = "Pizzeria",
                    Description = "domowa pizza a nie włoska",
                    ContactEmail = "pizzauromana@wp.pl",
                    ContactNumber = "997",
                    HasDelivery = false,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Margarita",
                            Price = 25
                        },
                        new Dish()
                        {
                            Name = "Pepperoni",
                            Price= 30
                        }
                    },
                    Address = new Address()
                    {
                        City = "Białystok",
                        Street = "Lipowa",
                        PostalCode = "15-001"
                    }
                }
            };
            return restaurants;
        }
    }
}
