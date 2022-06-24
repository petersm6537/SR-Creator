using SldWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static SR_Creator.globalFunctions.globalVariablesStatic;

namespace SR_Creator
{
    public partial class formInput : Form
    {
        public formInput()
        {
            InitializeComponent();
        }


        #region Events
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
            if (tabControl.SelectedIndex < 3)
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
            if(createSWInput.Checked = true)
            {
                packAndGo();
            }

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            editDimensions();
        }

        #endregion Events


        #region Methods


        private void writeXML()
        {
            // Writes all values to an XML document

            //Creates new global variable object
            //globalFunctions.globalVariables globalVariables = new globalFunctions.globalVariables();
            
            //Assigns values to XML elements, from input form
            partNumber = inputPartNumber.Text;
            insideDiameter = inputInsideDiameter.Value;
            crossSection = inputCrossSection.Value;
            thickness = inputThickness.Value;
            slitThickness = Convert.ToDecimal(inputSlitThickness.Text);
            slitAngle = inputSlitAngle.Text;
            comments = partNumber;

            //Creates new XML object and establishes elements
            XDocument configXML = new XDocument(
                new XComment($"{comments} XML Configuration DO NOT DELETE"),
                new XElement("SlitRingDimensions",
                    new XElement("insideDiameter", insideDiameter),
                    new XElement("crossSection", crossSection),
                    new XElement("slitThickness", slitThickness),
                    new XElement("slitAngle", slitAngle)));

            //Enter savefiledialog here
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Users\Public\Documents";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = $@"{partNumber}-Configuration.xml";


            //Save file with save file dialog, have the option to cancel
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = saveFileDialog.FileName;
                configXML.Save(filepath);
                this.Close();

            }

        }

        public void getFileDirectory()
        {
            //Sets filepath, can be used globally
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileDirectory = Path.GetDirectoryName(openFileDialog.FileName);
            }
        }

        public void getPackAndGoTemplate()
        {
            try
            {
                if (slitAngle == "20.5")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\20.5 Degree\Design\20.5 Degree-Slitting Fixture.SLDDRW";
                }
                if (slitAngle == "25")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\25 Degree\Design\25 Degree-Slitting Fixture.SLDDRW";
                }
                if (slitAngle == "45")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\45 Degree\Design\45 Degree-Slitting Fixture.SLDDRW";
                }

            }
            catch
            {
                MessageBox.Show("Error: Slit angle not chosen");
            }
        }

        public void packAndGo()
        {
            //Pack and goes the SW drawing to selected location

            //Create solidworks objects
            ModelDoc2 swModelDoc = default(ModelDoc2);
            ModelDocExtension swModelDocExt = default(ModelDocExtension);
            PackAndGo swPackAndGo = default(PackAndGo);
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();

            //Get directories
            getPackAndGoTemplate();

            //Open drawing
            swModelDoc = (ModelDoc2)swApp.OpenDoc6(swPackAndGoDirectory, 3,2,"",0,0);
            swModelDocExt = (ModelDocExtension)swModelDoc.Extension;

            //Get pack and go object
            swPackAndGo = (PackAndGo)swModelDocExt.GetPackAndGo();


            //Adjust properties of pack and go
            swPackAndGo.IncludeDrawings = true;
            swPackAndGo.SetSaveToName(true, fileDirectory = Path.GetDirectoryName(filepath));
            swPackAndGo.AddPrefix = $"{partNumber}-";

            //Pack and go
            swModelDocExt.SavePackAndGo(swPackAndGo);

        }

        public void editDimensions()
        {
            //Creates all solidworks objects
            ModelDoc2 swModelDoc = default(ModelDoc2);
            ModelDocExtension swModelDocExt = default(ModelDocExtension);
            SelectionMgr swSelectionMgr = default(SelectionMgr);
            //Feature swFeat = default(Feature);
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();
            SldWorks.Dimension swInsideDiameter;
            //Dimension swInsideDiameter = default(Dimension);
            Sketch swSketch = default(Sketch);
            //SelectData swSelData = default(SelectData);

            insideDiameter = .625M;

            //sets doc to correct doc
            swModelDoc = swApp.ActiveDoc;
            swModelDocExt = swModelDoc.Extension;



        }


        #endregion Methods


    }
}
