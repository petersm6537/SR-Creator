
namespace SR_Creator
{
    partial class formInput
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.inputPartNumber = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputSlitAngle = new System.Windows.Forms.ComboBox();
            this.inputSlitThickness = new System.Windows.Forms.ComboBox();
            this.inputInsideDiameter = new System.Windows.Forms.NumericUpDown();
            this.inputCrossSection = new System.Windows.Forms.NumericUpDown();
            this.inputThickness = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.createConfigButton = new System.Windows.Forms.Button();
            this.createSWInput = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputInsideDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCrossSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputThickness)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.forwardButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 236);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 72);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(158, 66);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardButton.Location = new System.Drawing.Point(167, 3);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(158, 66);
            this.forwardButton.TabIndex = 5;
            this.forwardButton.Text = ">";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(328, 227);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(320, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Part Number";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.labelPartNumber, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.inputPartNumber, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 195);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.AutoSize = true;
            this.labelPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPartNumber.Location = new System.Drawing.Point(3, 0);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(308, 97);
            this.labelPartNumber.TabIndex = 0;
            this.labelPartNumber.Text = "Please enter part number:";
            this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputPartNumber
            // 
            this.inputPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPartNumber.Location = new System.Drawing.Point(3, 100);
            this.inputPartNumber.Name = "inputPartNumber";
            this.inputPartNumber.Size = new System.Drawing.Size(308, 20);
            this.inputPartNumber.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(320, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dimensions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.inputSlitAngle, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.inputSlitThickness, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.inputInsideDiameter, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.inputCrossSection, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.inputThickness, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(314, 195);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inside Diameter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cross Section";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thickness";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Slit Thickness";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "Slit Angle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputSlitAngle
            // 
            this.inputSlitAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSlitAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputSlitAngle.FormattingEnabled = true;
            this.inputSlitAngle.Items.AddRange(new object[] {
            "20.5",
            "25",
            "45"});
            this.inputSlitAngle.Location = new System.Drawing.Point(160, 159);
            this.inputSlitAngle.Name = "inputSlitAngle";
            this.inputSlitAngle.Size = new System.Drawing.Size(151, 21);
            this.inputSlitAngle.TabIndex = 4;
            // 
            // inputSlitThickness
            // 
            this.inputSlitThickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSlitThickness.FormattingEnabled = true;
            this.inputSlitThickness.Items.AddRange(new object[] {
            ".005",
            ".01"});
            this.inputSlitThickness.Location = new System.Drawing.Point(160, 120);
            this.inputSlitThickness.Name = "inputSlitThickness";
            this.inputSlitThickness.Size = new System.Drawing.Size(151, 21);
            this.inputSlitThickness.TabIndex = 3;
            // 
            // inputInsideDiameter
            // 
            this.inputInsideDiameter.DecimalPlaces = 4;
            this.inputInsideDiameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputInsideDiameter.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.inputInsideDiameter.Location = new System.Drawing.Point(160, 3);
            this.inputInsideDiameter.Name = "inputInsideDiameter";
            this.inputInsideDiameter.Size = new System.Drawing.Size(151, 20);
            this.inputInsideDiameter.TabIndex = 0;
            // 
            // inputCrossSection
            // 
            this.inputCrossSection.DecimalPlaces = 4;
            this.inputCrossSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputCrossSection.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.inputCrossSection.Location = new System.Drawing.Point(160, 42);
            this.inputCrossSection.Name = "inputCrossSection";
            this.inputCrossSection.Size = new System.Drawing.Size(151, 20);
            this.inputCrossSection.TabIndex = 1;
            // 
            // inputThickness
            // 
            this.inputThickness.DecimalPlaces = 4;
            this.inputThickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputThickness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.inputThickness.Location = new System.Drawing.Point(160, 81);
            this.inputThickness.Name = "inputThickness";
            this.inputThickness.Size = new System.Drawing.Size(151, 20);
            this.inputThickness.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(320, 201);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Create";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.createConfigButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.createSWInput, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(320, 201);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // createConfigButton
            // 
            this.createConfigButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createConfigButton.Location = new System.Drawing.Point(3, 3);
            this.createConfigButton.Name = "createConfigButton";
            this.createConfigButton.Size = new System.Drawing.Size(234, 94);
            this.createConfigButton.TabIndex = 0;
            this.createConfigButton.Text = "Create Config";
            this.createConfigButton.UseVisualStyleBackColor = true;
            this.createConfigButton.Click += new System.EventHandler(this.createConfigButton_Click);
            // 
            // createSWInput
            // 
            this.createSWInput.AutoSize = true;
            this.createSWInput.Location = new System.Drawing.Point(3, 103);
            this.createSWInput.Name = "createSWInput";
            this.createSWInput.Size = new System.Drawing.Size(125, 17);
            this.createSWInput.TabIndex = 1;
            this.createSWInput.Text = "Create Solidwork File";
            this.createSWInput.UseVisualStyleBackColor = true;
            // 
            // formInput
            // 
            this.AcceptButton = this.forwardButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SR Creator - Input";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formInput_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputInsideDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputCrossSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputThickness)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.TextBox inputPartNumber;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox inputSlitAngle;
        private System.Windows.Forms.ComboBox inputSlitThickness;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button createConfigButton;
        private System.Windows.Forms.NumericUpDown inputInsideDiameter;
        private System.Windows.Forms.NumericUpDown inputCrossSection;
        private System.Windows.Forms.NumericUpDown inputThickness;
        private System.Windows.Forms.CheckBox createSWInput;
    }
}