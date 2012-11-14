using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using OSYS.Classes;
using OSYS.Controls;

namespace OSYS
{

   
    public partial class CGroupButton : UserControl
    {
        public event CGroupButtonsClickEventHandler Clicked;
        
        public CGroupButton()
        {
            // Required to initialize variables
            InitializeComponent();
            Loaded += new RoutedEventHandler(CGroupButton_Loaded);
            btnMain.IsGroupControl = true;
            btnMain.Width = buttonWidth;
            btnMain.Height = buttonHeight;
            btnMain.Margin = new Thickness(horizontalButtonMargin, 0, horizontalButtonMargin, 0);
            btnMain.Clicked += new System.EventHandler(btnMain_Clicked);
            sbOpen.Completed += new EventHandler(sbOpen_Completed);
            ButtonsOpened = false;
      
        }

        void CGroupButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (spButtons.Children.Count > 0) return;
            for (int i = 0; i < buttons.Count ; i++)
            {
                CButton item=buttons[i];
                spButtons.Children.Add(item);
                item.Index = i;
                item.Width = buttonWidth;
                item.Height = buttonHeight;
                item.Margin = new Thickness(horizontalButtonMargin, 0, horizontalButtonMargin, 0);
                item.Clicked += new System.EventHandler(item_Clicked);
                item.MouseLeave += new System.Windows.Input.MouseEventHandler(item_MouseLeave);
                item.MouseEnter += new System.Windows.Input.MouseEventHandler(item_MouseEnter);

            }  
        }


        List<CButton> buttons=new List<CButton>();
        public List<CButton> Buttons { get { return buttons; } }

        bool buttonsOpened=false;
        public bool ButtonsOpened
        {
            get { return buttonsOpened; }
            set
            {
                buttonsOpened = value;
                if (value)
                {
                    spButtons.Visibility = Visibility.Visible;
                    spMainButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    spButtons.Visibility = Visibility.Collapsed;
                    spMainButton.Visibility = Visibility.Visible;
                }

            }
        }

        private int buttonWidth=36;

        public int ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                btnMain.Width = value;
                foreach (CButton item in buttons)
                {
                    item.Width = value;
                }
            }
        }

        private int buttonHeight=32;

        public int ButtonHeight
        {
            get { return buttonHeight; }
            set
            {
                buttonHeight = value;
                btnMain.Height = value;
                foreach (CButton item in buttons)
                {
                    item.Height = value;
                }
            }
        }

        private int horizontalButtonMargin=2;

        public int HorizontalButtonMargin
        {
            get { return horizontalButtonMargin; }
            set
            {
                horizontalButtonMargin = value;

                btnMain.Margin = new Thickness(horizontalButtonMargin, 0, horizontalButtonMargin, 0);
                foreach (CButton item in buttons)
                {
                    item.Margin = new Thickness(horizontalButtonMargin, 0, horizontalButtonMargin, 0);
                }
            }
        }


        public ImageSource MainButtonBackImage
        {
            get { return btnMain.BackImage; }
            set { btnMain.BackImage = value; }
        }



        void sbOpen_Completed(object sender, EventArgs e)
        {
            if (buttons.Count > 0) buttons[0].Focus();
            buttonsOpened = true;

        }

        private void btnMain_Clicked(object sender, System.EventArgs e)
        {
            sbOpen.Begin();

        }

        private void item_Clicked(object sender, System.EventArgs e)
        {
            //sbClose.Begin();
            if (Clicked != null) Clicked(sender as CButton);
        }

        private void item_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (buttonsOpened) sbClose.Begin();
        }

        private void item_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            sbClose.Pause();
        }
    }
}