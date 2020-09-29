using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// 部隊を表すコントロール
    /// </summary>
    public partial class UnitControl : UserControl
    {
        /// <summary>
        /// 兵種画像
        /// </summary>
        static readonly Dictionary<Branch, Image> branchImg = new Dictionary<Branch, Image>()
        {
            { Branch.歩兵, Image.FromFile(@"img\Unit\歩兵.png") },
            { Branch.騎兵, Image.FromFile(@"img\Unit\騎兵.png") }
        };

        #region メンバ変数

        /// <summary>
        /// ツールチップ
        /// </summary>
        readonly ToolTip toolTip = new ToolTip();

        #endregion

        #region プロパティ

        /// <summary>
        /// 部隊
        /// </summary>
        public Unit Unit { get; private set; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="unit">部隊</param>
        public UnitControl(Unit unit)
        {
            InitializeComponent();

            this.Unit = unit;
            this.Unit.ChangedStatus += this.OnChangedStatus;

            this.Draw(unit);

            this.TabStop = false;
            this.toolTip.SetToolTip(this, this.ToString());
        }

        private void Draw(Unit unit)
        {
            int width = HexLabel.BOUNDING_SIDE_LENGTH - 4;
            int height = width / 3;
            this.SetBounds(this.Left, this.Top, width, height);

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
        }

        private void OnChangedStatus(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this, this.ToString());
        }

        /// <summary>
        /// 情報を表示する
        /// </summary>
        public void ShowInfo()
        {
            this.toolTip.Show(this.ToString(), this, 1000);
        }

        public override string ToString()
        {
            return $"{this.Unit}:{this.Unit.Headcount}";
        }

        #endregion
    }
}
