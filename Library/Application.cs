using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.UI.Base;
using Microsoft.Extensions.Configuration;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Library.Core;
using Library.Infrastructure;

namespace Library.UI
{
    public class Application
    {
        public Application(string title)
        {
            this.Title = title;
            Pages = new Dictionary<Type, PageBase>();
            History = new Stack<PageBase>();

        }
        
        protected string Title { get; set; }

        private Dictionary<Type, PageBase> Pages { get; set; }
       
        private Stack<PageBase> History { get; set; }

        internal PageBase CurrentPage => History.Any() ? History.Peek() : null;

        internal IConfiguration Configuration { get; set; }

        internal void NavigateHome()
        {
            while (History.Count > 1)
                History.Pop();

            Console.Clear();
            CurrentPage.Display();

        }

        internal IServiceCollection Services { get; set; }

        internal T NavigateTo<T>() where T: PageBase
        {
            if (CurrentPage != null && CurrentPage.GetType() == typeof(T))
                return (T)CurrentPage;

            PageBase nextPage;

            if (!Pages.TryGetValue(typeof(T), out nextPage))
                throw new Exception();

            History.Push(nextPage);
            
            Console.Clear();
            
            CurrentPage.Display();

            return CurrentPage as T;

        }

        public int Run()
        {
            BuildConfigurations();

            BuildServices();

            try
            {
                Console.Title = Title;

                CurrentPage.Display();

                return 0;
            }
            catch (Exception ex)
            {
                OutputHelper.WriteLine(ex.Message);
                return -1;

            }

        }

        private void BuildConfigurations()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .AddEnvironmentVariables()
            .Build();

            this.Configuration = Configuration;
        }

        private void BuildServices()
        {
            var serviceProvider = new ServiceCollection();
            
            serviceProvider.RegisterCoreServices();
            serviceProvider.RegisterInfrastructureServices();

            this.Services = serviceProvider;
        }

    }
}
