namespace WolfIsland
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.btnDisaster = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShowStats = new System.Windows.Forms.Button();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.speedSlider = new System.Windows.Forms.TrackBar();
            this.pbIsland = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsland)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(14, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Старт / Пауза";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStep
            // 
            this.btnStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStep.FlatAppearance.BorderSize = 0;
            this.btnStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStep.ForeColor = System.Drawing.Color.White;
            this.btnStep.Location = new System.Drawing.Point(141, 28);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(122, 23);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "Один крок";
            this.btnStep.UseVisualStyleBackColor = false;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(14, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Скинути";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 300;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // btnDisaster
            // 
            this.btnDisaster.BackColor = System.Drawing.Color.Maroon;
            this.btnDisaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisaster.FlatAppearance.BorderSize = 0;
            this.btnDisaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisaster.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDisaster.ForeColor = System.Drawing.Color.White;
            this.btnDisaster.Location = new System.Drawing.Point(14, 86);
            this.btnDisaster.Name = "btnDisaster";
            this.btnDisaster.Size = new System.Drawing.Size(249, 23);
            this.btnDisaster.TabIndex = 11;
            this.btnDisaster.Text = "Епідемія";
            this.btnDisaster.UseVisualStyleBackColor = false;
            this.btnDisaster.Click += new System.EventHandler(this.btnDisaster_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(294, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Карта острова";
            // 
            // btnShowStats
            // 
            this.btnShowStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnShowStats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowStats.FlatAppearance.BorderSize = 0;
            this.btnShowStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowStats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowStats.ForeColor = System.Drawing.Color.White;
            this.btnShowStats.Location = new System.Drawing.Point(141, 57);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.Size = new System.Drawing.Size(122, 23);
            this.btnShowStats.TabIndex = 13;
            this.btnShowStats.Text = "Відкрити аналітику";
            this.btnShowStats.UseVisualStyleBackColor = false;
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpeedValue.ForeColor = System.Drawing.Color.White;
            this.lblSpeedValue.Location = new System.Drawing.Point(76, 112);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(128, 21);
            this.lblSpeedValue.TabIndex = 26;
            this.lblSpeedValue.Text = "Швидкість: x10";
            // 
            // speedSlider
            // 
            this.speedSlider.Location = new System.Drawing.Point(14, 136);
            this.speedSlider.Maximum = 50;
            this.speedSlider.Minimum = 1;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(249, 45);
            this.speedSlider.TabIndex = 25;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedSlider.Value = 10;
            // 
            // pbIsland
            // 
            this.pbIsland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.pbIsland.Location = new System.Drawing.Point(12, 35);
            this.pbIsland.Name = "pbIsland";
            this.pbIsland.Size = new System.Drawing.Size(677, 676);
            this.pbIsland.TabIndex = 0;
            this.pbIsland.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lblSpeedValue);
            this.groupBox1.Controls.Add(this.speedSlider);
            this.groupBox1.Controls.Add(this.btnStep);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnShowStats);
            this.groupBox1.Controls.Add(this.btnDisaster);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(711, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 190);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Керування симуляцією";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.BackColor = System.Drawing.Color.Transparent;
            this.lblStats.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStats.ForeColor = System.Drawing.Color.White;
            this.lblStats.Location = new System.Drawing.Point(10, 25);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(99, 19);
            this.lblStats.TabIndex = 28;
            this.lblStats.Text = "Статистика";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStats);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(711, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 120);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Статистика";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1009, 731);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbIsland);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вовчий острів";
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsland)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button btnDisaster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShowStats;
        public System.Windows.Forms.Label lblSpeedValue;
        public System.Windows.Forms.TrackBar speedSlider;
        private System.Windows.Forms.PictureBox pbIsland;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

