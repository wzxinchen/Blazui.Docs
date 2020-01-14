using Blazui.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public class QuickStartBase : PageBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await MainLayout.InitilizePageAsync();
        }
    }
}
