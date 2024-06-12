using DailyApp.WPF.Models;
using Prism.Mvvm;

namespace DailyApp.WPF.ViewModels
{
    public class HomeUCViewModel : BindableBase
    {
        public HomeUCViewModel()
        {
            this.CreateStatPanel();
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

        private void CreateStatPanel()
        {
            StatPanelList = new List<StatPanelInfo>();

            StatPanelList.Add(new StatPanelInfo() { Icon = "ClockFast", ItemName = "彙總", BackColor = "#FF0CA0FF", ViewName = "WaitUC", Result = "9" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "ClockCheckOutline", ItemName = "已完成", BackColor = "#FF1ECA3A", ViewName = "WaitUC", Result = "9" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "ChartLineVariant", ItemName = "完成比例", BackColor = "#FF02C6DC", Result = "90%" });
            StatPanelList.Add(new StatPanelInfo() { Icon = "PlaylistStar", ItemName = "備忘錄", BackColor = "#FFFFA000", ViewName = "MemoUC", Result = "20" });
        }
    }
}