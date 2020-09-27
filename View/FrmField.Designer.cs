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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlField = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFinishPhase = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ColHeadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDisplay = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlField
            // 
            this.pnlField.Location = new System.Drawing.Point(12, 108);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(1217, 612);
            this.pnlField.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1739, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 125);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnFinishPhase
            // 
            this.btnFinishPhase.Enabled = false;
            this.btnFinishPhase.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinishPhase.Location = new System.Drawing.Point(1256, 28);
            this.btnFinishPhase.Name = "btnFinishPhase";
            this.btnFinishPhase.Size = new System.Drawing.Size(205, 48);
            this.btnFinishPhase.TabIndex = 2;
            this.btnFinishPhase.Text = "フェーズ終了";
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
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColHeadCount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColHeadCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColHeadCount.FillWeight = 50F;
            this.ColHeadCount.HeaderText = "兵数";
            this.ColHeadCount.MinimumWidth = 6;
            this.ColHeadCount.Name = "ColHeadCount";
            this.ColHeadCount.ReadOnly = true;
            this.ColHeadCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColHeadCount.Width = 125;
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
            // ColDisplay
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColDisplay.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColDisplay.HeaderText = "表示";
            this.ColDisplay.MinimumWidth = 6;
            this.ColDisplay.Name = "ColDisplay";
            this.ColDisplay.ReadOnly = true;
            this.ColDisplay.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDisplay.Width = 50;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImageColumn1.HeaderText = "表示";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "部隊";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "兵数";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // gridUnits
            // 
            this.gridUnits.AllowUserToAddRows = false;
            this.gridUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridUnits.Location = new System.Drawing.Point(1256, 108);
            this.gridUnits.Name = "gridUnits";
            this.gridUnits.RowHeadersVisible = false;
            this.gridUnits.RowHeadersWidth = 51;
            this.gridUnits.Size = new System.Drawing.Size(280, 612);
            this.gridUnits.TabIndex = 4;
            this.gridUnits.Text = "dataGridView1";
            // 
            // FrmField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.gridUnits);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlField);
            this.Controls.Add(this.btnFinishPhase);
            this.Name = "FrmField";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFinishPhase;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView gridUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHeadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewImageColumn ColDisplay;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

