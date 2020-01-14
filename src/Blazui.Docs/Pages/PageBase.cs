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
    public class PageBase : BComponentBase
    {
        [Inject]
        public ProductService ProductService { get; set; }

        [CascadingParameter]
        public MainLayout MainLayout { get; set; }
    }
}
