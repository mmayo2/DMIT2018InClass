using eRestaurant.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(SetMockedTimeToLastBill);
    }
    protected void SetMockedTimeToLastBill()
    {
        var controller = new AdHocController();
        var info = controller.GetLastBillDateTime();

        SearchDate.Text = info.ToString("yyyy-MM-dd");

        SearchTime.Text = info.ToString("HH:mm:ss");
    }
}