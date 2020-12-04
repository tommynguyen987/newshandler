using System;

namespace MyUtility.Data.Job
{
    public class Cohoivieclam
    {
        public static void PostRequest(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            var url = "http://cohoivieclam.vn/dang-nhap.html";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted;
            timer.Enabled = true;
            timer.Start();
        }

        private static void wbr_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (!wbr.Url.AbsoluteUri.Contains("quan-ly-ho-so-nguoi-tim-viec.html") && wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("aspnetForm");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("ctl00_ContentPlaceHolder1_txtemail").SetAttribute("value", UserInfo.Email);
                        wbr.Document.GetElementById("ctl00_ContentPlaceHolder1_txtmatkhau").SetAttribute("value", UserInfo.Password);
                        form.InvokeMember("submit");                        
                        form.SetAttribute("action", "quan-ly-ho-so-nguoi-tim-viec.html");
                        form.InvokeMember("submit");

                        wbr.DocumentCompleted -= wbr_DocumentCompleted;                        
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }            
        }      

        public static void RefreshNews(System.Windows.Forms.WebBrowser wbr)
        {
            System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("aspnetForm");
            int sumPostedNews = GetSumPostedNews(wbr);
            if (sumPostedNews == 1)
        	{
                string codeString = String.Format("$('.content_vl_hot input[type=\"checkbox\"]').val();");
                object value = wbr.Document.InvokeScript("eval", new[] { codeString });                
                
                string url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");
            }
            if (sumPostedNews == 2)
            {
                string codeString = String.Format("$('.content_vl_hot tr:first-child input[type=\"checkbox\"]').val();");
                object value = wbr.Document.InvokeScript("eval", new[] { codeString });
                string url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");

                codeString = String.Format("$('.content_vl_hot tr:last-child input[type=\"checkbox\"]').val();");
                value = wbr.Document.InvokeScript("eval", new[] { codeString });
                url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");
            }
            if (sumPostedNews == 3)
            {
                string codeString = String.Format("$('.content_vl_hot tr:first-child input[type=\"checkbox\"]').val();");
                object value = wbr.Document.InvokeScript("eval", new[] { codeString });
                string url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");

                codeString = String.Format("$('.content_vl_hot tr:first-child').next().children('td input[type=\"checkbox\"]').val();");
                value = wbr.Document.InvokeScript("eval", new[] { codeString });
                url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");

                codeString = String.Format("$('.content_vl_hot tr:last-child input[type=\"checkbox\"]').val();");
                value = wbr.Document.InvokeScript("eval", new[] { codeString });
                url = "http://www.cohoivieclam.vn/quanlyhoso.aspx?lm=" + value.ToString();
                form.SetAttribute("action", url);
                form.InvokeMember("submit");
            }            
        }

        static int GetSumPostedNews(System.Windows.Forms.WebBrowser wbr)
        {
            int sumPostedNews;
            try
            {
                string codeString = String.Format("$('.content_vl_hot input[type=\"checkbox\"]').length;");
                object value = wbr.Document.InvokeScript("eval", new[] { codeString });

                if (int.TryParse(value.ToString(), out sumPostedNews))
                {
                    return sumPostedNews;
                }
            }
            catch (Exception)
            {
                return 0;
            }            
            return 0;
        }
    }    
}
