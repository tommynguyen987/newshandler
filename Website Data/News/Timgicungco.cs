using System;

namespace MyUtility.Data.News
{
    public class Timgicungco
    {
        public static void PostRequest(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            var url = "http://vietid.net/OauthServerV2/RegisterV2?app_key=07234206219b51690a3bc234115a34f2&clearsession=1&oauth_token=";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_PostRequest;
            timer.Enabled = true;
            timer.Start();
        }

        private static void wbr_DocumentCompleted_PostRequest(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (!wbr.Url.AbsoluteUri.Contains("quan-ly-ho-so-nguoi-tim-viec.html") && wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("show_connect");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("email").SetAttribute("value", "tommynguyen987@gmail.com");//(UserInfo.Email="tommynguyen987@gmail.com")
                        wbr.Document.GetElementById("password").SetAttribute("value", "12345678");//(UserInfo.Password = "12345678")
                        wbr.Document.GetElementById("confirm_password").SetAttribute("value", "12345678");
                        wbr.Document.GetElementById("full_name").SetAttribute("value", "tester");//(UserInfo.Fullname = "tester")
                        form.InvokeMember("submit");
                        string script = "<script> function HideForm() { $('#show_connect').hide(); } </script>";
                        string css= "<style> .modal-window { position: fixed; top: 50%; left: 50%; margin: 0px; padding: 0px; z-index: 102; } </style>";
                        string popupWindow = "<div id=\"myModal\" class=\"modal-window\" style=\"width:600px; height:800px; margin-top:-266.6666666666667px; margin-left:-300px;\"><iframe scrolling=\"no\" allowtransparency=\"true\" src=\"http://vietid.net/Authentication/Registermobile?app_key=07234206219b51690a3bc234115a34f2&amp;call_back=http://rongbay.com/mingid/ming_return.php\" style=\"width:700px;height:600px\" frameborder=\"0\"></iframe></div>";
                        wbr.Document.CreateElement(script+css+popupWindow);
                        wbr.Document.InvokeScript("HideForm()");
                        
                        //form.SetAttribute("action", "http://vietid.net/Authentication/Registermobile?app_key=07234206219b51690a3bc234115a34f2&call_back=http://rongbay.com/mingid/ming_return.php");
                        //form.InvokeMember("submit");

                        wbr.DocumentCompleted -= wbr_DocumentCompleted_PostRequest;
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
