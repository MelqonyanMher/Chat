using Chat.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Client.Shared
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = true;
        //private ApplicationUser[] forecasts;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    try
        //    {
        //        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        //    }
        //    catch (AccessTokenNotAvailableException exception)
        //    {
        //        exception.Redirect();
        //    }
        //}
    }
}
