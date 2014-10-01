using eRestaurant.DAL;
using eRestaurant.Entities;
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
    public class MenuController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Item> ListMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                return context.Items.Include(it => it.MenuCategory).ToList();
            }
        }
    }
}
