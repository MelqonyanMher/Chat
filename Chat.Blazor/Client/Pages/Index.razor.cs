using Chat.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Chat.Blazor.Client.Pages
{
    public partial class Index:IDisposable
    {
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider _context { get; set; }
        [Inject]
        public HttpClient Http { get; set; }

        private HubConnection hubConnection;
        private List<Message> messages = new List<Message>();
        private Message message = new Message();

        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .Build();

            try
            {
                messages = await Http.GetFromJsonAsync<List<Message>>("Message/messages");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            message.UserName = (await _context.GetAuthenticationStateAsync()).User.Identity.Name;
            message.Date = DateTime.Now;

            hubConnection.On<Message>("ReceiveMessage", (message) =>
            {
                messages.Add(message);
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }

        async Task Send()
        {
            hubConnection.SendAsync("SendMessage", message);

            try
            {
                 await Http.PostAsJsonAsync<Message>("Message/message", message);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private async Task OnKeyPress(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                await Send();
            }
        }
        public bool IsConnected =>
            hubConnection.State == HubConnectionState.Connected;

        public void Dispose()
        {
            _ = hubConnection.DisposeAsync();
        }
    }
}
