using RestaurantAPI3.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantAPI3.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        PagedResult<RestaurantDto> GetAll(RestaurantQuery query);
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Modify(int id, ModifyRestaurantDto dto);
    }
}