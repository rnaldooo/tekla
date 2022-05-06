using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSM = Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using System.Collections;
using Tekla.Structures.Geometry3d;
using System.Threading;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Solid;
using TSD = Tekla.Structures.Drawing;
using TSDUI = Tekla.Structures.Drawing.UI;



namespace criarvistaelevacao
{
    //extern alias v210;

    public partial class Form1 : Form
    {


        TSM.Model myModel = new TSM.Model();
        TSM.Beam vigaPrincipal;
        TSM.ContourPlate chPrincipal;
        TSM.BoltArray baPrincipal;
        TSM.BoltGroup bgPrincipal;
        TSM.Beam vigapolyPrincipal;
        int para = 0;
        int i_arred1 = 5;

        //TSM.Beam vigaSecundaria;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Picker picker = new Picker();

            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            TSM.Part obj1 = (TSM.Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            vigaPrincipal = obj1 as Beam;
            double topLevel = 0.0000;
            string str = String.Empty;
            bool f = vigaPrincipal.GetReportProperty("TOP_LEVEL_UNFORMATTED", ref topLevel);
            //vigaPrincipal.
            // topLevel = topLevel / 1000.0;
            toplevel1.Text = topLevel.ToString();
            vigaPrincipal.GetReportProperty("ASSEMBLY_POS", ref str);
            apos1.Text = str;
            //  TSM.UI.View View1 = new TSM.UI.View();
            //  View1.Name = "Example View";
            //  View1.
            //  View1.ViewCoordinateSystem.AxisX = new Vector(1, 0, 0);
            // View1.ViewCoordinateSystem.AxisY = new Vector(0, 1, 0);
            // Work area has to be set for new views
            //  View1.WorkArea.MinPoint = new Point(-3000, -3000, -3000);
            //  View1.WorkArea.MaxPoint = new Point(15000, 33000, 12000);
            //  View1.ViewDepthUp = 10000;
            //  View1.ViewDepthDown = 2000;
            // View1.Insert();
            // View1.WorkArea.MinPoint = new Point(-3000, -3000, -3000);
            // View1.WorkArea.MaxPoint = new Point(5000, 3000, 2000);
            //View1.Modify();
            int ia = 0;
            ModelViewEnumerator ViewEnum = ViewHandler.GetAllViews();
            while (ViewEnum.MoveNext())
            {
                TSM.UI.View Viewt = ViewEnum.Current;

                if (Viewt.Name == ("Vista" + ia))
                {
                    while (Viewt.Name == ("Vista" + ia))
                    {
                        ia++;
                    }
                }
            }
            // ViewCoordinateSystem = { Origin = new Point(0, 0, topLevel), AxisX = new Vector(1, 0, 0), AxisY = new Vector(0, 1, 0) };
            //  CoordinateSystem CoordinateSystem1 = new CoordinateSystem(new Point(), new Vector(1, 0, 0), new Vector(0, 1, 0));
            //Point d11, d22;
            var view2 = new TSM.UI.View();
            view2.DisplayCoordinateSystem.AxisX = new Vector(1000.0, 0.0, 0.0);
            view2.DisplayCoordinateSystem.AxisY = new Vector(0.0, 1000.0, 0.0);
            view2.DisplayCoordinateSystem.Origin = new Point(0.0, 0.0, topLevel);
            view2.DisplayType = TSM.UI.View.DisplayOrientationType.DISPLAY_VIEW_PLANE;
            //Identifier = 
            view2.Name = "Vista" + ia.ToString();
            view2.ViewCoordinateSystem.AxisX = new Vector(1000.0, 0.0, 0.0);
            view2.ViewCoordinateSystem.AxisY = new Vector(0.0, 1000.0, 0.0);
            view2.ViewCoordinateSystem.Origin = new Point(0.0, 0.0, topLevel);
            view2.ViewDepthDown = 500.0;
            view2.ViewDepthUp = 500.0;
            //ViewFilter = "Plan view"
            //ViewProjection = TSM.UI.View.ViewProjectionType.ORTHOGONAL_PROJECTION,
            //ViewRendering = TSM.UI.View.ViewRenderingType.WIREFRAME_VIEW,
            //view2.WorkArea.MinPoint = new Point(-3000.0, -3000.0, -3000.0);
            //view2.WorkArea.MaxPoint = new Point(5000.0, 3000.0, 2000.0);
            view2.Insert();
            view2.Modify();
            ViewHandler.ShowView(view2);

            //WorkArea = { MinPoint = new Point(-3000, -3000, -3000), MaxPoint = new Point(3000, 3000, 3000) },

            //
            //var view4 = new TSM.UI.View();
            //{
            //View newView = new View(GADrawing.GetSheet(), CoordinateSystem, CoordinateSystem, new AABB(new Point(0, 0), new Point(1000, 1000, 1000)));
            //.DisplayCoordinateSystem = { Origin = new Point(0, 0, topLevel), AxisX = new Vector(1, 0, 0), AxisY = new Vector(0, 1, 0) },
            //ViewCoordinateSystem = { Origin = new Point(0, 0, topLevel), AxisX = new Vector(1, 0, 0), AxisY = new Vector(0, 1, 0) },
            //};
            //d11 = vigaPrincipal.StartPoint;
            //d22 = vigaPrincipal.EndPoint;
            //view2.IsPerspectiveViewProjection();
            //view2.ViewProjection = TSM.UI.View.ViewProjectionType.ORTHOGONAL_PROJECTION;
            //view2.ViewRendering = TSM.UI.View.ViewRenderingType.WIREFRAME_VIEW;
            //vigaPrincipal.StartPoint =
            //   vigaPrincipal.EndPoint =


            //  ViewHandler.ShowView("Example View");

            //MessageBox.Show(texto);
            //vigaPrincipal.Insert();
            // myModel.CommitChanges();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Tekla.Structures.Model.UI
            TSM.Model myModel2 = new TSM.Model();
            //Tekla.Structures.



            ModelViewEnumerator ViewEnum = ViewHandler.GetAllViews();
            while (ViewEnum.MoveNext())
            {
                TSM.UI.View Viewt = ViewEnum.Current;
                comboBox1.Items.Add(Viewt.ViewFilter);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // limparTextBoxes();

            Picker picker = new Picker();
            try { i_arred1 = int.Parse(tb_casasdec.Text); } catch { }

            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            try
            {
                TSM.Part obj1 = (TSM.Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);


                string classe1 = obj1.Class;
                try { textBox21.Text = obj1.Position.Depth.ToString(); } catch { }
                try { textBox18.Text = Math.Round(obj1.Position.DepthOffset, i_arred1).ToString().Replace(",", "."); } catch { }
                try { textBox20.Text = obj1.Position.Plane.ToString(); } catch { }
                try { textBox17.Text = Math.Round(obj1.Position.PlaneOffset, i_arred1).ToString().Replace(",", "."); } catch { }
                try { textBox19.Text = obj1.Position.Rotation.ToString(); } catch { }
                try { textBox23.Text = Math.Round(obj1.Position.RotationOffset, i_arred1).ToString().Replace(",", "."); } catch { }


                string classe2 = obj1.GetType().ToString();
                cclasse.Text = classe2;

                if (classe2 == "Tekla.Structures.Model.ContourPlate")
                {
                    chPrincipal = obj1 as Tekla.Structures.Model.ContourPlate;
                    double topLevel = 0.0000;
                    double xi1 = 0.0000;
                    double xf1 = 0.0000;
                    double yi1 = 0.0000;
                    double yf1 = 0.0000;
                    double zi1 = 0.0000;
                    double zf1 = 0.0000;
                    double compr = 0.0000;
                    double larg = 0.0000;
                    double altu = 0.0000;
                    int fasee = 99999;
                    string str = String.Empty;
                    string str2 = String.Empty;
                    string acab = String.Empty;
                    try
                    {
                        bool f = chPrincipal.GetReportProperty("TOP_LEVEL_UNFORMATTED", ref topLevel);
                        //vigaPrincipal.
                        // topLevel = topLevel / 1000.0;                
                        str2 = topLevel.ToString();
                        str2 = str2.Replace(",", ".");
                        toplevel1.Text = str2;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("ASSEMBLY_POS", ref str);
                        apos1.Text = str;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("PART_POS", ref str);
                        ppos1.Text = str;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("LENGTH", ref compr);
                        ccompri1.Text = Math.Round(compr, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("WIDTH", ref larg);
                        ccompri2.Text = Math.Round(larg, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("HEIGHT", ref altu);
                        ccompri3.Text = Math.Round(altu, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("PHASE.NAME", ref str);
                        ffase2.Text = str;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("MATERIAL", ref str);
                        mmate1.Text = str;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("PROFILE", ref str);
                        pperf.Text = str;
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("PHASE", ref fasee);
                        ffase1.Text = fasee.ToString();
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("PHASE", ref fasee);
                        ffase1.Text = fasee.ToString();
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("START_X", ref xi1);
                        dx1.Text = Math.Round(xi1, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("START_Y", ref yi1);
                        dy1.Text = Math.Round(yi1, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("START_Z", ref zi1);
                        dz1.Text = Math.Round(zi1, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("END_X", ref xf1);
                        dx2.Text = Math.Round(xf1, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("END_Y", ref yf1);
                        dy2.Text = Math.Round(yf1, i_arred1).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        chPrincipal.GetReportProperty("END_Z", ref zf1);
                        dz2.Text = Math.Round(zf1, i_arred1).ToString().Replace(",", ".");
                        double x11 = (xf1 - xi1);
                        double y11 = (yf1 - yi1);
                        double z11 = (zf1 - zi1);
                        double ddist = Math.Sqrt(Math.Pow(x11, 2) + Math.Pow(y11, 2) + Math.Pow(z11, 2));
                        ddx1.Text = x11.ToString().Replace(",", ".");
                        ddy1.Text = y11.ToString().Replace(",", ".");
                        ddz1.Text = z11.ToString().Replace(",", ".");
                        ddist1.Text = ddist.ToString().Replace(",", ".");
                        ddang1.Text = (Math.Atan(x11 / y11) * 180 / Math.PI).ToString().Replace(",", ".");
                    }
                    catch { }
                    try
                    {
                        vigaPrincipal.GetReportProperty("FINISH", ref acab);
                        mmate2.Text = acab.ToString().Replace(",", ".");
                    }
                    catch { }

                    try
                    {
                        Clipboard.SetText(str2);
                    }
                    catch { }
                }
                else
                {
                    if (classe2 == "Tekla.Structures.Model.Beam")
                    {
                        vigaPrincipal = obj1 as Tekla.Structures.Model.Beam;

                        double topLevel = 0.0000;
                        double xi1 = 0.0000;
                        double xf1 = 0.0000;
                        double yi1 = 0.0000;
                        double yf1 = 0.0000;
                        double zi1 = 0.0000;
                        double zf1 = 0.0000;
                        double compr = 0.0000;
                        double larg = 0.0000;
                        double altu = 0.0000;
                        int fasee = 99999;
                        string str = String.Empty;
                        string str2 = String.Empty;
                        string acab = String.Empty;
                        try
                        {
                            bool f = vigaPrincipal.GetReportProperty("TOP_LEVEL_UNFORMATTED", ref topLevel);
                            //vigaPrincipal.
                            // topLevel = topLevel / 1000.0;                
                            str2 = topLevel.ToString();
                            str2 = str2.Replace(",", ".");
                            toplevel1.Text = str2;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("ASSEMBLY_POS", ref str);
                            apos1.Text = str;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("PART_POS", ref str);
                            ppos1.Text = str;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("LENGTH", ref compr);
                            ccompri1.Text = Math.Round(compr, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            chPrincipal.GetReportProperty("WIDTH", ref larg);
                            ccompri2.Text = Math.Round(larg, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            chPrincipal.GetReportProperty("HEIGHT", ref altu);
                            ccompri3.Text = Math.Round(altu, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("PHASE.NAME", ref str);
                            ffase2.Text = str;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("MATERIAL", ref str);
                            mmate1.Text = str;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("PROFILE", ref str);
                            pperf.Text = str;
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("PHASE", ref fasee);
                            ffase1.Text = fasee.ToString();
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("PHASE", ref fasee);
                            ffase1.Text = fasee.ToString();
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("START_X", ref xi1);
                            dx1.Text = Math.Round(xi1, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("START_Y", ref yi1);
                            dy1.Text = Math.Round(yi1, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("START_Z", ref zi1);
                            dz1.Text = Math.Round(zi1, i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("END_X", ref xf1);
                            dx2.Text = Math.Round(xf1, i_arred1).ToString().Replace(",", ".");
                            //  xf1 = Math.Round(xf1, i_arred1);
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("END_Y", ref yf1);
                            dy2.Text = Math.Round(yf1, i_arred1).ToString().Replace(",", ".");
                            //  yf1 = Math.Round(yf1, i_arred1);
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("END_Z", ref zf1);
                            dz2.Text = zf1.ToString().Replace(",", ".");
                            double x11 = Math.Round((xf1 - xi1), i_arred1);
                            double y11 = Math.Round((yf1 - yi1), i_arred1);
                            double z11 = Math.Round((zf1 - zi1), i_arred1);
                            double ddist = Math.Round(Math.Sqrt(Math.Pow(x11, 2) + Math.Pow(y11, 2) + Math.Pow(z11, 2)), i_arred1);
                            ddx1.Text = x11.ToString().Replace(",", ".");
                            ddy1.Text = y11.ToString().Replace(",", ".");
                            ddz1.Text = z11.ToString().Replace(",", ".");
                            ddist1.Text = ddist.ToString().Replace(",", ".");
                            ddang1.Text = Math.Round((Math.Atan(x11 / y11) * 180 / Math.PI), i_arred1).ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            vigaPrincipal.GetReportProperty("FINISH", ref acab);
                            mmate2.Text = acab.ToString().Replace(",", ".");
                        }
                        catch { }
                        try
                        {
                            Clipboard.SetText(str2);
                        }
                        catch { }
                    }
                    else { }
                }

            }
            catch
            {
                para = 1;
                textBox22.Text = para.ToString();
            }

        }
        public void limparTextBoxes()
        {
            var t = Form.ActiveForm.Controls.OfType<TextBox>().AsEnumerable<TextBox>();
            foreach (TextBox item in t)
            {
                item.Text = "";
            }

            //foreach (Control c in control.Controls)
            //{

            //  if (c is TextBox)
            //  {

            //       ((TextBox)c).Clear();

            //     }

            //     if (c.HasChildren)
            //     {

            //         limparTextBoxes(c);

            //      }

            //    }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            int contador = 0;
            Point pontoanterior = new Point();
            Picker picker = new Picker();
            try
            {
                ArrayList apoin = picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);
                //pontoanterior = apoin[0];
                foreach (Point p in apoin)
                {
                    if (contador == 0)
                    {
                        pontoanterior = p;
                        dx1.Text = pontoanterior.X.ToString().Replace(",", ".");
                        dy1.Text = pontoanterior.Y.ToString().Replace(",", ".");
                        dz1.Text = pontoanterior.Z.ToString().Replace(",", ".");
                    }
                    else
                    {
                        dx2.Text = p.X.ToString().Replace(",", ".");
                        dy2.Text = p.Y.ToString().Replace(",", ".");
                        dz2.Text = p.Z.ToString().Replace(",", ".");
                    }
                    contador++;

                    double x11 = (p.X - pontoanterior.X);
                    double y11 = (p.Y - pontoanterior.Y);
                    double z11 = (p.Z - pontoanterior.Z);
                    double ddist = Math.Sqrt(Math.Pow(x11, 2) + Math.Pow(y11, 2) + Math.Pow(z11, 2));
                    ddx1.Text = x11.ToString().Replace(",", ".");
                    ddy1.Text = y11.ToString().Replace(",", ".");
                    ddz1.Text = z11.ToString().Replace(",", ".");
                    ddist1.Text = ddist.ToString().Replace(",", ".");
                    ddang1.Text = (Math.Atan(x11 / y11) * 180 / Math.PI).ToString().Replace(",", ".");
                }
            }
            catch (Exception e11)
            {
            }
            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            //Part obj1 = (Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
        }
        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            dx1.SelectAll();
        }
        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            dy1.SelectAll();
        }
        private void textBox7_MouseDown(object sender, MouseEventArgs e)
        {
            dz1.SelectAll();
        }
        private void textBox8_MouseDown(object sender, MouseEventArgs e)
        {
            dz2.SelectAll();
        }
        private void textBox9_MouseDown(object sender, MouseEventArgs e)
        {
            dy2.SelectAll();
        }
        private void textBox10_MouseDown(object sender, MouseEventArgs e)
        {
            dx2.SelectAll();
        }
        private void textBox11_MouseDown(object sender, MouseEventArgs e)
        {
            ddz1.SelectAll();
        }
        private void textBox12_MouseDown(object sender, MouseEventArgs e)
        {
            ddy1.SelectAll();
        }
        private void textBox13_MouseDown(object sender, MouseEventArgs e)
        {
            ddx1.SelectAll();
        }
        private void textBox14_MouseDown(object sender, MouseEventArgs e)
        {
            ddist1.SelectAll();
        }
        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            ddang1.SelectAll();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            para = 0;
            while (para == 0)
            {
                //ConsoleKeyInfo info = Console.ReadKey();
                // while (Event.current.KeyCode == Keys.Escape)
                // while (e.KeyCode == Keys.Escape)
                // while (Console.ReadKey().Key != ConsoleKey.Escape)
                //System.Windows.Forms.SendKeys.SendWait("{ESC}");
                //  {
                button3_Click(sender, e);
                this.Refresh();
                //  }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // TSDUI.Picker picker = new TSD.DrawingHandler().GetPicker();
            //TSD.Part obj1 = (TSD.Part)picker.PickObject((TSDUI.Picker.PickObjectEnum.PICK_ONE_PART);



            // TreeView drawingListTreeView = new TreeView();
            //TSD.DrawingHandler DrawingHandler = new TSD.DrawingHandler();
            // CheckBox ShowViews = new CheckBox();
            // CheckBox ShowObjectsInViews = new CheckBox();      
            AddDrawingInformationToDrawingListTreeView();



        }

        private void AddChildDrawingObjectsToTreeNode(TreeNode Node, Tekla.Structures.Drawing.IHasChildren CurrentContainer)
        {
            TSD.DrawingObjectEnumerator ObjectList = CurrentContainer.GetObjects(); // Gets the objects that are placed directly to the current container object.
            ObjectList.SelectInstances = false; // The instances don't need to be automatically selected, only whether the object exists or not has to be found out (objects properties are not used at all).

            while (ObjectList.MoveNext())
            {
                //Console.WriteLine(ObjectList.Current.GetType().ToString());

                if (ShowObjectsInViews.Checked || ObjectList.Current is TSD.ViewBase)
                {
                    TreeNode CurrentNode = new TreeNode("" + ObjectList.Current.GetType());
                    //TreeNode CurrentNode = new TreeNode("" + ObjectList.Current.ToString());

                    CurrentNode.Tag = ObjectList.Current;

                    if (ObjectList.Current is Tekla.Structures.Drawing.IHasChildren)
                        AddChildDrawingObjectsToTreeNode(CurrentNode, ObjectList.Current as TSD.IHasChildren);

                    Node.Nodes.Add(CurrentNode);
                }
            }
        }

        private void AddDrawingInformationToDrawingListTreeView()
        {
            drawingListTreeView.Nodes.Clear();
            TSD.DrawingEnumerator DrawingList = new TSD.DrawingHandler().GetDrawings(); // Get drawing list.

            while (DrawingList.MoveNext())
            {
                TSD.Drawing CurrentDrawing = DrawingList.Current;

                // Add the drawing name to the UI tree.
                TreeNode DrawingNode = new TreeNode();
                DrawingNode.Tag = CurrentDrawing;
                DrawingNode.Text = "" + CurrentDrawing.Mark.ToString();
                //DrawingNode.Text = "" + CurrentDrawing.GetType();

                if (ShowViews.Checked)
                    if (CurrentDrawing.GetType().ToString() != "Tekla.Structures.Drawing.MultiDrawing")
                    {
                        AddChildDrawingObjectsToTreeNode(DrawingNode, CurrentDrawing.GetSheet()); // Add all the objects placed to the sheet to the UI tree.
                    }
                drawingListTreeView.Nodes.Add(DrawingNode);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int contador = 0;
            Point pontoanterior = new Point();
            Picker picker = new Picker();
            double x11 = 0.0, y11 = 0.0, z11 = 0.0, x22 = 0.0, y22 = 0.0, z22 = 0.0;
            try
            {
                ArrayList apoin = picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);

                foreach (Point p in apoin)
                {
                    if (contador == 0)
                    {
                        pontoanterior = p;
                        dx1.Text = pontoanterior.X.ToString().Replace(",", ".");
                        dy1.Text = pontoanterior.Y.ToString().Replace(",", ".");
                        dz1.Text = pontoanterior.Z.ToString().Replace(",", ".");
                        x11 = pontoanterior.X;
                        y11 = pontoanterior.Y;
                        z11 = pontoanterior.Z;
                    }
                    else
                    {
                        dx2.Text = p.X.ToString().Replace(",", ".");
                        dy2.Text = p.Y.ToString().Replace(",", ".");
                        dz2.Text = p.Z.ToString().Replace(",", ".");
                        x22 = pontoanterior.X;
                        y22 = pontoanterior.Y;
                        z22 = pontoanterior.Z;
                    }
                    contador++;
                }



            }
            catch
            {
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {

            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            // TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().GetAllObjects();
            //  foreach (ModelObject obj in myEnum)
            //  {
            //      if (obj is Part)
            //     {
            //        Part parte = obj as Part;

            // while (selectedObjects.MoveNext())
            //  {
            //      Part part = selectedObjects.Current as Part;
            //
            //      Beam beam = part as Beam;
            //      ContourPlate contourPlate = part as ContourPlate;

            //      if (beam != null)
            //       {
            //          MessageBox.Show("This is a beam!");
            //       }
            //      else if (contourPlate != null)
            //       {
            //            MessageBox.Show("This is a contourPlate!");
            //       }
            //     }

            //  TSMUI.ModelObjectSelector modelObjectSelector = new TSMUI.ModelObjectSelector();
            //    TSM.ModelObjectEnumerator selectedObjects = modelObjectSelector.GetSelectedObjects();



            //       Common.Localizer.GetTranslatedString(Common.Constants.MessagesToTheUser.SelectObjects));

            //    ArrayList selectedModelObjectsIDs = new ArrayList();
            //    while (selectedObjectsModelObjectEnumerator.MoveNext())
            //    {
            //        if (selectedObjectsModelObjectEnumerator.Current.GetType() == typeof(Component) ||
            //           selectedObjectsModelObjectEnumerator.Current.GetType() == typeof(CustomPart) ||
            //           selectedObjectsModelObjectEnumerator.Current.GetType() == typeof(Beam))
            //       {
            //           selectedModelObjectsIDs.Add(selectedObjectsModelObjectEnumerator.Current.Identifier);
            //        }
            //    }





            try
            {
                //TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");

                //  TSM.ModelObjectEnumerator myEnum = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_PARTS, "selecione as peças");
                //       foreach (Part pp in myEnum)
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;
                       // PolyBeam pl = pp as PolyBeam;


                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {
                                chPrincipal.GetReportProperty("" + textBox10.Text + "", ref str1);
                                chPrincipal.SetUserProperty("" + textBox11.Text + "", str1.Replace(textBox34.Text,textBox35.Text) + textBox38.Text);
                            }
                            catch { }
                            try
                            {
                                chPrincipal.GetReportProperty("" + textBox15.Text + "", ref str2);
                                chPrincipal.SetUserProperty("" + textBox14.Text + "", str2.Replace(textBox36.Text, textBox37.Text) + textBox39.Text);
                            }
                            catch { }
                        }
                        else
                        {

                            if (classe2 == "Tekla.Structures.Model.PolyBeam")
                            {

                                PolyBeam pl = pp as PolyBeam;
                               // vigapolyPrincipal = pp as PolyBeam;
                                try
                                {
                                    pl.GetReportProperty("" + textBox10.Text + "", ref str1);
                                    pl.SetUserProperty("" + textBox11.Text + "", str1.Replace(textBox34.Text, textBox35.Text) + textBox38.Text);
                                }
                                catch { }
                                try
                                {
                                    pl.GetReportProperty("" + textBox15.Text + "", ref str2);
                                    pl.SetUserProperty("" + textBox14.Text + "", str2.Replace(textBox36.Text, textBox37.Text) + textBox39.Text);
                                }
                                catch { }

                            }
                            else
                            {

                                vigaPrincipal = pp as Beam;
                                try
                                {
                                    vigaPrincipal.GetReportProperty("" + textBox10.Text + "", ref str1);
                                    vigaPrincipal.SetUserProperty("" + textBox11.Text + "", str1.Replace(textBox34.Text, textBox35.Text) + textBox38.Text);
                                }
                                catch { }
                                try
                                {
                                    vigaPrincipal.GetReportProperty("" + textBox15.Text + "", ref str2);
                                    vigaPrincipal.SetUserProperty("" + textBox14.Text + "", str2.Replace(textBox36.Text, textBox37.Text) + textBox39.Text);
                                }
                                catch { }
                            }
                        }
                    }
                    else { }

                }
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {

                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        string str3 = string.Empty;
                        Double compr = 0.000;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {
                                chPrincipal.GetReportProperty("" + textBox13.Text + "", ref str1);
                                chPrincipal.SetUserProperty("" + textBox12.Text + "", str1);
                                //  str3 = "[" + chPrincipal.Position.Depth.ToString() + " ;" + Math.Round(chPrincipal.Position.DepthOffset, 2).ToString().Replace(",", ".") + " ] [" +
                                //               chPrincipal.Position.Plane.ToString() + " ;" + Math.Round(chPrincipal.Position.PlaneOffset, 2).ToString().Replace(",", ".") + " ] [" +
                                //               chPrincipal.Position.Rotation.ToString() + " ;" + Math.Round(chPrincipal.Position.RotationOffset, 2).ToString().Replace(",", ".") + " ]";
                                //  chPrincipal.SetUserProperty("" + textBox29.Text + "", str3);
                            }
                            catch { }
                            try
                            {
                                //   chPrincipal.GetReportProperty("PART_POS", ref str2);
                                //   chPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                        else
                        {
                            vigaPrincipal = pp as Beam;
                            try
                            {
                                str3 = "";
                                if (textBox13.Text == "LENGTH")
                                {
                                    vigaPrincipal.GetReportProperty("LENGTH", ref compr);
                                    str3 = Math.Round(compr, int.Parse(textBox26.Text, System.Globalization.CultureInfo.InvariantCulture)).ToString().Replace(",", ".");
                                    vigaPrincipal.SetUserProperty("" + textBox12.Text + "", str3);
                                }
                                else
                                {

                                    vigaPrincipal.GetReportProperty("" + textBox13.Text + "", ref str1);
                                    vigaPrincipal.SetUserProperty("" + textBox12.Text + "", str1);
                                    str3 = "[" + vigaPrincipal.Position.Depth.ToString() + " ;" + Math.Round(vigaPrincipal.Position.DepthOffset, 2).ToString().Replace(",", ".") + " ] [" +
                                                 vigaPrincipal.Position.Plane.ToString() + " ;" + Math.Round(vigaPrincipal.Position.PlaneOffset, 2).ToString().Replace(",", ".") + " ] [" +
                                                 vigaPrincipal.Position.Rotation.ToString() + " ;" + Math.Round(vigaPrincipal.Position.RotationOffset, 2).ToString().Replace(",", ".") + " ]";
                                    Console.WriteLine("str3 = " + str3);
                                    vigaPrincipal.SetUserProperty("comment", str3); //USER_FIELD_4                              

                                }



                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }


                    }

                    else { }

                    if (obj is BoltArray)
                    {
                        BoltArray bba = obj as BoltArray;
                        string classe3 = bba.GetType().ToString();
                        Console.WriteLine(classe3);

                        string str4 = string.Empty;
                        if (classe3 == "Tekla.Structures.Model.BoltArray")
                        {
                            baPrincipal = bba as Tekla.Structures.Model.BoltArray;
                            try
                            {
                                if (baPrincipal.Bolt)
                                {
                                    // str4 = ":" + baPrincipal.BoltSize.ToString() + "[" + (baPrincipal.Tolerance + baPrincipal.BoltSize).ToString() + "]";
                                    baPrincipal.SetUserProperty("BOLT_COMMENT", "Parafuso");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_1", Math.Round(baPrincipal.BoltSize, 3).ToString());
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_2", Math.Round(baPrincipal.Tolerance + baPrincipal.BoltSize, 3).ToString());
                                }
                                else
                                {
                                    str4 = "[" + (baPrincipal.Tolerance + baPrincipal.BoltSize).ToString() + "]";
                                    baPrincipal.SetUserProperty("BOLT_COMMENT", "Furo");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_1", "");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_2", Math.Round(baPrincipal.Tolerance + baPrincipal.BoltSize, 3).ToString());
                                }
                                // baPrincipal.GetReportProperty("bolt_structure", ref str4);
                                // Console.WriteLine(str4);
                            }
                            catch { }
                        }
                        else { }
                    }
                    else
                    { }
                }
            }
            catch { }




        }

        private void button10_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {
                                chPrincipal.GetReportProperty("PROFILE", ref str1);
                                Console.Write(str1 + "--> ");
                                str2 = str1.Replace("*", "X");
                                chPrincipal.Profile.ProfileString = str2;
                                chPrincipal.SetUserProperty("PROFILE", str2);
                                chPrincipal.Modify();
                                chPrincipal.GetReportProperty("PROFILE", ref str1);
                                Console.WriteLine(str2 + " = " + str1);
                            }
                            catch { }
                            try
                            {
                                //   chPrincipal.GetReportProperty("PART_POS", ref str2);
                                //   chPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                        else
                        {
                        }
                        if (classe2 == "Tekla.Structures.Model.Beam")
                        {
                            vigaPrincipal = pp as Tekla.Structures.Model.Beam;
                            try
                            {
                                vigaPrincipal.GetReportProperty("PROFILE", ref str1);
                                Console.Write("  [  " + str1 + "--> ");
                                str2 = str1.Replace("*", "X");
                                str2 = str2.Replace(",", ".");
                                vigaPrincipal.Profile.ProfileString = str2;
                                vigaPrincipal.SetUserProperty("PROFILE", str2);
                                vigaPrincipal.Modify();
                                Console.Write(str2 + " = " + str1 + "  ]  ");
                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }
            }
            catch { }








        }

        private void button11_Click(object sender, EventArgs e)
        {

            int total_perfis = 170;
            string[,] perfis_cores = new string[total_perfis, 2];
            int cont_perfis = 1;
            int adic_perfil = 0;




            for (int i = 0; i < total_perfis; i++)
            {
                perfis_cores[i, 0] = i.ToString();
            }

            //           int ia =1;

            //  perfis_cores[ia,1] =    "750*119" ; ia++;
            //perfis_cores[ia,1] = "CS400X136" ; ia++;
            //perfis_cores[ia,1] = "CS400X155" ; ia++;
            //perfis_cores[ia,1] = "CS400X191" ; ia++;
            //perfis_cores[ia,1] = "HP200X53.0" ; ia++;
            //perfis_cores[ia,1] = "HP250X62.0" ; ia++;
            //perfis_cores[ia,1] = "HP250X85.0" ; ia++;
            //perfis_cores[ia,1] = "HP310X79.0" ; ia++;
            //perfis_cores[ia,1] = "HP310X93.0" ; ia++;
            //perfis_cores[ia,1] = "HP310X110.0" ; ia++;
            //perfis_cores[ia,1] = "HP310X125.0" ; ia++;
            //perfis_cores[ia,1] = "PS750X119" ; ia++;
            //perfis_cores[ia,1] = "PS750X132" ; ia++;
            //perfis_cores[ia,1] = "PS750X144" ; ia++;
            //perfis_cores[ia,1] = "PS800X144" ; ia++;
            //perfis_cores[ia,1] = "PS800X152" ; ia++;
            //perfis_cores[ia,1] = "PS800X167" ; ia++;
            //perfis_cores[ia,1] = "PS900X160" ; ia++;
            //perfis_cores[ia,1] = "PS900X174" ; ia++;
            //perfis_cores[ia,1] = "PS900X189" ; ia++;
            //perfis_cores[ia,1] = "PS900X204" ; ia++;
            //perfis_cores[ia,1] = "PS1000X153" ; ia++;
            //perfis_cores[ia,1] = "RHS120*60*4.25" ; ia++;
            //perfis_cores[ia,1] = "RHS200*75*6.35" ; ia++;
            //perfis_cores[ia,1] = "RHS200*100*6.35" ; ia++;
            //perfis_cores[ia,1] = "RHS200*120*9.5" ; ia++;
            //perfis_cores[ia,1] = "RHS200*120*12.5" ; ia++;
            //perfis_cores[ia,1] = "U50X25X3.04" ; ia++;
            //perfis_cores[ia,1] = "U75X37.5X3.04" ; ia++;
            //perfis_cores[ia,1] = "W150X13.0" ; ia++;
            //perfis_cores[ia,1] = "W200X15.0" ; ia++;
            //perfis_cores[ia,1] = "W200X22.5" ; ia++;
            //perfis_cores[ia,1] = "W200X26.6" ; ia++;
            //perfis_cores[ia,1] = "W200X35.9" ; ia++;
            //perfis_cores[ia,1] = "W200X41.7" ; ia++;
            //perfis_cores[ia,1] = "W200X46.1" ; ia++;
            //perfis_cores[ia,1] = "W200X52.0" ; ia++;
            //perfis_cores[ia,1] = "W200X59.0" ; ia++;
            //perfis_cores[ia,1] = "W250X17.9" ; ia++;
            //perfis_cores[ia,1] = "W250X73.0" ; ia++;
            //perfis_cores[ia,1] = "W250X89.0" ; ia++;
            //perfis_cores[ia,1] = "W310X21.0" ; ia++;
            //perfis_cores[ia,1] = "W310X23.8" ; ia++;
            //perfis_cores[ia,1] = "W310X28.3" ; ia++;
            //perfis_cores[ia,1] = "W310X32.7" ; ia++;
            //perfis_cores[ia,1] = "W310X97.0" ; ia++;
            //perfis_cores[ia,1] = "W310X107.0" ; ia++;
            //perfis_cores[ia,1] = "W360X32.9" ; ia++;
            //perfis_cores[ia,1] = "W410X38.8" ; ia++;
            //perfis_cores[ia,1] = "W410X46.1" ; ia++;
            //perfis_cores[ia,1] = "W460X52.0" ; ia++;
            //perfis_cores[ia,1] = "W460X60.0" ; ia++;
            //perfis_cores[ia,1] = "W530X66.0" ; ia++;
            //perfis_cores[ia,1] = "W530X72.0" ; ia++;
            //perfis_cores[ia,1] = "W610X82.0" ; ia++;
            //perfis_cores[ia,1] = "W610X92.0" ; ia++;
            //perfis_cores[ia,1] = "W610X101.0" ; ia++;
            //perfis_cores[ia,1] = "W610X113.0" ; ia++;
            //perfis_cores[ia,1] = "W610X125.0";



            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {


                            }
                            catch { }
                            try
                            {
                                //   chPrincipal.GetReportProperty("PART_POS", ref str2);
                                //   chPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                        else
                        {
                            vigaPrincipal = pp as Beam;
                            try
                            {
                                str1 = "";
                                vigaPrincipal.GetReportProperty("PROFILE", ref str1);

                                if (str1 == "")
                                {
                                }

                                else
                                {

                                    for (int i = 0; i < total_perfis; i++)
                                    {
                                        if (perfis_cores[i, 1] == str1)
                                        {
                                            vigaPrincipal.SetUserProperty("CLASS", perfis_cores[i, 0]);
                                            vigaPrincipal.Class = perfis_cores[i, 0];
                                            vigaPrincipal.Modify();
                                            break;
                                        }
                                        else
                                        {
                                            adic_perfil++;
                                            //perfis_cores[cont_perfis, 1] = str1;
                                            // vigaPrincipal.SetUserProperty("CLASS", str2);
                                            // cont_perfis++;
                                            //   break;
                                        }
                                    }

                                    if (adic_perfil == total_perfis)
                                    { adic_perfil = 999; }
                                    else { adic_perfil = 0; }


                                    if (adic_perfil == 999)
                                    {
                                        cont_perfis++;
                                        perfis_cores[cont_perfis, 1] = str1;
                                        vigaPrincipal.SetUserProperty("CLASS", perfis_cores[cont_perfis, 0].ToString());
                                        vigaPrincipal.Class = perfis_cores[cont_perfis, 0];
                                        vigaPrincipal.Modify();
                                        adic_perfil = 0;
                                        Console.WriteLine("[" + cont_perfis.ToString() + "] " + perfis_cores[cont_perfis, 0].ToString() + " , " + perfis_cores[cont_perfis, 1].ToString());
                                    }
                                    else { }

                                }

                                //  str2 = str1.Replace("*", "X");
                                // vigaPrincipal.Profile.ProfileString = str2;
                                // 
                                // vigaPrincipal.Modify();

                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }
            }
            catch { }






        }

        private void button12_Click(object sender, EventArgs e)
        {



            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {
                                double daa = 0.0;
                                double laa = 0.0;
                                double taa = 0.0;

                                chPrincipal.GetReportProperty("LENGHT", ref str2);
                                daa = double.Parse(str1, System.Globalization.CultureInfo.InvariantCulture);
                                if (textBox16.Text != "")
                                {
                                    laa = double.Parse(textBox16.Text, System.Globalization.CultureInfo.InvariantCulture);
                                    taa = daa * taa;
                                }
                                else
                                {
                                    chPrincipal.GetReportProperty("TSD_TOTAL_STUDS", ref str1);
                                    laa = double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
                                    taa = laa / daa;
                                }
                                chPrincipal.SetUserProperty("USER_FIELD_4", taa.ToString());
                            }
                            catch { }
                            try
                            {
                                //   chPrincipal.GetReportProperty("PART_POS", ref str2);
                                //   chPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                        else
                        {
                            vigaPrincipal = pp as Beam;
                            try
                            {
                                double daa = 0.0000;
                                double laa = 0.00000;
                                double taa = 0.0000;

                                double aaa = 0.000;

                                chPrincipal.GetReportProperty("LENGHT", ref aaa);

                                chPrincipal.GetReportProperty("LENGHT", ref str2);
                                daa = double.Parse(str1, System.Globalization.CultureInfo.InvariantCulture);
                                if (textBox16.Text != "")
                                {
                                    laa = double.Parse(textBox16.Text, System.Globalization.CultureInfo.InvariantCulture);
                                    taa = daa * taa;
                                }
                                else
                                {
                                    chPrincipal.GetReportProperty("TSD_TOTAL_STUDS", ref str1);
                                    laa = double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
                                    taa = laa / daa;
                                }
                                chPrincipal.SetUserProperty("USER_FIELD_4", taa.ToString());



                                //double commpr = 0.0000;
                                // int stuss = 0;



                                //chPrincipal.GetReportProperty("TSD_TOTAL_STUDS", ref daa);
                                // daa = double.Parse(stuss.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                // chPrincipal.GetReportProperty("LENGTH", ref commpr);
                                //  laa = double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
                                //   taa = laa / daa;
                                //   chPrincipal.SetUserProperty("USER_FIELD_4", taa.ToString());
                            }
                            catch { }
                            //textBox4.Text = compr.ToString().Replace(",", ".");
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }
            }
            catch { }


        }



        private void button13_Click(object sender, EventArgs e)
        {


            TSM.Model model = new TSM.Model();


            ArrayList ObjectsToSelect = new ArrayList();

            TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().GetAllObjects();
            ArrayList ObjectsToSelect2 = new ArrayList();

            foreach (ModelObject obj in myEnum)
            {
                string sid = obj.Identifier.ToString();
                // Console.Write(" " + sid + " ");
                if (sid == textBox25.Text)
                {
                    //public bool Select(ArrayList ModelObjects);
                    //public bool Select(    ArrayList ModelObjects,    bool ShowDimensions)
                    //public ModelObjectSelector()
                    //public abstract bool Select()
                    //public DrawingObjectEnumerator GetSelected()


                    //  Model Model = new Model();

                    //   Beam B = new Beam(new Point(0, 0, 0), new Point(0, 0, 1000));
                    //   Beam B1 = new Beam(new Point(0, 1000, 0), new Point(0, 1000, 5000));
                    //   Beam B2 = new Beam(new Point(0, 2000, 0), new Point(0, 2000, 5000));

                    //   B.Insert();
                    //   B1.Insert();
                    //   B2.Insert();

                    //  ArrayList ObjectsToSelect = new ArrayList();
                    //   ObjectsToSelect.Add(B);
                    //   ObjectsToSelect.Add(B1);
                    //   ObjectsToSelect.Add(B2);

                    //   Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
                    //   MS.Select(ObjectsToSelect);

                    //   Model.CommitChanges();




                    ObjectsToSelect2.Add(obj);

                    //obj.Select();
                    Console.WriteLine("achou = " + sid);
                    break;
                    // TSM.ModelObjectSelector aaaaa = new TSM.ModelObjectSelector.ger;
                    // TSM.ModelObjectSelector(Object)

                    //  Part parte = obj as Part;
                    //   int iid = parte.PartNumber;
                    //  int numeroSolda = parte.GetWelds().GetSize();
                    //if ((numeroParafusos + numeroSolda) == 0)
                    // {
                    //     ObjectsToSelect.Add(parte);
                    // MessageBox.Show("peça voando" + parte.PartNumber.Prefix.ToString());
                    //  }
                    // numeroParafusos = 0;
                    //  numeroSolda = 0;
                }

            }

            //   Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
            //    MS.Select(ObjectsToSelect);


            Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
            MS.Select(ObjectsToSelect2);

            // Model.CommitChanges();




        }

        private void button14_Click(object sender, EventArgs e)
        {

            int contador = 0;
            Point ponto1 = new Point();
            Point ponto2 = new Point();

            Picker picker = new Picker();
            try
            {
                ArrayList apoin = picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);
                //pontoanterior = apoin[0];
                foreach (Point p in apoin)
                {
                    if (contador == 0)
                    {
                        ponto1 = p;
                        ax1.Text = ponto1.X.ToString().Replace(",", ".");
                        ay1.Text = ponto1.Y.ToString().Replace(",", ".");
                        az1.Text = ponto1.Z.ToString().Replace(",", ".");
                    }
                    else
                    {
                        ponto2 = p;
                        ax2.Text = ponto2.X.ToString().Replace(",", ".");
                        ay2.Text = ponto2.Y.ToString().Replace(",", ".");
                        az2.Text = ponto2.Z.ToString().Replace(",", ".");
                    }
                    contador++;
                }

                double x11 = (ponto2.X - ponto1.X);
                double y11 = (ponto2.Y - ponto1.Y);
                //  double z11 = (ponto2.Z - ponto1.Z);
                //      double ddist = Math.Sqrt(Math.Pow(x11, 2) + Math.Pow(y11, 2) + Math.Pow(z11, 2));
                // textBox13.Text = x11.ToString().Replace(",", ".");
                // textBox12.Text = y11.ToString().Replace(",", ".");
                // textBox11.Text = z11.ToString().Replace(",", ".");
                //  textBox14.Text = ddist.ToString().Replace(",", ".");
                aL1.Text = (Math.Atan(x11 / y11) * 180 / Math.PI).ToString().Replace(",", ".");
                adif.Text = (double.Parse(aL1.Text, System.Globalization.CultureInfo.InvariantCulture) - double.Parse(aL2.Text, System.Globalization.CultureInfo.InvariantCulture)).ToString().Replace(",", ".");

            }
            catch (Exception e11)
            {
            }
            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            //Part obj1 = (Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);

            try
            {
                Clipboard.SetText(adif.Text);
            }
            catch { }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            int contador = 0;
            Point ponto1 = new Point();
            Point ponto2 = new Point();

            Picker picker = new Picker();
            try
            {
                ArrayList apoin = picker.PickPoints(Picker.PickPointEnum.PICK_TWO_POINTS);
                //pontoanterior = apoin[0];
                foreach (Point p in apoin)
                {
                    if (contador == 0)
                    {
                        ponto1 = p;
                        ax3.Text = ponto1.X.ToString().Replace(",", ".");
                        ay3.Text = ponto1.Y.ToString().Replace(",", ".");
                        az3.Text = ponto1.Z.ToString().Replace(",", ".");
                    }
                    else
                    {
                        ponto2 = p;
                        ax4.Text = ponto2.X.ToString().Replace(",", ".");
                        ay4.Text = ponto2.Y.ToString().Replace(",", ".");
                        az4.Text = ponto2.Z.ToString().Replace(",", ".");
                    }
                    contador++;
                }

                double x11 = (ponto2.X - ponto1.X);
                double y11 = (ponto2.Y - ponto1.Y);
                //  double z11 = (ponto2.Z - ponto1.Z);
                //      double ddist = Math.Sqrt(Math.Pow(x11, 2) + Math.Pow(y11, 2) + Math.Pow(z11, 2));
                // textBox13.Text = x11.ToString().Replace(",", ".");
                // textBox12.Text = y11.ToString().Replace(",", ".");
                // textBox11.Text = z11.ToString().Replace(",", ".");
                //  textBox14.Text = ddist.ToString().Replace(",", ".");
                aL2.Text = (Math.Atan(x11 / y11) * 180 / Math.PI).ToString().Replace(",", ".");
                adif.Text = (double.Parse(aL1.Text, System.Globalization.CultureInfo.InvariantCulture) - double.Parse(aL2.Text, System.Globalization.CultureInfo.InvariantCulture)).ToString().Replace(",", ".");

            }
            catch (Exception e11)
            {
            }

            try
            {
                Clipboard.SetText(adif.Text);
            }
            catch { }

            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            //Part obj1 = (Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);


        }

        private void button16_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");

                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;
                        string str2 = string.Empty;


                        if (classe2 == "Tekla.Structures.Model.Beam")
                        {
                            vigaPrincipal = pp as Tekla.Structures.Model.Beam;
                            try
                            {
                                vigaPrincipal.GetReportProperty("PROFILE", ref str1);
                                if (str1 == textBox2.Text)
                                {
                                    Console.Write("  [  " + str1 + "--> ");
                                    str2 = textBox1.Text;

                                    vigaPrincipal.Profile.ProfileString = str2;
                                    vigaPrincipal.SetUserProperty("PROFILE", str2);
                                    vigaPrincipal.Modify();
                                    Console.Write(str2 + "  ]  ");
                                }
                                else { }
                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }

                //   Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
                //    MS.Select(ObjectsToSelect);



                // Model.CommitChanges();


            }
            catch { }
        }

        private void button17_Click(object sender, EventArgs e)
        {




            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        string str1 = string.Empty;
                        string str2 = string.Empty;
                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try
                            {
                                // double daa = 0.0;
                                // double laa = 0.0;
                                // double taa = 0.0;
                                //  chPrincipal.GetReportProperty("TSD_TOTAL_STUDS", ref str1);
                                //  daa = double.Parse(str1, System.Globalization.CultureInfo.InvariantCulture);
                                //  chPrincipal.GetReportProperty("LENGHT", ref str2);
                                //  laa = double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
                                //  taa = laa / daa;vigaPrincipal.GetReportProperty("PROFILE", ref str1)
                                str1 = chPrincipal.Identifier.ToString();
                                chPrincipal.SetUserProperty("USER_FIELD_4", chPrincipal.Identifier.ToString());
                            }
                            catch { }
                            try
                            {
                                //   chPrincipal.GetReportProperty("PART_POS", ref str2);
                                //   chPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                        else
                        {
                            vigaPrincipal = pp as Beam;
                            try
                            {
                                // double daa = 0.0000;
                                // double laa = 0.00000;
                                //// double taa = 0.0000;
                                // double commpr = 0.0000;
                                //  int stuss = 0;

                                //textBox4.Text = compr.ToString().Replace(",", ".");

                                // chPrincipal.GetReportProperty("TSD_TOTAL_STUDS", ref daa);
                                // daa = double.Parse(stuss.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                // chPrincipal.GetReportProperty("LENGTH", ref commpr);
                                //laa = double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
                                //taa = laa / daa;
                                str1 = vigaPrincipal.Identifier.ToString();
                                vigaPrincipal.SetUserProperty("USER_FIELD_4", str1);
                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }
            }
            catch { }



        }

        private void button18_Click(object sender, EventArgs e)
        {



            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");
                foreach (ModelObject obj in MEnu)
                {
                    if (obj is ControlPoint)
                    {
                        //ControlPoint pp = obj as ControlPoint;
                        string str1 = string.Empty;
                        //string classe1 = pp.Class;
                        string classe2 = obj.GetType().ToString();
                        // string str1 = string.Empty;
                        // string str2 = string.Empty;
                        //if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        // {
                        //  chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                        try
                        {
                            ArrayList lista1 = new ArrayList();
                            //ArrayList lista2 = new ArrayList();
                            // ArrayList lista3 = new ArrayList();
                            // lista1 = obj.GetAllUserProperties();

                            //obj.GetReportProperty("LOCKED", ref str1);
                            // obj.GetReportProperty("OBJECT_LOCKED", ref str1);
                            // obj.GetReportProperty("IS_LOCKED", ref str1);
                            // obj.GetReportProperty("LOCKED_BY", ref str1);

                            //  obj.GetUserProperty("LOCKED", ref str1);
                            // obj.GetUserProperty("OBJECT_LOCKED", ref str1);
                            obj.GetUserProperty("IS_LOCKED", ref str1);
                            // obj.GetUserProperty("LOCKED_BY", ref str1);
                            obj.SetUserProperty("IS_LOCKED", "");
                            // obj.Delete();

                        }
                        catch { }


                    }

                    else { }
                }
            }
            catch { }





        }

        private void button19_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            try
            {
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");

                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();
                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;
                        string str2 = string.Empty;


                        if (classe2 == "Tekla.Structures.Model.Beam")
                        {
                            vigaPrincipal = pp as Tekla.Structures.Model.Beam;
                            try
                            {
                                vigaPrincipal.GetReportProperty("PROFILE", ref str1);
                                if (str1 == textBox2.Text)
                                {
                                    Console.Write("  [  " + str1 + "--> ");
                                    str2 = textBox1.Text;

                                    vigaPrincipal.Profile.ProfileString = str2;
                                    vigaPrincipal.SetUserProperty("PROFILE", str2);
                                    vigaPrincipal.Modify();
                                    Console.Write(str2 + "  ]  ");
                                }
                                else { }
                            }
                            catch { }
                            try
                            {
                                // vigaPrincipal.GetReportProperty("PART_POS", ref str2);
                                //  vigaPrincipal.SetUserProperty("USER_FIELD_2", str2);
                            }
                            catch { }
                        }
                    }

                    else { }
                }

                //   Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
                //    MS.Select(ObjectsToSelect);



                // Model.CommitChanges();


            }
            catch { }
        }

        private void button20_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();


            try
            {

                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");

                foreach (ModelObject obj in MEnu)
                {
                    if (obj is Part)
                    {
                        Part pp = obj as Part;

                        string classe1 = pp.Class;
                        string classe2 = pp.GetType().ToString();

                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;
                        string str2 = string.Empty;

                        string str3 = string.Empty;
                        try
                        {
                            if (radioButton1.Checked) { str3 = "X"; } else { }
                            if (radioButton2.Checked) { str3 = "Y"; } else { }
                            if (radioButton3.Checked) { str3 = "Z"; } else { }
                        }
                        catch { }



                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {
                            chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
                            try { } catch { }
                        }
                        else
                        {

                            if (classe2 == "Tekla.Structures.Model.Beam")
                            {
                                vigaPrincipal = pp as Tekla.Structures.Model.Beam;
                                try
                                {
                                    vigaPrincipal.GetReportProperty("START_" + str3, ref str1);

                                    Console.Write("  [  " + str1 + "--> ");
                                    str2 = textBox3.Text;
                                    if (radioButton1.Checked)
                                    {
                                        // vendo a tolerancia
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            vigaPrincipal.StartPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.EndPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.SetUserProperty("START_X", str2);
                                            vigaPrincipal.SetUserProperty("END_X", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(vigaPrincipal.StartPoint.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.StartPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("START_X", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(vigaPrincipal.EndPoint.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.EndPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("END_X", str2);
                                            }
                                            else { }
                                        }
                                    }
                                    if (radioButton2.Checked)
                                    {
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            vigaPrincipal.StartPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.EndPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.SetUserProperty("START_Y", str2);
                                            vigaPrincipal.SetUserProperty("END_Y", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(vigaPrincipal.StartPoint.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.StartPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("START_Y", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(vigaPrincipal.EndPoint.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.EndPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("END_Y", str2);
                                            }
                                            else
                                            { }
                                        }
                                    }
                                    if (radioButton3.Checked)
                                    {
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            vigaPrincipal.StartPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.EndPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            vigaPrincipal.SetUserProperty("START_Z", str2);
                                            vigaPrincipal.SetUserProperty("END_Z", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(vigaPrincipal.StartPoint.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.StartPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("START_Z", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(vigaPrincipal.EndPoint.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                vigaPrincipal.EndPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                vigaPrincipal.SetUserProperty("END_Z", str2);
                                            }
                                            else
                                            { }
                                        }
                                    }
                                    //  vigaPrincipal.SetUserProperty("PROFILE", str2);

                                    vigaPrincipal.Modify();
                                    Console.Write(str2 + "  ]  ");

                                }
                                catch { }
                            }
                            else { }
                        }
                    }

                }
            }

            catch { }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox6.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox5.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox4.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int contador = 0;
            Point pontoanterior = new Point();
            Picker picker = new Picker();
            try
            {
                ArrayList apoin = picker.PickPoints(Picker.PickPointEnum.PICK_ONE_POINT);
                //pontoanterior = apoin[0];
                foreach (Point p in apoin)
                {

                    textBox6.Text = p.X.ToString().Replace(",", ".");
                    textBox5.Text = p.Y.ToString().Replace(",", ".");
                    textBox4.Text = p.Z.ToString().Replace(",", ".");
                }


                if (radioButton1.Checked) { textBox3.Text = textBox6.Text; } else { };
                if (radioButton2.Checked) { textBox3.Text = textBox5.Text; } else { };
                if (radioButton3.Checked) { textBox3.Text = textBox4.Text; } else { };

            }
            catch (Exception e11)
            {
            }
            //Part obj1 = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
            //Part obj1 = (Part)picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = (double.Parse(adif.Text, System.Globalization.CultureInfo.InvariantCulture) - double.Parse(textBox8.Text, System.Globalization.CultureInfo.InvariantCulture)).ToString().Replace(",", ".");
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            ArrayList ObjectsToSelect = new ArrayList();
            TSM.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
            MS.Select(ObjectsToSelect);
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            // ArrayList ObjectsToSelect = new ArrayList();

            // TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().GetAllObjects();
            //  ArrayList ObjectsToSelect2 = new ArrayList();
            // ArrayList ObjectsToSelect = new ArrayList();
            try
            {

                // TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().GetAllObjects();
                TSM.ModelObjectEnumerator myEnum = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, "SELECIONE OS parafusos");
                foreach (ModelObject obj in myEnum)
                {

                    if (obj is BoltArray)
                    {
                        BoltArray bba = obj as BoltArray;
                        string classe3 = bba.GetType().ToString();
                        // Console.WriteLine(classe3);

                        string str4 = string.Empty;
                        if (classe3 == "Tekla.Structures.Model.BoltArray")
                        {
                            baPrincipal = bba as Tekla.Structures.Model.BoltArray;
                            try
                            {
                                if (baPrincipal.Bolt)
                                {
                                    // str4 = ":" + baPrincipal.BoltSize.ToString() + "[" + (baPrincipal.Tolerance + baPrincipal.BoltSize).ToString() + "]";
                                    baPrincipal.SetUserProperty("BOLT_COMMENT", "Parafuso");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_1", Math.Round(baPrincipal.BoltSize, 3).ToString());
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_2", Math.Round(baPrincipal.Tolerance + baPrincipal.BoltSize, 3).ToString());
                                }
                                else
                                {
                                    //   str4 = "[" + (baPrincipal.Tolerance + baPrincipal.BoltSize).ToString() + "]";
                                    baPrincipal.SetUserProperty("BOLT_COMMENT", "Furo");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_1", "");
                                    baPrincipal.SetUserProperty("BOLT_USERFIELD_2", Math.Round(baPrincipal.Tolerance + baPrincipal.BoltSize, 3).ToString());
                                }
                                // baPrincipal.GetReportProperty("bolt_structure", ref str4);
                                // Console.WriteLine(str4);

                            }
                            catch { }
                        }
                        else { }
                    }
                    else
                    { }
                }
            }
            catch { }

        }
        public List<TSM.BoltGroup> sss()
        {
            Picker picker = new Picker();

            List<TSM.BoltGroup> result = new List<BoltGroup>();
            TSM.ModelObjectEnumerator myEnum = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, "SELECIONE OS parafusos");
            return result;
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void ccompri2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();


            try
            {


                //  TSM.ModelObjectEnumerator MEnu = sss();

                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, "SELECIONE OS parafusos");

                foreach (ModelObject obj in MEnu)
                {
                    if (obj is BoltGroup)
                    {
                        BoltGroup pp = obj as BoltGroup;
                        //firstposition
                        //second position


                        string classe1 = pp.BoltSize.ToString();
                        string classe2 = pp.GetType().ToString();

                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;
                        string str2 = string.Empty;

                        string str3 = string.Empty;
                        try
                        {
                            if (radioButton1.Checked) { str3 = "X"; } else { }
                            if (radioButton2.Checked) { str3 = "Y"; } else { }
                            if (radioButton3.Checked) { str3 = "Z"; } else { }
                        }
                        catch { }



                        if (classe2 == "Tekla.Structures.Model.ContourPlate")
                        {

                            try { } catch { }
                        }
                        else
                        {

                            if (classe2 == "Tekla.Structures.Model.BoltArray")
                            {
                                bgPrincipal = pp as Tekla.Structures.Model.BoltGroup;
                                try
                                {
                                    //  bgPrincipal.GetReportProperty("START_" + str3, ref str1);

                                    //  Console.Write("  [  " + str1 + "--> ");
                                    str2 = textBox3.Text;
                                    if (radioButton1.Checked)
                                    {
                                        // vendo a tolerancia
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            bgPrincipal.FirstPosition.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            bgPrincipal.SecondPosition.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            // bgPrincipal.SetUserProperty("START_X", str2);
                                            // bgPrincipal.SetUserProperty("END_X", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(bgPrincipal.FirstPosition.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.FirstPosition.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                //  bgPrincipal.SetUserProperty("START_X", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(bgPrincipal.FirstPosition.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.SecondPosition.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                //  vigaPrincipal.SetUserProperty("END_X", str2);
                                            }
                                            else { }
                                        }
                                    }
                                    if (radioButton2.Checked)
                                    {
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            bgPrincipal.FirstPosition.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            bgPrincipal.SecondPosition.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            // bgPrincipal.SetUserProperty("START_Y", str2);
                                            // bgPrincipal.SetUserProperty("END_Y", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(bgPrincipal.FirstPosition.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.FirstPosition.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                //   vigaPrincipal.SetUserProperty("START_Y", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(bgPrincipal.SecondPosition.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.SecondPosition.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                // bgPrincipal.SetUserProperty("END_Y", str2);
                                            }
                                            else
                                            { }
                                        }
                                    }
                                    if (radioButton3.Checked)
                                    {
                                        if (textBox7.Text == "" || textBox7.Text == "0")
                                        {
                                            bgPrincipal.FirstPosition.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            bgPrincipal.SecondPosition.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                            // bgPrincipal.SetUserProperty("START_Z", str2);
                                            // bgPrincipal.SetUserProperty("END_Z", str2);
                                        }
                                        else
                                        {
                                            double dd1;
                                            dd1 = Math.Abs(bgPrincipal.FirstPosition.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.FirstPosition.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                //   bgPrincipal.SetUserProperty("START_Z", str2);
                                            }
                                            else { }
                                            dd1 = Math.Abs(bgPrincipal.SecondPosition.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                                            if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                                            {
                                                bgPrincipal.SecondPosition.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                                //    bgPrincipal.SetUserProperty("END_Z", str2);
                                            }
                                            else
                                            { }
                                        }
                                    }
                                    //  vigaPrincipal.SetUserProperty("PROFILE", str2);

                                    bgPrincipal.Modify();
                                    Console.Write(str2 + "  ]  ");

                                }
                                catch { }
                            }
                            else { }
                        }
                    }

                }
            }

            catch { }






        }

        private void button25_Click(object sender, EventArgs e)
        {


            Picker picker = new Picker();
            //TSM.ModelObjectSelector moss = new TSM.ModelObjectSelector();
            TSM.Model model = new TSM.Model();
            ArrayList ObjectsToSelect = new ArrayList();
            int iaa = 0;

            try
            {
                //TSM.ModelObjectSelector msel = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, "sell");
                TSM.ModelObjectEnumerator MEnu = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_BOLTGROUPS, "SELECIONE OS parafusos");

                foreach (ModelObject obj in MEnu)
                {
                    if (obj is BoltGroup)
                    {
                        BoltGroup pp = obj as BoltGroup;
                        //firstposition
                        //second position


                        string classe1 = pp.BoltSize.ToString();
                        string classe2 = pp.GetType().ToString();

                        Console.WriteLine(classe1 + " | " + classe2);
                        string str1 = string.Empty;



                        if (classe2 == "Tekla.Structures.Model.BoltArray")
                        {
                            iaa++;

                        }
                        else { }

                    }

                }
            }

            catch { }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            //Model CurrentModel = new Model();
            PhaseCollection PhaseCollection = myModel.GetPhases();
            if (myModel.GetConnectionStatus())
            {
                foreach (Phase p in PhaseCollection)
                {
                    // MessageBox.Show("Name = " + p.PhaseName + ", number = " + p.PhaseNumber);      
                    // Add the drawing name to the UI tree.
                    TreeNode FaseNode = new TreeNode();
                    FaseNode.Tag = p.PhaseNumber;
                    //FaseNode.Text = "" + p.PhaseName.ToString();
                    FaseNode.Text = "[" + p.PhaseNumber.ToString() + "] " + p.PhaseName.ToString();
                    //DrawingNode.Text = "" + CurrentDrawing.GetType();
                    drawingListTreeView.Nodes.Add(FaseNode);
                }
            }

            // PhaseCollection[Phase[888888];
            Phase ph1 = new Phase();
            ph1.PhaseNumber = 888888;
            ph1.PhaseName = "teste";
            ph1.Insert();
            //PhaseCollection Pcol = TSM.GetPhases();

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            TSD.DrawingHandler dh = new TSD.DrawingHandler();

            TSD.MultiDrawing m1;
            TSD.DrawingObject d11;

            // dh.GetDrawings(d11);
            //Console.WriteLine(d11.GetType().ToString());

            int i1 = int.Parse(textBox32.Text);
            int i2 = int.Parse(textBox33.Text);

            // m1.Title1 =i1.ToString();
            for (int i = 0; i == i2; i++)
            {

            }
        }
    }
}


// https://github.com/dawiddyrcz


/* 

       private void AddChildDrawingObjectsToTreeNode(TreeNode Node, Tekla.Structures.Drawing.IHasChildren CurrentContainer)
       {
           TSD.DrawingObjectEnumerator ObjectList = CurrentContainer.GetObjects(); // Gets the objects that are placed directly to the current container object.
           ObjectList.SelectInstances = false; // The instances don't need to be automatically selected, only whether the object exists or not has to be found out (objects properties are not used at all).

           while (ObjectList.MoveNext())
           {
               //Console.WriteLine(ObjectList.Current.GetType().ToString());

               if (ShowObjectsInViews.Checked || ObjectList.Current is TSD.ViewBase)
               {
                   TreeNode CurrentNode = new TreeNode("" + ObjectList.Current.GetType());
                   //TreeNode CurrentNode = new TreeNode("" + ObjectList.Current.ToString());

                   CurrentNode.Tag = ObjectList.Current;

                   if (ObjectList.Current is Tekla.Structures.Drawing.IHasChildren)
                       AddChildDrawingObjectsToTreeNode(CurrentNode, ObjectList.Current as TSD.IHasChildren);

                   Node.Nodes.Add(CurrentNode);
               }
           }
       }

       private void AddDrawingInformationToDrawingListTreeView()
       {


       }
       */



//Private Function SelectParts() As List(Of TSM.Part)
//Dim objUIPICker As TSM.UI.Picker
//Dim objModelObjectEnumerator As TSM.ModelObjectEnumerator
//Dim lstOutput As List(Of TSM.Part)

//  objUIPICker = New TSM.UI.Picker()
//  lstOutput = New List(Of TSM.Part)

//  Try
//      'This line asks the user to select an object from the model
//      objModelObjectEnumerator = objUIPICker.PickObjects(Tekla.Structures.Model.UI.Picker.PickObjectsEnum.PICK_N_PARTS, &amp; quot; Select Objects&amp; quot;)
//      'loops through all the objects selected by the user
//      While objModelObjectEnumerator.MoveNext
//          'adds the object to the output list
//           lstOutput.Add(objModelObjectEnumerator.Current)
//      End While
//    Catch
//    End Try
//       Return lstOutput
//    End Function
/*        
private void button22_Click(object sender, EventArgs e)
{




Picker picker = new Picker();
TSM.Model model = new TSM.Model();
ArrayList ObjectsToSelect = new ArrayList();

try
{

TSM.ModelObjectEnumerator MEnu = picker.PickPoints(Picker.PickPointEnum...PickObjectsEnum.PICK_N_OBJECTS, "SELECIONE OS OBJETOS");

foreach (ModelObject obj in MEnu)
{
  if (obj is Part)
  {
      Part pp = obj as Part;

      string classe1 = pp.Class;
      string classe2 = pp.GetType().ToString();

      Console.WriteLine(classe1 + " | " + classe2);
      string str1 = string.Empty;
      string str2 = string.Empty;

      string str3 = string.Empty;
      try
      {
          if (radioButton1.Checked) { str3 = "X"; } else { }
          if (radioButton2.Checked) { str3 = "Y"; } else { }
          if (radioButton3.Checked) { str3 = "Z"; } else { }
      }
      catch { }



      if (classe2 == "Tekla.Structures.Model.ContourPlate")
      {
          chPrincipal = pp as Tekla.Structures.Model.ContourPlate;
          try { } catch { }
      }
      else
      {

          if (classe2 == "Tekla.Structures.Model.Beam")
          {
              vigaPrincipal = pp as Tekla.Structures.Model.Beam;
              try
              {
                  vigaPrincipal.GetReportProperty("START_" + str3, ref str1);

                  Console.Write("  [  " + str1 + "--> ");
                  str2 = textBox3.Text;
                  if (radioButton1.Checked)
                  {
                      // vendo a tolerancia
                      if (textBox7.Text == "" || textBox7.Text == "0")
                      {
                          vigaPrincipal.StartPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.EndPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.SetUserProperty("START_X", str2);
                          vigaPrincipal.SetUserProperty("END_X", str2);
                      }
                      else
                      {
                          double dd1;
                          dd1 = Math.Abs(vigaPrincipal.StartPoint.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.StartPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("START_X", str2);
                          }
                          else { }
                          dd1 = Math.Abs(vigaPrincipal.EndPoint.X - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.EndPoint.X = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("END_X", str2);
                          }
                          else { }
                      }
                  }
                  if (radioButton2.Checked)
                  {
                      if (textBox7.Text == "" || textBox7.Text == "0")
                      {
                          vigaPrincipal.StartPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.EndPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.SetUserProperty("START_Y", str2);
                          vigaPrincipal.SetUserProperty("END_Y", str2);
                      }
                      else
                      {
                          double dd1;
                          dd1 = Math.Abs(vigaPrincipal.StartPoint.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.StartPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("START_Y", str2);
                          }
                          else { }
                          dd1 = Math.Abs(vigaPrincipal.EndPoint.Y - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.EndPoint.Y = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("END_Y", str2);
                          }
                          else
                          { }
                      }
                  }
                  if (radioButton3.Checked)
                  {
                      if (textBox7.Text == "" || textBox7.Text == "0")
                      {
                          vigaPrincipal.StartPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.EndPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                          vigaPrincipal.SetUserProperty("START_Z", str2);
                          vigaPrincipal.SetUserProperty("END_Z", str2);
                      }
                      else
                      {
                          double dd1;
                          dd1 = Math.Abs(vigaPrincipal.StartPoint.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.StartPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("START_Z", str2);
                          }
                          else { }
                          dd1 = Math.Abs(vigaPrincipal.EndPoint.Z - double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture));
                          if (dd1 < double.Parse(textBox7.Text, System.Globalization.CultureInfo.InvariantCulture))
                          {
                              vigaPrincipal.EndPoint.Z = double.Parse(str2.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                              vigaPrincipal.SetUserProperty("END_Z", str2);
                          }
                          else
                          { }
                      }
                  }
                  //  vigaPrincipal.SetUserProperty("PROFILE", str2);

                  vigaPrincipal.Modify();
                  Console.Write(str2 + "  ]  ");

              }
              catch { }
          }
          else { }
      }
  }

}
}

catch { }




}

*/



















