using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnalizerClassTest
{
    [TestClass]
    public class AnalizerClassDllTest
    {
        [TestMethod]
        public void ReverseStringTest()
        {
            string x = "kcab ot tnorf";
            string exp = "front to back";
            string res = AnalizerClass.AnilizerClassDll.ReverceString(x);
            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void ToPolandStringTest()
        {
            string x = "(1+2)*4+3";
            string exp = " 1 2 + 4 *3+";

            string res = AnalizerClass.AnilizerClassDll.ToPolandString(x);
            Assert.AreEqual(exp, res);
          
        }

        [TestMethod]
        public void VAlidationTest()
        {
            string x = "qwertyui\0";
            bool exp = false;
            bool res = AnalizerClass.AnilizerClassDll.Validation(x);
            Assert.AreEqual(exp, res);

            string y = "qwer1tyui";
            bool exp1 = false;
            bool res1 = AnalizerClass.AnilizerClassDll.Validation(y);
            Assert.AreEqual(exp1, res1);

            string z = "1234(444";
            bool exp2 = false;
            bool res2 = AnalizerClass.AnilizerClassDll.Validation(z);
            Assert.AreEqual(exp2, res2);

            string r = ".1";
            bool exp3 = false;
            bool res3 = AnalizerClass.AnilizerClassDll.Validation(r);
            Assert.AreEqual(exp3, res3);
        }
    }
}
