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
}