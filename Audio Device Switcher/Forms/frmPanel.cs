/**
 *  Code for the panel form.
 *  Copyright (C) 2015 Bitex Kuang
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */

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
using Audio_Device_Switcher.Resources;
using Audio_Device_Switcher.Widget;

namespace Audio_Device_Switcher.Forms {
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
            this.GetAudioDevices();

            this.panelList.Controls.Clear();

            for (int i = 0; i < devices.Count; i++) {
                var device = devices[i];
                ListItem item = new ListItem(device.GetID(), device.GetName(), device.GetDescription());
                if (device.IsCurrentDefault()) {
                    item.SetDefaultDevice(true);
                    this.lblCurrentDevice.Text = device.GetName();
                }
                item.SetOnClickListener(onListItemClickListener);
                this.panelList.Controls.Add(item);
            }

            this.RearrangeListItem();
        }

        /* 重新调整列表项的大小和位置 */
        private void RearrangeListItem() {
            for (int i = 0; i < this.panelList.Controls.Count; i++) {
                ListItem item = (ListItem)this.panelList.Controls[i];
                item.Width = this.panelList.ClientRectangle.Width;
                item.Top = 10 + item.Height * i;
            }
        }
        #endregion

        public frmPanel() {
            InitializeComponent();

            this.onListItemClickListener = new OnListItemClickListener(this);
        }

        #region 窗体事件处理方法
        private void frmPanel_Load(object sender, EventArgs e) {
            this.aboutMenuItem.Text = Strings.aboutMenuItem;
            this.audioDeviceMenuItem.Text = Strings.audioDeviceMenuItem;
            this.exitMenuItem.Text = Strings.exitMenuItem;
            this.labelCurrentDefault.Text = Strings.labelCurrentDefault;
            this.linkAudioDevice.Text = Strings.linkAudioDevice;

            this.Hide();
        }

        private void frmPanel_Shown(object sender, EventArgs e) {
            this.RefreshAudioDeviceList();
        }

        private void frmPanel_Deactivate(object sender, EventArgs e) {
            this.Hide();
        }

        private void frmPanel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }
        #endregion

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
            this.RearrangeListItem();
        }

        private void panelBottom_SizeChanged(object sender, EventArgs e) {
            this.linkAudioDevice.Left = (this.panelBottom.ClientRectangle.Width - this.linkAudioDevice.Width) / 2;
        }

        private void linkAudioDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("mmsys.cpl");
            this.Hide();
        }

        #region 菜单项
        private void audioDeviceMenuItem_Click(object sender, EventArgs e) {
            Process.Start("mmsys.cpl");
            this.Hide();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/7bitex/Audio-Device-Switcher");
        }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion

    }
}
