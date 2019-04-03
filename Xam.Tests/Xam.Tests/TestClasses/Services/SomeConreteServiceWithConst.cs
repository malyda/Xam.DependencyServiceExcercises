using System;
using System.Collections.Generic;
using System.Text;
using Xam.Tests.TestClasses.Abstract;
using Xam.Tests.TestClasses.Entity;

namespace Xam.Tests.TestClasses.Services
{
    public class SomeConreteServiceWithConst : AService
    {
        public SomeClass SomeClassInstance;
        public SomeConreteServiceWithConst(SomeClass someClassInstance)
        {
            SomeClassInstance = someClassInstance;
            this.ServiceName = "created via const";
        }
    }
}
