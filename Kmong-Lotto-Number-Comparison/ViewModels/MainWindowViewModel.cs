using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Kmong_Lotto_Number_Comparison.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<List<byte>> originGames;
        public ObservableCollection<List<byte>> OriginGames
        {
            get { return originGames; }
            set { SetProperty(ref originGames, value); }
        }

        private ObservableCollection<List<byte>> exceptGames;
        public ObservableCollection<List<byte>> ExceptGames
        {
            get { return exceptGames; }
            set { SetProperty(ref exceptGames, value); }
        }

        private int _OriginGamesCnt;
        public int OriginGamesCnt
        {
            get { return _OriginGamesCnt; }
            set { SetProperty(ref _OriginGamesCnt, value); }
        }

        private int _ExceptGamseCnt;
        public int ExceptGamesCnt
        {
            get { return _ExceptGamseCnt; }
            set { SetProperty(ref _ExceptGamseCnt, value); }
        }
        private object _ModalPage;
        public object ModalPage
        {
            get { return _ModalPage; }
            set { SetProperty(ref _ModalPage, value); }
        }
        public ICommand CFileOpenOriginGame { get; set; }

        private bool JobOnWork;
        public bool BJobOnWorkOriginBtn
        {
            get { return JobOnWork; }
            set { SetProperty(ref JobOnWork, value); }
        }

        private bool JobOnWorkExcept;
        public bool BJobOnWorkExceptBtn
        {
            get { return JobOnWorkExcept; }
            set { SetProperty(ref JobOnWorkExcept, value); }
        }

        private DelegateCommand<string> _CEraseSameNumber;
        public DelegateCommand<string> CEraseSameNumber =>
            _CEraseSameNumber ?? (_CEraseSameNumber = new DelegateCommand<string>(OnEraseSameNumber));

        private DelegateCommand _CSaveGameList;
        public DelegateCommand CSaveGameList =>
            _CSaveGameList ?? (_CSaveGameList = new DelegateCommand(ExecuteCSaveGameList));

        void ExecuteCSaveGameList()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "텍스트 파일 (*.txt)|*txt";
            if (dlg.ShowDialog() == true)
            {
                using(StreamWriter sw = new StreamWriter(dlg.FileName, false))
                {
                    foreach (var item in OriginGames)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var c in item)
                        {
                            if (c < 10) sb.Append('0');
                            sb.Append(c);
                            sb.Append(" ");
                        }
                        sb.Remove(sb.Length-1,1);
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
        }

        public MainWindowViewModel()
        {
            CFileOpenOriginGame = new DelegateCommand<string>(OnFileOpenOriginGame);
        }

        private async void OnFileOpenOriginGame(string param)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "텍스트 파일 (*.txt)|*txt";

            ObservableCollection<List<byte>> bb = new ObservableCollection<List<byte>>();
            // when Open Dlg
            if (dlg.ShowDialog() == true)
            {
                if (param.Equals("Origin"))
                {
                    BJobOnWorkOriginBtn = true;
                    OriginGames = new ObservableCollection<List<byte>>();
                }
                else if ( param.Equals("Erase"))
                {
                    BJobOnWorkExceptBtn = true;
                    ExceptGames = new ObservableCollection<List<byte>>();
                }

                DispatcherTimer dt= new DispatcherTimer();
                dt.Interval = new TimeSpan(0, 0, 0, 0, 500);
                dt.Tick += (s, e) =>
                {
                    App.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        if (param.Equals("Origin")) OriginGamesCnt = bb.Count;
                        else ExceptGamesCnt = bb.Count;
                    }), DispatcherPriority.Background);

                };

                dt.Start();

                await Task.Run(async () =>
                {
                    using (StreamReader sr = new StreamReader(dlg.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            string oneLine = await sr.ReadLineAsync();
                            string[] values = oneLine.Split(new char[2]{ ' ', '\t'});

                            List<byte> temp = new List<byte>();

                            for (int i = 0; i < 6; i++)
                            {
                                byte valuebyte = 255;
                                bool safe = byte.TryParse(values[i], out valuebyte);
                                temp.Add(valuebyte);
                            }

                            bb.Add(temp);
                        }
                    }
                });
                dt.Stop();

                if (param.Equals("Origin")) BJobOnWorkOriginBtn = false;
                else BJobOnWorkExceptBtn = false;

                if (param.Equals("Origin"))
                {
                    OriginGames = bb;
                    OriginGamesCnt = bb.Count;
                }
                else
                {
                    ExceptGames = bb;
                    ExceptGamesCnt = bb.Count;
                }
            }
        }

        private async void OnEraseSameNumber(string sparam)
        {
            int param = int.Parse(sparam);
            ObservableCollection<List<byte>> bb = new ObservableCollection<List<byte>>();

            bool[] table = new bool[100];

            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += (s, e) =>
            {
                OriginGamesCnt = bb.Count;
            };
            dt.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dt.Start();

            ModalPage = new PopupViewModel();

            await Task.Run(() =>
            {
                for (int idx = 0; idx < OriginGames.Count; idx++)
                {

                    var list = OriginGames[idx];
                    foreach( var item in list) table[item] = true;
                    bool letsErase = false;

                    foreach (List<byte> oList in ExceptGames)
                    {
                        int matchCount = 0;
                        foreach (var item in oList) if (table[item]) matchCount++;

                        if (matchCount == param)
                        {
                            letsErase = true;
                            break;
                        }
                    }
                    foreach (var item in list) table[item] = false;

                    if (letsErase == false)
                    {
                        bb.Add(OriginGames[idx]);
                    }
                }

            });
            dt.Stop();
            OriginGames = bb;
            OriginGamesCnt = bb.Count;
            ModalPage = null;
        }
    }
}
