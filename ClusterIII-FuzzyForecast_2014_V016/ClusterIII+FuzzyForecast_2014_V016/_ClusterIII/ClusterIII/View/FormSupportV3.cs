using System.Windows.Forms;

namespace ClusterIII.View
{
    /// <summary>
    /// Класс поддержки функционала формы
    /// </summary>
    public static class FormSupport
    {
        /// <summary>
        /// Класс изменения размеров
        /// </summary>
        public static class SizeChanged
        {
            /// <summary>
            /// Лень присваивать параметры много раз, по этому пишу этот метод.
            /// </summary>            
            private static Control SetThis(Control LocalControl, int Top, int Left, int Height, int Width)
            {
                LocalControl.Top=Top;
                LocalControl.Left=Left;
                LocalControl.Height = Height;
                LocalControl.Width = Width;
                return LocalControl;
            }

            /// <summary>
            /// Метод, что описывает изменение размеров окон.
            /// </summary>
            /// <param name="MasterControl">Управляющий элемент внешнего окна.</param>
            /// <param name="SlaveControl">Управляющий элемент вложенного, внутреннего окна</param>
            /// <param name="HShift">HeightShift - Вертикальный сдвиг, отступ</param>
            /// <param name="WShift">WidthShift - Вертикальный сдвиг, отступ</param>
            public static void MasterSlave1(Control MasterControl, Control SlaveControl, int UpShift, int DownShift, int LeftShift, int RightShift)
            {
                //Ручная доводка до совершенства
                int Top = UpShift;
                int Left = LeftShift;
                int Height = MasterControl.Height - UpShift - DownShift;
                int Width = MasterControl.Width - LeftShift - RightShift;
                //MasterControl
                //MasterControl.ToString
                if (
                    (MasterControl.Name == "FormMain") || 
                    (MasterControl.Name == "DataImport") || 
                    (MasterControl.Name == "ClusterPlan") ||
                    (MasterControl.Name == "FormResult")
                    )
                {
                    Height = Height - 36;
                    Width = Width - 14;
                }
                
                SetThis(SlaveControl, Top, Left, Height, Width);
            }

            /// <summary>
            /// Метод, что описывает изменение размеров окон.
            /// </summary>
            /// <param name="MasterControl">Управляющий элемент внешнего окна.</param>
            /// <param name="SlaveControl">Управляющий элемент вложенного, внутреннего окна1</param>            
            /// <param name="SlaveControl2">Управляющий элемент вложенного, внутреннего окна2</param>
            /// <param name="HShift">HeightShift - Вертикальный сдвиг, отступ</param>
            /// <param name="WShift">WidthShift - Вертикальный сдвиг, отступ</param>
            public static void MasterSlave2(Control MasterControl, Control SlaveControl1, Control SlaveControl2, int UpShift, int DownShift, int LeftShift, int RightShift)
            {
                //Ручная доводка до совершенства
                int Top = UpShift;
                int Left = LeftShift;
                int Height = MasterControl.Height - UpShift - DownShift;
                int Width = MasterControl.Width - LeftShift - RightShift;
                if (
                    (MasterControl.Name == "FormMain") || 
                    (MasterControl.Name == "DataImport") || 
                    (MasterControl.Name == "ClusterPlan")
                    )
                {
                    Height = Height - 36;
                    Width = Width - 14;
                }
                SetThis(SlaveControl1, Top, Left, SlaveControl1.Height, Width);
                SetThis(SlaveControl2, SlaveControl1.Height + UpShift, Left, Height - SlaveControl1.Height - DownShift, Width);
            }

            /// <summary>
            /// Метод, что описывает изменение размеров окон.
            /// </summary>
            /// <param name="MasterControl">Управляющий элемент внешнего окна.</param>
            /// <param name="SlaveControl">Управляющий элемент вложенного, внутреннего окна1</param>            
            /// <param name="SlaveControl2">Управляющий элемент вложенного, внутреннего окна2</param>
            /// <param name="HShift">HeightShift - Вертикальный сдвиг, отступ</param>
            /// <param name="WShift">WidthShift - Вертикальный сдвиг, отступ</param>
            public static void MasterSlave3(Control MasterControl, Control SlaveControl1, Control SlaveControl2, int UpShift, int DownShift, int LeftShift, int RightShift)
            {
                //Ручная доводка до совершенства
                int Top = UpShift;
                int Left = LeftShift;
                int Height = MasterControl.Height - UpShift - DownShift;
                int Width = MasterControl.Width - LeftShift - RightShift;
                if (
                    (MasterControl.Name == "FormMain") || 
                    (MasterControl.Name == "DataImport") || 
                    (MasterControl.Name == "ClusterPlan") ||
                    (MasterControl.Name == "FormResult")
                    )
                {
                    Height = Height - 36;
                    Width = Width - 14;
                }
                SetThis(SlaveControl1, Top, Left, Height, Width/2);
                SetThis(SlaveControl2, Top, Left + Width / 2, Height, Width/2);
            }
        }
    }    
}