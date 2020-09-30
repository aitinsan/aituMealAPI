using aitumeal.Data;
using aitumeal.Models;
using aitumeal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aitumeal.Repositories
{
    public class MealCategoryRepository:IMealCategoryRepository
    {
        private readonly DataContext _dbContext;
        public MealCategoryRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MealCategory> GetMealCategories()
        {
            return _dbContext.MealCategories.OrderBy(x => x.Category);
        }

        public bool AddMealCategory(MealCategory mo)
        {
            _dbContext.Add(mo);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
