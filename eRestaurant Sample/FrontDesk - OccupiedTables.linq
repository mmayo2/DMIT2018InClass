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
//							&& (!billing.PaidStatus || billing.OrderPaid >= time)
						select billing,
				Reservations = from booking in data.ReservationTables
							   from billing in booking.Reservation.Bills
							   where  billing.BillDate.Year == date.Year
							&& billing.BillDate.Month == date.Month
							&& billing.BillDate.Day == date.Day
							&& billing.BillDate.TimeOfDay <= time
//							&& (!billing.PaidStatus || billing.OrderPaid >= time)
						select billing
			};
step1.Dump("Step 1 of my queries");

var step2 = from data in step1.ToList()
			select new 
			{
				Table = data.Table,
				Seating = data.Seating,
				CommonBilling = from info in data.Bills.Union(data.Reservations)
								select info
			};
step2.Dump("Step 2 of my queries - unioning the result");

var step3 = from data in step2
			select new
			{
				Table = data.Table,
				Seating = data.Seating,
				Taken = data.CommonBilling.Count() > 0,
				CommonBilling = data.CommonBilling.FirstOrDefault()
			};
step3.Dump("Step 3 of my queries - pull out the first (only) item from the common billing list");

var step4 = from data in step3
		select new
		{
			Table = data.Table,
			Seating = data.Seating,
			Taken = data.Taken,
			BillID = data.Taken ?
					 data.CommonBilling.BillID
				   : (int?) null
		};
step4.Dump("Step 4 of my queries - my final results that I need for the form");