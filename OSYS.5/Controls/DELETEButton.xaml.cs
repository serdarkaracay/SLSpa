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

namespace OSYS.Controls
{
    public partial class DELETEButton : UserControl
    {
        public event EventHandler CheckedChanged;

        public event EventHandler Click;

        bool isChecked = false;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                VisualStateManager.GoToState(this, (isChecked ? "Selected" : "HoverUnchecked"), false);
            }
        }
        public DELETEButton()
        {
            // Required to initialize variables
            InitializeComponent();
            MouseLeftButtonDown += (s, e) =>
            {
                VisualStateManager.GoToState(this, "HoverChecked", false);
            };

            MouseLeftButtonUp += (s, e) =>
            {
                VisualStateManager.GoToState(this, "HoverUnchecked", false);
                if (Click != null && !isChecked) Click(this, null);
            };
            MouseEnter += (s, e) =>
            {
                VisualStateManager.GoToState(this, "HoverUnchecked", false);
            };

            MouseLeave += (s, e) =>
            {
                VisualStateManager.GoToState(this, "NormalUnchecked", false);
            };

            ToolTipService.SetToolTip(btnDelete, "Sil");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null) Click(this, null);
        }
    }
}
