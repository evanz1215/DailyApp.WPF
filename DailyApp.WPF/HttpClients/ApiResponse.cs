using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.HttpClients;
public class ApiResponse
{
    /// <summary>
    /// 結果編碼
    /// </summary>
    public int ResultCode { get; set; }

    /// <summary>
    /// 結果訊息
    /// </summary>
    public string Msg { get; set; }

    /// <summary>
    /// 數據
    /// </summary>
    public object ResultData { get; set; }
}
