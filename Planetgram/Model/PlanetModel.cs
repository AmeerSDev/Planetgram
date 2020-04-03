using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Planetgram.Model
{
    public class PlanetModel{ }
    public class Planet : INotifyPropertyChanged
    {
        private int r;
        private int n;
        private string color;
        private Point3DCollection points;
        private Int32Collection triangleIndices;

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                if (color != value)
                {
                    color = value;
                    RaisePropertyChanged("Color");
                }
            }
        }
        public int Radius
        {
            get
            {
                return r;
            }

            set
            {
                if (r != value)
                {
                    r = value;
                    RaisePropertyChanged("Radius");
                }
            }
        }
        public int Separators
        {
            get
            {
                return n;
            }

            set
            {
                if (n != value)
                {
                    n = value;
                    RaisePropertyChanged("Separators");
                }
            }
        }
        public Point3DCollection Points
        {
            get
            {
                return points;
            }

            set
            {
                if (points != value)
                {
                    points = value;
                    RaisePropertyChanged("Points");
                }
            }
        }
        public Int32Collection TriangleIndices
        {
            get
            {
                return triangleIndices;
            }

            set
            {
                if (triangleIndices != value)
                {
                    triangleIndices = value;
                    RaisePropertyChanged("TriangleIndices");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
