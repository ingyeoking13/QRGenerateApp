using System.Windows;
using System.Windows.Controls;

namespace yhDesign
{
    public class CircularButton : Control
    {
        static CircularButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CircularButton), new FrameworkPropertyMetadata(typeof(CircularButton)));
        }

        public double ellipseWidth { get; set; }
        public double ellipseHeight { get; set; }
        public double innerEllipseWidth { get; set; }
        public double innerEllipseHeight { get; set; }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            ellipseWidth = sizeInfo.NewSize.Width;
            ellipseHeight = sizeInfo.NewSize.Height;

            innerEllipseHeight = sizeInfo.NewSize.Height - 5;
            innerEllipseWidth = sizeInfo.NewSize.Width - 5;
        }
    }
}
