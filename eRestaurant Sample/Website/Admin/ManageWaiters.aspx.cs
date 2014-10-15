using System;
using EatIn.UI;
using eRestaurant.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eRestaurant.Entities;

public partial class Admin_ManageWaiters : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // TODO: List the waiters in the DDL
        }
    }
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
    protected void Add_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(AddWaiter, "Added Waiter", "The new waiter was successfully added.");
    }

    public void AddWaiter()
    {
        Waiter person = new Waiter()
        {
            FirstName = FirstName.Text,
            LastName = LastName.Text,
            Address = Address.Text,
            Phone = Phone.Text,
            HireDate = DateTime.Parse(HireDate.Text)
        };
        DateTime firedOn;
        if (DateTime.TryParse(ReleaseDate.Text, out firedOn))
            person.ReleaseDate = firedOn;

        var controller = new RestaurantAdminController();
        person.WaiterID = controller.AddWaiter(person);
        WaiterID.Text = person.WaiterID.ToString();
        // TODO: Re-populate drop down list of waiters and set the selected value as well
    }
}