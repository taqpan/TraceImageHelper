using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace TraceImageHelper {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            this.MouseLeftButtonDown += delegate { DragMove(); };
            openImage();
        }

        private void MenuItemOpen_OnClick(object sender, RoutedEventArgs e) {
            openImage();
        }

        private void MenuItemClose_OnClick(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void openImage() {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true) {
                this.Close();
                return;
            }

            BitmapImage bmp = null;
            try {
                bmp = new BitmapImage(new Uri(ofd.FileName));
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

            if (bmp == null) {
                this.Close();
                return;
            }

            this.Width = bmp.Width;
            this.Height = bmp.Height;
            View.Source = bmp;
        }
    }
}
