using DragProject.Libs;
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
    /// DragControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DragControl : UserControl
    {
        private ElementAdoner _elementAdoner = default;
        public DragControl()
        {
            InitializeComponent();
            MouseMove += DragControl_MouseMove;
            PreviewGiveFeedback += DragControl_PreviewGiveFeedback;
        }

        private void DragControl_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            _elementAdoner.SetArrange(this);
        }

        private void DragControl_MouseMove(object sender, MouseEventArgs e)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this); //객체 최상단 렌더링 z-Index;
            _elementAdoner = new ElementAdoner(this);
            adornerLayer.Add(_elementAdoner);

            DragDrop.DoDragDrop(this, Background, DragDropEffects.Copy);

            adornerLayer.Remove(_elementAdoner);
        }
    }
}
