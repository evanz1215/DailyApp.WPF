using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.Dtos;

public class AccountInfoDto
{
    public string Name { get; set; }
    public string Account { get; set; }
    public string Pwd { get; set; }
    public string ConfirmPwd { get; set; }
}