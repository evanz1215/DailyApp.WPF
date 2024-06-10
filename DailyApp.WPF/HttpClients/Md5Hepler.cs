using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.HttpClients;

public class Md5Hepler
{
    public static string GetMd5(string content)
    {
        return string.Join(string.Empty, MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(content)).Select(x => x.ToString("x2")));
    }
}