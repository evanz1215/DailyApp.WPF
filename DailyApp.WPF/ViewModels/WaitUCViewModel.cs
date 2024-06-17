using DailyApp.WPF.Dtos;
using Prism.Commands;
using Prism.Mvvm;

namespace DailyApp.WPF.ViewModels
{
    public class WaitUCViewModel : BindableBase
    {
        public DelegateCommand ShowAddWaitComm { get; private set; }

        public WaitUCViewModel()
        {
            ShowAddWaitComm = new DelegateCommand(ShowAddWaitHandler);
            this.CreateWaitList();
        }

        private void ShowAddWaitHandler()
        {
            this.IsShowAddWait = true;
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

        private void CreateWaitList()
        {
            WaitList = new List<WaitInfoDto>();
            WaitList.Add(new WaitInfoDto() { WaitId = 1, Title = "待辦事項1", Content = "待辦事項1Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 2, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 3, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 4, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 5, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 6, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 7, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 8, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 9, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
            WaitList.Add(new WaitInfoDto() { WaitId = 10, Title = "待辦事項2", Content = "待辦事項2Content", Status = 0 });
        }

        private bool _isShowAddWait;

        public bool IsShowAddWait
        {
            get { return _isShowAddWait; }
            set
            {
                _isShowAddWait = value;
                RaisePropertyChanged();
            }
        }
    }
}