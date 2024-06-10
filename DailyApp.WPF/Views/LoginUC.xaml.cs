using DailyApp.WPF.MsgEvents;
using Prism.Events;
using System.Windows.Controls;

namespace DailyApp.WPF.Views;

/// <summary>
/// LoginUC.xaml 的互動邏輯
/// </summary>
public partial class LoginUC : UserControl
{
    private readonly IEventAggregator _eventAggregator;

    public LoginUC(IEventAggregator eventAggregator)
    {
        InitializeComponent();
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<MsgEvent>().Subscribe(SubHandler);
    }

    /// <summary>
    /// 訂閱後執行的操作
    /// </summary>
    /// <param name="msg"></param>
    private void SubHandler(string msg)
    {
        // 可以使用委託的方式，將訊息發送到LoginUCViewModel
        // 這樣就可以在ViewModel中處理訊息
        // 或者定義一個屬性把控件傳入ViewModel中
        RegLoginBar.MessageQueue.Enqueue(msg);
    }
}