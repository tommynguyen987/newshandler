using System;

namespace MyUtility.Data.Job
{
    public class Vietnamwork
    {
        public static void PostRequest(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            var url = "http://hcm.vieclam.24h.com.vn/ajax/account/dang_nhap_tk?txt_ten_dang_nhap=" + UserInfo.Email + "&txt_mat_khau=" + UserInfo.Password;
            wbr.Url = new Uri(url);
            try
            {
                System.Threading.Thread.Sleep(5 * 1000);

                url = "http://hcm.vieclam.24h.com.vn/ntv-trang-quan-tri-tin-tim-viec.html";
                wbr.Navigate(url);
                timer.Enabled = true;
                timer.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }
        }

        public static void RefreshNews(System.Windows.Forms.WebBrowser wbr)
        {
            int sumPostedNews = GetSumPostedNews(wbr);
            for (int i = 0; i < sumPostedNews; i++)
            {
                string codeString1 = String.Format("$('input[id=checkbox_ttv[" + i + "]]').val();");
                object value1 = wbr.Document.InvokeScript("eval", new[] { codeString1 });
                string[] arg = { value1.ToString() };
                wbr.Document.InvokeScript("ntv_quan_tri_lam_moi_1_ttv", arg);
                wbr.Refresh();
            }            
        }

        static int GetSumPostedNews(System.Windows.Forms.WebBrowser wbr)
        {
            int sumPostedNews;
            string codeString = String.Format("$('#tong_so_ttv_da_dang').val();");
            object value = wbr.Document.InvokeScript("eval", new[] { codeString });

            if (int.TryParse(value.ToString(), out sumPostedNews))
            {
                return sumPostedNews;
            }
            return 0;
        }
    }    
}
