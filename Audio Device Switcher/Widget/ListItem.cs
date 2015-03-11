using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audio_Device_Switcher.Widget {
    public partial class ListItem : UserControl {

        // 点击事件的listener
        public interface IOnClickListener {
            void OnClick(int id);
        }

        bool mouseHover = false;

        Font NameFont = new Font("Microsoft YaHei", 9);
        Font DefaultNameFont = new Font("Microsoft YaHei", 9, FontStyle.Bold);

        Color HoverBackgroundColor = Color.FromArgb(229, 243, 251);
        Color HoverBorderColor = Color.FromArgb(112, 192, 231);
        Color NormalBackgroundColor = Color.Transparent;

        private IOnClickListener onClickListener;

        int id;
        string name;
        string description;
        bool defaultDevice = false;

        #region 获取方法
        public int GetID() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public string GetDescription() {
            return description;
        }

        public bool IsDefaultDevice() {
            return defaultDevice;
        }
        #endregion

        #region 设置方法
        public void SetID(int id) {
            this.id = id;
        }

        public void SetOnClickListener(IOnClickListener listener) {
            this.onClickListener = listener;
        }

        public void SetName(string name) {
            this.name = name;

            this.lblName.Text = name;
        }

        public void SetDescription(string description) {
            this.description = description;

            this.lblDescription.Text = description;
        }

        public void SetDefaultDevice(bool defaultDevice) {
            this.defaultDevice = defaultDevice;

            if (defaultDevice) {
                this.lblName.Font = DefaultNameFont;
            } else {
                this.lblName.Font = NameFont;
            }
        }
        #endregion

        #region 构造方法
        public ListItem() {
            InitializeComponent();
        }

        public ListItem(int id, string name, string description) {
            InitializeComponent();

            this.id = id;
            this.name = name;
            this.description = description;
            this.defaultDevice = false;

            this.lblName.Text = name;
            this.lblDescription.Text = description;
            lblName.Font = NameFont;
        }

        public ListItem(int id, string name, string description, bool defaultDevice) {
            InitializeComponent();

            this.id = id;
            this.name = name;
            this.description = description;
            this.defaultDevice = defaultDevice;

            this.lblName.Text = name;
            this.lblDescription.Text = description;
            if (defaultDevice) {
                lblName.Font = DefaultNameFont;
            } else {
                lblName.Font = NameFont;
            }
        }
        #endregion

        #region 鼠标事件
        private void ListItem_MouseClick(object sender, MouseEventArgs e) {
            if (this.onClickListener != null) {
                this.onClickListener.OnClick(this.id);
            }
        }

        private void ListItem_MouseEnter(object sender, EventArgs e) {
            this.mouseHover = true;
            this.BackColor = HoverBackgroundColor;
        }

        private void ListItem_MouseHover(object sender, EventArgs e) {
            this.mouseHover = true;
            this.BackColor = HoverBackgroundColor;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e) {
            if (this.GetChildAtPoint(this.PointToClient(MousePosition)) == null) {
                this.mouseHover = false;
                this.BackColor = NormalBackgroundColor;
            }
        }
        #endregion

        private void ListItem_Paint(object sender, PaintEventArgs e) {
            if (mouseHover) {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.HoverBorderColor, ButtonBorderStyle.Solid);
            }
        }
    }
}
