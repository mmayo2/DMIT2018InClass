<Query Kind="Expression">
  <Connection>
    <ID>8adac6b4-5e4c-47bd-bae3-90b443f66636</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from info in Bills
where info.BillDate.Year == 2014
	&& info.BillDate.Month == 9
	&& info.BillDate.Day == 15
group info by info.BillDate.Hour into infoGroup
select new 
{
	Hour = infoGroup.Key,
	CustomerBillCount = infoGroup.Count(),
	CustomersCount = infoGroup.Sum(x => x.NumberInParty)
}