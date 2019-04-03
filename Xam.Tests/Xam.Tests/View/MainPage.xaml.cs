using Xam.Tests.DI;
using Xam.Tests.VM;
using Xamarin.Forms;

namespace Xam.Tests.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var x = CustomDependencyServiceExtended.Resolve<MainPage>();

            this.BindingContext = x;
        }
    }
}
