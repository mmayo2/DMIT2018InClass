<Query Kind="Statements">
  <Connection>
    <ID>9f0fd28d-3e5b-4f7d-b832-88838f4d2edd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var date = Bills.Max(b => b.BillDate).Date;
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0, 30, 0));
date.Add(time).Dump("The test date/time I am using");

var step1 = from data in Tables
			select new 
			{
				Table = data.TableNumber,
				Seating = data.Capacity,
				Bills = from billing in data.Bills
						where  billing.BillDate.Year == date.Year
							&& billing.BillDate.Month == date.Month
							&& billing.BillDate.Day == date.Day
							&& billing.BillDate.TimeOfDay <= time
							&& (!billing.PaidStatus || billing.OrderPaid >= time)
						select billing
			};
step1.Dump("Step 1 of my queries");