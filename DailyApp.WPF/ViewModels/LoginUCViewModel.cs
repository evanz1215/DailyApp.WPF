using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DailyApp.WPF.ViewModels;

public class LoginUCViewModel : BindableBase, IDialogAware
{
    public string Title { get; set; } = "我的日常";

    public event Action<IDialogResult> RequestClose;

    public DelegateCommand LoginComm { get; set; }
    public DelegateCommand ShowLoginInfoComm { get; set; }
    public DelegateCommand ShowRegInfoComm { get; set; }

    public LoginUCViewModel()
    {
        LoginComm = new DelegateCommand(LoginHandler);
        ShowLoginInfoComm = new DelegateCommand(ShowLoginInfo);
        ShowRegInfoComm = new DelegateCommand(ShowRegInfo);
    }

    /// <summary>
    /// 登入方法
    /// </summary>
    private void LoginHandler()
    {
        // 模擬登入成功
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
    }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }

    /// <summary>
    /// 顯示內容索引
    /// </summary>
    private int _selectedIndex;

    /// <summary>
    /// 顯示內容索引
    /// </summary>
    public int SelectedIndex
    {
        get { return _selectedIndex; }
        set
        {
            _selectedIndex = value;
            RaisePropertyChanged();
        }
    }

    private void ShowLoginInfo()
    {
        this.SelectedIndex = 0;
    }

    private void ShowRegInfo()
    {
        this.SelectedIndex = 1;
    }

    /// <summary>
    /// 密碼
    /// </summary>
    private string _pwd;

    /// <summary>
    /// 密碼
    /// </summary>
    public string Pwd
    {
        get { return _pwd; }
        set
        {
            _pwd = value;
            RaisePropertyChanged();
        }
    }
}