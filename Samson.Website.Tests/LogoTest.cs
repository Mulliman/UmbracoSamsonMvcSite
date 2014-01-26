using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samson.Website.Controllers;
using Samson.Website.Models;
using Samson.Website.Tests.Mocks;

namespace Samson.Website.Tests
{
    [TestClass]
    public class LogoTest
    {
        private readonly LogoController controller =
            new LogoController(new MockWebsiteContentService(), new MockImageMediaService());

        [TestMethod]
        public void TestMethod1()
        {
            var result = controller.Index()  as ViewResult;

            Assert.IsTrue(result != null);
            Assert.IsTrue(result.Model != null);

            var logoVM = result.Model as LogoModel;

            Assert.IsTrue(logoVM != null);
            Assert.IsTrue(logoVM.Url == "/");
        }
    }
}
