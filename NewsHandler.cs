using MyUtility.Data.Job;
using MyUtility.Data.News;
using Gecko;
using Gecko.DOM;
using System;
using System.Windows.Forms;

namespace MyUtility
{
    public partial class NewsHandler : Form
    {
        #region Website info
        static string[] listWebsiteTypes = { "----- Vui lòng chọn loại đăng tin -----", "Đăng Tin Việc Làm", "Đăng Tin Rao Vặt" };

        static string[] listJobWebsites = 
        { 
            "----- Vui lòng chọn trang web -----",
            "http://www.vietnamworks.com", "http://www.careerlink.vn", "http://www.timviecnhanh.com", "http://www.mywork.com.vn", "http://www.1001vieclam.com", 
            "http://www.vieclam.24h.com.vn", "http://www.careerbuilder.vn", "http://www.cohoivieclam.vn", "http://ketnoisunghiep.vn/" 
        };
        
        static string[] listNewsWebsites = 
        { 
            "----- Vui lòng chọn trang web -----",
            /*"http://dropcoverholdon.net/", "http://annoncesjaunes.org/", "http://ecaumex.org/", "http://fguimp.org/", "http://filandolarete.org/", 
            "http://future-coasts.org/", "http://hartfordfavs.org/", "http://mail-scanner.biz/", "http://studyinpolska.org/", "http://sulzerdowdingandmills.co.uk/",
            "http://theatreview.co/", "http://transplantwisconsin.org/", "http://westeros.biz/", "http://2fa4d.com/", "http://abnehm-wunder.com/",
            "http://adserverplus.org/", "http://assemblymedia.co.uk/", "http://ateliersduchangement.com/", "http://axogreen.com/", "http://camaraastorga.org/",
            "http://capecodcvb.org/", "http://capitulum-trogir.org/", "http://ced-hr.com/", "http://centreasia.net/", "http://covadis-lr.org/",
            "http://duhanhviet.org/", "http://ecctd2013.org/", "http://fedexinstitute.com/", "http://fedexinstitute.org/", "http://fondculture.com/",
            "http://gailjuiceplus.com/", "http://globaldialysis.mobi/", "http://globus-bilder.com/", "http://guifx.org/", "http://joug.co/",
            "http://jrodriguezjuiceplus.com/", "http://justrentaldubai.com/", "http://lesateliersduchangement.com/", "http://lyricsfreak.org/", "http://matter-aerosol.net/",
            "http://miltenyi-microarray.com/", "http://mirnaservice.com/", "http://mygreenusb.com/", "http://ozetest.com/", "http://photoscience.org/",
            "http://princejuiceplus.com/", "http://regioncusco.net/", "http://sciencecentertvny.org/", "http://sctechvalley.org/", "http://sjbbjl.com/",
            "http://sleep4life.org/", "http://srisaivignan.org/", "http://statesvilledistrictumc.org/", "http://svenskastatoil.net/", "http://svenska-statoil.net/",
            "http://trademark-expo.com/", */

            "http://rongbay.com", "http://raocucnhanh.com", "http://raovat.net", "http://raovatkhuyenmai.com", 
            "http://vatgia.com/raovat", "http://www.raovat123.com", "http://raovatgiamgia.com", "http://bvn.vn", "http://atintot.com",
            "http://webraovat.com", "http://muabanraovat.com", "http://muaban.net", "http://www.quangcaoso.vn", "http://colien.vn",
            "http://www.bingzon.com", "http://chophien.com", "http://timgicungco.com", "http://www.raovat.vn", "http://tinraovat.net",
            "http://chodientu.vn", "http://enbac.com", "http://www.choso.vn", "http://baomuabanraovat.com", "http://muaban-raovat.net",
            "http://webmuaban.vn", "http://muare.vn", "http://raovathot.com", "http://chosaigon.com", "http://muaban.com.vn",
            "http://raovatdaugia.com", "http://bang.vn", "http://timkiemraovat.com", "http://raovatquangcao.net", "http://raovat.vnexpress.net",
            "http://shoplink.vn","http://vaolaco.com", "http://www.chotot.vn"
        };
        #endregion
        
        public NewsHandler()
        {
            InitializeComponent();
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "xulrunner");
            Xpcom.Initialize(path);
            //StartUpManager.AddApplicationToCurrentUserStartup("NewsHandler");            
        }

        #region Methods 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);
        [Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        private void EnableFunctions(bool isEnabled)
        {
            btnCreateNews.Enabled = isEnabled;
            btnDeleteNews.Enabled = isEnabled;
            btnUpdateNews.Enabled = isEnabled;
        }

        private void FillListWebsites()
        {
            if (cbListWebsiteTypes.SelectedIndex == 0)
            {
                cbListWebsites.DataSource = null;
                btnHandle.Enabled = false;
            }
            else if (cbListWebsiteTypes.SelectedIndex == 1)
            {
                cbListWebsites.DataSource = listJobWebsites;
                cbListWebsites.SelectedIndex = 0;
            }
            else
            {
                cbListWebsites.DataSource = listNewsWebsites;
                cbListWebsites.SelectedIndex = 0;
            }
        }

        private void WindowsInSystemTray(bool inTray)
        {
            if (inTray)
            {
                this.ShowInTaskbar = false;
                AnimateWindow(this.Handle, 50, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(500);
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                AnimateWindow(this.Handle, 700, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_ACTIVATE);
                this.Activate();
                myNotifyIcon.Visible = false;
            }
        }

        private void CreateNews()
        {

        }
        
        #endregion

        private void NewsHandler_Load(object sender, EventArgs e)
        {
            cbListWebsiteTypes.DataSource = listWebsiteTypes;
            cbListWebsiteTypes.SelectedIndex = 0;
            myNotifyIcon.BalloonTipText = "Your application is still working" + System.Environment.NewLine + "Double click into icon to show application.";
            EnableFunctions(false);
            //WindowsInSystemTray(true);
        }
        
        private void btnHandle_Click(object sender, EventArgs e)
        {
            #region Job Posts
            if (cbListWebsiteTypes.SelectedIndex == 1)
            {
                if (chkHandleEveryNews.Checked) //Xử lý từng trang web đăng tin việc làm
                {
                    switch (cbListWebsites.SelectedIndex)
                    {
                        case 1:
                            Vietnamwork.PostRequest(webBrowser1, timer1);
                            break;
                        case 2:
                            Careerlink.PostRequest(webBrowser1, timer1);
                            break;
                        case 3:
                            Timviecnhanh.PostRequest(webBrowser1, timer1);
                            break;
                        case 4:
                            Mywork.PostRequest(webBrowser1, timer1);
                            break;
                        case 5:
                            Vieclam1001.PostRequest(webBrowser1, timer1);
                            break;
                        case 6:
                            Vieclam24h.PostRequest(webBrowser1, timer1);
                            break;
                        case 7:
                            Careerbuilder.PostRequest(webBrowser1, timer1);
                            break;
                        case 8:
                            Cohoivieclam.PostRequest(webBrowser1, timer1);
                            break;      
                        case 9:
                             Ketnoisunghiep.PostRequest(webBrowser1, timer1);
                            break;      
                        default:
                            MessageBox.Show("Vui lòn chọn trang web đăng tin!");
                            break;
                    }
                }
                else //Xử lý tất cả các trang web đăng tin việc làm theo hàng đợi
                {

                }
            }
            #endregion

            #region News Posts
            else if (cbListWebsiteTypes.SelectedIndex == 2)
            {
                if (chkHandleEveryNews.Checked) //Xử lý từng trang web đăng tin rao vặt
                {
                    switch (cbListWebsites.SelectedIndex)
                    {
                        case 1://57:
                            Rongbay.PostRequest(geckoWebBrowser1);                            
                            timer2.Enabled = true;
                            timer2.Start();
                            break;
                        case 2://58:
                            Raocucnhanh.PostRequest(webBrowser1, timer1);
                            break;
                        case 3://59:
                            RaovatNet.PostRequest(webBrowser1, timer1);
                            break;
                        case 4://60:
                            Raovatkhuyenmai.PostRequest(webBrowser1, timer1);
                            break;
                        case 5://61:
                            Vatgiaraovat.PostRequest(webBrowser1, timer1);
                            break;
                        case 6://62:
                            Raovat123.PostRequest(webBrowser1, timer1);
                            break;
                        case 7://63:
                            Raovatgiamgia.PostRequest(webBrowser1, timer1);
                            break;
                        case 8://64:
                            Bvn.PostRequest(webBrowser1, timer1);
                            break;
                        case 9://65:
                            Atintot.PostRequest(webBrowser1, timer1);
                            break;
                        case 10://66:
                            Webraovat.PostRequest(webBrowser1, timer1);
                            break;
                        case 11://67:
                            MuabanraovatCom.PostRequest(webBrowser1, timer1);
                            break;
                        case 12://68:
                            MuabanNet.PostRequest(webBrowser1, timer1);
                            break;
                        case 13://69:
                            Quangcaoso.PostRequest(webBrowser1, timer1);
                            break;
                        case 14://70:
                            Colien.PostRequest(webBrowser1, timer1);
                            break;
                        case 15://71:
                            Bingzon.PostRequest(webBrowser1, timer1);
                            break;
                        case 16://72:
                            Chophien.PostRequest(webBrowser1, timer1);
                            break;
                        case 17://73:
                            Timgicungco.PostRequest(webBrowser1, timer1);
                            break;
                        case 18://74:
                            RaovatVn.PostRequest(webBrowser1, timer1);
                            break;
                        case 19://75:
                            Tinraovat.PostRequest(webBrowser1, timer1);
                            break;
                        case 20://76:
                            Chodientu.PostRequest(webBrowser1, timer1);
                            break;
                        case 21://77:
                            Enbac.PostRequest(webBrowser1, timer1);
                            break;
                        case 22://78:
                            Choso.PostRequest(webBrowser1, timer1);
                            break;
                        case 23://79:
                            Baomuabanraovat.PostRequest(webBrowser1, timer1);
                            break;
                        case 24://80:
                            MuabanraovatNet.PostRequest(webBrowser1, timer1);
                            break;
                        case 25://81:
                            Webmuaban.PostRequest(webBrowser1, timer1);
                            break;
                        case 26://82:
                            Muare.PostRequest(webBrowser1, timer1);
                            break;
                        case 27://83:
                            Raovathot.PostRequest(webBrowser1, timer1);
                            break;
                        case 28://84:
                            Chosaigon.PostRequest(webBrowser1, timer1);
                            break;
                        case 29://85:
                            MuabanComVn.PostRequest(webBrowser1, timer1);
                            break;
                        case 30://86:
                            Raovatdaugia.PostRequest(webBrowser1, timer1);
                            break;
                        case 31://87:
                            Bang.PostRequest(webBrowser1, timer1);
                            break;
                        case 32://88:
                            Timkiemraovat.PostRequest(webBrowser1, timer1);
                            break;
                        case 33://89:
                            Raovatquangcao.PostRequest(webBrowser1, timer1);
                            break;
                        case 34://90:
                            RaovatVnExpress.PostRequest(webBrowser1, timer1);
                            break;
                        case 35://91:
                            Shoplink.PostRequest(webBrowser1, timer1);
                            break;
                        case 36://92:
                            Vaolaco.PostRequest(webBrowser1, timer1);
                            break;
                        case 37://93:
                            Chotot.PostRequest(webBrowser1, timer1);
                            break;
                        default:
                            MessageBox.Show("Vui lòn chọn trang web đăng tin!");
                            break;
                    }                    
                }
                else //Xử lý tất cả các trang web đăng tin rao vặt theo hàng đợi
                {

                }
            }
            #endregion

            EnableFunctions(true);
        }   

        private void cbListWebsiteTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkHandleEveryNews.Checked)
            {
                cbListWebsites.Enabled = true;
                FillListWebsites();
            }
            else
            {
                cbListWebsites.Enabled = false;
                if (cbListWebsiteTypes.SelectedIndex == 0)
                {
                    btnHandle.Enabled = false;
                }
                else
                {
                    btnHandle.Enabled = true;
                }
            }            
            EnableFunctions(false);
        }

        private void cbListWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListWebsites.SelectedIndex == 0)
            {
                btnHandle.Enabled = false;
            }
            else
            {
                btnHandle.Enabled = true;
            }
            EnableFunctions(false);
        }

        private void chkHandleEveryNews_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHandleEveryNews.Checked)
            {
                cbListWebsites.Enabled = true;
                FillListWebsites();
            }
            else
            {
                cbListWebsites.DataSource = null;
                cbListWebsites.Enabled = false;
                if (cbListWebsiteTypes.SelectedIndex == 0)
                {
                    btnHandle.Enabled = false;
                }
                else
                {
                    btnHandle.Enabled = true;
                }
            }
        }   

        private void btnCreateNews_Click(object sender, EventArgs e)
        {
            CreateNews();
        }

        private void btnDeleteNews_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateNews_Click(object sender, EventArgs e)
        {

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbListWebsiteTypes.SelectedIndex == 1)
            {
                switch (cbListWebsites.SelectedIndex)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Vieclam24h.RefreshNews(webBrowser1);
                        break;
                    case 7:
                        break;
                    case 8:
                        Cohoivieclam.RefreshNews(webBrowser1);
                        break;
                    default:
                        Vieclam24h.RefreshNews(webBrowser1);
                        break;
                }
            }
            else
            {
                
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (geckoWebBrowser1.Url.AbsoluteUri.IndexOf("/#inbox") != -1)
            {
                Rongbay.RedirectActiveLink(geckoWebBrowser1, timer1, timer2);                
            }
        }   
    
        private void NewsHandler_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                WindowsInSystemTray(true);                
            }
        }

        private void NewsHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //WindowsInSystemTray(true);
        }   

        private void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowsInSystemTray(false);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsInSystemTray(false);
        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myNotifyIcon.Dispose();
            this.Dispose();
        }                                                       
    }
}
