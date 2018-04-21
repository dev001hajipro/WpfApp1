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
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch;
        private long frameCounter = 0;
        private double timeSpan;
        public MainWindow()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            timeSpan = stopwatch.Elapsed.TotalMilliseconds;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            frameCounter++;
            FrameCounterText.Content = frameCounter;
            
            FPSText.Content = 1000.0 / (stopwatch.Elapsed.TotalMilliseconds - timeSpan);
            //ElapsedTicksText.Content = frameCount / stopwatch.Elapsed.TotalSeconds;
            timeSpan = stopwatch.ElapsedMilliseconds;
            TotalMillisecondsText.Content = timeSpan; // トータルの経過時間をミリ秒で表示

            //ElapsedTicksText.Content = stopwatch.ElapsedTicks / Stopwatch.Frequency;
            //ElapsedTicksText.Content = Stopwatch.Frequency;

            StopwatchText.Content = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            NameText.Text = "";
            AgeText.Text = "";
            Console.WriteLine("OnClick");
        }

        private void WindowOnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void StartButtonOnClick(object sender, RoutedEventArgs e) => 
            stopwatch.Start();
        private void StopButtonOnClick(object sender, RoutedEventArgs e) =>
            stopwatch.Stop();
    }
}
