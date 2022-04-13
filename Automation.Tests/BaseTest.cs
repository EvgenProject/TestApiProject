using System;
using System.Collections.Generic;
using System.Linq;
using Automation.API.Client.User;
using NUnit.Framework;

namespace Automation.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected UserService UserService;

        [SetUp]
        public void BeforeEachTest()
        {
            var test = TestContext.CurrentContext.Test;
            TestContext.Progress.WriteLine($"[{DateTime.Now:HH:mm:ss}]: Test started '{test.FullName}'");
            UserService = new UserService();
        }

        [TearDown]
        public void AfterEachTest()
        {
            var test = TestContext.CurrentContext.Test;
            TestContext.Progress.WriteLine($"[{DateTime.Now:HH:mm:ss}]: Test finished '{test.FullName}'");
        }
    }
}
