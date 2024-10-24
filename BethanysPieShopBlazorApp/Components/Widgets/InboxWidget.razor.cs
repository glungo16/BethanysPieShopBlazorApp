using BethanysPieShopBlazorApp.State;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopBlazorApp.Components.Widgets
{
    public partial class InboxWidget
    {
        [Inject]
        ApplicationState ApplicationState { get; set; }

        public int MessageCount { get; set; } = 0;

        protected override void OnInitialized()
        {
            MessageCount = ApplicationState.NumberOfMessages;
        }
    }
}
