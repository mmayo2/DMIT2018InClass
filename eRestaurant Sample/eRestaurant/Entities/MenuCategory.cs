using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class MenuCategory
    {
        public int MenuCategoryID { get; set; }
        public string Description { get; set; }

        #region Navigation Properties
        public virtual ICollection<Item> Items { get; set; }
        #endregion
    }
}
