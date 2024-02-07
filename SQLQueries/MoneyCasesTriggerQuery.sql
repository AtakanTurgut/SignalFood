-- Kasadaki Toplam Paray� otomatik artt�rma i�lemi
create Trigger SumMoneyCases
on Orders
after update
as
declare @Description nvarchar(max)
declare @TotalPrice decimal(18, 2)
select @Description = Description from inserted
select @TotalPrice = TotalPrice from inserted
if (@Description = 'Kapal�')
begin
 update MoneyCases set TotalAmount = TotalAmount + @TotalPrice
end