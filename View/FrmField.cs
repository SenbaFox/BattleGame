using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace BattleGame
{
    /// <summary>
    /// 戦場画面
    /// </summary>
    public partial class FrmField : Form, IGameBoard
    {
        private const int COL_DISPLAY = 0;
        private const int COL_UNIT = 1;
        private const int COL_HEADCOUNT = 2;
        private const int COL_MOVABLE_DISTANCE = 3;
        private const int COL_ATTACK_TARGET = 4;

        private readonly Game game = new Game();

        private readonly Dictionary<Unit, UnitControl> unitControls = new Dictionary<Unit, UnitControl>();

        private readonly Dictionary<Hex, HexLabel> hexLabels = new Dictionary<Hex, HexLabel>();

        public FrmField()
        {
            InitializeComponent();
        }

        private void FrmField_Load(object sender, EventArgs e)
        {
            if (this.game.TryInitialize(this, out string errMsg) == false)
            {
                MessageBox.Show(errMsg, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int y = 0;
            for(int i = 0; i < this.game.BattleField.Hexes.Length; i++)
            {
                Hex[] lineHexes = this.game.BattleField.Hexes[i];
                int x = (i % 2 == 0) ? 0 : (HexLabel.BOUNDING_SIDE_LENGTH / 2);

                foreach (Hex hex in lineHexes)
                {
                    HexLabel hexLabel = this.CreateHexLabel(hex, x, y);

                    if (hex.IsUnitLanded)
                    {
                        UnitControl unitControl = this.CreateUnitControl(hex.LandedUnit);
                        this.MoveUnit(unitControl, hexLabel);
                    }

                    x += hexLabel.Width;
                }

                y += (int)(HexLabel.BOUNDING_SIDE_LENGTH * (2.0 / 3.0));
            }

            this.SetGridUnits();

            this.btnFinishPhase.Enabled = true;
        }

        private HexLabel CreateHexLabel(Hex hex, int x, int y)
        {
            HexLabel hexLabel = new HexLabel(hex);
            hexLabel.Click += this.HexLabel_Click;
            this.hexLabels.Add(hex, hexLabel);
            this.pnlField.Controls.Add(hexLabel);
            hexLabel.Location = new Point(x, y);

            return hexLabel;
        }

        private void HexLabel_Click(object sender, EventArgs e)
        {
            HexLabel hexLabel = (HexLabel)sender;
            this.game.SelectHex(hexLabel.Hex);
        }

        private UnitControl CreateUnitControl(Unit unit)
        {
            UnitControl unitControl = new UnitControl(unit);
            unitControl.Click += this.UnitControl_Click;
            this.unitControls.Add(unit, unitControl);
            this.pnlField.Controls.Add(unitControl);
            unitControl.BringToFront();

            return unitControl;
        }

        private void UnitControl_Click(object sender, EventArgs e)
        {
            UnitControl unitControl = (UnitControl)sender;
            this.game.SelectUnit(unitControl.Unit);
        }

        // TODO:ユニットコントロール生成もこのメソッドで行い、メソッド名を変更する
        public void SetGridUnits()
        {
            foreach (Army army in this.game.Armies)
            {
                foreach (Unit unit in army.Units)
                {
                    // TODO:行追加を一つのメソッドにする
                    int rowIndex = this.gridUnits.Rows.Add();
                    DataGridViewRow row = this.gridUnits.Rows[rowIndex];

                    ((DataGridViewImageCell)row.Cells[COL_DISPLAY]).Value = this.unitControls[unit].BackgroundImage;
                    row.Cells[COL_UNIT].Value = unit.Name;
                    row.Cells[COL_HEADCOUNT].Value = unit.Headcount;
                    row.Cells[COL_MOVABLE_DISTANCE].Value = unit.MovableDistanceInCurrentPhase;

                    row.Tag = unit;

                    unit.ChangedStatus += this.OnUnitChangedStatus;
                }
            }
        }

        private void OnUnitChangedStatus(object sender, EventArgs e)
        {
            Unit unit = (Unit)sender;

            DataGridViewRow row = this.GetRow(unit);
            row.Cells[COL_HEADCOUNT].Value = unit.Headcount;
            row.Cells[COL_MOVABLE_DISTANCE].Value = unit.MovableDistanceInCurrentPhase;

            if (unit.IsAnnihilation)
            {
                this.pnlField.Controls.Remove(this.unitControls[unit]);
            }
        }

        private DataGridViewRow GetRow(Unit unit)
        {
            foreach (DataGridViewRow row in this.gridUnits.Rows)
            {
                if (row.Tag == unit)
                {
                    return row;
                }
            }

            Debug.Assert(false, unit.ToString() + "のグリッド行が見つかりません。");
            return null;
        }

        private void BtnFinishPhase_Click(object sender, EventArgs e)
        {
            this.game.MoveNextPhase();
        }

        public void OnChangePhase(IPhase phase)
        {
            this.lblStatus.Text = phase.Name;
            this.gridUnits.Columns[COL_MOVABLE_DISTANCE].Visible = (phase.Type == PhaseType.移動);
            this.gridUnits.Columns[COL_ATTACK_TARGET].Visible = (phase.Type == PhaseType.攻撃);
        }

        public void OnUnitMove(Unit unit, Hex hex)
        {
            this.MoveUnit(this.unitControls[unit], this.hexLabels[hex]);
        }

        private void MoveUnit(UnitControl unit, HexLabel hex)
        {
            int x = hex.Location.X + ((hex.Width - unit.Width) / 2);
            int y = hex.Location.Y + ((hex.Height - unit.Height) / 2);
            unit.Location = new Point(x, y);
        }

        public void OnAttackTargetChanged(Unit unit, Unit targetOrNull)
        {
            DataGridViewRow row = this.GetRow(unit);
            row.Cells[COL_ATTACK_TARGET].Value = targetOrNull;
        }

        public void OnAttack(Unit target, int targetDamage, Unit counteredAttacker, int attackerDamage)
        {
            ToolTip tip = new ToolTip
            {
                IsBalloon = true
            };
            string text = $"攻撃! {target.Name}のダメージ:{targetDamage}" + Environment.NewLine +
                          $"反撃! {counteredAttacker.Name}のダメージ:{attackerDamage}";
            tip.Show(text, this.unitControls[target], 0, -80, 2000);
        }

        public void OnFinishedGame(string result)
        {
            lblStatus.Text = result;
        }
    }
}
