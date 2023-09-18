using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;
using System.Collections.Generic;


namespace UnitTestProject1.UTModel
{
    [TestClass]
    public class UTGroup
    {
        /// <summary>
        /// Метод тестирования класса Group
        /// </summary>
        [TestMethod]
        public void GroupUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Group Expected = new Group();
            Expected.Name = "TestName";
            Expected.GParamList = new List<Param>();
            // act
            Group Input = new Group(Expected.Name,Expected.GParamList);
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + ".Name");
            Assert.AreEqual(Expected.GParamList, Input.GParamList, ErrorMessage + Convert.ToString(Input.GetType()) + ".GParamList");
        }

        /// <summary>
        /// Метод тестирования Group.FaceClone()
        /// </summary>
        [TestMethod]
        public void Group_FaceClone_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Group Expected = new Group();
            Expected.Name = "TestName";
            Expected.GParamList = new List<Param>();
            // act
            Group Input = Expected.FaceClone();            
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.GParamList.Count, Input.GParamList.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .GParamList.Count");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }
        /// <summary>
        /// Метод тестирования Group.EqualTrue(Group LocalGroup)
        /// </summary>
        [TestMethod]
        public void Group_I_EqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\nGroup.EqualTrue(Group LocalGroup)";
            // arrange            
            Group Input1 = new Group
                (
                    "TestGroupName",
                    new Param().GenList(new Param[] {
                    new Param("TestParamName0", (double) 0),
                    new Param("TestParamName1", (double) 1),
                    new Param("TestParamName2", (double) 2),
                    new Param("TestParamName3", (double) 3)
                    })
                );
            Group Input2 = new Group
                (
                    "TestGroupName",
                    new Param().GenList(new Param[] {
                    new Param("TestParamName0", (double) 0),
                    new Param("TestParamName1", (double) 1),
                    new Param("TestParamName2", (double) 2),
                    new Param("TestParamName3", (double) 3)
                    })
                );
            // act
            bool flag = Input1.EqualTrue(Input2);
            // assert        
            Assert.AreEqual((bool)true, flag, ErrorMessage);
        }

        /// <summary>
        /// Метод тестирования Group.LGenList(Group[] GroupArray) 
        /// </summary>
        [TestMethod]
        public void Group_I_GenList()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\nGroup.GenList(Group[] GroupArray) ";
            // arrange                        
            List<Group> Input1 = new List<Group>();
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    )
                );
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                );
            List<Group> Input2 = new List<Group>();
            // act
            Input2= new Group().GenList
                (new Group[] {
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    ),
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                });
            bool flag = new Group().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreEqual((bool)true, flag, ErrorMessage);
        }

        /// <summary>
        /// Метод тестирования метода Group.ListEqualTrue(List(Param) Input1,List(Param) Input2)
        /// </summary>
        [TestMethod]
        public void Group_I_ListEqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\nGroup.ListEqualTrue(List<Param> Input1,List<Param> Input2)";
            // arrange            
            List<Group> Input1 = new List<Group>();
            List<Group> Input2 = new List<Group>();
            bool flag = false;
            //Проверка на несоответствие содержимого
            // act  
            Input1.Clear(); Input2.Clear();
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    )
                );
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                );
            Input2 = new Group().GenList
                (new Group[] {
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    ),
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 130000)
                        })
                    )
                });
            flag = new Group().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreEqual((bool)false, flag, ErrorMessage + "- Проверка на несоответствие содержимого");
            //Проверка на несоответствие размеров
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    )
                );
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                );
            Input2 = new Group().GenList
                (new Group[] {
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
//                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    )
                });
            flag = new Group().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + "- Проверка на несоответствие размеров");
            //Финальная проверка
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    )
                );
            Input1.Add
                (
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                );
            Input2 = new Group().GenList
                (new Group[] {
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName00", (double) 00),
                        new Param("TestParamName01", (double) 01),
                        new Param("TestParamName02", (double) 02),
                        new Param("TestParamName03", (double) 03)
                        })
                    ),
                    new Group
                    (
                        "TestGroupName",
                        new Param().GenList(new Param[] {
                        new Param("TestParamName10", (double) 10),
                        new Param("TestParamName11", (double) 11),
                        new Param("TestParamName12", (double) 12),
                        new Param("TestParamName13", (double) 13)
                        })
                    )
                });
            flag = new Group().ListEqualTrue(Input1, Input2);
            // assert
            Assert.AreEqual((bool)true, flag, ErrorMessage + "- Финальная проверка");
        }



    }
}
