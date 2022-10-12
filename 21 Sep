use Northwind
Select count(ContactName) from Customers;

Select count(ContactName) as count1 from Customers where ContactName like 'b%';

Select count(ContactName) as count2 from Customers where ContactName like '%s%';

Select City,count(ContactName) as count1 from Customers group by City;

Select top 3 City,count(ContactName) as count1 from Customers group by City order by count1 desc;

Select * from Customers where CustomerID in (Select top 1 CustomerId from Orders group by CustomerID order by count(OrderID) desc);

Select * from Customers where CustomerID in (Select top 1 CustomerId from Orders where year(ShippedDate)=1997  group by CustomerID order by count(OrderID) desc);

Select top 3 ShipCountry,count(OrderId) as count1 from Orders group by ShipCountry order by count1 desc; 

Select top 1 ShipName,count(OrderId) as count1 from Orders group by ShipName order by count1 desc; 

Select i.EmployeeID,i.FirstName,i.LastName,i.Reportsto,j.FirstName,j.LastName from Employees i inner join Employees j on i.ReportsTo=j.EmployeeID

Select LastName from Employees where DATENAME(Month,BirthDate)='November'

Select LastName,FirstName,Region from Employees  order by 3,1

Select * from Products where UnitPrice*UnitsOnOrder in (Select max(UnitPrice*UnitsOnOrder) from Products)

Select * from Products where UnitPrice*UnitsOnOrder in (Select min(UnitPrice*UnitsOnOrder) from Products where UnitsOnOrder<>0)

Select top 1 DATENAME(Month,OrderDate),count(Month(OrderDate)) as count1 from Orders group by DATENAME(Month,OrderDate) order by count1 desc

Select * from Employees where EmployeeID in (Select top 1 EmployeeID from Orders group by EmployeeID order by count(OrderId) desc);

Select ProductID,ProductName,SupplierID,CategoryID from Products order by CategoryID desc

Select region,count(EmployeeID) from employees group by Region

Select ShipRegion,sum(freight) as dollars from Orders group by ShipRegion

Select avg(freight) as average from orders

Select * from orders where freight > any(Select avg(freight) as average from orders)

Select k.CustomerID,k.ContactName,sum(l.freight) as totalsale from customers k inner join orders l on k.CustomerID=l.CustomerID group by k.CustomerID,k.ContactName order by totalsale desc

Select ProductName,ReorderLevel from Products where ReorderLevel<>0 and Discontinued=0 order by ReorderLevel desc

Select CustomerID,ContactName from Customers where CustomerID in (Select distinct(CustomerID) from Orders where Year(ShippedDate)=1996)

Select CustomerID,ContactName from Customers where CustomerID in (Select distinct(CustomerID) from Orders where Year(ShippedDate)<>1996)
