﻿using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.DAL.Repositories.Concretes.FoodRepository;

namespace Project.BLL.ManagerServices.Concretes
{
    public class FoodManager : BaseManager<Food>, IFoodManager
    {
        IFoodRepository _prep;

        // IRepository (_iRep) ve IFoodRepository (_prep) aynı constructor içeriside depency injection'a tabii tutuldular..
        public FoodManager(IRepository<Food> irep, IFoodRepository prep) : base(irep)
        {
            _prep = prep;
        }

        // _iRep ve _prep ayrı constructor içerisinde dependency injection'a tabii tutulamadı..
        //public FoodManager(IFoodRepository prep):base(prep)
        //{
        //    _prep = prep;
        //} 

        public async Task<IEnumerable<Food>> Get_FoodsByCategoryID_Async(int categoryid)
        {
            var Foods = await _prep.Get_FoodsByCategoryID_Async(categoryid).ToListAsync(); // convert ıqueryable to IEnumerable

            return Foods;
        }

        /*
        public async Task<IEnumerable<FoodDto_Repo>> GetActivesFoodNamesByCategoryofFoodIDAsync(int CategoryofFood_id)
        {
            var FoodNames = await _prep.GetActivesFoodNamesByCategoryofFoodIDAsync(CategoryofFood_id).ToListAsync();

            return FoodNames;
        }
        */

        public async Task<Food> GetFoodByIdwithCategoryofFoodValueAsync(int Food_id)
        {
            var Food = await _prep.GetFoodByIdwithCategoryofFoodValueAsync(Food_id).ToListAsync(); // convert ıqueryable to IEnumerable

            return Food[0];
        }
    }
}
