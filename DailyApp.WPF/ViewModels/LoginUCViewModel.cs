using Prism.Commands;
using Prism.Services.Dialogs;

namespace DailyApp.WPF.ViewModels;

public class LoginUCViewModel : IDialogAware
{
    public string Title { get; set; } = "我的日常";

    public DelegateCommand LoginComm { get; set; }


    public event Action<IDialogResult> RequestClose;

    public LoginUCViewModel()
    {
        LoginComm = new DelegateCommand(LoginHandler);
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
}