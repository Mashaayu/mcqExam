using Microsoft.AspNetCore.SignalR;

namespace ExamPrep.sever.hubs
{
    public class UserHub : Hub
    {

        public static int TotalViews { get; set; } = 0;
        public async Task  NewWindwLoaded()
        {
            TotalViews++;
            await Clients.All.SendAsync("Got One View ",TotalViews);
        }
    }
}
