using DailyApp.WPF.Models;
using DailyApp.WPF.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace DailyApp.WPF.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private IRegionNavigationJournal _journal;
    private readonly IHttpClientService _httpClientService;

    public MainWindowViewModel(IRegionManager regionManager, IRegionNavigationJournal journal, IHttpClientService httpClientService)
    {
        _regionManager = regionManager;
        LeftMenuList = new List<LeftMenuInfo>();
        this.CreateMenu();
        NavigateComm = new DelegateCommand<LeftMenuInfo>(NavigateHandler);
        _journal = journal;

        GoBackComm = new DelegateCommand(GoBackHandler);
        GoForwardComm = new DelegateCommand(GoForwardHandler);
        _httpClientService = httpClientService;

        //_httpClientService.GetAsync("GitHub", "/api/sss");
    }

    #region 左側菜單

    private List<LeftMenuInfo> _leftMenuList;

    public List<LeftMenuInfo> LeftMenuList
    {
        get { return _leftMenuList; }
        set
        {
            _leftMenuList = value;
            RaisePropertyChanged();
        }
    }

    #endregion 左側菜單

    /// <summary>
    /// 創建菜單數據
    /// </summary>
    private void CreateMenu()
    {
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "Home", MenuName = "首頁", ViewName = "HomeUC" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookOutline", MenuName = "待辦事項", ViewName = "WaitUC" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookPlus", MenuName = "備忘錄", ViewName = "MemoUC" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "設置", ViewName = "SettingUC" });
    }

    #region 區域導航

    public DelegateCommand<LeftMenuInfo> NavigateComm { get; set; }
    public DelegateCommand GoBackComm { get; private set; }
    public DelegateCommand GoForwardComm { get; private set; }

    private void NavigateHandler(LeftMenuInfo leftMenuInfo)
    {
        if (leftMenuInfo == null || string.IsNullOrWhiteSpace(leftMenuInfo.ViewName))
        {
            return;
        }

        // 紀錄導航
        _regionManager.RequestNavigate("MainViewRegion", leftMenuInfo.ViewName, (callback) =>
        {
            _journal = callback.Context.NavigationService.Journal;
        });
    }

    private void GoBackHandler()
    {
        if (_journal != null && _journal.CanGoBack)
        {
            _journal.GoBack();
        }
    }

    private void GoForwardHandler()
    {
        if (_journal != null && _journal.CanGoForward)
        {
            _journal.GoForward();
        }
    }

    #endregion 區域導航
}