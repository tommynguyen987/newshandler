using System;

namespace MyUtility.Data.News
{
    public class Rongbay
    {
        #region WebBrowser of WinForm
        public static void PostRequest(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            var url = "http://vietid.net/OauthServerV2/RegisterV2?app_key=07234206219b51690a3bc234115a34f2&clearsession=1&oauth_token=";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_PostRequest;            
            //timer.Enabled = true;
            //timer.Start();
        }

        private static void wbr_DocumentCompleted_PostRequest(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("show_connect");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("email").SetAttribute("value", Utility.RandomEmail());//UserInfo.Email = "buitran986@gmail.com");
                        wbr.Document.GetElementById("password").SetAttribute("value", UserInfo.Password = "12345678");
                        wbr.Document.GetElementById("confirm_password").SetAttribute("value", "12345678");
                        wbr.Document.GetElementById("full_name").SetAttribute("value", UserInfo.Fullname = "tester");
                        form.InvokeMember("submit");

                        wbr.DocumentCompleted -= wbr_DocumentCompleted_PostRequest;

                        AccountConfirm(wbr);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }
        }

        private static void AccountConfirm(System.Windows.Forms.WebBrowser wbr)
        {
            var url = "https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/&hl=vi";
            wbr.Url = new Uri(url);
            wbr.ScriptErrorsSuppressed = true;
            wbr.DocumentCompleted += wbr_DocumentCompleted_AccountConfirm;            
        }

        public static void RedirectActiveLink(System.Windows.Forms.WebBrowser wbr, System.Windows.Forms.Timer timer)
        {
            do
            {
                timer.Stop();    
                HttpSession session = new HttpSession();
                string content = session.GetMethodDownload(wbr.Url.AbsoluteUri, true, false, false, true);
                System.Text.StringBuilder scriptCode = new System.Text.StringBuilder();
                scriptCode.Append("function ExecuteJS(){");
                scriptCode.Append("    $('.Cp .xS .y6').each(function(){");
                scriptCode.Append("        alert('111');");
                scriptCode.Append("        var t = $(this).children(\"span:first-child\").html();");
                scriptCode.Append("        if(t.indexOf(\"Kích hoạt tài khoản VietID\") != -1){");
                scriptCode.Append("            alert('2222');");
                scriptCode.Append("             $('.aqw').click(function(){");
                scriptCode.Append("                alert('333');");
                scriptCode.Append("            });");
                scriptCode.Append("        }");
                scriptCode.Append("    });");
                scriptCode.Append("}");
                //wbr.Document.InvokeScript("eval", new Object[] { scriptCode.ToString() });
                wbr.Document.InvokeScript("execScript", new Object[] { scriptCode.ToString(), "JavaScript" });
                wbr.Document.InvokeScript("ExecuteJS");
                System.Threading.Thread.Sleep(7000);                
            } while (wbr.DocumentText.IndexOf("class=\"UI\"") == -1);
            //Login();
        }
        
        private static void wbr_DocumentCompleted_AccountConfirm(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wbr = sender as System.Windows.Forms.WebBrowser;
            try
            {
                if (wbr.ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.HtmlElement form = wbr.Document.GetElementById("gaia_loginform");
                    if (form != null)
                    {
                        wbr.Document.GetElementById("Email").SetAttribute("value", UserInfo.Email = "buitran986@gmail.com");
                        wbr.Document.GetElementById("Passwd").SetAttribute("value", UserInfo.Password = "yeuem1234567890");
                        form.InvokeMember("submit");
                        wbr.DocumentCompleted -= wbr_DocumentCompleted_AccountConfirm;
                    }

                    //if (wbr.Url.AbsoluteUri.IndexOf("/#inbox") != -1)
                    //{
                    //    System.Threading.Thread.Sleep(7000);
                    //    RedirectActiveLink(wbr);
                    //    wbr.DocumentCompleted -= wbr_DocumentCompleted_AccountConfirm;
                    //    Login();
                    //}
                }                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error!" + System.Environment.NewLine + ex.Message);
            }
        }

        #endregion
        
        public static void PostRequest(Gecko.GeckoWebBrowser browser)
        {
            var url = "http://vietid.net/OauthServerV2/RegisterV2?app_key=07234206219b51690a3bc234115a34f2&clearsession=1&oauth_token=";
            browser.Navigate(url);
            browser.DocumentCompleted += browser_DocumentCompleted_PostRequest;
        }

        private static void browser_DocumentCompleted_PostRequest(object sender, EventArgs e)
        {
            Gecko.GeckoWebBrowser browser = sender as  Gecko.GeckoWebBrowser;
            try
            {
                Gecko.DOM.GeckoInputElement email = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("email")[0].DomObject);
                email.Value = UserInfo.Email = Utility.RandomEmail();
                Gecko.DOM.GeckoInputElement password = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("password")[0].DomObject);
                password.Value = UserInfo.Password = "12345678";
                Gecko.DOM.GeckoInputElement confirmpassword = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("confirm_password")[0].DomObject);
                confirmpassword.Value = UserInfo.Password = "12345678";
                Gecko.DOM.GeckoInputElement fullname = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("full_name")[0].DomObject);
                fullname.Value = UserInfo.Fullname = "tester";
                browser.Navigate("javascript:void(document.forms[0].submit())");
                browser.DocumentCompleted -= browser_DocumentCompleted_PostRequest;

                AccountConfirm(browser);                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when posting registration request!" + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static void AccountConfirm(Gecko.GeckoWebBrowser browser)
        {
            var url = "https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/&hl=vi";
            browser.Navigate(url);
            browser.DocumentCompleted += browser_DocumentCompleted_AccountConfirm;
        }

        private static void browser_DocumentCompleted_AccountConfirm(object sender, EventArgs e)
        {
            Gecko.GeckoWebBrowser browser = sender as Gecko.GeckoWebBrowser;
            try
            {
                Gecko.DOM.GeckoInputElement email = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("Email")[0].DomObject);
                email.Value = UserInfo.Email = "buitran986@gmail.com";
                Gecko.DOM.GeckoInputElement password = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("Passwd")[0].DomObject);
                password.Value = UserInfo.Password = "yeuem1234567890";                
                browser.Navigate("javascript:void(document.forms[0].submit())");
                browser.DocumentCompleted -= browser_DocumentCompleted_AccountConfirm;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when confirming account!" + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
                
        public static void RedirectActiveLink(Gecko.GeckoWebBrowser browser, System.Windows.Forms.Timer timer1, System.Windows.Forms.Timer timer2 )
        {
            try
            {
                do
                {
                    timer2.Stop();
                    timer2.Enabled = false;                  
                    System.Text.StringBuilder scriptCode = new System.Text.StringBuilder();                    
                    scriptCode.Append("$('.Cp .xS .y6').each(function(){");
                    scriptCode.Append("    alert('111');");
                    scriptCode.Append("    var t = $(this).children('span:first-child').html();");
                    scriptCode.Append("    if(t.indexOf(\"Kích hoạt tài khoản VietID\") != -1){");
                    scriptCode.Append("        alert('2222');");
                    scriptCode.Append("        $(this).parent('.xT').parent('.xS').parent('.a4W').parent('.zA').addClass('aqw');");
                    scriptCode.Append("        $('.aqw').click(function(){");
                    scriptCode.Append("            alert('333');");
                    scriptCode.Append("        });");
                    scriptCode.Append("    }");
                    scriptCode.Append("});");     
                    var jqExecutor = new Gecko.JQuery.JQueryExecutor(browser.Window);
                    jqExecutor.ExecuteJQuery(scriptCode.ToString());                    
                } while (browser.Document.Body.InnerHtml.IndexOf("class=\"UI\"") == -1);                
                //Login(browser, timer1);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when redirecting link!" + System.Environment.NewLine + ex.Message,"Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                
            }                       
        }

        private static void Login(Gecko.GeckoWebBrowser browser, System.Windows.Forms.Timer timer1)
        {
            try
            {
                var url = "http://vietid.net/login";
                browser.Navigate(url);
                browser.DocumentCompleted += browser_DocumentCompleted_Login;
                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when logging in!" + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static void browser_DocumentCompleted_Login(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Gecko.GeckoWebBrowser browser = sender as Gecko.GeckoWebBrowser;
            try
            {
                Gecko.DOM.GeckoInputElement email = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("email_login")[0].DomObject);
                email.Value = UserInfo.Email;
                Gecko.DOM.GeckoInputElement password = new Gecko.DOM.GeckoInputElement(browser.Document.GetElementsByName("password_login")[0].DomObject);
                password.Value = UserInfo.Password;                
                browser.Navigate("javascript:void(document.forms[0].submit())");
                browser.DocumentCompleted -= browser_DocumentCompleted_Login;
                System.Threading.Thread.Sleep(3000);
                LoginRedirect(browser);         
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when posting registration request!" + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private static void LoginRedirect(Gecko.GeckoWebBrowser browser)
        {
            var url = "http://vietid.net/Authentication/Authenticate?oauth_token=dm5pX3Rva2VuPTAuMjc0MTIyMDAgMTQzMTk0MTk4NSs0NzUzNjQ4MjE=&callback=http://rongbay.com/mingid/mingid/ming_reload.php";
            browser.Navigate(url);
            browser.DocumentCompleted += browser_DocumentCompleted_LoginRedirect;
        }

        private static void browser_DocumentCompleted_LoginRedirect(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Gecko.GeckoWebBrowser browser = sender as Gecko.GeckoWebBrowser;
            try
            {
                browser.Navigate("javascript:void(document.forms[0].submit())");
                browser.DocumentCompleted -= browser_DocumentCompleted_LoginRedirect;
                System.Threading.Thread.Sleep(3000);
                browser.Navigate("http://rongbay.com/");
                HttpSession session = new HttpSession();
                session.Cookies.Add(new System.Net.Cookie("cookie",browser.Document.Cookie));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error occurs when confirming account!" + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
