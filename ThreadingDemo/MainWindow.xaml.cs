using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CancellationTokenSource _cts; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartCountingBtn_Click(object sender, RoutedEventArgs e)
        {
            _cts = new CancellationTokenSource();

            var _token = _cts.Token;

            var progress = new Progress<int>(value =>
            {
                _progressBar.Value = value;
                _textBoxProgress.Text = $"{value}%";
            });

            try
            {
                await Task.Run(() => LoopThroughNumbers(100, progress, _token));

                _textBoxProgress.Text = "Complete";
            }
            catch (OperationCanceledException ex)
            {
                _textBoxProgress.Text = "Cancelled";
            }
            finally
            {
                _cts.Dispose();
                
            }
        }

        private void LoopThroughNumbers(int count, IProgress<int> progress, CancellationToken ct)
        {
            for (int i = 0; i <= count; ++i)
            {
                Thread.Sleep(100);

                progress.Report((i * 100) / count);

                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
            }

           
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }
    }
}
