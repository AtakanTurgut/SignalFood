using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalFoodApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService,
                            IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService,
							INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        internal string Currency = "₺";

		public async Task SendCategoryCount()
        {
            var count = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);
        }

        public async Task SendProductCount()
        {
            var count = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", count);
		}

        public async Task ActivePassiveCategoryCount()
        {
			var count1 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", count1);

			var count2 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", count2);
		}
		public async Task SendStatistics()
        {
			var count1 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", count1);

			var count2 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", count2);

			var count3 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", count3.ToString("0.00") + Currency);

			var count4 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", count4.ToString("0.00") + Currency);

			var count5 = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", count5);

			var count6 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", count6);

			var count7 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", count7);

			var count8 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", count8);

			var count9 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", count9.ToString("0.00") + Currency);

			var count10 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", count10.ToString("0.00") + Currency);

			///

			var count12 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", count12);
		}

		public async Task SendProgress()
		{
			var count1 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", count1.ToString("0.00") + Currency);

			var count2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", count2);

			var count3 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", count3);
		}

		public async Task GetBookingList()
		{
			var count = _bookingService.TGetAll();
			await Clients.All.SendAsync("ReceiveBookingList", count);
        }

		public async Task SendNotification()
		{
            var count = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", count);

            var notificationListByStatusFalse = _notificationService.TGetAllNotificationByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByStatusFalse", notificationListByStatusFalse);
        }

		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

    }
}
