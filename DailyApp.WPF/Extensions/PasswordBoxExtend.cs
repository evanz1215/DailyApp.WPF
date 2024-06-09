using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace DailyApp.WPF.Extensions;

/// <summary>
/// PasswordBox擴展屬性
/// </summary>
public class PasswordBoxExtend
{
    public static string GetPwd(DependencyObject obj)
    {
        return (string)obj.GetValue(PwdProperty);
    }

    public static void SetPwd(DependencyObject obj, string value)
    {
        obj.SetValue(PwdProperty, value);
    }

    // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PwdProperty =
        DependencyProperty.RegisterAttached("Pwd", typeof(string), typeof(PasswordBoxExtend), new PropertyMetadata("", OnPwdChanged));

    /// <summary>
    /// 自定義附加屬性發生變化改變PasswordBox的屬性值
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void OnPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        PasswordBox pwdBox = d as PasswordBox;
        string newPwd = (string)e.NewValue;

        if (pwdBox != null && pwdBox.Password != newPwd)
        {
            pwdBox.Password = newPwd;
        }
    }
}

/// <summary>
/// Password行為 Password變化自訂義附加屬性跟著變化
/// </summary>
public class PasswordBoxBehavior : Behavior<PasswordBox>
{
    /// <summary>
    /// 附加 注入事件
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PasswordChanged += OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = sender as PasswordBox;
        string password = PasswordBoxExtend.GetPwd(passwordBox); // 附加屬性的值

        if (passwordBox != null && passwordBox.Password != password)
        {
            PasswordBoxExtend.SetPwd(passwordBox, passwordBox.Password);
        }
    }

    /// <summary>
    /// 銷毀 移除事件
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.PasswordChanged -= OnPasswordChanged;
    }
}