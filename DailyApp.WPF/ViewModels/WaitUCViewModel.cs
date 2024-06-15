using DailyApp.WPF.Dtos;
using Prism.Mvvm;

namespace DailyApp.WPF.ViewModels
{
    public class WaitUCViewModel : BindableBase
    {
        public WaitUCViewModel()
        {
            this.CreateWaitList();
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
    }
}