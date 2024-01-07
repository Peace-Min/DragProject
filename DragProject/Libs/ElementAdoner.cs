using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ConvertLib;

namespace DragProject.Libs
{
    public class ElementAdoner : Adorner
    {
        private Rect _renderRect;
        private Point _offset;
        private ImageSource _imageSourse;

        public ElementAdoner(FrameworkElement adornedElement) : base(adornedElement)
        {
            IsHitTestVisible = false; // 마우스막기
            Opacity = 0.7;

            _renderRect = new Rect(AdornedElement.RenderSize);
            _offset = new Point(-this._renderRect.Width / 2, - this._renderRect.Height / 2); //넓이의 반절만큼 좌측 위로의 포인트
            //elemenet 이미지로변경
            using(System.Drawing.Bitmap bmp= adornedElement.ToBitmap())
            {
                _imageSourse=bmp.ToImageSource();
            }
        }
        public void SetArrange(Visual visual)
        {
            System.Drawing.Point cursorPoint = System.Windows.Forms.Cursor.Position;
            Point point = visual.PointFromScreen(new Point(cursorPoint.X + _offset.X,cursorPoint.Y + _offset.Y));
            Arrange(new Rect(point, DesiredSize));
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawImage(_imageSourse, _renderRect);
        }
    }
}
