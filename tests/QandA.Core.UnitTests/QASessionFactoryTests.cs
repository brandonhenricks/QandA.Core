using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QandA.Core.UnitTests
{
    [TestClass]
    public class QASessionFactoryTests
    {

        [TestMethod]
        public void Public_Constructor_Null_Argument_Throws_Exception()
        {
            Assert.ThrowsException<ArgumentNullException>(()=> new QASessionFactory(null));
        }

        [TestMethod]
        public void Create_Returns_Default_Session()
        {
            var factory = new QASessionFactory();

            Assert.IsNotNull(factory.Create());
        }
    }
}
