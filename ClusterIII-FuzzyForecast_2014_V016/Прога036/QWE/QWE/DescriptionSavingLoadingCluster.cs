using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace MyСlusterWorkingSpace    
{
    public class StringList : List<String>{}
    
    /// <summary>
    /// Базовые методы сохранения и загрузки кластера (XML файлы)
    /// </summary>
    public class BasicMethodsOfSavingLoadingClusterFile
    {
        #region Сохранение в  XML файл
        /// <summary>
        /// Этот метод возвращает "центр" кластера в XML формате
        /// </summary>
        private void XmlCenter(XmlTextWriter MyXmlCenter, IntList MyCenter)
        {
            int i=0;
            MyXmlCenter.WriteStartElement("Center");
            MyXmlCenter.WriteAttributeString("Count", Convert.ToString(MyCenter.Count));
            foreach (int item in MyCenter)
            {
                MyXmlCenter.WriteAttributeString("X"+Convert.ToString(i), Convert.ToString(item));
                i++;
            }            
            MyXmlCenter.WriteEndElement();            
        }
        /// <summary>
        /// Этот метод возвращает список кластеров нижнего иерархического уровня в XML формате
        /// </summary>
        private void XmlStructureCluster(XmlTextWriter MyXmlStructureCluster, ClusterList MyStructureCluster)
        {            
            int i = 0;
            MyXmlStructureCluster.WriteStartElement("StructureCluster");
            MyXmlStructureCluster.WriteAttributeString("Count", Convert.ToString(MyStructureCluster.Count));
            foreach (Cluster item in MyStructureCluster)
            {
                XmlCluster(MyXmlStructureCluster, MyStructureCluster[i]);
                i++;
            }
            MyXmlStructureCluster.WriteEndElement();
        }
        /// <summary>
        /// Этот метод возвращает кластер верхнего иерархического уровня в XML формате
        /// </summary>        
        private void XmlCluster(XmlTextWriter MyXmlCluster, Cluster MyCluster)
        {            
            MyXmlCluster.WriteStartElement("Cluster");
            MyXmlCluster.WriteAttributeString("Name", MyCluster.Name);
            XmlCenter(MyXmlCluster, MyCluster.Center);
            XmlStructureCluster(MyXmlCluster, MyCluster.StructureCluster);
            MyXmlCluster.WriteEndElement();
        }
        /// <summary>
        /// Метод сохранения кластера в  XML файл
        /// </summary>
        public void SavingClusterToXml(Cluster MyCluster, string spath)
        {
            FileStream fs = new FileStream(spath, FileMode.Create);
            XmlTextWriter xmlOut = new XmlTextWriter(fs, System.Text.Encoding.Unicode);

            xmlOut.Formatting = Formatting.Indented;

            xmlOut.WriteStartDocument();
            xmlOut.WriteComment("Этот файл создан для примера");
            xmlOut.WriteStartElement("Body");
            XmlCluster(xmlOut, MyCluster);
                      xmlOut.WriteEndElement();
            xmlOut.WriteEndDocument();
            xmlOut.Close();
            fs.Close();
        }
        #endregion

        #region Загруузка из  XML файла
        /// <summary>
        /// Этот метод возвращает "центр" кластера из XML формата
        /// </summary>
        private void CenterXml(XmlTextReader MyCenterXml, IntList MyCenter)
        {            
            int Count = Convert.ToInt16(MyCenterXml.GetAttribute("Count"));            
                for(int i = 0;i<Count;i++)
                {                   
                        MyCenter.Add(Convert.ToInt16(MyCenterXml.GetAttribute("X" + Convert.ToString(i))));                            
                }
        }
        /// <summary>
        /// Этот метод возвращает список кластеров нижнего иерархического уровня из XML формата
        /// </summary>
        private void StructureClusterXml(XmlTextReader MyStructureClusterXml, ClusterList MyStructureCluster)
        {            
            int Count = Convert.ToInt16(MyStructureClusterXml.GetAttribute("Count"));            
            for (int i = 0; i < Count; i++)
            {
                if (Count!=0)
                {
                   Cluster MyLocalCluster=new Cluster();
                   MyStructureClusterXml.Read();
                   ClusterXml(MyStructureClusterXml,MyLocalCluster);
                   MyStructureCluster.Add(MyLocalCluster);
                }            
            }
            if (Count != 0) MyStructureClusterXml.Read();
            
        }
        /// <summary>
        /// Этот метод возвращает кластер верхнего иерархического уровня из XML формате
        /// </summary>        
        private void ClusterXml(XmlTextReader MyClusterXml, Cluster MyCluster)
        {
            if (MyClusterXml.Name == "Cluster") MyCluster.Name = MyClusterXml.GetAttribute("Name");  

                MyClusterXml.Read();if (MyClusterXml.Name == "Center") CenterXml(MyClusterXml, MyCluster.Center);
                MyClusterXml.Read();if (MyClusterXml.Name == "StructureCluster")StructureClusterXml(MyClusterXml, MyCluster.StructureCluster);
                MyClusterXml.Read();
        }
        /// <summary>
        /// Метод загрузки кластера из  XML файла
        /// </summary>        
        public Cluster LoadingClusterFromXml( string newFilename)
        {
            Cluster MyLocalCluster = new Cluster();

            FileStream fs = new FileStream(newFilename, FileMode.Open);
            XmlTextReader xmlIn = new XmlTextReader(fs);
            xmlIn.WhitespaceHandling = WhitespaceHandling.None;
            //перемещаем в начало документа
            xmlIn.MoveToContent();
            //цикл чтения тегов
            do
            {             
                //удалось ли прочитать тег
                if (!xmlIn.Read()) throw new ArgumentException("Ошибочка");

                if (xmlIn.Name == "Cluster")
                {                    
                    ClusterXml(xmlIn, MyLocalCluster);
                    break;                    
                }            
            } while (!xmlIn.EOF);

            xmlIn.Close();
            fs.Close();            
            return MyLocalCluster;
        }
        #endregion
    }			
}

