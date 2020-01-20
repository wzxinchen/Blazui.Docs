using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Pages
{
    public class ComponentDocsBase : PageBase
    {

        [Parameter]
        public string Product { get; set; }

        [Parameter]
        public string Version { get; set; }

        [Parameter]
        public string TagName { get; set; }

        protected override Task InitilizePageDataAsync()
        {

        }
    }
}
