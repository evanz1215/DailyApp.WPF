using DailyApp.WPF.Dtos;
using DailyApp.WPF.HttpClients;
using DailyApp.WPF.MsgEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DailyApp.WPF.ViewModels;

public class LoginUCViewModel : BindableBase, IDialogAware
{
    public string Title { get; set; } = "我的日常";

    public event Action<IDialogResult> RequestClose;

    public DelegateCommand LoginComm { get; set; }
    public DelegateCommand RegisterComm { get; set; }

    public DelegateCommand ShowLoginInfoComm { get; set; }
    public DelegateCommand ShowRegInfoComm { get; set; }

    private readonly HttpRestClient _httpRestClient;
    private readonly IEventAggregator _eventAggregator;

    public LoginUCViewModel(HttpRestClient httpRestClient, IEventAggregator eventAggregator)
    {
        LoginComm = new DelegateCommand(LoginHandler);
        RegisterComm = new DelegateCommand(RegisterHandler);
        ShowLoginInfoComm = new DelegateCommand(ShowLoginInfo);
        ShowRegInfoComm = new DelegateCommand(ShowRegInfo);

        AccountInfoDto = new AccountInfoDto();
        _httpRestClient = httpRestClient;
        _eventAggregator = eventAggregator;
    }

    /// <summary>
    /// 登入方法
    /// </summary>
    private void LoginHandler()
    {
        // 模擬登入成功
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
    }

    /// <summary>
    /// 註冊
    /// </summary>
    private void RegisterHandler()
    {
        if (string.IsNullOrWhiteSpace(AccountInfoDto.Account) || string.IsNullOrWhiteSpace(AccountInfoDto.Name) || string.IsNullOrWhiteSpace(AccountInfoDto.Pwd) || string.IsNullOrWhiteSpace(AccountInfoDto.ConfirmPwd))
        {
            // 改為發布消息
            //MessageBox.Show("請輸入完整資訊");
            _eventAggregator.GetEvent<MsgEvent>().Publish("請輸入完整資訊");
            return;
        }

        if (AccountInfoDto.Pwd != AccountInfoDto.ConfirmPwd)
        {
            // 改為發布消息
            //MessageBox.Show("請輸入完整資訊");
            _eventAggregator.GetEvent<MsgEvent>().Publish("請輸入完整資訊");
            return;
        }

        ApiRequest apiRequest = new ApiRequest();

        apiRequest.Method = RestSharp.Method.POST;
        apiRequest.Route = "Account/register";

        AccountInfoDto.Pwd = Md5Hepler.GetMd5(AccountInfoDto.Pwd);
        AccountInfoDto.ConfirmPwd = Md5Hepler.GetMd5(AccountInfoDto.ConfirmPwd);
        apiRequest.Parameters = AccountInfoDto;

        var response = _httpRestClient.Execute(apiRequest);

        if (response.ResultCode == 1)
        {
            //MessageBox.Show(response.Msg);
            _eventAggregator.GetEvent<MsgEvent>().Publish(response.Msg);
            SelectedIndex = 0; // 註冊成功後切換到登入頁面
        }
        else
        {
            //MessageBox.Show(response.Msg);
            _eventAggregator.GetEvent<MsgEvent>().Publish(response.Msg);
        }
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

    private AccountInfoDto _accountInfoDto;

    public AccountInfoDto AccountInfoDto
    {
        get { return _accountInfoDto; }
        set
        {
            _accountInfoDto = value;
            RaisePropertyChanged();
        }
    }
}