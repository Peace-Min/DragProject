using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragProject.Control
{
    /// <summary>
    /// DropControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DropControl : UserControl
    {
        public DropControl()
        {
            InitializeComponent();
            Drop += DropControl_Drop;
        }

        private void DropControl_Drop(object sender, DragEventArgs e)
        {
            SolidColorBrush a =e.Data.GetData(typeof(SolidColorBrush)) as SolidColorBrush;
            if( a != null)
            {
                this.Background = a;
            }
        }
    }
}
