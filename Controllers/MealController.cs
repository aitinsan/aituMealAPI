﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aitumeal.DTOs;
using aitumeal.Models;
using aitumeal.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aitumeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository _mealRepository;

        public MealController(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        [HttpGet]
        public IQueryable<Meal> GetMeals()
        {
            return _mealRepository.GetMeals();
        }

        [HttpPost]
        public ActionResult AddMeal(MealDTO md)
        {
            Meal m = new Meal()
            {
                Id = Guid.NewGuid(),
                Name = md.Name,
                Amount = md.Amount,
                Price = md.Price,
                MealCategoryId = md.MealCategoryId,
            };

            if (_mealRepository.AddMeal(m))
            {
                return Ok("A new meal was added successfully!");
            }
            return BadRequest("Oops, something went wrong with adding new meal!");
        }

       [HttpGet("findby/{categoryid}")]
       public IQueryable<Meal> GetMealByCategory(Guid categoryId)
        {
            return _mealRepository.GetMealByCategory(categoryId);
        }
    }
}
