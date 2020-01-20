using Blazui.Component;
using Blazui.Docs.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public class IntroductionBase : PageBase
    {
        protected string introduction;

        [Parameter]
        public string Product { get; set; }

        protected override Task InitilizePageDataAsync()
        {
            introduction = MainLayout.Product.Introduction;
            return Task.CompletedTask;
        }
    }
}
