using System.Windows;

namespace DailyApp.WPF.Views;

/// <summary>
/// MainWindow.xaml 的互動邏輯
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 最大窗口/還原窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMax_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowState = WindowState.Maximized;
        }
    }

    /// <summary>
    /// 關閉窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    /// <summary>
    /// 最小化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMin_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void ColorZone_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowState = WindowState.Maximized;
        }
    }


    /// <summary>
    /// 左側菜單選項改變後關閉菜單(可以用command寫)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lbMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        drawerHost.IsLeftDrawerOpen = false;
    }
}