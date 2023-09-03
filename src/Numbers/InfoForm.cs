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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        void Init()
        {
            var sb = new StringBuilder();
            var ntr = Manager.Current.Forest;
            ntr.Sort();
            sb.Append("Base").Append('\t');
            sb.Append("Digits").Append('\t');
            sb.Append("Pow").Append('\t');
            sb.Append("Add").Append('\t');
            sb.Append("\r\n");
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("\r\n");
            foreach (var tree in ntr)
            {
                sb.Append(tree.NumberSystem).Append('\t');
                sb.Append(tree.Digits).Append('\t');
                sb.Append(tree.Pow).Append('\t');
                sb.Append(tree.Add).Append('\t');
                sb.Append("\r\n");
            }
            textBox1.Text = sb.ToString();
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
            textBox1.ReadOnly = true;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
