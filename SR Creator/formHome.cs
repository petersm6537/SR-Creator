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
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }

        private void inputNew_Click(object sender, EventArgs e)
        {
            formInput formInput = new formInput();
            formInput.ShowDialog();
        }
    }
}
