using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalFoodApi.Hubs
{
    public class SignalRHub : Hub
    {
        SignalContext context = new SignalContext();

        public async Task SendCategoryCount()
        {
            var count = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);
        }
    }
}
