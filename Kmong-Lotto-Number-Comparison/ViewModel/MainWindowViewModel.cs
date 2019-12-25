using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

        private DelegateCommand<int> _CEraseSameNumber;
        public DelegateCommand<int> CEraseSameNumber =>
            _CEraseSameNumber ?? (_CEraseSameNumber = new DelegateCommand<int>(OnEraseSameNumber));



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
                            string[] values = oneLine.Split(' ');

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

        private void OnEraseSameNumber(int param)
        {
            byte[] table = new byte[100];
            for (int idx = 0; idx<OriginGames.Count; )
            {
                bool letsErase =  false;
                foreach(List<byte> oList in ExceptGames)
                {
                    var list = OriginGames[idx];

                    int opportunity = 6; 
                    for (int i=0; i<6; i++)
                    {
                        byte cur = list[i];
                        bool matched = false;
                        for (int j=0; j<6; j++)
                        {
                            matched |= cur == oList[j];
                        }

                        if (matched == false) opportunity--;
                        if (opportunity < param)
                        {
                            letsErase = true;
                            break;
                        }
                    }
                }
                if (letsErase)
                {
                    OriginGames.RemoveAt(idx);
                }
                else idx++;
            }

        }
    }
}
