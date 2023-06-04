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
        private readonly Manager _manager;

        public InfoForm(Manager manager)
        {
            InitializeComponent();

            _manager = manager;
        }

        void Init()
        {
            StringBuilder sb = new StringBuilder();
            NumberTreeCollection ntr = Manager.Current.Forest;
            ntr.Sort();
            sb.Append("Base").Append('\t');
            sb.Append("Digits").Append('\t');
            sb.Append("Pow").Append('\t');
            sb.Append("Add").Append('\t');
            sb.Append("Formula");
            sb.Append("\r\n");
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("======").Append('\t');
            sb.Append("==============");
            sb.Append("\r\n");
            foreach (NumberTree tree in ntr)
            {
                sb.Append(tree.NumberSystem).Append('\t');
                sb.Append(tree.Digits).Append('\t');
                sb.Append(tree.Pow).Append('\t');
                sb.Append(tree.Add).Append('\t');
                sb.Append(_manager.GetFormula(tree.NumberSystem, tree.Digits, tree.Pow, tree.Add));
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
