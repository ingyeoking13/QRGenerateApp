using System.Windows;
using System.Windows.Controls;

namespace yhDesign
{
    public class RaidoButton : Control
    {
        static RaidoButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RaidoButton), new FrameworkPropertyMetadata(typeof(RaidoButton)));
        }

        public string mycontent
        {
            get { return (string)GetValue(mycontentProperty); }
            set { SetValue(mycontentProperty, value); }
        }

        private double buttonWidth
        {
            get { return (double)GetValue(buttonWidthProperty); }
            set { SetValue(buttonWidthProperty, value); }
        }

        private double buttonHeight
        {
            get { return (double)GetValue(buttonHeightProperty); }
            set { SetValue(buttonHeightProperty, value); }
        }

        public bool? isClicked
        {
            get { return (bool?)GetValue(isClickedProperty); }
            set { SetValue(isClickedProperty, value); }
        }

        public static readonly DependencyProperty mycontentProperty =
            DependencyProperty.Register(nameof(mycontent), typeof(string), typeof(RaidoButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty isClickedProperty =
            DependencyProperty.Register(nameof(isClicked), typeof(bool?), typeof(RaidoButton), new PropertyMetadata(null));

        public static readonly DependencyProperty buttonHeightProperty =
            DependencyProperty.Register(nameof(buttonHeight), typeof(double), typeof(RaidoButton), new PropertyMetadata(0.0));

        public static readonly DependencyProperty buttonWidthProperty =
            DependencyProperty.Register(nameof(buttonWidth), typeof(double), typeof(RaidoButton), new PropertyMetadata(0.0));

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            buttonWidth = sizeInfo.NewSize.Width / 3;
            buttonHeight = sizeInfo.NewSize.Height - 10;
        }
    }
}
