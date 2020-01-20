using Blazui.Component;
using Blazui.Docs.Services;
using Blazui.Docs.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public abstract class PageBase : BComponentBase
    {
        [Inject]
        public ProductService ProductService { get; set; }

        [CascadingParameter]
        public MainLayout MainLayout { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }
            MainLayout.Loading();
            await MainLayout.InitilizePageAsync();
            await InitilizePageDataAsync();
            RequireRender = true;
            StateHasChanged();
            MainLayout.Refresh();
        }

        protected abstract Task InitilizePageDataAsync();
    }
}
