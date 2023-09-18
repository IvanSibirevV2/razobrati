using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClusterIII.View
{
    /// <summary>
    /// Описание основных цветов
    /// </summary>        
    public class MyColors
    {
        public BackGround MyBackGround = new BackGround();
        public foreground MyForeGround = new foreground();
    }
    /// <summary>
    /// Описание цветов фона
    /// </summary>    
    public class BackGround
    {        
        private const int q = 255;
        private const int w = 0;
        public Color NoSelected = Color.FromArgb(255, q, q, q);
        public Color Center = Color.FromArgb(255, 200, 200, 200);
        public Color Cluster = Color.FromArgb(255, w, q, w);
        public Color StructureCluster = Color.FromArgb(255, w, w, q);
        public Color CalculatedValue = Color.FromArgb(10, 200, 200, 200);

    }
    /// <summary>
    /// Описание цветов переднего плана
    /// </summary>
    public class foreground
    {
        private const int q = 200;
        private const int w = 0;
        public Color Center = Color.FromArgb(255, q, w, w);
        public Color Cluster = Color.FromArgb(255, w, q, w);
        public Color StructureCluster = Color.FromArgb(255, w, w, q);
        public Color CalculatedValue = Color.FromArgb(255, w, w, q);
        public Color CenterValue = Color.FromArgb(10, w, w, w);
    }
}