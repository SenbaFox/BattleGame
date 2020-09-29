namespace BattleGame
{
    partial class FrmField
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlField = new System.Windows.Forms.Panel();
            this.btnFinishPhase = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblArmyHeadCount = new System.Windows.Forms.Label();
            this.ColDisplay = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHeadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMovavleDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAttackTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridUnits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlField
            // 
            this.pnlField.Location = new System.Drawing.Point(12, 108);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(1217, 612);
            this.pnlField.TabIndex = 1;
            // 
            // btnFinishPhase
            // 
            this.btnFinishPhase.Enabled = false;
            this.btnFinishPhase.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinishPhase.Location = new System.Drawing.Point(1256, 12);
            this.btnFinishPhase.Name = "btnFinishPhase";
            this.btnFinishPhase.Size = new System.Drawing.Size(205, 48);
            this.btnFinishPhase.TabIndex = 2;
            this.btnFinishPhase.Text = "フェーズ終了(&F)";
            this.btnFinishPhase.Click += new System.EventHandler(this.BtnFinishPhase_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.Info;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1217, 96);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArmyHeadCount
            // 
            this.lblArmyHeadCount.Location = new System.Drawing.Point(1255, 77);
            this.lblArmyHeadCount.Name = "lblArmyHeadCount";
            this.lblArmyHeadCount.Size = new System.Drawing.Size(411, 27);
            this.lblArmyHeadCount.TabIndex = 3;
            this.lblArmyHeadCount.Text = "軍の兵数";
            // 
            // ColDisplay
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColDisplay.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColDisplay.HeaderText = "表示";
            this.ColDisplay.MinimumWidth = 6;
            this.ColDisplay.Name = "ColDisplay";
            this.ColDisplay.ReadOnly = true;
            this.ColDisplay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDisplay.Width = 50;
            // 
            // ColUnit
            // 
            this.ColUnit.HeaderText = "部隊";
            this.ColUnit.MinimumWidth = 6;
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColUnit.Width = 125;
            // 
            // ColHeadCount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColHeadCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColHeadCount.FillWeight = 50F;
            this.ColHeadCount.HeaderText = "兵数";
            this.ColHeadCount.MinimumWidth = 6;
            this.ColHeadCount.Name = "ColHeadCount";
            this.ColHeadCount.ReadOnly = true;
            this.ColHeadCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColHeadCount.Width = 80;
            // 
            // ColMovavleDistance
            // 
            this.ColMovavleDistance.HeaderText = "移動可能距離";
            this.ColMovavleDistance.MinimumWidth = 6;
            this.ColMovavleDistance.Name = "ColMovavleDistance";
            this.ColMovavleDistance.ReadOnly = true;
            this.ColMovavleDistance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColMovavleDistance.Visible = false;
            this.ColMovavleDistance.Width = 130;
            // 
            // ColAttackTarget
            // 
            this.ColAttackTarget.HeaderText = "攻撃対象";
            this.ColAttackTarget.MinimumWidth = 6;
            this.ColAttackTarget.Name = "ColAttackTarget";
            this.ColAttackTarget.ReadOnly = true;
            this.ColAttackTarget.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAttackTarget.Visible = false;
            this.ColAttackTarget.Width = 130;
            // 
            // FrmField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 753);
            // 
            // GridUnits
            // 
            this.GridUnits.AllowUserToAddRows = false;
            this.GridUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDisplay,
            this.ColUnit,
            this.ColHeadCount,
            this.ColMovavleDistance,
            this.ColAttackTarget});
            this.GridUnits.Location = new System.Drawing.Point(1256, 108);
            this.GridUnits.MultiSelect = false;
            this.GridUnits.Name = "GridUnits";
            this.GridUnits.RowHeadersVisible = false;
            this.GridUnits.RowHeadersWidth = 51;
            this.GridUnits.Size = new System.Drawing.Size(410, 612);
            this.GridUnits.TabIndex = 4;
            this.GridUnits.Text = "dataGridView1";
            this.GridUnits.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridUnits_CellMouseClick);
            this.Controls.Add(this.lblArmyHeadCount);
            this.Controls.Add(this.GridUnits);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlField);
            this.Controls.Add(this.btnFinishPhase);
            this.Name = "FrmField";
            this.Text = "BattleGame";
            this.Load += new System.EventHandler(this.FrmField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.Button btnFinishPhase;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView GridUnits;
        private System.Windows.Forms.Label lblArmyHeadCount;
        private System.Windows.Forms.DataGridViewImageColumn ColDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHeadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMovavleDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAttackTarget;
    }
}

