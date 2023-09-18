using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterIII.Model;
using System.Collections.Generic;

namespace UnitTestProject1.UTModel
{
    [TestClass]
    public class UTCluster
    {
        /// <summary>
        /// Метод тестирования класса Cluster
        /// </summary>
        [TestMethod]
        public void ClusterUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange      
                Cluster Expected = new Cluster();
                Expected.Name = "TestName";
                Expected.CGroupList= new List<Group>();
                Expected.SCluster = new List<Cluster>();
            
            // act
            Cluster Input = new Cluster(Expected.Name, Expected.CGroupList, Expected.SCluster);
            // assert
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + ".Name");
            Assert.AreEqual(Expected.CGroupList, Input.CGroupList, ErrorMessage + Convert.ToString(Input.GetType()) + ".CGroupList");
            Assert.AreEqual(Expected.SCluster, Input.SCluster, ErrorMessage + Convert.ToString(Input.GetType()) + ".SCluster");
        }
        /// <summary>
        /// Метод тестирования класса Cluster.FaceClone()
        /// </summary>
        [TestMethod]
        public void Cluster_FaceClone()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Expected = new Cluster("TestName", new List<Group>(), new List<Cluster>());            
            // act
            Cluster Input = Expected.FaceClone();            
            // assert            
            Assert.AreEqual(Expected.Name, Input.Name, ErrorMessage + Convert.ToString(Input.GetType()) + " .FaceClone() .Name");
            Assert.AreEqual(Expected.CGroupList.Count, Input.CGroupList.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .CGroupList.Count");
            Assert.AreEqual(Expected.SCluster.Count, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone() .SCluster.Count");
            Assert.AreNotEqual(Expected, Input, ErrorMessage + Convert.ToString(Input.GetType()) + ".FaceClone()");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.FaceClone()
        /// </summary>
        [TestMethod]
        public void Cluster_SameFaceClone_MethodUT()
        {            
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Input1 = new Cluster("TestClusterName",
                new Group().GenList(new Group[] {
                    new Group("TestGroupName",
                            new Param().GenList(new Param[] {
                                new Param("TestParamName0",(double)0),
                                new Param("TestParamName1",(double)0)
                            })
                        )
                })
                , new List<Cluster>());
            Cluster Input2 = Input1.FaceClone();
            Input2.SCluster.Add(Input1.FaceClone());
            Input2.SCluster.Add(Input1.FaceClone());
            Input2.SCluster.Add(Input1.FaceClone());
            Input1.SCluster.Add(new Cluster());
            Input1.SCluster.Add(new Cluster());
            Input1.SCluster.Add(new Cluster());            
            bool flag = false;
            // act
            Input1.SameFaceClone();
            flag = Input1.EqualTrue(Input2);            
            // assert            
            //Assert.AreEqual((bool)true, flag, ErrorMessage);
            Assert.AreEqual((bool)true, flag, ErrorMessage);
        }

        /// <summary>
        /// Метод тестирования класса Cluster.Add()
        /// </summary>
        [TestMethod]
        public void Cluster_Add_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Input = new Cluster("TestName", new List<Group>(), new List<Cluster>(new Cluster[10]));            
            // act
            Input.SCluster.Add(new Cluster());
            // assert            
            Assert.AreEqual(11, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + "Add()");            
        }
        
        /// <summary>
        /// Метод тестирования класса Cluster.RemoveAt()
        /// </summary>
        [TestMethod]
        public void Cluster_RemoveAt_MethodUT()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange            
            Cluster Input = new Cluster("TestName", new List<Group>(), new List<Cluster>(new Cluster[10]));
            // act
            Input.SCluster.RemoveAt(0);
            // assert            
            Assert.AreEqual(9, Input.SCluster.Count, ErrorMessage + Convert.ToString(Input.GetType()) + "Add()");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.StandartCenterReloader()
        /// </summary>
        [TestMethod]
        public void Cluster_StandartCenterReloader_MethodUT()
        {            
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            // arrange
            Cluster Input1 = new Cluster("TestClusterName",
                new Group().GenList(new Group[] {
                    new Group("TestGroupName",
                            new Param().GenList(new Param[] {
                                new Param("TestParamName0",(double)10),
                                new Param("TestParamName1",(double)10)
                            })
                        )
                })
                , new List<Cluster>());

            Cluster Input2 = new Cluster("TestClusterName",
                new Group().GenList(new Group[] {
                    new Group("TestGroupName",
                            new Param().GenList(new Param[] {
                                new Param("TestParamName0",(double)1),
                                new Param("TestParamName1",(double)1)
                            })
                        )
                })
                , new List<Cluster>());

            Input1.SCluster.Add(Input2.FaceClone());
            Input1.SCluster.Add(Input2.FaceClone());
            Input1.SCluster.Add(Input2.FaceClone());
            
            
            Input2.SCluster.Add(new Cluster());
            Input2.SCluster.Add(new Cluster());
            Input2.SCluster.Add(new Cluster());
            Input2.SameFaceClone();            
            
            bool flag = false;      
            // act            
            Input1.StandartCenterReloader();

            ;
            flag = Input1.EqualTrue(Input2);
            // assert    
            Assert.AreEqual((bool)true, flag, ErrorMessage);        
        }

        /// <summary>
        /// Метод тестирования класса Cluster.EqualTrue(Cluster LocalCluster)
        /// </summary>
        [TestMethod]
        public void Cluster_I_EqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n Cluster.EqualTrue(Cluster LocalCluster)";
            // arrange            
            Cluster Input1 = new Cluster();
                //Cluster("TestClusterName",new List<Group>(), new List<Cluster>());
            Cluster Input2 = new Cluster();
                //Cluster("TestClusterName",new List<Group>(), new List<Cluster>());
            bool flag = false;
            // act
            Input1 = new Cluster("TestClusterName1",new List<Group>(), new List<Cluster>());
            Input2 = new Cluster("TestClusterName2", new List<Group>(), new List<Cluster>());
            flag = Input1.EqualTrue(Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage+"- проверка имени");
            // act
            Input1 = new Cluster("TestClusterName",
                    new Group().GenList
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
                    })               
                , new List<Cluster>());
            Input2 = new Cluster("TestClusterName",
                    new Group().GenList
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
                    })               
                , new List<Cluster>());
            flag = Input1.EqualTrue(Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage+" - проверка на различные списки групп ");
            // act
            Input1 = new Cluster("TestClusterName", new List<Group>(), new List<Cluster>());            
            Input2 = new Cluster("TestClusterName", new List<Group>(), new List<Cluster>());
            Input1.SCluster.Add(Input2);
            flag = Input1.EqualTrue(Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + " - проверка на различные списки подкластеров ");
            // act
            Input1 = new Cluster("TestClusterName", new List<Group>(), new List<Cluster>());
            Input2 = new Cluster("TestClusterName", new List<Group>(), new List<Cluster>());
            //Input1.SCluster.Add(Input2);
            /*
            Input1.CGroupList.Add( new Group( "TestGroupName",new Param().GenList(new Param[] {
                            new Param("TestParamName10", (double) 10),
                            new Param("TestParamName11", (double) 11),
                            new Param("TestParamName12", (double) 12),
                            new Param("TestParamName13", (double) 130000)
                            })));
             * */
            flag = Input1.EqualTrue(Input2);
            // assert        
            Assert.AreEqual((bool)true, flag, ErrorMessage + " - финальная проверка");
        }

        /// <summary>
        /// Метод тестирования класса Cluster.ListEqualTrue(List(Cluster) ClusterList1, List(Cluster) ClusterList2)
        /// </summary>
        [TestMethod]
        public void Cluster_I_ListEqualTrue()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n Cluster.ListEqualTrue(List<Cluster> ClusterList1, List<Cluster> ClusterList2)";
            // arrange 
            List<Cluster> Input1 = new List<Cluster>();
            List<Cluster> Input2 = new List<Cluster>();
            bool flag = false;
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
                        new Group
                        (
                            "TestGroupName",
                            new Param().GenList(new Param[] {
                            new Param("TestParamName10", (double) 10),
                            new Param("TestParamName11", (double) 11),
                            new Param("TestParamName12", (double) 12),
                            new Param("TestParamName13", (double) 13000)
                            })
                        )
                   }), new List<Cluster>())
                );
            Input2.Add(Input1[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + " - проверка на содержимое");
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input2.Add(Input1[0]);
            Input2.Add(Input1[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + " - проверка на колличество кластеров");
            // act
            Input1.Clear();Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new  Group().GenList(new  Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input2.Add(Input1[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreEqual((bool)true, flag, ErrorMessage+" - финальная проверка");            
        }

        /// <summary>
        /// Метод тестирования класса Cluster.GenList(Cluster[] ClusterArray)
        /// </summary>
        [TestMethod]
        public void Cluster_I_GenList()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n Cluster.GenList(Cluster[] ClusterArray)";
            // arrange 
            List<Cluster> Input1 = new List<Cluster>();
            List<Cluster> Input2 = new List<Cluster>();
            bool flag = false;
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2 = new Cluster().GenList(new Cluster[]{
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
                        new Group
                        (
                            "TestGroupName",
                            new Param().GenList(new Param[] {
                            new Param("TestParamName10", (double) 10),
                            new Param("TestParamName11", (double) 11),
                            new Param("TestParamName12", (double) 12),
                            new Param("TestParamName13", (double) 13000)
                            })
                        )
                   }), new List<Cluster>())
            });
            Input2.Add(Input2[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + " - проверка на содержимое");
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2 = new Cluster().GenList(new Cluster[]{
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
            });
            Input2.Add(Input2[0]);
            Input2.Add(Input2[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreNotEqual((bool)true, flag, ErrorMessage + " - проверка проверка на колличество");
            // act
            Input1.Clear(); Input2.Clear();
            Input1.Add(
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
                );
            Input1.Add(Input1[0]);
            Input2 = new Cluster().GenList(new Cluster[]{
                new Cluster("TestClusterName",
                   new Group().GenList(new Group[] {
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
                        ,
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
                   }), new List<Cluster>())
            });
            Input2.Add(Input2[0]);
            flag = new Cluster().ListEqualTrue(Input1, Input2);
            // assert        
            Assert.AreEqual((bool)true, flag, ErrorMessage + " - финальная проверка");                        
        }

        /// <summary>
        /// Метод тестирования класса Cluster.GetInClusterToList()
        /// </summary>
        [TestMethod]
        public void Cluster_12GetInClusterToList()
        {            
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";            
            //Пишем шапку кластера
            Cluster Input1 = new Cluster("TestClusterName1",new List<Group>(),
                    new Cluster().GenList( new Cluster[] {
                        new Cluster("TestClusterName11",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName12",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName100",new List<Group>(),
                            new Cluster().GenList(new Cluster[] {
                                new Cluster("TestClusterName1xx",new List<Group>(),new List<Cluster>()),
                            })
                        )
                    })
                );
            Cluster Input2 = new Cluster("TestClusterName1", new List<Group>(),
                    new Cluster().GenList(new Cluster[] {
                        new Cluster("TestClusterName11",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName12",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName1xx",new List<Group>(),new List<Cluster>())
                    })
                );            
            bool flag = false;
            // act
            Cluster Input3 = new Cluster();
            Input3.SCluster = Input1.GetInClusterToList();
            flag = new Cluster().ListEqualTrue(Input2.SCluster, Input3.SCluster);            
            // assert
            Assert.AreEqual((bool)true, flag, ErrorMessage);                        
        }
        /// <summary>
        /// Метод тестирования класса Cluster.TurboGetInClusterToList()
        /// </summary>
        [TestMethod]
        public void Cluster_GetInClusterToListTurbo()
        {
            string ErrorMessage = "\nОшибка.\nТест не пройден\nРекомендую посмотреть:\n";
            //Пишем шапку кластера
            Cluster Input1 = new Cluster("TestClusterName1", new List<Group>(),
                    new Cluster().GenList(new Cluster[] {
                        new Cluster("TestClusterName11",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName12",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName100",new List<Group>(),
                            new Cluster().GenList(new Cluster[] {
                                new Cluster("TestClusterName1xx",new List<Group>(),new List<Cluster>()),
                            })
                        )
                    })
                );
            Cluster Input2 = new Cluster("TestClusterName1", new List<Group>(),
                    new Cluster().GenList(new Cluster[] {
                        new Cluster("TestClusterName11",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName12",new List<Group>(),new List<Cluster>()),
                        new Cluster("TestClusterName1xx",new List<Group>(),new List<Cluster>())
                    })
                );
            bool flag = false;
            // act
            Cluster Input3 = new Cluster();
            Input3.SCluster = Input1.GetInClusterToListTurbo();
            flag = new Cluster().ListEqualTrue(Input2.SCluster, Input3.SCluster);
            // assert
            Assert.AreEqual((bool)true, flag, ErrorMessage);
        }        
    }
}
