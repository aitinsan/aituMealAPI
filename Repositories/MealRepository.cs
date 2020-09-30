using aitumeal.Data;
using aitumeal.Models;
using aitumeal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aitumeal.Repositories
{
    public class MealRepository:IMealRepository
    {
        private readonly DataContext _dbContext;

        public MealRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Meal> GetMeals()
        {
            return _dbContext.Meals.Include(x => x.Category).OrderBy(x => x.Price);
        }

        public bool AddMeal(Meal m)
        {
            _dbContext.Add(m);
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<Meal> GetMealByCategory(Guid categoryId)
        {
            return _dbContext.Meals.Where(x=>x.MealCategoryId==categoryId);
        }
    }
}
