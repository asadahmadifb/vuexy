using Microsoft.AspNetCore.SignalR;

namespace AspnetCoreMvcStarter.Services
{
  public class OrderHub : Hub
  {
    public async Task SendOrderUpdate(string message)
    {
      await Clients.All.SendAsync("ReceiveOrderUpdate", message);
    }
  }
}
