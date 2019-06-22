using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoTemplate
{
    public partial class frmMain : Form
    {
        private Form child;
        private string childName;
        public frmMain()
        {
            child = new Form();
            InitializeComponent();
        }

        private void cmdButtonMain(object sender, EventArgs e)
        {
            var btnClicked = sender as Button;

            switch (btnClicked.Name)
            {
                case "btnMain1":
                    DisplayPage("Input", GetWindowName("Input"));
                    break;
                case "btnMain2":
                    DisplayPage("Login", GetWindowName("Login"));
                    break;
                case "btnMain3":
                    DisplayPage("Login", GetWindowName("Login"));
                    break;
                case "btnMain4":
                    DisplayPage("Login", GetWindowName("Login"));
                    break;
            }
        }


        protected void DisplayPage(string action, string windowName)
        {
            // child.name => current screen, Windowsname => new screen(clicked)
            int check = 0;
            ClearMainButtons();
            if (!child.Name.Equals(windowName) && !string.IsNullOrEmpty(windowName))
            {
                if (this.MdiChildren.Length <= 1)
                {
                    if (child.Visible)
                    {
                        child.Dispose();
                    }
                    switch (action)
                    {
                        case "Input":
                            btnMain1.BackColor = Color.Yellow;
                            child = new frmInput();
                            break;
                        case "btnMain2":
                            btnMain1.BackColor = Color.Yellow;
                            child = new frmLogin();
                            break;
                        case "btnMain3":
                            btnMain1.BackColor = Color.Yellow;
                            child = new frmLogin();
                            break;
                        case "Login":
                            btnMain1.BackColor = Color.Yellow;
                            child = new frmLogin();
                            break;
                        default:
                            check = 1;
                            break;
                    }

                    if (check != 1)
                    {
                        lblMainTitle.Text = "HỆ THỐNG QUẢN LÝ PHƯƠNG TIỆN - XUẤT NHẬP VẬT TƯ - [" + action + "]";
                        child.MdiParent = this;
                        child.StartPosition = FormStartPosition.Manual;
                        child.WindowState = FormWindowState.Normal;
                        child.Show();
                    }
                    childName = action;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DisplayPage("Input", GetWindowName("Input"));
        }

        protected string GetWindowName(string name)
        {
            switch (name)
            {
                case "Input":
                    return "frmInput";
                case "Login":
                    return "frmLogin";
                default:
                    return "frmInput";
            }
        }

        protected void ClearMainButtons()
        {
            btnMain1.BackColor = Color.Empty;
            btnMain2.BackColor = Color.Empty;
            btnMain3.BackColor = Color.Empty;
            btnMain4.BackColor = Color.Empty;

        }
    }


}
