using Blazui.Component;
using Blazui.Docs.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public class IntroductionBase : BComponentBase
    {
        protected string introduction;

        [CascadingParameter]
        public MainLayout MainLayout { get; set; }

        [Parameter]
        public string Product { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await MainLayout.InitlizeProductAsync();
            introduction = MainLayout.Product.Introduction;
            RequireRender = true;
            StateHasChanged();
        }

    }
}
