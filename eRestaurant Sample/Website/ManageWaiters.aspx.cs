using System;
using eRestaurant.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageWaiters : System.Web.UI.Page
{
    protected void ShowWaiter_Click(object sender, EventArgs e)
    {
        if (WaitersDropDown.SelectedIndex == 0)
            MessageUserControl.ShowInfo("Please select a waiter before clicking Show Waiter.");
        else
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
    }
    public void GetWaiterInfo()
    {
        RestaurantAdminController controller = new RestaurantAdminController();
        var waiter = controller.GetWaiter(int.Parse(WaitersDropDown.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        HireDate.Text = waiter.HireDate.ToShortDateString();
        if (waiter.ReleaseDate.HasValue)
            ReleaseDate.Text = waiter.ReleaseDate.Value.ToShortDateString();
    }
}