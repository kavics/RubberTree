using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Numbers
{
    public partial class MainForm : Form
    {
        NumberTree _ntree;
        NumberDrawing _ndrawing;
        Graphics _graphics;
        Point _origo;

        public MainForm()
        {
            InitializeComponent();
        }

        void Init()
        {
            Application.Idle += new EventHandler(Application_Idle);
            _hasEvent = true;
            _startingEvent = true;

            Text = "Numbers V" + Assembly.GetExecutingAssembly().GetName().Version;

            udNumberSystem.Value = 10;
            udDigits.Value = 2;
            udCircle.Minimum = 0;
            udCircle.Maximum = 0;
            udCircle.Value = 0;
            udAdd.Value = 0;
            udPow.Value = 2;
            lbRepulsionMax.Text = "0";
            lbRubberMax.Text = "0";
            lbForceMax.Text = "0";

            UpdateFormula();
            InitGraphics();

            _ndrawing = new NumberDrawing(_graphics);
            Manager.Current.CurrentSpaceSize = pictureBox1.Size;
        }

        void InitGraphics()
        {
            InitGraphics(pictureBox1.Size);
        }

        void InitGraphics(Size spaceSize)
        {
            Debug.WriteLine($"InitGraphics w={Width} h={Height}");
            pictureBox1.Image = new Bitmap(spaceSize.Width, spaceSize.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);
            _origo = new Point(Convert.ToInt32(_graphics.VisibleClipBounds.Width / 2), Convert.ToInt32(_graphics.VisibleClipBounds.Height / 2));
            if (_ndrawing != null)
                _ndrawing.Graph = _graphics;
        }

        void ResizeGraphics()
        {
            NumberCircle circle = (NumberCircle)_ntree.Circles[Convert.ToInt32(udCircle.Value)];
            pictureBox1.Size = circle.SpaceSize;
            tbSpaceWidth.Text = circle.SpaceSize.Width.ToString();
            tbSpaceHeight.Text = circle.SpaceSize.Height.ToString();
            InitGraphics();
            DrawOneCircle();
        }

        void UpdateFormula()
        {
            lbFormula.Text = Manager.Current.GetFormula(
                udNumberSystem.Value, udDigits.Value, udPow.Value, udAdd.Value);
        }

        void RefreshParameterPanel()
        {
            udAdd.Refresh();
            udCircle.Refresh();
            udDigits.Refresh();
            udNumberSystem.Refresh();
            udPow.Refresh();
            UpdateFormula();
            lbFormula.Refresh();
        }


        void RequestCalculate()
        {
            _rubberRun = false;
            _hasEvent = true;
            _calculatingEvent = true;
        }

        void Calculate()
        {
            RefreshParameterPanel();
            _ntree = Manager.Current.GetTree((int)udNumberSystem.Value, (int)udDigits.Value, (int)udPow.Value, (int)udAdd.Value);
            _ntree.Build();

            textBox1.Clear();
            listBox1.Items.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("Circles:\r\n");
            foreach (NumberCollection circle in _ntree.Circles)
            {
                foreach (Number number in circle)
                    sb.Append(number.ToString()).Append(" > ");
                sb.Append(circle[0].ToString());
                sb.Append("\r\n");
            }
            textBox1.Text = sb.ToString();

            foreach (Number number in _ntree.Numbers)
            {
                sb.Length = 0;
                Number n = number;
                sb.Append(n.ToString());
                sb.Append(" > ");
                n = n.Child;
                sb.Append(n.ToString());
                while (!n.IsCircleMember)
                {
                    sb.Append(" > ");
                    sb.Append(n.ToString());
                    n = n.Child;
                }
                listBox1.Items.Add(sb.ToString());
            }

            udCircle.Maximum = _ntree.Circles.Count - 1;

            if (_graphics != null)
            {
                ResizeGraphics();
                //DrawOneCircle();
                if (_isAnimationRunning)
                    Rubber();
            }
        }

        void DrawOneCircle()
        {
            _graphics.Clear(SystemColors.Control);
            NumberCollection circle = _ntree.Circles[Convert.ToInt32(udCircle.Value)];
            _ndrawing.DrawNumberCircle(circle, _origo);
            pictureBox1.Refresh();
        }


        bool _rubberRun;
        void Rubber()
        {
            _rubberRun = true;
            if (_ntree != null)
            {
                calcOneButton.Enabled = false;
                while (_rubberRun)
                {
                    RubberOne();
                }
                calcOneButton.Enabled = true;
            }
        }

        void RubberOne()
        {
            NumberCollection circle = _ntree.Circles[Convert.ToInt32(udCircle.Value)];
            _ntree.Rubber(circle);
            lbRepulsionMax.Text = String.Format("{0}", _ntree.RepulsionMax.ToString("0.#####"));
            lbRubberMax.Text = String.Format("{0}", _ntree.RubberMax.ToString("0.#####"));
            lbForceMax.Text = String.Format("{0}", _ntree.ForceMax.ToString("0.#####"));
            DrawOneCircle();
            pictureBox1.Refresh();
            Application.DoEvents();
        }


        void SelectNumber(int index)
        {
            bool run = _isAnimationRunning;
            if (run)
                _rubberRun = false;
            Number number = _ntree.Numbers[index];
            NumberPropertiesForm form = new NumberPropertiesForm();
            form.TargetNumber = number;
            form.ShowDialog();
            form.Dispose();
            DrawOneCircle();
            if (run)
                Rubber();
        }


        double CheckDouble(string input, double defaultValue)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(input);
            }
            catch
            {
                d = defaultValue;
            }
            return d;
        }

        int CheckInt(string input, int defaultValue)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(input);
            }
            catch
            {
                i = defaultValue;
            }
            return i;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            InitGraphics();
            DrawOneCircle();
        }

        private void udCircle_ValueChanged(object sender, EventArgs e)
        {
            ResizeGraphics();
        }

        private bool _isAnimationRunning;
        private void startStopButton_Click(object sender, EventArgs e)
        {
            _isAnimationRunning = !_isAnimationRunning;
            if (_isAnimationRunning)
            {
                startStopButton.Text = "Stop";
                startStopButton.BackColor = SystemColors.Highlight;
                startStopButton.ForeColor = SystemColors.HighlightText;
                Rubber();
            }
            else
            {
                startStopButton.Text = "Start";
                startStopButton.BackColor = SystemColors.Control;
                startStopButton.ForeColor = SystemColors.ControlText;
                _rubberRun = false;
            }
        }

        private void calcOneButton_Click(object sender, EventArgs e)
        {
            RubberOne();
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _rubberRun = false;
            Manager.Current.Save();
        }

        private void udPow_ValueChanged(object sender, EventArgs e)
        {
            RequestCalculate();
            UpdateFormula();
        }

        private void udAdd_ValueChanged(object sender, EventArgs e)
        {
            RequestCalculate();
            UpdateFormula();
        }

        private void udNumberSystem_ValueChanged(object sender, EventArgs e)
        {
            RequestCalculate();
            UpdateFormula();
        }

        private void udDigits_ValueChanged(object sender, EventArgs e)
        {
            RequestCalculate();
            UpdateFormula();
        }

        private void btInfo_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm(Manager.Current);
            form.ShowDialog();
            form.Dispose();
        }


        bool _hasEvent;
        bool _startingEvent;
        bool _calculatingEvent;

        private void Application_Idle(object sender, EventArgs e)
        {
            if (_hasEvent)
            {
                _hasEvent = false;
                if (_startingEvent)
                {
                    _startingEvent = false;
                    Console.WriteLine("_startingEvent");
                    Calculate();
                }
                else if (_calculatingEvent)
                {
                    _calculatingEvent = false;
                    Console.WriteLine("_startingEvent");
                    Calculate();
                }
            }
        }

        private void listBox1_DoubleClick(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                SelectNumber(listBox1.SelectedIndex);
        }

        private void listBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (listBox1.SelectedIndex >= 0)
                    SelectNumber(listBox1.SelectedIndex);
        }


        private void tbRepulsionPow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_ntree != null)
                    tbRepulsionPow.Text = _ntree.RepulsionPow.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (_ntree != null)
                    _ntree.RepulsionPow = CheckDouble(tbRepulsionPow.Text, _ntree.RepulsionPow);
            }
        }

        private void tbRepulsionPow_Leave(object sender, EventArgs e)
        {
            _ntree.RepulsionPow = CheckDouble(tbRepulsionPow.Text, _ntree.RepulsionPow);
            tbRepulsionPow.Text = _ntree.RepulsionPow.ToString();
        }

        private void tbRepulsionMul_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_ntree != null)
                    tbRepulsionMul.Text = _ntree.RepulsionMul.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (_ntree != null)
                    _ntree.RepulsionMul = CheckDouble(tbRepulsionMul.Text, _ntree.RepulsionMul);
            }
        }

        private void tbRepulsionMul_Leave(object sender, System.EventArgs e)
        {
            _ntree.RepulsionMul = CheckDouble(tbRepulsionMul.Text, _ntree.RepulsionMul);
            tbRepulsionMul.Text = _ntree.RepulsionMul.ToString();
        }

        private void tbRubberPow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_ntree != null)
                    tbRubberPow.Text = _ntree.RubberPow.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (_ntree != null)
                    _ntree.RubberPow = CheckDouble(tbRubberPow.Text, _ntree.RubberPow);
            }
        }

        private void tbRubberPow_Leave(object sender, System.EventArgs e)
        {
            _ntree.RubberPow = CheckDouble(tbRubberPow.Text, _ntree.RubberPow);
            tbRubberPow.Text = _ntree.RubberPow.ToString();
        }

        private void tbRubberMul_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_ntree != null)
                    tbRubberMul.Text = _ntree.RubberMul.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (_ntree != null)
                    _ntree.RubberMul = CheckDouble(tbRubberMul.Text, _ntree.RubberMul);
            }
        }

        private void tbRubberMul_Leave(object sender, System.EventArgs e)
        {
            _ntree.RubberMul = CheckDouble(tbRubberMul.Text, _ntree.RubberMul);
            tbRubberMul.Text = _ntree.RubberMul.ToString();
        }

        private void tbSpaceWidth_KeyDown(object sender, KeyEventArgs e)
        {
            NumberCircle circle = (NumberCircle)_ntree.Circles[Convert.ToInt32(udCircle.Value)];
            int width = circle.SpaceSize.Width;
            if (e.KeyCode == Keys.Escape)
            {
                tbSpaceWidth.Text = width.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                width = CheckInt(tbSpaceWidth.Text, width);
                circle.SpaceSize = new Size(width, Convert.ToInt32(tbSpaceHeight.Text));
                ResizeGraphics();
            }
        }

        private void tbSpaceWidth_Leave(object sender, EventArgs e)
        {
            NumberCircle circle = (NumberCircle)_ntree.Circles[Convert.ToInt32(udCircle.Value)];
            int width = circle.SpaceSize.Width;
            width = CheckInt(tbSpaceWidth.Text, width);
            circle.SpaceSize = new Size(width, Convert.ToInt32(tbSpaceHeight.Text));
            ResizeGraphics();
        }

        private void tbSpaceHeight_KeyDown(object sender, KeyEventArgs e)
        {
            NumberCircle circle = (NumberCircle)_ntree.Circles[Convert.ToInt32(udCircle.Value)];
            int height = circle.SpaceSize.Height;
            if (e.KeyCode == Keys.Escape)
            {
                tbSpaceHeight.Text = height.ToString();
                return;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                height = CheckInt(tbSpaceHeight.Text, height);
                circle.SpaceSize = new Size(Convert.ToInt32(tbSpaceWidth.Text), height);
                ResizeGraphics();
            }
        }

        private void tbSpaceHeight_Leave(object sender, EventArgs e)
        {
            NumberCircle circle = (NumberCircle)_ntree.Circles[Convert.ToInt32(udCircle.Value)];
            int height = circle.SpaceSize.Height;
            height = CheckInt(tbSpaceHeight.Text, height);
            circle.SpaceSize = new Size(Convert.ToInt32(tbSpaceWidth.Text), height);
            ResizeGraphics();
        }

    }
}