using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Audio_Device_Switcher.Data;
using Audio_Device_Switcher.Widget;

namespace Audio_Device_Switcher {
    public partial class frmPanel : Form {

        /* 列表项单击事件的listener */
        private class OnListItemClickListener : ListItem.IOnClickListener {
            private frmPanel form; // 用于刷新设备列表

            public OnListItemClickListener(frmPanel form) {
                this.form = form;
            }

            public void OnClick(int id) {
                SetDefaultAudioDevice(id);
                form.RefreshAudioDeviceList();
            }
        }

        private List<Device> devices = new List<Device>();
        private OnListItemClickListener onListItemClickListener;

        #region 音频设备相关方法
        /* 获取音频设备列表 */
        private void GetAudioDevices() {
            devices.Clear();
            var loadDeviceListProc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "EndPointController.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            loadDeviceListProc.Start();
            StringCollection values = new StringCollection();

            loadDeviceListProc.OutputDataReceived += (s, args) => {
                lock (values) {
                    values.Add(args.Data);
                }
            };
            loadDeviceListProc.BeginOutputReadLine();
            loadDeviceListProc.WaitForExit();

            foreach (string line in values) {
                if (line != null) {
                    string[] strs = line.Split('|');
                    // 提取设备名和描述
                    Device device = new Device(Int32.Parse(strs[0]), strs[1], strs[2], (Int32.Parse(strs[3]) == 1) ? true : false);
                    devices.Add(device);
                }
            }
        }

        /* 设置默认音频设备 */
        private static void SetDefaultAudioDevice(int id) {
            var setDefaultDeviceProc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "EndPointController.exe",
                    Arguments = id.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            setDefaultDeviceProc.Start();
            setDefaultDeviceProc.WaitForExit();
        }
        #endregion

        #region UI
        /* 刷新音频设备列表 */
        private void RefreshAudioDeviceList() {
            GetAudioDevices();

            this.panelList.Controls.Clear();

            for (int i = 0; i < devices.Count; i++) {
                var device = devices[i];
                ListItem item = new ListItem(device.GetID(), device.GetName(), device.GetDescription());
                if (device.IsCurrentDefault()) {
                    item.SetDefaultDevice(true);
                    this.lblCurrentDevice.Text = device.GetName();
                }
                item.SetOnClickListener(onListItemClickListener);
                item.Width = this.panelList.ClientRectangle.Width;
                item.Top = item.Height * i;
                this.panelList.Controls.Add(item);
            }
        }
        #endregion

        public frmPanel() {
            InitializeComponent();

            this.onListItemClickListener = new OnListItemClickListener(this);
        }

        private void frmPanel_Load(object sender, EventArgs e) {
            this.Hide();
        }

        private void frmPanel_Shown(object sender, EventArgs e) {
            RefreshAudioDeviceList();
        }

        private void frmPanel_Deactivate(object sender, EventArgs e) {
            this.Hide();
        }

        private void frmPanel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                if (!this.Visible) {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    if (MousePosition.Y < Screen.PrimaryScreen.WorkingArea.Bottom) {
                        this.Top = MousePosition.Y - this.Height - 16;
                    } else {
                        this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - 8 - this.Height;
                    }
                    this.Left = MousePosition.X - this.Width / 2;
                    //this.Left = Screen.PrimaryScreen.WorkingArea.Right - 8 - this.Width;
                    this.Activate();
                }
            }
        }

        private void panelList_SizeChanged(object sender, EventArgs e) {
            // 列表Panel大小变化时，调整每个列表项的大小和位置
            for (int i = 0; i < this.panelList.Controls.Count; i++) {
                ListItem item = (ListItem)this.panelList.Controls[i];
                item.Width = this.panelList.ClientRectangle.Width;
                item.Top = item.Height * i;
            }
        }

        private void linkAudioDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("mmsys.cpl");
            this.Hide();
        }

        #region 菜单项
        private void exitMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void audioDeviceMenuItem_Click(object sender, EventArgs e) {
            Process.Start("mmsys.cpl");
            this.Hide();
        }
        #endregion

    }
}
