using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCustomControl
{
    public partial class CustomControl1 : Control
    {
        VScrollBar _vScrollBar;
        public CustomControl1()
        {
            InitializeComponent();
            _vScrollBar = new VScrollBar();
            //this.ControlAdded += CustomControl1_ControlAdded;
        }

        private void CustomControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            UpdateRectanglePositioning();
        }

        [DefaultValue(true), Category("Hex"), Description("Gets or sets the visibility of a vertical scroll bar.")]
        public bool VScrollBarVisible
        {
            get { return this._vScrollBarVisible; }
            set
            {
                if (_vScrollBarVisible == value)
                    return;

                _vScrollBarVisible = value;

                if (_vScrollBarVisible)
                    Controls.Add(_vScrollBar);
                else
                    Controls.Remove(_vScrollBar);

                UpdateRectanglePositioning();
                //UpdateScrollSize();

                //OnVScrollBarVisibleChanged(EventArgs.Empty);
            }
        }
        bool _vScrollBarVisible;

        void UpdateRectanglePositioning()
        {
            _vScrollBar.Left = this.Width - _vScrollBar.Width;
            _vScrollBar.Top = 0;
            _vScrollBar.Height = this.Height;
            _vScrollBar.Update();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var brush = new SolidBrush(Color.Black);
            var start = new Point(0, 0);
            var end = new Point(this.Width, this.Height);
            pe.Graphics.DrawLine(new Pen(brush), start, end);
            pe.Graphics.DrawString("안녕하세요", Font, brush, new PointF(10, 10));

            UpdateRectanglePositioning();
        }
    }
}
