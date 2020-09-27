using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// へクスを表すラベル
    /// </summary>
    /// <remarks>UserControlのBackgroundImageだと上手く表示できない画像があるのでラベルを継承する</remarks>
    public partial class HexLabel : Label
    {
        /// <summary>
        /// 外接矩形の1辺の長さ
        /// </summary>
        public const int BOUNDING_SIDE_LENGTH = 30;

        /// <summary>
        /// 頂点の配列
        /// </summary>
        static readonly Point[] vertex = new Point[] { new Point(15, 0), new Point(0, 8), new Point(0, 21),
                                              new Point(15, 30), new Point(30, 21), new Point(30, 8) };

        /// <summary>
        /// 地形画像
        /// </summary>
        static readonly Dictionary<int, Image> geographyImg = new Dictionary<int, Image>();

        public Hex Hex { get; private set; }

        public HexLabel(Hex hex)
        {
            InitializeComponent();

            this.Hex = hex;

            this.SetBounds(this.Left, this.Top, BOUNDING_SIDE_LENGTH, BOUNDING_SIDE_LENGTH);

            byte[] types = { (byte) PathPointType.Line, (byte) PathPointType.Line, (byte) PathPointType.Line,
                             (byte) PathPointType.Line, (byte) PathPointType.Line, (byte) PathPointType.Line  };
            GraphicsPath path = new GraphicsPath(HexLabel.vertex, types);
            this.Region = new Region(path);

            if (HexLabel.geographyImg.Count == 0)
            {
                HexLabel.geographyImg.Add(0, Image.FromFile(@"img\Geography\plain.png"));
                HexLabel.geographyImg.Add(1, Image.FromFile(@"img\Geography\sea.png"));
            }

            if (geographyImg.ContainsKey(hex.Geography.ID))
            {
                this.Image = geographyImg[hex.Geography.ID];
            }
        }

        private void HexLabel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // 枠線を描画(BorderStyleを設定するだけだと上手く描画できない)
                Pen pen = new Pen(Color.Black, 1);
                pen.DashStyle = DashStyle.Solid;

                Graphics graphics = e.Graphics;
                // 右の線は1ポイント内側に描画する
                Point[] borderVertex = (Point[])(HexLabel.vertex.Clone());
                borderVertex[4].X -= 1;
                borderVertex[5].X -= 1;
                graphics.DrawPolygon(pen, borderVertex);

                pen.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
