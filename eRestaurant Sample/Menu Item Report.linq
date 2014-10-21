<Query Kind="Expression">
  <Connection>
    <ID>9f0fd28d-3e5b-4f7d-b832-88838f4d2edd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from cat in Items
orderby cat.MenuCategory.Description, cat.Description
select new
{
	CategoryDescription = cat.MenuCategory.Description,
	ItemDescription = cat.Description,
	Price = cat.CurrentPrice,
	Calories = cat.Calories,
	COmment = cat.Comment
}