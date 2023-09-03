namespace Numbers;

public partial class NumberPropertiesForm : Form
{
    public Number TargetNumber { get; set; }

    public NumberPropertiesForm()
    {
        InitializeComponent();
    }

    void Init()
    {
        tbPosX.Text = TargetNumber.X.ToString();
        tbPosY.Text = TargetNumber.Y.ToString();
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
        TargetNumber.X = x;
        TargetNumber.Y = y;
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