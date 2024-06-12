namespace DailyApp.WPF.Models
{
    /// <summary>
    /// 首頁統計面板
    /// </summary>
    public class StatPanelInfo
    {
        /// <summary>
        /// 圖示
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 統計結果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 背景顏色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 跳轉
        /// </summary>
        public string ViewName { get; set; }
    }
}