using DailyApp.WPF.Models;
using Prism.Mvvm;

namespace DailyApp.WPF.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel()
    {
        LeftMenuList = new List<LeftMenuInfo>();
        this.CreateMenu();
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
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "Home", MenuName = "首頁", ViewName = "IndexView" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookOutline", MenuName = "代辦事項", ViewName = "Waitiew" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookPlus", MenuName = "備忘錄", ViewName = "MemoView" });
        LeftMenuList.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "設置", ViewName = "SettingView" });
    }
}