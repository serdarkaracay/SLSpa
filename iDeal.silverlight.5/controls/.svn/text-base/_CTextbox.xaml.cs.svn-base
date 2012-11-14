using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;

namespace iDeal.silverlight.controls
{
    public partial class CTextbox : UserControl
    {
        
        public event EventHandler Clicked;

        public CTextbox()
        {
            InitializeComponent();
            image.Opacity = imageOpacity;
            dropShadowEffect.ShadowDepth = 1;
        }
        double imageOpacity=.5;
        public double ImageOpacity { get { return imageOpacity; } set { imageOpacity = value; image.Opacity = imageOpacity; } }

        DropShadowEffect  dropShadowEffect=new DropShadowEffect();

        public bool IsImageEffectOn
        {
            get { return image.Effect !=null; }
            set
            {
                if (value) image.Effect = dropShadowEffect;
                else image.Effect = null;
            }
        }
        

        public static readonly DependencyProperty BackImageProperty = DependencyProperty.Register("BackImage", typeof(ImageSource), typeof(CButton), new PropertyMetadata(OnBackImageChanged));

        public ImageSource BackImage
        {
            get { return (ImageSource)image.GetValue(Image.SourceProperty); }
            set
            {
                image.Source = value;
               
            }
        }
        public static void OnBackImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CButton).BackImage = (ImageSource)e.NewValue;

        }

        Brush  hoverColor=new SolidColorBrush(Color.FromArgb(0x66, 0xff, 0xff, 0xff));

        public Brush HoverColor
        {
            get { return hoverColor; }
            set { hoverColor = value; }
        }

        Brush  backColor=new SolidColorBrush(Color.FromArgb(0x66, 0xc1, 0xc1, 0xc1));

        public Brush BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        Brush checkedBackColor=new SolidColorBrush(Color.FromArgb(0x66, 0xFF, 0xaC, 0x60));

        public Brush CheckedBackColor
        {
            get { return checkedBackColor; }
            set { checkedBackColor = value; }
        }

        Brush mouseDownColor=new SolidColorBrush(Color.FromArgb(0x66, 0xFF, 0xDC, 0x60));

        public Brush MouseDownColor
        {
            get { return mouseDownColor; }
            set { mouseDownColor = value; }
        }


        bool isToggle=false;
        public bool IsToggle
        {
            get { return isToggle; }
            set
            {
                isToggle = value;

            }
        }

        bool isChecked=false;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                try
                {
                    isChecked = value;
                    
                    drawNormal();
                    if (Clicked != null) 
                        Clicked(this, new EventArgs());
                }
                catch 
                {
                    
                  
                }
            }
        }
        public void SetChecked()
        {
            isChecked = true;
            drawNormal();
        }

        public void SetUnchecked()
        {
            isChecked = false;
            drawNormal();
        }

        private string  groupName="";

        public string  GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        
        
        Cursor defaultCursor=Cursors.Arrow;
        private void UserControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rect.Fill = HoverColor;
            if (image != null) image.Opacity = 1;
            defaultCursor = Cursor;
            Cursor = Cursors.Hand;
        }

        private void UserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            drawNormal();

            Cursor = defaultCursor;
        }

        private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rect.Fill = MouseDownColor;
            rectOutset.Visibility = Visibility.Collapsed;
            rectInset.Visibility = Visibility.Visible;
            if (image != null) image.Opacity = 1;

        }

        private void UserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isChecked = !isChecked;
            drawNormal();
            if (image != null) image.Opacity = 1;
            if (Clicked != null) Clicked(this, new EventArgs());
        }

        void drawNormal()
        {
            if (IsToggle)
            {
                if (isChecked)
                {
                    rect.Fill = CheckedBackColor;
                    rectOutset.Visibility = Visibility.Collapsed;
                    rectInset.Visibility = Visibility.Visible;
                    if (image != null) image.Opacity = 1;
                }
                else
                {
                    rect.Fill = BackColor;
                    rectOutset.Visibility = Visibility.Visible;
                    rectInset.Visibility = Visibility.Collapsed;
                    if (image != null) image.Opacity = imageOpacity;
                }
            }
            else
            {
                rect.Fill = BackColor;
                rectOutset.Visibility = Visibility.Visible;
                rectInset.Visibility = Visibility.Collapsed;
                if (image != null) image.Opacity = imageOpacity;
            }
        }

    }
}
