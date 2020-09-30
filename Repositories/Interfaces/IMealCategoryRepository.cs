using aitumeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aitumeal.Repositories.Interfaces
{
    public interface IMealCategoryRepository
    {
        public IQueryable<MealCategory> GetMealCategories();
        public bool AddMealCategory(MealCategory mc);
    }
}
