using eRestaurant.DAL;
using eRestaurant.Entities;
using eRestaurant.Entities.DTOs;
using eRestaurant.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace eRestaurant.BLL
{
    [DataObject]
    public class ReportsController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItem> GetReportCategoryMenuItems()
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.MenuCategory.Description, cat.Description
                              select new CategoryMenuItem
                              {
                                  CategoryDescription = cat.MenuCategory.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }  
    }
}
