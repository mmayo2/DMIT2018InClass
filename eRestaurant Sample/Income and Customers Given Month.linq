<Query Kind="Statements">
  <Connection>
    <ID>8adac6b4-5e4c-47bd-bae3-90b443f66636</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Get the following from the Bills table for a given month/year:
// Billdate, ID, # people served, total amount billed
// Then, display the total income for the month and the number of customers served

// 0) Set up info that might me passed in to my BLL
var month = DateTime.Today.Month - 1;
var year = DateTime.Today.Year;

// 1) Get the data for the month/year with a sum of each Bill's BillItems
var billsInMonth = 	from item in Bills
				   	where item.PaidStatus // Only the bills that were/are paid
				   		&& item.BillDate.Month == month
						&& item.BillDate.Year == year
					orderby item.BillDate
				   	select new
				   	{
				    	BillDate = item.BillDate,
						BillID = item.BillID,
						NumberOfCustomers = item.NumberInParty,
						TotalAmount = item.BillItems.Sum(bi => bi.Quantity * bi.SalePrice)
				   	};
// billsInMonth.Dump();

