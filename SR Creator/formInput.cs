using SldWorks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class SS : Form
    {
        public SS()
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
            // Disables back button if user is at final tab
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
            //If tab index is changed, the form decides if it needs to disable forward or back buttons
            disableForwardButton();
            disableBackButton();
        }

        private void formInput_Load(object sender, EventArgs e)
        {
            //When the form is loaded, the form decides if it needs to disable forward or back buttons
            disableForwardButton();
            disableBackButton();
            inputPartNumber.Select();
        }

        private void createConfigButton_Click(object sender, EventArgs e)
        {
            //Writes and XML, and if box is checked, pack and gos SW files
            
            writeXML();

            if(createSWInput.Checked == true)
            {
                swFunctions();
            }

        }

        #endregion Events


        #region Methods


        private void writeXML()
        {
            // Writes all values entered in form to an XML document, will be imported into a solidworks file

            //Creates new global variable object
            //globalFunctions.globalVariables globalVariables = new globalFunctions.globalVariables();
            
            //Assigns values to XML elements, from input form
            partNumber = inputPartNumber.Text;
            revisionNumber = inputRevisionNumber.Text;
            insideDiameter = inputInsideDiameter.Value;
            crossSection = inputCrossSection.Value;
            thickness = inputThickness.Value;
            try { slitThickness = Convert.ToDecimal(inputSlitThickness.Text); }
            catch { }
            slitAngle = inputSlitAngle.Text;
            comments = partNumber;

            //Creates new XML object and establishes elements
            XDocument configXML = new XDocument(
                new XComment($"{comments} XML Configuration DO NOT DELETE"),
                new XElement("SlitRingDimensions",
                    new XElement("PartNumber",partNumber),
                    new XElement("RevisionNumber",revisionNumber),
                    new XElement("insideDiameter", insideDiameter),
                    new XElement("crossSection", crossSection),
                    new XElement("Thickness", thickness),
                    new XElement("slitThickness", slitThickness),
                    new XElement("slitAngle", slitAngle))) ;

            //Creates a save file dialog object
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

            //Gets the filepath for the correct slit ring template to use based on the "slit angle" selected in the form
            try
            {
                if (slitAngle == "20.5")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\20.5 Degree\Slitting Fixture.SLDDRW";
                }
                if (slitAngle == "25")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\25 Degree\Slitting Fixture.SLDDRW";
                }
                if (slitAngle == "45")
                {
                    swPackAndGoDirectory = $@"{ staticFileDirectory}\45 Degree\Slitting Fixture.SLDDRW";
                }

            }
            catch
            {
                MessageBox.Show("Error: Slit angle not chosen");
            }
        }

        public void editSwDrawingCustomProps()
        {
            //Edit custom properties in drawing

            SldWorks.SldWorks swApp = new SldWorks.SldWorks();

            swApp.CommandInProgress = true;
            swApp.UserControl = true;

            ModelDoc2 swModelDoc = swApp.ActiveDoc;

            ModelDocExtension swModelDocExt = swModelDoc.Extension;

            
            //Below is how you access general custom properties
            CustomPropertyManager customPropertyManager = swModelDocExt.CustomPropertyManager[""];

            //Overwrites the existing custom properties
            customPropertyManager.Add3("Job Number", (int)swCustomInfoType_e.swCustomInfoText, "", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Stamp Mold", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber} {revisionNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Revision", (int)swCustomInfoType_e.swCustomInfoText, $@"{revisionNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Designer", (int)swCustomInfoType_e.swCustomInfoText, "CRC", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

            swModelDoc.EditRebuild3();

        }

        public void swFunctions()
        {
            //PERFORMS ALL SOLIDWORKS FUNCTIONS IN ONE METHOD
            //SEEMS TO BE PROBLEMS WHEN CREATING MORE THAN ONE OBJECT

            //Create solidworks objects
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();
            
            swApp.CommandInProgress = true;
            swApp.UserControl = true;



            ModelDoc2 swModelDoc = default(ModelDoc2);
            ModelDocExtension swModelDocExt = default(ModelDocExtension);
            PackAndGo swPackAndGo = default(PackAndGo);

            
            //Pack and goes the SW drawing to selected location
            
            
            
            //Get directories
            getPackAndGoTemplate();

            //Open drawing
            //swModelDoc = swApp.OpenDoc6(swPackAndGoDirectory, 3, 2, "", 0, 0);

            swModelDoc = swApp.OpenDoc6(swPackAndGoDirectory, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 1,1);

            swModelDocExt = (ModelDocExtension)swModelDoc.Extension;

            //Get pack and go object
            swPackAndGo = (PackAndGo)swModelDocExt.GetPackAndGo();


            //Adjust properties of pack and go
            swPackAndGo.IncludeDrawings = true;
            swPackAndGo.SetSaveToName(true, fileDirectory = Path.GetDirectoryName(filepath));
            swPackAndGo.AddPrefix = $"{partNumber}-";

            //Pack and go
            swModelDocExt.SavePackAndGo(swPackAndGo);


            //Closes the drawing
            swApp.CloseDoc(swModelDoc.GetPathName());
            
            
            
            
            //BEGIN OPENING DOCUMENTS AND EDITING





            //Establishes filepaths for all documents to be edited
            string assemblyPath = $@"{fileDirectory}\{partNumber}-Slitting Fixture.sldasm";
            string drawingPath = $@"{fileDirectory}\{partNumber}-Slitting Fixture.slddrw";
            string topPlatePath = $@"{fileDirectory}\{partNumber}-Top Plate.sldprt";
            string bottomPlatePath = $@"{fileDirectory}\{partNumber}-Bottom Plate.sldprt";




            //SOLIDWORKS ASSEMBLY PORTION
            //Opens assembly and edits dimensions
            swModelDoc = swApp.OpenDoc6(assemblyPath, 2, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);

            //Creates dimension objects for each dimension
            Dimension swInsideDiameter = swModelDoc.Parameter($@"D1@Sketch1@{partNumber}-Wearband-Piston.Part");
            Dimension swCrossSection = swModelDoc.Parameter($@"D2@Sketch1@{partNumber}-Wearband-Piston.Part");
            Dimension swThickness = swModelDoc.Parameter($@"D1@Boss-Extrude1@{partNumber}-Wearband-Piston.Part");
            Dimension swSlitThick = swModelDoc.Parameter($@"D2@Sketch2@{partNumber}-Wearband-Piston.Part");


            //Sets the values of the dimensions
            swInsideDiameter.SetValue3(Convert.ToDouble(insideDiameter), 2, null);
            swCrossSection.SetValue3(Convert.ToDouble(crossSection), 2, null);
            swThickness.SetValue3(Convert.ToDouble(thickness), 2, null);
            swSlitThick.SetValue3(Convert.ToDouble(slitThickness), 2, null);

            //Rebuilds and saves document
            swModelDoc.EditRebuild3();
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, -1);


            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());



            //SOLIDWORKS PARTS PORTION
            //Opens the top plate and changes engraving
            swModelDoc = swApp.OpenDoc6(topPlatePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
            Configuration swConfig = swModelDoc.GetActiveConfiguration();
            CustomPropertyManager swCustomPropMgr = swConfig.CustomPropertyManager;
            swCustomPropMgr.Add3("Part Number", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());

            //Opens the bottom plate and changes engraving
            swModelDoc = swApp.OpenDoc6(bottomPlatePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
            swConfig = swModelDoc.GetActiveConfiguration();
            swCustomPropMgr = swConfig.CustomPropertyManager;
            swCustomPropMgr.Add3("Part Number", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());



            //SOLIDWORKS DRAWING PORTION
            //Opens drawing rebuilds and saves
            swModelDoc = swApp.OpenDoc6(drawingPath, 3, 1, "", 0, 0);
            swModelDocExt = swModelDoc.Extension;

            //Changes general custom properties
            CustomPropertyManager customPropertyManager = swModelDocExt.CustomPropertyManager[""];

            //Overwrites the existing custom properties
            customPropertyManager.Add3("Job Number", (int)swCustomInfoType_e.swCustomInfoText, "", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Stamp Mold", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber} {revisionNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Revision", (int)swCustomInfoType_e.swCustomInfoText, $@"{revisionNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            customPropertyManager.Add3("Designer", (int)swCustomInfoType_e.swCustomInfoText, "MMP", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);


            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            swModelDoc.Extension.SaveAs3($@"{drawingPath}.pdf", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, null, 0, 0);

            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());

            //swApp.ExitApp();

        }

        public void packAndGo()
        {
            //OBSOLETE REMOVE



            //Pack and goes the SW drawing to selected location

            //Create solidworks objects
            ModelDoc2 swModelDoc = default(ModelDoc2);
            ModelDocExtension swModelDocExt = default(ModelDocExtension);
            PackAndGo swPackAndGo = default(PackAndGo);
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();

            swApp.Visible = true;
            swApp.UserControl = true;

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

            
            //Closes the drawing
            swApp.CloseDoc(swModelDoc.GetPathName());

            //Opens assembly and edit dims
            editDimensions();



        }

        public void editDimensions()
        {
            //OBSOLETE REMOVE
            
            
            
            
            //This method is meant to open the solidworks files created, and change the dimension values to the values entered in the form
            //Creates all solidworks objects
            SldWorks.SldWorks swApp = new SldWorks.SldWorks();

            swApp.Visible = true;

            //Establishes filepaths for all documents to be edited
            string assemblyPath = $@"{fileDirectory}\{partNumber}-Slitting Fixture.sldasm";
            string drawingPath = $@"{fileDirectory}\{partNumber}-Slitting Fixture.slddrw";
            string topPlatePath = $@"{fileDirectory}\{partNumber}-Top Plate.sldprt";
            string bottomPlatePath = $@"{fileDirectory}\{partNumber}-Bottom Plate.sldprt";

            
            
            
            //SOLIDWORKS ASSEMBLY PORTION
            //Opens assembly and edits dimensions
            ModelDoc2 swModelDoc = swApp.OpenDoc6(assemblyPath,2, (int)swOpenDocOptions_e.swOpenDocOptions_Silent,"", 0,0);

            //Creates dimension objects for each dimension
            Dimension swInsideDiameter = swModelDoc.Parameter($@"D1@Sketch1@{partNumber}-Wearband-Piston.Part");
            Dimension swCrossSection = swModelDoc.Parameter($@"D2@Sketch1@{partNumber}-Wearband-Piston.Part");
            Dimension swThickness = swModelDoc.Parameter($@"D1@Boss-Extrude1@{partNumber}-Wearband-Piston.Part");
            Dimension swSlitThick = swModelDoc.Parameter($@"D2@Sketch2@{partNumber}-Wearband-Piston.Part");


            //Sets the values of the dimensions
            swInsideDiameter.SetValue3(Convert.ToDouble(insideDiameter),2,null);
            swCrossSection.SetValue3(Convert.ToDouble(crossSection), 2, null);
            swThickness.SetValue3(Convert.ToDouble(thickness), 2, null);
            swSlitThick.SetValue3(Convert.ToDouble(slitThickness), 2, null);

            //Rebuilds and saves document
            swModelDoc.EditRebuild3();
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0,-1);


            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());



            //SOLIDWORKS PARTS PORTION
            //Opens the top plate and changes engraving
            swModelDoc = swApp.OpenDoc6(topPlatePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
            Configuration swConfig = swModelDoc.GetActiveConfiguration();
            CustomPropertyManager swCustomPropMgr = swConfig.CustomPropertyManager;
            swCustomPropMgr.Add3("Part Number", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());

            //Opens the bottom plate and changes engraving
            swModelDoc = swApp.OpenDoc6(bottomPlatePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
            swConfig = swModelDoc.GetActiveConfiguration();
            swCustomPropMgr = swConfig.CustomPropertyManager;
            swCustomPropMgr.Add3("Part Number", (int)swCustomInfoType_e.swCustomInfoText, $@"{partNumber}", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());



            //SOLIDWORKS DRAWING PORTION
            //Opens drawing rebuilds and saves
            swModelDoc = swApp.OpenDoc6(drawingPath, 3, 1, "", 0, 0);
            swModelDoc.ForceRebuild3(false);
            swModelDoc.Save3((int)swSaveAsOptions_e.swSaveAsOptions_SaveReferenced, 0, 0);
            swModelDoc.Extension.SaveAs3($@"{drawingPath}.pdf",(int)swSaveAsVersion_e.swSaveAsCurrentVersion,(int)swSaveAsOptions_e.swSaveAsOptions_Silent,null,null,0,0);
            
            //Closes document
            swApp.CloseDoc(swModelDoc.GetPathName());

            swApp.ExitApp();
        }

        #endregion Methods

        private void button1_Click(object sender, EventArgs e)
        {
            editSwDrawingCustomProps();
        }
    }
}
