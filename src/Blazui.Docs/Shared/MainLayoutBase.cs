using Blazui.Component;
using Blazui.Component.Container;
using Blazui.Component.NavMenu;
using Blazui.Docs.Model;
using Blazui.Docs.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazui.Docs.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        protected BDropDown productDropDown;
        protected BLayout layout;
        protected BMenu leftMenu;
        [Inject]
        private ProductService ProductService { get; set; }

        [Inject]
        private MessageService MessageService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private LoadingService LoadingService { get; set; }
        internal ProductModel Product { get; private set; }

        internal VersionModel Version { get; private set; }
        private string[] paths;

        protected List<ProductModel> Products { get; private set; }

        protected List<VersionModel> Versions { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            paths = new Uri(NavigationManager.Uri).Segments.Where(x => x != "/").Select(x => x.Trim('/')).ToArray();
            if (paths.Length == 0)
            {
                Products = await ProductService.GetProductsAsync();
                NavigationManager.NavigateTo($"/{Products.FirstOrDefault().NugetPackageName}");
            }
        }

        public void Loading()
        {
            LoadingService.Show(new LoadingOption()
            {
                Background = "rgba(0, 0, 0, 0.1)",
                Text = "拼命加载中",
                IconClass = "el-icon-loading"
            });
        }

        public void Refresh()
        {
            leftMenu.MarkAsRequireRender();
            productDropDown.MarkAsRequireRender();
            StateHasChanged();
            LoadingService.CloseFullScreenLoading();
        }

        public async Task InitilizePageAsync()
        {
            paths = new Uri(NavigationManager.Uri).Segments.Where(x => x != "/").Select(x => x.Trim('/')).ToArray();
            Products = await ProductService.GetProductsAsync();
            if (paths.Length == 0)
            {
                NavigationManager.NavigateTo($"/{Products.FirstOrDefault().NugetPackageName}");
                return;
            }

            if (IsIntroductionPage(paths) || IsQuickStartPage(paths))
            {
                Product = Products.FirstOrDefault(x => x.NugetPackageName.Equals(paths[0], StringComparison.CurrentCultureIgnoreCase));
                if (Product == null)
                {
                    MessageService.Show($"当前产品不存在:{paths[0]}");
                    return;
                }
                Versions = await ProductService.GetVersionsAsync(Product.Id);
                Version = Versions.FirstOrDefault();
                if (Version == null)
                {
                    MessageService.Show($"当前产品不存在版本:{paths[0]}");
                }
            }
        }

        private bool IsIntroductionPage(string[] paths)
        {
            return paths.Length == 1 || paths.Length == 2;
        }
        private bool IsQuickStartPage(string[] paths)
        {
            return paths.Length == 3 && paths[2] == "quickstart";
        }

        protected bool MatchMenu(string menuRoute)
        {
            if (menuRoute == null)
            {
                return false;
            }

            var paths = new Uri(NavigationManager.Uri).Segments.Where(x => x != "/").Select(x => x.Trim('/')).ToArray();
            var menuPaths = menuRoute.Split('/').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            if (IsIntroductionPage(paths) && IsIntroductionPage(menuPaths))
            {

                return true;
            }
            if (IsQuickStartPage(paths) && IsQuickStartPage(menuPaths))
            {

                return true;
            }

            return false;
        }
    }
}
