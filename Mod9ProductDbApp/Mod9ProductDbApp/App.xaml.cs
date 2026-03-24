using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Mod9ProductDbApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //This service provide will register all our services/dbcontext and also provide instances of objects
        // as we inject those services in the constructors in different classes in our app.
        private ServiceProvider provider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Data.BookContext>(options =>
            {
                options.UseSqlite("Data Source = books.db");
            });
            //inferface, implementor
            services.AddSingleton<Services.ICRUD, Services.CRUD>();
            services.AddSingleton<MainWindow>();
            provider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
