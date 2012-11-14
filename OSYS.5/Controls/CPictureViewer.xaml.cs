using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO;

namespace OSYS
{
	public partial class CPictureViewer : UserControl
	{
		public CPictureViewer()
		{
			// Required to initialize variables
			InitializeComponent();
		    Storyboard2.Completed += new EventHandler(Storyboard2_Completed);
       }

		private void closeGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            Storyboard2.Begin();
		}

        void Storyboard2_Completed(object sender, EventArgs e)
        {

            Dispatcher.BeginInvoke(() =>
            {
                Visibility = Visibility.Collapsed;
            });
                
        }



        internal void ShowPicture(ImageSource bmp)
        {
            image1.Source = bmp;
            Visibility = Visibility.Visible;
            Storyboard1.Begin();
        }
        SaveFileDialog sfd=new SaveFileDialog();

        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //FileStream filestream = new FileStream(photolocation, FileMode.Create);
            //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(objImage));
            //encoder.Save(filestream);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard2.Begin();
        }
    }
}