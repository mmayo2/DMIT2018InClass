<Query Kind="Statements">
  <Connection>
    <ID>3c9a56fb-4850-4c2d-ad03-b9a3461b4eb7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

/* Example 1: Querying data from eRestaurant */
var result = from row in Tables
			 where row.Capacity > 3
			 select row;

result.Dump(); // The .dump() method is an extension in LinqPad - not a .net method

/* Example 2: Query a simple array of strings */
string[] names = {"Dan", "Don", "Sam", "Dwayne", "Laurel", "Steve"};
names.Dump();

var shortlist = from person in names
				where person.StartsWith("D")
				select person;
shortlist.Dump();

/* Example 3: Find the most recent Bill and it's total */
//Get all the bills that have been placed
var allBills = from item in Bills
			   where item.OrderPlaced.HasValue
			   select new // declaring an "anonymous type" on the fly
				{		  // using an initializer list to set the properties
					BillDate = item.BillDate,
					IsReady = item.OrderReady
				};
allBills.Count().Dump(); // Show the count of items
allBills.Take(5).Dump(); // Show first 5 bills