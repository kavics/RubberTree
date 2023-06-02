using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numbers
{
    public partial class NumberPropertiesForm : Form
    {
        Number _number;

        public Number TargetNumber
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public NumberPropertiesForm()
        {
            InitializeComponent();
        }

        void Init()
        {
            tbPosX.Text = _number.X.ToString();
            tbPosY.Text = _number.Y.ToString();
        }

        void Ok()
        {
            bool hasError = false;
            float x = 0;
            float y = 0;
            string msg = "";
            try
            {
                x = Convert.ToSingle(tbPosX.Text);
                y = Convert.ToSingle(tbPosY.Text);
            }
            catch (Exception e)
            {
                msg = e.Message;
                hasError = true;
            }
            if (hasError)
            {
                MessageBox.Show(msg, "Set Number Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _number.X = x;
            _number.Y = y;
            this.DialogResult = DialogResult.OK;
        }

        void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void NumberPropertiesForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }


        private void Common_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Ok();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }
        }
        private void Button_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

    }
}
