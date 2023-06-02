namespace Numbers
{
    partial class NumberPropertiesForm
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
            groupBox1 = new GroupBox();
            tbPosY = new TextBox();
            label2 = new Label();
            tbPosX = new TextBox();
            label1 = new Label();
            btOk = new Button();
            btCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbPosY);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbPosX);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(162, 72);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Position:";
            // 
            // tbPosY
            // 
            tbPosY.Location = new Point(32, 40);
            tbPosY.Name = "tbPosY";
            tbPosY.Size = new Size(120, 23);
            tbPosY.TabIndex = 3;
            tbPosY.KeyDown += Common_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 44);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "Y:";
            // 
            // tbPosX
            // 
            tbPosX.BorderStyle = BorderStyle.FixedSingle;
            tbPosX.Location = new Point(32, 16);
            tbPosX.Name = "tbPosX";
            tbPosX.Size = new Size(120, 23);
            tbPosX.TabIndex = 1;
            tbPosX.KeyDown += Common_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 20);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "X:";
            // 
            // btOk
            // 
            btOk.Location = new Point(4, 86);
            btOk.Name = "btOk";
            btOk.Size = new Size(75, 23);
            btOk.TabIndex = 1;
            btOk.Text = "Ok";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            btOk.KeyDown += Button_KeyDown;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(88, 86);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(75, 23);
            btCancel.TabIndex = 2;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            btCancel.KeyDown += Button_KeyDown;
            // 
            // NumberPropertiesForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(170, 120);
            Controls.Add(btCancel);
            Controls.Add(btOk);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NumberPropertiesForm";
            Padding = new Padding(4);
            Text = "NumberPropertiesForm";
            Load += NumberPropertiesForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbPosY;
        private Label label2;
        private TextBox tbPosX;
        private Label label1;
        private Button btOk;
        private Button btCancel;
    }
}