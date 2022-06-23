using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR_Creator
{
    public partial class formInput : Form
    {
        public formInput()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //Press back button, go back a tab
            int selectedTab = tabControl.SelectedIndex;
            if (tabControl.SelectedIndex > 0)
            {
                tabControl.SelectedIndex = selectedTab - 1;
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            //Press forward button, go forward a tab
            int selectedTab = tabControl.SelectedIndex;
            if(tabControl.SelectedIndex < 3)
            {
                tabControl.SelectedIndex = selectedTab + 1;
            }
        }
    }
}
