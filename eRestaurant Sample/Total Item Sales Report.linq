<Query Kind="Statements">
  <Connection>
    <ID>8adac6b4-5e4c-47bd-bae3-90b443f66636</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Total Item Sales Report
var results = from info in BillItems
			  orderby info.Item.MenuCategory.Description, info.Item.Description
			  select new
			  {
			  		CategoryDescription = info.Item.MenuCategory.Description,
					ItemDescription = info.Item.Description,
					Quantity = info.Quantity,
					Price = info.SalePrice,
					Cost = info.UnitCost
			  };
results.Count().Dump();
results.Dump();