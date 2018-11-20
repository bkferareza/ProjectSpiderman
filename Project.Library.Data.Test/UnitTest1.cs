using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Library.Data.Database;

namespace Project.Library.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //testing the crappy database
            var item = CrappyDatabase.Instance.GetBookList();
            var result = CrappyDatabase.Instance.GetBorrowers();
            var a = item;
        }
    }
}
