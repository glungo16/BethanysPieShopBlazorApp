using Microsoft.AspNetCore.Components;

namespace BethanysPieShopBlazorApp.Components
{
    public partial class ProfilePicture
    {
        // Parameter that is between the open and closed brackets: It must be RenderFragment and be called Child Content
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
