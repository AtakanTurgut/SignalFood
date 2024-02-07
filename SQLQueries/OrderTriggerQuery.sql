-- Sipariþ Detay Id'si kullanarak Sipariþ tutarýný her sipariþte otomatik ekleme iþlemi
create Trigger IncreaseOrderTotalPrice
on OrderDetails
after insert
as
declare @OrderId int
declare @OrderPrice decimal
select @OrderId = OrderId from inserted
select @OrderPrice = TotalPrice from inserted
update Orders set TotalPrice = TotalPrice + @OrderPrice 
where OrderId = @OrderId

-- Sipariþ Detay Id'si kullanarak Sipariþ tutarýný her sipariþ iptalinde otomatik eksiltme iþlemi
create Trigger DecreaseOrderTotalPrice
on OrderDetails
after delete
as
declare @OrderId int
declare @OrderPrice decimal
select @OrderId = OrderId from deleted
select @OrderPrice = TotalPrice from deleted
update Orders set TotalPrice = TotalPrice - @OrderPrice 
where OrderId = @OrderId