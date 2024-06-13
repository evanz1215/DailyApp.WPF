using DailyApp.WPF.Dtos;
using DailyApp.WPF.Models;
using Prism.Mvvm;

namespace DailyApp.WPF.ViewModels
{
    public class HomeUCViewModel : BindableBase
    {
        public HomeUCViewModel()
        {
            this.CreateStatPanel();
            this.CreateWaitList();
            this.CreateMemoList();
        }

        private List<StatPanelInfo> _statPanelList;

        public List<StatPanelInfo> StatPanelList
        {
            get { return _statPanelList; }
            set
            {
                _statPanelList = value;
                RaisePropertyChanged();
            }
        }

        private List<WaitInfoDto> _waitList;

        public List<WaitInfoDto> WaitList
        {
            get { return _waitList; }
            set
            {
                _waitList = value;
                RaisePropertyChanged();
            }
        }

        private List<MemoInfoDto> _memoList;

        public List<MemoInfoDto> MemoList
        {
            get { return _memoList; }
            set
            {
                _memoList = value;
                RaisePropertyChanged();
            }
        }

        private void CreateStatPanel()
        {
            StatPanelList = new List<StatPanelInfo>();

            StatPanelList.Add(new StatPanelInfo() { Icon = "ClockFast", ItemName = "彙總", BackColor = "#FF0CA0FF", ViewName = "WaitUC", Result = "9" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "ClockCheckOutline", ItemName = "已完成", BackColor = "#FF1ECA3A", ViewName = "WaitUC", Result = "9" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "ChartLineVariant", ItemName = "完成比例", BackColor = "#FF02C6DC", Result = "90%" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "PlaylistStar", ItemName = "備忘錄", BackColor = "#FFFFA000", ViewName = "MemoUC", Result = "20" });
        }

        private void CreateWaitList()
        {
            WaitList = new List<WaitInfoDto>();
            WaitList.Add(new WaitInfoDto() { WaitId = 1, Title = "待辦事項1", Content = "待辦事項1", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 2, Title = "待辦事項2", Content = "待辦事項2", Status = 0 });
        }
        private void CreateMemoList()
        {
            MemoList = new List<MemoInfoDto>();
            MemoList.Add(new MemoInfoDto() { MemoId = 1, Title = "待辦事項1", Content = "待辦事項1", Status = 0 });
            MemoList.Add(new MemoInfoDto() { MemoId = 2, Title = "待辦事項2", Content = "待辦事項2", Status = 0 });
        }
    }
}