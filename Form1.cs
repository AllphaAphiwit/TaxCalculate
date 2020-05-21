using System;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class คำนวณภาษี : Form
    {
        double answer, salary, resultfamily, resultinterest, resultinvest, resultdonate, resulteconomy;
        public คำนวณภาษี()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "โสด";
            radioButton1.Checked = true;
            radioButton6.Checked = true;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "โสด")
            {
                radioButton1.Checked = true;
                radioButton6.Checked = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
            }
            else if (comboBox1.Text == "สมรส(คู่สมรสไม่มีรายได้)")
            {
                radioButton1.Checked = true;
                radioButton6.Checked = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }
            else
            {
                radioButton1.Checked = true;
                radioButton6.Checked = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            numericUpDown29_ValueChanged(sender, e);
            textsalaley_ValueChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textsalaley_ValueChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            textsalaley_ValueChanged(sender, e);
            numericUpDown40_ValueChanged(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            resultLabel.Text = "0";
            textsalaley_ValueChanged(sender, e);
        }

        private void textsalaley_ValueChanged(object sender, EventArgs e)
        {
            resultfamily = 0;
            salary = Convert.ToDouble(textsalaley.Value) * 12;
            int young = Convert.ToInt32(numericUpDown1.Value) * 30000;
            int young61 = Convert.ToInt32(numericUpDown2.Value);
            int hospital = Convert.ToInt32(numericUpDown3.Value);
            int criple = Convert.ToInt32(numericUpDown4.Value) * 60000;
            double temp = salary * 0.5;

            if (temp > 100000) { resultfamily += 100000; }
            else { resultfamily += temp; }

            if (comboBox1.Text == "สมรส(คู่สมรสไม่มีรายได้)") { resultfamily += 120000; }
            else { resultfamily += 60000; }

            if (young61 >= 1)
            {
                if (young == 0) { young61 = (young61 * 60000) - 30000; }
                else { young61 = young61 * 60000; }
            }
            else { young61 = 0; }

            if (radioButton1.Checked)
            {
                if (radioButton4.Checked) { resultfamily += 60000; }
                else if (radioButton5.Checked) { resultfamily += 30000; }
                else if (radioButton6.Checked) { resultfamily += 0; }
            }
            else if (radioButton2.Checked)
            {
                if (radioButton4.Checked) { resultfamily += 90000; }
                else if (radioButton5.Checked) { resultfamily += 60000; }
                else if (radioButton6.Checked) { resultfamily += 30000; }
            }
            else if (radioButton3.Checked)
            {
                if (radioButton4.Checked) { resultfamily += 120000; }
                else if (radioButton5.Checked) { resultfamily += 90000; }
                else if (radioButton6.Checked) { resultfamily += 60000; }
            }
            resultfamily = resultfamily + young + young61 + criple + hospital;
            answer = salary - (resultfamily + resultinvest + resultinterest + resulteconomy + resultdonate);
            if (answer < 0) { answer = 0; }
            realsalaley.Text = answer.ToString("#,0.#");
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            resultinterest = 0;
            double interest0 = Convert.ToDouble(numericUpDown5.Value);
            double interest1 = Convert.ToDouble(numericUpDown6.Value) * 0.04;
            label75.Text = interest1.ToString("#,0.#");
            double interest2 = Convert.ToDouble(numericUpDown7.Value) * 0.04;
            label77.Text = interest2.ToString("#,0.#");
            resultinterest = interest0 + interest1 +  interest2;
            interest.Text = resultinterest.ToString("#,0.#");
        }

        private void numericUpDown29_ValueChanged(object sender, EventArgs e)
        {
            resultinvest = 0;
            double invest = salary * 0.15; int temp;
            int invest0 = Convert.ToInt32(numericUpDown29.Value);
            int invest1 = Convert.ToInt32(numericUpDown39.Value);
            int invest2 = Convert.ToInt32(numericUpDown38.Value);
            int invest3 = Convert.ToInt32(numericUpDown37.Value);
            int invest4 = Convert.ToInt32(numericUpDown36.Value);
            int invest5 = Convert.ToInt32(numericUpDown35.Value);
            int invest6 = Convert.ToInt32(numericUpDown34.Value);
            int invest7 = Convert.ToInt32(numericUpDown33.Value);
            int invest8 = Convert.ToInt32(numericUpDown32.Value);
            int invest9 = Convert.ToInt32(numericUpDown31.Value);
            int invest10 = Convert.ToInt32(numericUpDown30.Value);

            if (numericUpDown39.Focused)
            {
                while (true)
                {
                    if ((invest1 + invest2) > 100000) { invest1 -= 1; }
                    else { numericUpDown39.Value = Convert.ToInt32(invest1); break; }
                }
            }
            else if (numericUpDown38.Focused)
            {
                while (true)
                {
                    if ((invest1 + invest2) > 100000) { invest2 -= 1; }
                    else { numericUpDown38.Value = Convert.ToInt32(invest2); break; }
                }
            }

            if (invest > 490000) { label133.Text = invest.ToString("#,0"); numericUpDown34.Maximum = 490000; }
            else { label133.Text = invest.ToString("#,0"); numericUpDown34.Maximum = Convert.ToInt32(invest); }

            if (invest > 500000) { label132.Text = invest.ToString("#,0"); numericUpDown33.Maximum = 500000; }
            else { label132.Text = invest.ToString("#,0"); numericUpDown33.Maximum = Convert.ToInt32(invest); }

            if (invest > 200000) { label130.Text = invest.ToString("#,0"); numericUpDown32.Maximum = 200000; }
            else { label130.Text = invest.ToString("#,0"); numericUpDown32.Maximum = Convert.ToInt32(invest); }

            if (invest > 500000) { label122.Text = invest.ToString("#,0"); numericUpDown31.Maximum = 500000; }
            else { label122.Text = invest.ToString("#,0"); numericUpDown31.Maximum = Convert.ToInt32(invest); }

            if (invest > 500000) { label120.Text = invest.ToString("#,0"); numericUpDown30.Maximum = 500000; }
            else { label120.Text = invest.ToString("#,0"); numericUpDown30.Maximum = Convert.ToInt32(invest); }

            if (numericUpDown32.Value == 0)
            {
                temp = invest6 + invest7 + invest8 + invest10;
            }
            else
            {
                temp = invest6 + invest7 + invest8 + invest10;
                if (temp > 500000) { temp = 500000; }
                else { temp = invest6 + invest7 + invest8 + invest10; }
            }

            resultinvest = invest0 + invest1 + invest2 + invest3 + invest4 + invest5 + temp + invest9;
            textinvest.Text = resultinvest.ToString("#,0");
        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown40_ValueChanged(sender, e);
            resulteconomy = 0;
            int economy0 = Convert.ToInt32(numericUpDown21.Value);
            int economy1 = Convert.ToInt32(numericUpDown22.Value);
            int economy2 = Convert.ToInt32(numericUpDown23.Value);
            int economy3 = Convert.ToInt32(numericUpDown24.Value);
            int economy4 = Convert.ToInt32(numericUpDown25.Value);
            int economy5 = Convert.ToInt32(numericUpDown26.Value);

            if (numericUpDown25.Focused)
            {
                while (true)
                {
                    if ((economy4 + economy5) > 20000) { economy4 -= 1; }
                    else { numericUpDown25.Value = Convert.ToInt32(economy4); break; }
                }
            }
            else if (numericUpDown26.Focused)
            {
                while (true)
                {
                    if ((economy4 + economy5) > 20000) { economy5 -= 1; }
                    else { numericUpDown26.Value = Convert.ToInt32(economy5); break; }
                }
            }
            resulteconomy = economy0 + economy1 + economy2 + economy3 + economy4 + economy5;
            economy.Text = resulteconomy.ToString("#,0");
        }

        private void numericUpDown40_ValueChanged(object sender, EventArgs e)
        {
            double sum0, sum1;
            resultdonate = 0;
            sum0 = (salary - (resultfamily + resultinvest + resultinterest + resulteconomy)) * 0.1;
            if (sum0 < 0) { sum0 = 0; }
            label153.Text = sum0.ToString("#,0.#");
            numericUpDown40.Maximum = Convert.ToInt32(sum0 / 2);
            double donate0 = Convert.ToDouble(numericUpDown40.Value) * 2;

            sum1 = (salary - (resultfamily + resultinvest + resultinterest + resulteconomy + donate0)) * 0.1;
            if (sum1 < 0) { sum1 = 0; }
            label168.Text = sum1.ToString("#,0.#");
            numericUpDown41.Maximum = Convert.ToInt32(sum1);
            double donate1 = Convert.ToDouble(numericUpDown41.Value);

            double donate2 = Convert.ToDouble(numericUpDown42.Value);
            resultdonate = donate0 + donate1 + donate2;
            textBoxdonate.Text = resultdonate.ToString("#,0");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textsalaley_ValueChanged(sender, e);

            if (answer >= 0 && answer <= 150000) { answer = 0; }
            else if (answer >= 150001 && answer <= 300000) { answer = (answer - 150000) * 0.05; }
            else if (answer >= 300001 && answer <= 500000) { answer = ((answer - 300000) * 0.1) + 7500; }
            else if (answer >= 500001 && answer <= 750000) { answer = ((answer - 500000) * 0.15) + 27500; }
            else if (answer >= 750001 && answer <= 1000000) { answer = ((answer - 750000) * 0.2) + 65000; }
            else if (answer >= 1000001 && answer <= 2000000) { answer = ((answer - 1000000) * 0.25) + 115000; }
            else if (answer >= 2000001 && answer <= 5000000) { answer = ((answer - 2000000) * 0.3) + 365000; }
            else if (answer > 5000000) { answer = ((answer - 5000000) * 0.35) + 1265000; }
            resultLabel.Text = answer.ToString("#,0.##");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "โสด";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown29.Value = 0;
            numericUpDown30.Value = 0;
            numericUpDown31.Value = 0;
            numericUpDown32.Value = 0;
            numericUpDown33.Value = 0;
            numericUpDown34.Value = 0;
            numericUpDown35.Value = 0;
            numericUpDown36.Value = 0;
            numericUpDown37.Value = 0;
            numericUpDown38.Value = 0;
            numericUpDown39.Value = 0;
            numericUpDown21.Value = 0;
            numericUpDown22.Value = 0;
            numericUpDown23.Value = 0;
            numericUpDown24.Value = 0;
            numericUpDown25.Value = 0;
            numericUpDown26.Value = 0;
            numericUpDown40.Value = 0;
            numericUpDown41.Value = 0;
            numericUpDown42.Value = 0;
            textsalaley.Value = 0;
            panel1.Visible = false;
            panel2.Visible = false;
        }
    }
}