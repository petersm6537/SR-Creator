using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SR_Creator
{
    public partial class formInput : Form
    {
        public formInput()
        {
            InitializeComponent();
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

        private void disableForwardButton()
        {
            // Disables forward button if user is at final tab
            if (tabControl.SelectedIndex > 1)
            {
                forwardButton.Enabled = false;
            }

            else
            {
                forwardButton.Enabled = true;
            }
        }

        private void disableBackButton()
        {
            // Disables forward button if user is at final tab
            if (tabControl.SelectedIndex == 0)
            {
                backButton.Enabled = false;
            }

            else
            {
                backButton.Enabled = true;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            disableForwardButton();
            disableBackButton();
        }

        private void formInput_Load(object sender, EventArgs e)
        {
            disableForwardButton();
            disableBackButton();
        }

        private void createConfigButton_Click(object sender, EventArgs e)
        {
            //Dump values into XML, need to be able to check everything is there

            writeXML();

        }

        private void writeXML()
        {
            // Writes all values to an XML document

            //Creates new global variable object
            globalFunctions.globalVariables globalVariables = new globalFunctions.globalVariables();

            //Assigns values to XML elements, from input form
            globalVariables.comments = "Comments";
            globalVariables.partNumber = inputPartNumber.Text;
            globalVariables.insideDiameter = inputInsideDiameter.Value;
            globalVariables.crossSection = inputCrossSection.Value;
            globalVariables.thickness = inputThickness.Value;
            globalVariables.slitThickness = Convert.ToDecimal(inputSlitThickness.Text);
            globalVariables.slitAngle = inputSlitAngle.Text;


            //Creates new XML object and establishes elements
            XDocument configXML = new XDocument(
                new XComment("Comment"),
                new XElement("Root",
                    new XElement("insideDiameter", globalVariables.insideDiameter),
                    new XElement("crossSection", globalVariables.crossSection),
                    new XElement("slitThickness", globalVariables.slitThickness),
                    new XElement("slitAngle", globalVariables.slitAngle)));

            //Enter savefiledialog here

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Users\Public\Documents";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = $@"{globalVariables.partNumber}-Configuration.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                globalVariables.filepath = saveFileDialog.FileName;
                configXML.Save(globalVariables.filepath);
                this.Close();

            }

        }
    }
}
