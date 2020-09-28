using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace View
{
    public partial class UnitControl : UserControl
    {
        /// <summary>
        /// 兵種画像
        /// </summary>
        static readonly Dictionary<Branch, Image> branchImg = new Dictionary<Branch, Image>();

        readonly ToolTip toolTip = new ToolTip();

        /// <summary>
        /// 部隊
        /// </summary>
        public Unit Unit { get; private set; }

        public UnitControl(Unit unit)
        {
            InitializeComponent();

            int width = HexLabel.BOUNDING_SIDE_LENGTH - 4;
            int height = width / 3;
            this.SetBounds(this.Left, this.Top, width, height);
            this.TabStop = false;

            this.Unit = unit;

            // TODO:リファクタリング
            if (UnitControl.branchImg.Count == 0)
            {
                UnitControl.branchImg.Add(Branch.歩兵, Image.FromFile(@"img\Unit\歩兵.png"));
                UnitControl.branchImg.Add(Branch.騎兵, Image.FromFile(@"img\Unit\騎兵.png"));
            }

            Bitmap canvas = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(canvas);
            Bitmap img = (Bitmap)UnitControl.branchImg[this.Unit.Branch];
            ImageAttributes attributes = new ImageAttributes();
            if (unit.Army.ID != 0)
            {
                ColorMap[] colorMaps = new ColorMap[] { new ColorMap() };
                colorMaps[0].OldColor = img.GetPixel((img.Width - 1), (img.Height - 1));
                colorMaps[0].NewColor = Color.Red;
                attributes.SetRemapTable(colorMaps);
            }
            g.DrawImage(img, new Rectangle(0, 0, width, height),
                        0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = canvas;

            this.Unit.ChangedStatus += this.OnChangedStatus;

            this.toolTip.SetToolTip(this, this.ToString());
        }

        private void OnChangedStatus(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this, this.ToString());
        }

        public void ShowInfo()
        {
            this.toolTip.Show(this.ToString(), this, 1000);
        }

        public override string ToString()
        {
            return $"{this.Unit}:{this.Unit.Headcount}";
        }
    }
}
