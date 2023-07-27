﻿using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.DAL.Repositories.Concretes.MenuDetailRepository;

namespace Project.BLL.ManagerServices.Concretes
{
    public class MenuDetailManager : BaseManager<MenuDetail>, IMenuDetailManager
    {
        IMenuDetailRepository _mdrep;

        public MenuDetailManager(IRepository<MenuDetail> irep, IMenuDetailRepository mdrep) : base(irep)
        {
            _mdrep = mdrep;
        }

        public async Task<IEnumerable<object>> Get_FoodsofMenu_Async(short Menu_ID)
        {            
            var Foods = await _mdrep.Get_FoodsofMenu_Async(Menu_ID).ToListAsync(); 
            // convert ıqueryable to IEnumerable (using namespace EntityFrameworkCore)

            return Foods;
        }

         public async Task<IEnumerable<CategoriesOfMenu_Repo>> Get_CategoriesofMenu_Async(short Menu_ID)
        {

            var Categories = await _mdrep.Get_CategoriesofMenu_Async(Menu_ID).ToListAsync();
            // convert ıqueryable to IEnumerable (using namespace EntityFrameworkCore)


            return Categories;
        }

        public async Task<bool> IsExist_FoodinMenu_Async(short selected_foodID, short menu_ID)
        {
            bool food_exists = await _mdrep.IsExist_FoodinMenu_Repo_Async(selected_foodID, menu_ID);//.ToListAsync();

            return food_exists;
        }

        public void Insert_FoodonMenu_Async(short selected_foodID, string category_Name, short menu_ID)
        {
            _mdrep.Insert_FoodonMenu_Repo_Async(selected_foodID, category_Name, menu_ID);//.ToListAsync();
        }
    }
}
