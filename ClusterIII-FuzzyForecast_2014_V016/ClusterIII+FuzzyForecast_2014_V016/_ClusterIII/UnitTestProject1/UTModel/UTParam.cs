using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;

using System.Collections.Generic;

namespace UnitTestProject1.UTModel
{    
    [TestClass]
    public class UTParam
    {
        /// <summary>
        /// Метод тестирования класса Param
        /// </summary>
        [TestMethod]
        public void Param_Param()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";

            // arrange            
            Param Expected = new Param();
            Expected.Name = "TestName";
            Expected.P=new double();
            // act
            Param Input = new Param(Expected.Name, Expected.P);
            // assert
            Assert.AreEqual( Expected.Name  , Input.Name   , ErrorMessage + Convert.ToString( Input.GetType() ) + ".Name");
            Assert.AreEqual( Expected.P     , Input.P      , ErrorMessage + Convert.ToString( Input.GetType() ) + ".P"   );
        }
        /// <summary>
        /// Метод тестирования метода Param.FaceClone()
        /// </summary>
        [TestMethod]
        public void Param_FaceClone()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Param Expected = new Param("TestName", new double());
            // act
            Param Input = Expected.FaceClone();            
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.P, Input.P, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .P");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }
        /// <summary>
        /// Метод тестирования метода Param.EqualThatTrue(Param LocalParam)
        /// </summary>
        [TestMethod]
        public void Param_I_EqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Param Input1 = new Param("TestName", (double)0);
            Param Input2 = new Param("TestName", (double)0);
            // act
            bool flag = Input1.EqualTrue(Input2);
            // assert
            Assert.AreEqual((bool)true, flag, ErrorMessage + "Param.EqualThatTrue(Param LocalParam)");            
        }
        /// <summary>
        /// Метод тестирования метода Param.ListEqualTrue(List(Param) Input1,List(Param) Input2)
        /// </summary>
        [TestMethod]
        public void Param_I_ListEqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\nParam.ListEqualTrue(List<Param> Input1,List<Param> Input2)";
            // arrange            
            List<Param> Input1 = new List<Param>();
            List<Param> Input2 = new List<Param>();
            bool flag = false;
            //Проверка на несоответствие содержимого
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(new Param("TestName0", (double)0));
            Input1.Add(new Param("TestName1", (double)10));            
            Input2.Add(new Param("TestName0", (double)0));
            Input2.Add(new Param("TestName1", (double)1));
            flag = new Param().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreEqual((bool)false, flag, ErrorMessage + "- Проверка на несоответствие содержимого");
            //Проверка на несоответствие размеров
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(new Param("TestName0", (double)0));
            Input1.Add(new Param("TestName1", (double)1));
            Input1.Add(new Param("TestName2", (double)2));
            Input2.Add(new Param("TestName0", (double)0));
            Input2.Add(new Param("TestName1", (double)1));            
            flag = new Param().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + "- Проверка на несоответствие размеров");
            //Финальная проверка
            // act
            Input1.Clear();Input2.Clear();
            Input1.Add(new Param("TestName0", (double)0));
            Input1.Add(new Param("TestName1", (double)1));
            Input1.Add(new Param("TestName2", (double)2));
            Input2.Add(new Param("TestName0", (double)0));
            Input2.Add(new Param("TestName1", (double)1));
            Input2.Add(new Param("TestName2", (double)2));
            flag = new Param().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreEqual((bool)true, flag, ErrorMessage + "- Финальная проверка");
        }
        /// <summary>
        /// Метод тестирования метода Param.(new Param[] ParamArray)
        /// </summary>
        [TestMethod]
        public void Param_I_GenList()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\nParam.(new Param[] ParamArray)";
            // arrange            
            List<Param> Expected = new List<Param>();
            Expected.Add(new Param("TestName0", (double)0));
            Expected.Add(new Param("TestName1", (double)1));
            Expected.Add(new Param("TestName2", (double)2));
            // act
            List<Param> Input = new List<Param>();
            Input.Clear();
            Input = new Param().GenList
                (new Param[] { 
                    new Param("TestName0", (double)0),
                    new Param("TestName1", (double)1),
                    new Param("TestName2", (double)2),
                });            
            // assert
            bool flag = new Param().ListEqualTrue(Input,Expected);
            Assert.AreEqual((bool)true, flag, ErrorMessage);
            //Проверка на несоответствие размеров
        }
    }
}
