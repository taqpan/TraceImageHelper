using System;
using System.Windows;
using System.Windows.Input;
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

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Up:
                    this.Top -= 1;
                    break;
                case Key.Down:
                    this.Top += 1;
                    break;
                case Key.Left:
                    this.Left -= 1;
                    break;
                case Key.Right:
                    this.Left += 1;
                    break;
            }
        }

        private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e) {
            var o = this.Opacity;
            o += e.Delta > 0 ? 0.05 : -0.05;
            if (o < 0.2) o = 0.2;
            if (o > 1) o = 1;
            this.Opacity = o;
        }
    }
}
