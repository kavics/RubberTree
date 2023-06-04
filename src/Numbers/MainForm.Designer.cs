using System.Runtime.InteropServices;

namespace Numbers
{
    partial class MainForm
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
            pnlFill = new Panel();
            pictureBox1 = new PictureBox();
            pnlLeft = new Panel();
            startStopButton = new Button();
            calcOneButton = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            pnlTop = new Panel();
            lbForceMax = new Label();
            lbRubberMax = new Label();
            lbRepulsionMax = new Label();
            groupBox2 = new GroupBox();
            tbRubberMul = new TextBox();
            tbRubberPow = new TextBox();
            label9 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            tbRepulsionMul = new TextBox();
            tbRepulsionPow = new TextBox();
            label8 = new Label();
            label6 = new Label();
            groupBox3 = new GroupBox();
            label12 = new Label();
            tbSpaceHeight = new TextBox();
            tbSpaceWidth = new TextBox();
            udAdd = new NumericUpDown();
            udPow = new NumericUpDown();
            udDigits = new NumericUpDown();
            udNumberSystem = new NumericUpDown();
            udCircle = new NumericUpDown();
            label11 = new Label();
            label10 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lbFormula = new Label();
            btInfo = new Button();
            pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlLeft.SuspendLayout();
            pnlTop.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)udAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udPow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDigits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udNumberSystem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udCircle).BeginInit();
            SuspendLayout();
            // 
            // pnlFill
            // 
            pnlFill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlFill.Controls.Add(pictureBox1);
            pnlFill.Location = new Point(255, 0);
            pnlFill.Name = "pnlFill";
            pnlFill.Size = new Size(759, 726);
            pnlFill.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(8, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(742, 709);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // pnlLeft
            // 
            pnlLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlLeft.Controls.Add(startStopButton);
            pnlLeft.Controls.Add(calcOneButton);
            pnlLeft.Controls.Add(listBox1);
            pnlLeft.Controls.Add(textBox1);
            pnlLeft.Controls.Add(pnlTop);
            pnlLeft.Controls.Add(btInfo);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(2);
            pnlLeft.Size = new Size(249, 726);
            pnlLeft.TabIndex = 1;
            // 
            // startStopButton
            // 
            startStopButton.Location = new Point(2, 2);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(75, 25);
            startStopButton.TabIndex = 23;
            startStopButton.Text = "Start";
            startStopButton.UseVisualStyleBackColor = true;
            startStopButton.Click += startStopButton_Click;
            // 
            // calcOneButton
            // 
            calcOneButton.Location = new Point(77, 2);
            calcOneButton.Name = "calcOneButton";
            calcOneButton.Size = new Size(75, 25);
            calcOneButton.TabIndex = 5;
            calcOneButton.Text = "Calc One";
            calcOneButton.UseVisualStyleBackColor = true;
            calcOneButton.Click += calcOneButton_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(2, 408);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(244, 304);
            listBox1.TabIndex = 13;
            listBox1.DoubleClick += listBox1_DoubleClick;
            listBox1.KeyDown += listBox1_KeyDown;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(2, 264);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 144);
            textBox1.TabIndex = 8;
            textBox1.Text = "textBox1";
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lbForceMax);
            pnlTop.Controls.Add(lbRubberMax);
            pnlTop.Controls.Add(lbRepulsionMax);
            pnlTop.Controls.Add(groupBox2);
            pnlTop.Controls.Add(groupBox1);
            pnlTop.Controls.Add(groupBox3);
            pnlTop.Location = new Point(2, 28);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(246, 236);
            pnlTop.TabIndex = 0;
            // 
            // lbForceMax
            // 
            lbForceMax.BorderStyle = BorderStyle.FixedSingle;
            lbForceMax.Location = new Point(164, 208);
            lbForceMax.Name = "lbForceMax";
            lbForceMax.Size = new Size(74, 20);
            lbForceMax.TabIndex = 27;
            lbForceMax.Text = "lbForceMax";
            // 
            // lbRubberMax
            // 
            lbRubberMax.BorderStyle = BorderStyle.FixedSingle;
            lbRubberMax.Location = new Point(84, 208);
            lbRubberMax.Name = "lbRubberMax";
            lbRubberMax.Size = new Size(74, 20);
            lbRubberMax.TabIndex = 26;
            lbRubberMax.Text = "lbRubberMax";
            // 
            // lbRepulsionMax
            // 
            lbRepulsionMax.BorderStyle = BorderStyle.FixedSingle;
            lbRepulsionMax.Location = new Point(4, 208);
            lbRepulsionMax.Name = "lbRepulsionMax";
            lbRepulsionMax.Size = new Size(74, 20);
            lbRepulsionMax.TabIndex = 25;
            lbRepulsionMax.Text = "lbRepulsionMax";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbRubberMul);
            groupBox2.Controls.Add(tbRubberPow);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(120, 138);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(120, 66);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Rubber:";
            // 
            // tbRubberMul
            // 
            tbRubberMul.BorderStyle = BorderStyle.FixedSingle;
            tbRubberMul.Location = new Point(64, 40);
            tbRubberMul.Name = "tbRubberMul";
            tbRubberMul.Size = new Size(48, 23);
            tbRubberMul.TabIndex = 33;
            tbRubberMul.Text = "500";
            tbRubberMul.KeyDown += tbRubberMul_KeyDown;
            tbRubberMul.Leave += tbRubberMul_Leave;
            // 
            // tbRubberPow
            // 
            tbRubberPow.BorderStyle = BorderStyle.FixedSingle;
            tbRubberPow.Location = new Point(64, 16);
            tbRubberPow.Name = "tbRubberPow";
            tbRubberPow.Size = new Size(48, 23);
            tbRubberPow.TabIndex = 32;
            tbRubberPow.Text = "2";
            tbRubberPow.KeyDown += tbRubberPow_KeyDown;
            tbRubberPow.Leave += tbRubberPow_Leave;
            // 
            // label9
            // 
            label9.Location = new Point(2, 40);
            label9.Name = "label9";
            label9.Size = new Size(48, 20);
            label9.TabIndex = 1;
            label9.Text = "Mul:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(2, 16);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 0;
            label7.Text = "Pow (>=1)";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbRepulsionMul);
            groupBox1.Controls.Add(tbRepulsionPow);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(0, 138);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(120, 66);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Repulsion:";
            // 
            // tbRepulsionMul
            // 
            tbRepulsionMul.BorderStyle = BorderStyle.FixedSingle;
            tbRepulsionMul.Location = new Point(64, 40);
            tbRepulsionMul.Name = "tbRepulsionMul";
            tbRepulsionMul.Size = new Size(48, 23);
            tbRepulsionMul.TabIndex = 31;
            tbRepulsionMul.Text = "1000";
            tbRepulsionMul.KeyDown += tbRepulsionMul_KeyDown;
            tbRepulsionMul.Leave += tbRepulsionMul_Leave;
            // 
            // tbRepulsionPow
            // 
            tbRepulsionPow.BorderStyle = BorderStyle.FixedSingle;
            tbRepulsionPow.Location = new Point(64, 16);
            tbRepulsionPow.Name = "tbRepulsionPow";
            tbRepulsionPow.Size = new Size(48, 23);
            tbRepulsionPow.TabIndex = 30;
            tbRepulsionPow.Text = "-2";
            tbRepulsionPow.KeyDown += tbRepulsionPow_KeyDown;
            tbRepulsionPow.Leave += tbRepulsionPow_Leave;
            // 
            // label8
            // 
            label8.Location = new Point(2, 40);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 1;
            label8.Text = "Mul:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Location = new Point(2, 16);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 0;
            label6.Text = "Pow (<=1)";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(tbSpaceHeight);
            groupBox3.Controls.Add(tbSpaceWidth);
            groupBox3.Controls.Add(udAdd);
            groupBox3.Controls.Add(udPow);
            groupBox3.Controls.Add(udDigits);
            groupBox3.Controls.Add(udNumberSystem);
            groupBox3.Controls.Add(udCircle);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(lbFormula);
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(240, 138);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Universe:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(2, 19);
            label12.Name = "label12";
            label12.Size = new Size(54, 15);
            label12.TabIndex = 30;
            label12.Text = "Formula:";
            // 
            // tbSpaceHeight
            // 
            tbSpaceHeight.BorderStyle = BorderStyle.FixedSingle;
            tbSpaceHeight.Location = new Point(184, 88);
            tbSpaceHeight.Name = "tbSpaceHeight";
            tbSpaceHeight.Size = new Size(48, 23);
            tbSpaceHeight.TabIndex = 29;
            tbSpaceHeight.Text = "600";
            tbSpaceHeight.KeyDown += tbSpaceHeight_KeyDown;
            tbSpaceHeight.Leave += tbSpaceHeight_Leave;
            // 
            // tbSpaceWidth
            // 
            tbSpaceWidth.BorderStyle = BorderStyle.FixedSingle;
            tbSpaceWidth.Location = new Point(184, 64);
            tbSpaceWidth.Name = "tbSpaceWidth";
            tbSpaceWidth.Size = new Size(48, 23);
            tbSpaceWidth.TabIndex = 28;
            tbSpaceWidth.Text = "600";
            tbSpaceWidth.KeyDown += tbSpaceWidth_KeyDown;
            tbSpaceWidth.Leave += tbSpaceWidth_Leave;
            // 
            // udAdd
            // 
            udAdd.BorderStyle = BorderStyle.FixedSingle;
            udAdd.Location = new Point(61, 112);
            udAdd.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            udAdd.Name = "udAdd";
            udAdd.Size = new Size(48, 23);
            udAdd.TabIndex = 27;
            udAdd.TextAlign = HorizontalAlignment.Right;
            udAdd.ValueChanged += udAdd_ValueChanged;
            // 
            // udPow
            // 
            udPow.BorderStyle = BorderStyle.FixedSingle;
            udPow.Location = new Point(61, 88);
            udPow.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            udPow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            udPow.Name = "udPow";
            udPow.Size = new Size(48, 23);
            udPow.TabIndex = 26;
            udPow.TextAlign = HorizontalAlignment.Right;
            udPow.Value = new decimal(new int[] { 2, 0, 0, 0 });
            udPow.ValueChanged += udPow_ValueChanged;
            // 
            // udDigits
            // 
            udDigits.BorderStyle = BorderStyle.FixedSingle;
            udDigits.Location = new Point(61, 64);
            udDigits.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            udDigits.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            udDigits.Name = "udDigits";
            udDigits.Size = new Size(48, 23);
            udDigits.TabIndex = 25;
            udDigits.TextAlign = HorizontalAlignment.Right;
            udDigits.Value = new decimal(new int[] { 2, 0, 0, 0 });
            udDigits.ValueChanged += udDigits_ValueChanged;
            // 
            // udNumberSystem
            // 
            udNumberSystem.BorderStyle = BorderStyle.FixedSingle;
            udNumberSystem.Location = new Point(61, 40);
            udNumberSystem.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            udNumberSystem.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            udNumberSystem.Name = "udNumberSystem";
            udNumberSystem.Size = new Size(48, 23);
            udNumberSystem.TabIndex = 24;
            udNumberSystem.TextAlign = HorizontalAlignment.Right;
            udNumberSystem.Value = new decimal(new int[] { 10, 0, 0, 0 });
            udNumberSystem.ValueChanged += udNumberSystem_ValueChanged;
            // 
            // udCircle
            // 
            udCircle.BorderStyle = BorderStyle.FixedSingle;
            udCircle.Location = new Point(184, 40);
            udCircle.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            udCircle.Name = "udCircle";
            udCircle.Size = new Size(48, 23);
            udCircle.TabIndex = 23;
            udCircle.TextAlign = HorizontalAlignment.Right;
            udCircle.ValueChanged += udCircle_ValueChanged;
            // 
            // label11
            // 
            label11.Location = new Point(135, 88);
            label11.Name = "label11";
            label11.Size = new Size(46, 20);
            label11.TabIndex = 21;
            label11.Text = "Height:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Location = new Point(135, 64);
            label10.Name = "label10";
            label10.Size = new Size(42, 20);
            label10.TabIndex = 20;
            label10.Text = "Width:";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(21, 112);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 19;
            label5.Text = "Add:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(21, 88);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 18;
            label4.Text = "Pow:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(135, 40);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 17;
            label3.Text = "Circle:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(21, 64);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 16;
            label2.Text = "Digits:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(21, 40);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 15;
            label1.Text = "Base:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbFormula
            // 
            lbFormula.BorderStyle = BorderStyle.FixedSingle;
            lbFormula.Location = new Point(61, 16);
            lbFormula.Name = "lbFormula";
            lbFormula.Size = new Size(171, 20);
            lbFormula.TabIndex = 14;
            lbFormula.Text = "X^1 + 0";
            lbFormula.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btInfo
            // 
            btInfo.Location = new Point(166, 2);
            btInfo.Name = "btInfo";
            btInfo.Size = new Size(80, 25);
            btInfo.TabIndex = 22;
            btInfo.Text = "Saved info";
            btInfo.UseVisualStyleBackColor = true;
            btInfo.Click += btInfo_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 726);
            Controls.Add(pnlLeft);
            Controls.Add(pnlFill);
            Name = "MainForm";
            Text = "MainForm";
            Closing += MainForm_Closing;
            Load += MainForm_Load;
            pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlTop.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)udAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)udPow).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDigits).EndInit();
            ((System.ComponentModel.ISupportInitialize)udNumberSystem).EndInit();
            ((System.ComponentModel.ISupportInitialize)udCircle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFill;
        private PictureBox pictureBox1;
        private Panel pnlLeft;
        private Panel pnlTop;
        private Button calcOneButton;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label lbForceMax;
        private Label lbRubberMax;
        private Label lbRepulsionMax;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private TextBox tbRubberMul;
        private TextBox tbRubberPow;
        private Label label9;
        private Label label7;
        private TextBox tbRepulsionMul;
        private TextBox tbRepulsionPow;
        private Label label8;
        private Label label6;
        private TextBox tbSpaceHeight;
        private TextBox tbSpaceWidth;
        private NumericUpDown udAdd;
        private NumericUpDown udPow;
        private NumericUpDown udDigits;
        private NumericUpDown udNumberSystem;
        private NumericUpDown udCircle;
        private Button btInfo;
        private Label label11;
        private Label label10;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lbFormula;
        private Label label12;
        private Button startStopButton;
    }
}