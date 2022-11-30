using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommunityToolkit.Mvvm.WpfDemo.ViewModels
{
    public class AsyncRelayCommandPageViewModel : ObservableObject
    {
        private string textResult;
        public string TextResult { get => textResult; set => SetProperty(ref textResult, value); }


        private string urlSource;

        public string UrlSource { get => urlSource; set => SetProperty(ref urlSource, value); }

        private string url;
        public string Url
        { 
            get => url;
            set
            {
                SetProperty(ref url, value);
                StartGetHtmlTaskCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GetTextCommand { get; set; }

        public IAsyncRelayCommand GetTextCommand2 { get; set; }

        public IAsyncRelayCommand StartGetHtmlTaskCommand { get; set; }

        public ICommand CancelGetHtmlTaskCommand { get; set; }

        public AsyncRelayCommandPageViewModel()
        {
            GetTextCommand = new AsyncRelayCommand(GetText);
            GetTextCommand2 = new AsyncRelayCommand(GetText2);
            StartGetHtmlTaskCommand = new AsyncRelayCommand(StartTask, () => !string.IsNullOrEmpty(Url));
            CancelGetHtmlTaskCommand = new RelayCommand(CancelTask);
        }

        public async Task GetText()
        {
            await Task.Delay(3000); //模拟耗时操作
            TextResult =  "Hello world!";
        }

        public async Task<string> GetText2()
        {
            await Task.Delay(3000); //模拟耗时操作
            return "Hello world!";
        }

        private async Task StartTask(System.Threading.CancellationToken cancellationToken)
        {
            UrlSource = await GetHtmlSource(Url, cancellationToken);
        }

        private async Task<string> GetHtmlSource(string url,System.Threading.CancellationToken cancellationToken)
        {
            var result = await Task.Run(async () =>
            {

                try
                {
                    //模拟等待5秒，防止加载太快看不到效果
                    await Task.Delay(5000,cancellationToken);
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    return ex.Message;
                }

            }, cancellationToken);

            return result;
        }

        private void CancelTask()
        {
            StartGetHtmlTaskCommand.Cancel();
        }

    }
}
