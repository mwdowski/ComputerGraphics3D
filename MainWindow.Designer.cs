namespace ComputerGraphics3D
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fogTrackBar = new System.Windows.Forms.TrackBar();
            this.cameraGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.staticCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.notMovingFollowingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.movingFollowingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.movingObjectCheckBox = new System.Windows.Forms.CheckBox();
            this.shadingModeGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.constantShadingModeRadioButton = new System.Windows.Forms.RadioButton();
            this.gouraudShadingModeRadioButton = new System.Windows.Forms.RadioButton();
            this.phongShadingModeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.movingLightDirectionTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fogTrackBar)).BeginInit();
            this.cameraGroupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.shadingModeGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movingLightDirectionTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 729);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1144, 723);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cameraGroupBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.movingObjectCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.shadingModeGroupBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1153, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 723);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 67);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Day/night";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(3, 19);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(182, 45);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.fogTrackBar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 67);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fog";
            // 
            // fogTrackBar
            // 
            this.fogTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.fogTrackBar.LargeChange = 10;
            this.fogTrackBar.Location = new System.Drawing.Point(3, 19);
            this.fogTrackBar.Maximum = 100;
            this.fogTrackBar.Name = "fogTrackBar";
            this.fogTrackBar.Size = new System.Drawing.Size(182, 45);
            this.fogTrackBar.SmallChange = 5;
            this.fogTrackBar.TabIndex = 0;
            this.fogTrackBar.TickFrequency = 5;
            // 
            // cameraGroupBox
            // 
            this.cameraGroupBox.AutoSize = true;
            this.cameraGroupBox.Controls.Add(this.tableLayoutPanel4);
            this.cameraGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cameraGroupBox.Location = new System.Drawing.Point(3, 131);
            this.cameraGroupBox.Name = "cameraGroupBox";
            this.cameraGroupBox.Size = new System.Drawing.Size(188, 97);
            this.cameraGroupBox.TabIndex = 2;
            this.cameraGroupBox.TabStop = false;
            this.cameraGroupBox.Text = "Camera";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.staticCameraRadioButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.notMovingFollowingCameraRadioButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.movingFollowingCameraRadioButton, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(182, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // staticCameraRadioButton
            // 
            this.staticCameraRadioButton.AutoSize = true;
            this.staticCameraRadioButton.Checked = true;
            this.staticCameraRadioButton.Location = new System.Drawing.Point(3, 3);
            this.staticCameraRadioButton.Name = "staticCameraRadioButton";
            this.staticCameraRadioButton.Size = new System.Drawing.Size(112, 19);
            this.staticCameraRadioButton.TabIndex = 0;
            this.staticCameraRadioButton.TabStop = true;
            this.staticCameraRadioButton.Text = "Static (from top)";
            this.staticCameraRadioButton.UseVisualStyleBackColor = true;
            // 
            // notMovingFollowingCameraRadioButton
            // 
            this.notMovingFollowingCameraRadioButton.AutoSize = true;
            this.notMovingFollowingCameraRadioButton.Location = new System.Drawing.Point(3, 28);
            this.notMovingFollowingCameraRadioButton.Name = "notMovingFollowingCameraRadioButton";
            this.notMovingFollowingCameraRadioButton.Size = new System.Drawing.Size(150, 19);
            this.notMovingFollowingCameraRadioButton.TabIndex = 1;
            this.notMovingFollowingCameraRadioButton.Text = "Not moving - following";
            this.notMovingFollowingCameraRadioButton.UseVisualStyleBackColor = true;
            // 
            // movingFollowingCameraRadioButton
            // 
            this.movingFollowingCameraRadioButton.AutoSize = true;
            this.movingFollowingCameraRadioButton.Location = new System.Drawing.Point(3, 53);
            this.movingFollowingCameraRadioButton.Name = "movingFollowingCameraRadioButton";
            this.movingFollowingCameraRadioButton.Size = new System.Drawing.Size(127, 19);
            this.movingFollowingCameraRadioButton.TabIndex = 2;
            this.movingFollowingCameraRadioButton.Text = "Moving - following";
            this.movingFollowingCameraRadioButton.UseVisualStyleBackColor = true;
            // 
            // movingObjectCheckBox
            // 
            this.movingObjectCheckBox.AutoSize = true;
            this.movingObjectCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.movingObjectCheckBox.Location = new System.Drawing.Point(3, 3);
            this.movingObjectCheckBox.Name = "movingObjectCheckBox";
            this.movingObjectCheckBox.Size = new System.Drawing.Size(188, 19);
            this.movingObjectCheckBox.TabIndex = 0;
            this.movingObjectCheckBox.Text = "Moving object\'s \"vibrations\"";
            this.movingObjectCheckBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.movingObjectCheckBox.UseVisualStyleBackColor = true;
            // 
            // shadingModeGroupBox
            // 
            this.shadingModeGroupBox.AutoSize = true;
            this.shadingModeGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.shadingModeGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.shadingModeGroupBox.Location = new System.Drawing.Point(3, 28);
            this.shadingModeGroupBox.Name = "shadingModeGroupBox";
            this.shadingModeGroupBox.Size = new System.Drawing.Size(188, 97);
            this.shadingModeGroupBox.TabIndex = 1;
            this.shadingModeGroupBox.TabStop = false;
            this.shadingModeGroupBox.Text = "Shading mode";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.constantShadingModeRadioButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.gouraudShadingModeRadioButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.phongShadingModeRadioButton, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(182, 75);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // constantShadingModeRadioButton
            // 
            this.constantShadingModeRadioButton.AutoSize = true;
            this.constantShadingModeRadioButton.Checked = true;
            this.constantShadingModeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.constantShadingModeRadioButton.Name = "constantShadingModeRadioButton";
            this.constantShadingModeRadioButton.Size = new System.Drawing.Size(73, 19);
            this.constantShadingModeRadioButton.TabIndex = 0;
            this.constantShadingModeRadioButton.TabStop = true;
            this.constantShadingModeRadioButton.Text = "Constant";
            this.constantShadingModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // gouraudShadingModeRadioButton
            // 
            this.gouraudShadingModeRadioButton.AutoSize = true;
            this.gouraudShadingModeRadioButton.Location = new System.Drawing.Point(3, 28);
            this.gouraudShadingModeRadioButton.Name = "gouraudShadingModeRadioButton";
            this.gouraudShadingModeRadioButton.Size = new System.Drawing.Size(71, 19);
            this.gouraudShadingModeRadioButton.TabIndex = 1;
            this.gouraudShadingModeRadioButton.Text = "Gouraud";
            this.gouraudShadingModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // phongShadingModeRadioButton
            // 
            this.phongShadingModeRadioButton.AutoSize = true;
            this.phongShadingModeRadioButton.Location = new System.Drawing.Point(3, 53);
            this.phongShadingModeRadioButton.Name = "phongShadingModeRadioButton";
            this.phongShadingModeRadioButton.Size = new System.Drawing.Size(60, 19);
            this.phongShadingModeRadioButton.TabIndex = 2;
            this.phongShadingModeRadioButton.Text = "Phong";
            this.phongShadingModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.movingLightDirectionTrackBar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Moving light direction";
            // 
            // movingLightDirectionTrackBar
            // 
            this.movingLightDirectionTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.movingLightDirectionTrackBar.LargeChange = 30;
            this.movingLightDirectionTrackBar.Location = new System.Drawing.Point(3, 19);
            this.movingLightDirectionTrackBar.Maximum = 90;
            this.movingLightDirectionTrackBar.Minimum = -90;
            this.movingLightDirectionTrackBar.Name = "movingLightDirectionTrackBar";
            this.movingLightDirectionTrackBar.Size = new System.Drawing.Size(182, 45);
            this.movingLightDirectionTrackBar.SmallChange = 10;
            this.movingLightDirectionTrackBar.TabIndex = 0;
            this.movingLightDirectionTrackBar.TickFrequency = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 708);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Michał Wdowski, 2023";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Computer Graphics 3D";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fogTrackBar)).EndInit();
            this.cameraGroupBox.ResumeLayout(false);
            this.cameraGroupBox.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.shadingModeGroupBox.ResumeLayout(false);
            this.shadingModeGroupBox.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movingLightDirectionTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox movingObjectCheckBox;
        private GroupBox shadingModeGroupBox;
        private TableLayoutPanel tableLayoutPanel3;
        private RadioButton constantShadingModeRadioButton;
        private RadioButton gouraudShadingModeRadioButton;
        private RadioButton phongShadingModeRadioButton;
        private GroupBox cameraGroupBox;
        private TableLayoutPanel tableLayoutPanel4;
        private RadioButton staticCameraRadioButton;
        private RadioButton notMovingFollowingCameraRadioButton;
        private RadioButton movingFollowingCameraRadioButton;
        private GroupBox groupBox1;
        private TrackBar movingLightDirectionTrackBar;
        private GroupBox groupBox3;
        private TrackBar trackBar1;
        private GroupBox groupBox2;
        private TrackBar fogTrackBar;
        private Label label1;
    }
}