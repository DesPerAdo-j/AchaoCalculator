using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesPerAdo_j1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesPerAdo_j1;
using System.Data;
namespace DesPerAdo_j1.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void button1_ClickTest()
        {
            Form1 form1 = new Form1();
            DataTable dataTable = new DataTable();
            Dictionary<int, string> hash = new Dictionary<int, string> { { 1, "+" }, { 2, "-" }, { 3, "*" }, { 4, "/" } };
            Assert.AreEqual(int.Parse(form1.NewMethod1("23+67/67", dataTable).ToString()),24);

        }
    }
}