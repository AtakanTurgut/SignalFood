-- Sipari� Detay Id'si kullanarak Sipari� tutar�n� her sipari�te otomatik ekleme i�lemi
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

-- Sipari� Detay Id'si kullanarak Sipari� tutar�n� her sipari� iptalinde otomatik eksiltme i�lemi
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