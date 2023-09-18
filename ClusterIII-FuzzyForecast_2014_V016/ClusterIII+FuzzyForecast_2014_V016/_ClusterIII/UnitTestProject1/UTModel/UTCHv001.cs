using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;
using System.Collections.Generic;
using ClusterIII.ClusterMethods.CH;

namespace UnitTestProject1.UTModel
{
    [TestClass]
    public class UTCHv001
    {
        /// <summary>
        /// Метод тестирования класса CHclassV001.Distance(Cluster A, Cluster B)
        /// </summary>
        [TestMethod]
        public void CHclassV001_Distance()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n CHclassV001.Distance(Cluster A, Cluster B)";
            // arrange      
            Cluster Input1 = new Cluster();
            Cluster Input2 = new Cluster();
            double Expected = 5;
            double InputMain = 0;
            //gen Input
            Input1 = new Cluster("TestClusterName",new Group().GenList(new Group[] {new Group("TestGroupName",
                            new Param().GenList(new Param[] {
                            new Param("TestParamName00", (double) 00),
                            new Param("TestParamName01", (double) 00)
                            }))}), new List<Cluster>());
            Input2 = new Cluster("TestClusterName", new Group().GenList(new Group[] {new Group("TestGroupName",
                            new Param().GenList(new Param[] {
                            new Param("TestParamName00", (double) 4),
                            new Param("TestParamName01", (double) 3)
                            }))}), new List<Cluster>());
            // act      
            CHclassV001 CH = new CHclassV001();
            InputMain = CH.Distance(Input1, Input2);            
            // assert            
            Assert.AreEqual(Expected, InputMain, ErrorMessage);   
        }
    }
}
