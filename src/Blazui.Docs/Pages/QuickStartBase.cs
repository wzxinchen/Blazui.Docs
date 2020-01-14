using Blazui.Component;
using Blazui.Docs.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public class QuickStartBase : PageBase
    {
        private List<StepModel> steps;
        protected string quickStart;

        [Parameter]
        public string Product { get; set; }

        [Parameter]
        public string Version { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await MainLayout.InitilizePageAsync();
            steps = await ProductService.GetQuickStartStepsAsync(MainLayout.Version.Id);
            quickStart = string.Join(Environment.NewLine, steps.Select(x => $"### {x.Title}{Environment.NewLine}{x.Description}"));
            RequireRender = true;
            StateHasChanged();
        }
    }
}
