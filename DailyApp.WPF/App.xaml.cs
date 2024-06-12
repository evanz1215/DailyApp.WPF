using DailyApp.WPF.HttpClients;
using DailyApp.WPF.ViewModels;
using DailyApp.WPF.Views;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Windows;

namespace DailyApp.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    /// <summary>
    /// 依賴注入
    /// </summary>
    /// <param name="containerRegistry"></param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterDialog<LoginUC, LoginUCViewModel>();
        containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));

        containerRegistry.RegisterForNavigation<HomeUC, HomeUCViewModel>();
        containerRegistry.RegisterForNavigation<WaitUC, WaitUCViewModel>();
        containerRegistry.RegisterForNavigation<MemoUC, MemoUCViewModel>();
        containerRegistry.RegisterForNavigation<SettingUC, SettingUCViewModel>();


    }

    /// <summary>
    /// 初始化
    /// </summary>
    //protected override void OnInitialized()
    //{
    //    // 判斷是否已經登入
    //    var dialog = Container.Resolve<IDialogService>();
    //    dialog.ShowDialog("LoginUC", callback =>
    //    {
    //        if (callback.Result != ButtonResult.OK)
    //        {
    //            Environment.Exit(0);
    //            return;
    //        }
    //        base.OnInitialized();
    //    });
    //}
}