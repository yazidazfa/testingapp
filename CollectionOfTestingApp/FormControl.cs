using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionOfTestingApp
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var formgroup1 = new FormGroup1();
            //formgroup1.Show();

            userControl(userGroup11);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var formgroup2 = new FormGroup2();
            //formgroup2.Show();
            userControl(userGroup21);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var formgroup3 = new FormGroup3();
            //formgroup3.Show();
            userControl(userGroup31);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //var formgroup7 = new FormGroup7();
            //formgroup7.Show();
            userControl(userGroup71);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //var formgroup6 = new FormGroup6();
            //formgroup6.Show();
            //userControl(userGroup61);
            elementHost1.Visible = true;
            elementHost1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //var formgroup5 = new FormGroup5();
            //formgroup5.Show();
            userControl(userGroup91);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //var formgroup4 = new FormGroup4();
            //formgroup4.Show();
            userControl(userGroup41);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            userControl(userControl11);
        }

        private void FormControl_Load(object sender, EventArgs e)
        {
            userControl(userControl11);
        }

        public void userControl(UserControl userControl)
        {
            userControl11.Visible = false;
            userGroup31.Visible = false;
            userGroup11.Visible = false;
            userGroup71.Visible = false;
            userGroup91.Visible = false;
            userGroup81.Visible = false;
            userGroup41.Visible = false;
            loadTesting.Visible = false;
            instrumentation.Visible = false;
            selfDocumentation.Visible = false;
            conciseness.Visible = false;
            dataCommonality.Visible = false;
            halsteadCalculator.Visible = false;
            performanceExecution.Visible = false;
            errorTolerance.Visible = false;
            
            
            //userGroup61.Visible = false;
            //userGroup21.Visible = false;
            //userControl12.Visible


            userControl.Visible = true;
            userControl.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userControl(userGroup81);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userControl(loadTesting);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
           userControl(instrumentation);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            userControl(selfDocumentation);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            userControl(performanceExecution);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            userControl(conciseness);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            userControl(dataCommonality);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            userControl(halsteadCalculator);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            userControl(cyclomaticComplexity);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            userControl(errorTolerance);
        }
    }
}
