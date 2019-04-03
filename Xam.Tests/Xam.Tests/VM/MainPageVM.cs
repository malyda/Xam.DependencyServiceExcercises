using Xam.Tests.DI;
using Xam.Tests.TestClasses.Abstract;
using Xam.Tests.TestClasses.Services;

namespace Xam.Tests.VM
{
    public class MainPageVM : VMbase
    {
        private int someValue;

        public int SomeValue
        {
            get { return someValue; }
            set {
                someValue = value;
                OnPropertyChanded();
            }
        }


        AService someConcreteService;

        public MainPageVM(AService someConcreteService)
        {
            this.someConcreteService = someConcreteService;
        }

    }
}
