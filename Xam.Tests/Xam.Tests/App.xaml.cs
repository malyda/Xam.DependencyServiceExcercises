using Xam.Tests.DI;
using Xam.Tests.DI.Utility;
using Xam.Tests.TestClasses.Abstract;
using Xam.Tests.TestClasses.Entity;
using Xam.Tests.TestClasses.Services;
using Xam.Tests.View;
using Xam.Tests.VM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.Tests
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterServices();
            RegisterPagesVM();

            var service = CustomDependencyServiceExtended.Resolve<AService>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


       void RegisterServices()
        {
            CustomDependencyServiceExtended.RegisterFactory<InstanceCreator, InstanceCreator>();
            CustomDependencyServiceExtended.RegisterFactory<AService, SomeConcreteService>();
           // CustomDependencyServiceExtended.RegisterFactory<AService, SomeConreteServiceWithConst>(() => new SomeConreteServiceWithConst(new SomeClass()));
        }

        void RegisterPagesVM()
        {
            CustomDependencyServiceExtended.RegisterFactory<MainPage, MainPageVM>();
        }
    }
}
