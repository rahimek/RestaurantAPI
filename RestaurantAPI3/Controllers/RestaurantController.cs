﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI3.Entites;
using RestaurantAPI3.Models;
using RestaurantAPI3.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;

namespace RestaurantAPI3.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var id = _restaurantService.Create(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        [Authorize(Policy = "CreatedAtLeast2Restaurants")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery]RestaurantQuery query)
        {
            var restaurantsDtos = _restaurantService.GetAll(query);
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute]int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);

        }

        [HttpPut("{id}")]
        public ActionResult Modify([FromRoute]int id, [FromBody] ModifyRestaurantDto dto)
        {
            _restaurantService.Modify(id,dto);
            return Ok();
        }

    }
}
