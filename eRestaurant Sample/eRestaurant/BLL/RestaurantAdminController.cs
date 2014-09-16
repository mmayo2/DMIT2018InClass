using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    public class RestaurantAdminController
    {
        #region Manage Waiters
        #region Command
        public int AddWaiter(Waiter item)
        {
            throw new NotImplementedException();
        }

        public void UpdateWaiter(Waiter item)
        {         
        }

        public void DeleteWaiter(Waiter item)
        {
        }
        #endregion
        #region Query 
        public List<Waiter> ListAllWaiters()
        {
            throw new NotImplementedException();
        }
        public Waiter GetWaiter(int waiterID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Manage Tables
        #region Command
        public int AddTable(Table item)
        {
            throw new NotImplementedException();
        }

        public void UpdateTable(Table item)
        {
        }

        public void DeleteTable(Table item)
        {
        }
        #endregion
        #region Query
        public List<Table> ListAllTables()
        {
            throw new NotImplementedException();
        }
        public Table GetTable(int tableID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Manage Items
        #region Command
        public int AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
        }

        public void DeleteItem(Item item)
        {
        }
        #endregion
        #region Query
        public List<Item> ListAllItems()
        {
            throw new NotImplementedException();
        }
        public Item GetItem(int itemID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Manage Special Events
        #region Command
        public int AddSpecialEvent(SpecialEvent item)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecialEvent(SpecialEvent item)
        {
        }

        public void DeleteSpecialEvent(SpecialEvent item)
        {
        }
        #endregion
        #region Query
        public List<SpecialEvent> ListAllEvents()
        {
            throw new NotImplementedException();
        }
        public SpecialEvent GetEvent(int specialeventID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
