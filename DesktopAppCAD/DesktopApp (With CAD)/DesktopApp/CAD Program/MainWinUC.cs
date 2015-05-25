/**
 * Developed by Jesper Kristiansen jkristia@yahoo.com (2007)
 * Source Code From http://www.codeproject.com/Articles/22549/OpenS-CAD-a-simple-D-CAD-application
 * Edited By Andrea Cerrai (2014)
 **/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DesktopApp.CAD_Program.Resources;
using System.Xml;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;


/**
 * Main User Control
 * Can Open and edit XML files
 * Added electrical symbols to drawer
 * Changed architecture from MDI form to User Controls to allow for CAD program to be a child and embed in Desktop App
 **/

namespace DesktopApp.CAD_Program
{
    public partial class MainWinUC : UserControl, ICanvasOwner, IEditToolOwner
    {
        Utils.MenuItemManager m_menuItems = new Utils.MenuItemManager();
        CanvasCtrl m_canvas;
        DataModel m_data;

        ToolStrip strip, Editstrip, Drawstrip, Layerstrip, EditToolsstrip;
        StatusStrip status;
        ToolStripMenuItem menuitem, Drawmenu, menu;


        string m_filename = string.Empty;

        public int fuse, resistor, capacitor;

        public MainWinUC()
        {
            Utils.UnitPoint p = Utils.HitUtil.CenterPointFrom3Points(new Utils.UnitPoint(0, 2), new Utils.UnitPoint(1.4142136f, 1.4142136f), new Utils.UnitPoint(2, 0));

            InitializeComponent();

            m_data = new DataModel();

            m_canvas = new CanvasCtrl(this, m_data);
            m_canvas.Dock = DockStyle.Fill;
            Controls.Add(m_canvas);
            m_canvas.SetCenter(new Utils.UnitPoint(0, 0));
            m_canvas.RunningSnaps = new Type[] 
				{
				typeof(DrawTools.VertextSnapPoint),
				typeof(DrawTools.MidpointSnapPoint),
				typeof(DrawTools.IntersectSnapPoint),
				typeof(DrawTools.QuadrantSnapPoint),
				typeof(DrawTools.CenterSnapPoint),
				typeof(DrawTools.DivisionSnapPoint),
				};

            m_canvas.AddQuickSnapType(Keys.N, typeof(DrawTools.NearestSnapPoint));
            m_canvas.AddQuickSnapType(Keys.M, typeof(DrawTools.MidpointSnapPoint));
            m_canvas.AddQuickSnapType(Keys.I, typeof(DrawTools.IntersectSnapPoint));
            m_canvas.AddQuickSnapType(Keys.V, typeof(DrawTools.VertextSnapPoint));
            m_canvas.AddQuickSnapType(Keys.P, typeof(DrawTools.PerpendicularSnapPoint));
            m_canvas.AddQuickSnapType(Keys.Q, typeof(DrawTools.QuadrantSnapPoint));
            m_canvas.AddQuickSnapType(Keys.C, typeof(DrawTools.CenterSnapPoint));
            m_canvas.AddQuickSnapType(Keys.T, typeof(DrawTools.TangentSnapPoint));
            m_canvas.AddQuickSnapType(Keys.D, typeof(DrawTools.DivisionSnapPoint));

            m_canvas.KeyDown += new KeyEventHandler(OnCanvasKeyDown);

            m_menuItems = new Utils.MenuItemManager(this);
            m_menuItems.SetupStripPanels();
            SetupToolbars();
            SetupLayerToolstrip();
            SetupEditTools();
            UpdateLayerUI();

            /*MenuStrip menuitem = new MenuStrip();
            menuitem.Items.Add(m_menuItems.GetMenuStrip("edit"));
            menuitem.Items.Add(m_menuItems.GetMenuStrip("draw"));
            menuitem.Visible = false;
            Controls.Add(menuitem);*/

            Application.Idle += new EventHandler(OnIdle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_canvas.SetCenter(m_data.CenterPoint);
        }

        void SetupToolbars()
        {
            Utils.MenuItem mmitem = m_menuItems.GetItem("New");
            mmitem.Text = "&New";
            mmitem.Image = MenuImages16x16.Image(MenuImages16x16.eIndexes.NewDocument);
            mmitem.Click += new EventHandler(OnFileNew);
            mmitem.ToolTipText = "New document";

            mmitem = m_menuItems.GetItem("Open");
            mmitem.Text = "&Open";
            mmitem.Image = MenuImages16x16.Image(MenuImages16x16.eIndexes.OpenDocument);
            mmitem.Click += new EventHandler(OnFileOpen);
            mmitem.ToolTipText = "Open document";

            mmitem = m_menuItems.GetItem("Save");
            mmitem.Text = "&Save";
            mmitem.Image = MenuImages16x16.Image(MenuImages16x16.eIndexes.SaveDocument);
            mmitem.Click += new EventHandler(OnFileSave);
            mmitem.ToolTipText = "Save document";

            mmitem = m_menuItems.GetItem("SaveAs");
            mmitem.Text = "Save &As";
            mmitem.Click += new EventHandler(OnFileSaveAs);

            strip = m_menuItems.GetStrip("file");
            strip.Items.Add(m_menuItems.GetItem("New").CreateButton());
            strip.Items.Add(m_menuItems.GetItem("Open").CreateButton());
            strip.Items.Add(m_menuItems.GetItem("Save").CreateButton());

            menuitem = m_menuItems.GetMenuStrip("file");
            menuitem.Text = "&File";
            menuitem.DropDownItems.Add(m_menuItems.GetItem("New").CreateMenuItem());
            menuitem.DropDownItems.Add(m_menuItems.GetItem("Open").CreateMenuItem());
            menuitem.DropDownItems.Add(m_menuItems.GetItem("Save").CreateMenuItem());
            menuitem.DropDownItems.Add(m_menuItems.GetItem("SaveAs").CreateMenuItem());
            //menuitem.DropDownItems.Add(new ToolStripSeparator());
            //menuitem.DropDownItems.Add(m_menuItems.GetItem("Exit").CreateMenuItem());
            m_mainMenu.Items.Insert(0, menuitem);

            mmitem = m_menuItems.GetItem("Undo");

            mmitem.Text = "Undo";
            mmitem.Image = MenuImages16x16.Image(MenuImages16x16.eIndexes.Undo);
            mmitem.ToolTipText = "Undo (Ctrl-Z)";
            mmitem.Click += new EventHandler(OnUndo);
            mmitem.ShortcutKeys = Shortcut.CtrlZ;

            mmitem = m_menuItems.GetItem("Redo");
            mmitem.Text = "Redo";
            mmitem.ToolTipText = "Undo (Ctrl-Y)";
            mmitem.Image = MenuImages16x16.Image(MenuImages16x16.eIndexes.Redo);
            mmitem.Click += new EventHandler(OnRedo);
            mmitem.ShortcutKeys = Shortcut.CtrlY;

            mmitem = m_menuItems.GetItem("Select");
            mmitem.Text = "Select";
            mmitem.ToolTipText = "Select (Esc)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Select);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.ShortcutKeyDisplayString = "Esc";
            mmitem.SingleKey = Keys.Escape;
            mmitem.Tag = "select";

            mmitem = m_menuItems.GetItem("Pan");
            mmitem.Text = "Pan";
            mmitem.ToolTipText = "Pan (P)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Pan);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.ShortcutKeyDisplayString = "P";
            mmitem.SingleKey = Keys.P;
            mmitem.Tag = "pan";

            mmitem = m_menuItems.GetItem("Move");
            mmitem.Text = "Move";
            mmitem.ToolTipText = "Move (M)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Move);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.ShortcutKeyDisplayString = "M";
            mmitem.SingleKey = Keys.M;
            mmitem.Tag = "move";

            Editstrip = m_menuItems.GetStrip("edit");
            Editstrip.Items.Add(m_menuItems.GetItem("Select").CreateButton());
            Editstrip.Items.Add(m_menuItems.GetItem("Pan").CreateButton());
            Editstrip.Items.Add(m_menuItems.GetItem("Move").CreateButton());
            Editstrip.Items.Add(new ToolStripSeparator());
            Editstrip.Items.Add(m_menuItems.GetItem("Undo").CreateButton());
            Editstrip.Items.Add(m_menuItems.GetItem("Redo").CreateButton());

            menu = m_menuItems.GetMenuStrip("edit");
            menu.Text = "&Edit";
            menu.DropDownItems.Add(m_menuItems.GetItem("Undo").CreateMenuItem());
            menu.DropDownItems.Add(m_menuItems.GetItem("Redo").CreateMenuItem());
            menu.DropDownItems.Add(new ToolStripSeparator());
            menu.DropDownItems.Add(m_menuItems.GetItem("Select").CreateMenuItem());
            menu.DropDownItems.Add(m_menuItems.GetItem("Pan").CreateMenuItem());
            menu.DropDownItems.Add(m_menuItems.GetItem("Move").CreateMenuItem());
            m_mainMenu.Items.Insert(1, menu);

            mmitem = m_menuItems.GetItem("Lines");
            mmitem.Text = "Lines";
            mmitem.ToolTipText = "Lines (L)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Line);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.SingleKey = Keys.L;
            mmitem.ShortcutKeyDisplayString = "L";
            mmitem.Tag = "lines";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.LineEdit(false));

            mmitem = m_menuItems.GetItem("Line");
            mmitem.Text = "Line";
            mmitem.ToolTipText = "Single line (S)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Line);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.SingleKey = Keys.S;
            mmitem.ShortcutKeyDisplayString = "S";
            mmitem.Tag = "singleline";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.LineEdit(true));

            mmitem = m_menuItems.GetItem("Circle2P");
            mmitem.Text = "Circle 2P";
            mmitem.ToolTipText = "Circle 2 point";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Circle2P);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.Tag = "circle2P";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Circle(DrawTools.Arc.eArcType.type2point));

            mmitem = m_menuItems.GetItem("CircleCR");
            mmitem.Text = "Circle CR";
            mmitem.ToolTipText = "Circle Center-Radius";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.CircleCR);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.SingleKey = Keys.C;
            mmitem.ShortcutKeyDisplayString = "C";
            mmitem.Tag = "circleCR";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Circle(DrawTools.Arc.eArcType.typeCenterRadius));

            mmitem = m_menuItems.GetItem("Arc2P");
            mmitem.Text = "Arc 2P";
            mmitem.ToolTipText = "Arc 2 point";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Arc2P);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.Tag = "arc2P";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Arc(DrawTools.Arc.eArcType.type2point));

            mmitem = m_menuItems.GetItem("Arc3P132");
            mmitem.Text = "Arc 3P";
            mmitem.ToolTipText = "Arc 3 point (Start / End / Include)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Arc3P132);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.Tag = "arc3P132";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Arc3Point(DrawTools.Arc3Point.eArcType.kArc3P132));

            mmitem = m_menuItems.GetItem("Arc3P123");
            mmitem.Text = "Arc 3P";
            mmitem.ToolTipText = "Arc 3 point (Start / Include / End)";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.Arc3P123);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.Tag = "arc3P123";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Arc3Point(DrawTools.Arc3Point.eArcType.kArc3P123));

            mmitem = m_menuItems.GetItem("ArcCR");
            mmitem.Text = "Arc CR";
            mmitem.ToolTipText = "Arc Center-Radius";
            mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.ArcCR);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.SingleKey = Keys.A;
            mmitem.ShortcutKeyDisplayString = "A";
            mmitem.Tag = "arcCR";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.Arc(DrawTools.Arc.eArcType.typeCenterRadius));

            mmitem = m_menuItems.GetItem("Fuse");
            mmitem.Text = "Fuse";
            mmitem.ToolTipText = "Fuse";
            mmitem.Image = DrawToolsImagesExtra16x16.Image(DrawToolsImagesExtra16x16.eIndexes.Fuse);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.ShortcutKeyDisplayString = "F";
            mmitem.Tag = "Fuse";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.LineEditFuse(true));

            mmitem = m_menuItems.GetItem("Capacitor");
            mmitem.Text = "Capacitor";
            mmitem.ToolTipText = "Capacitor";
            mmitem.Image = DrawToolsImagesExtra16x16.Image(DrawToolsImagesExtra16x16.eIndexes.Capacitor);
            mmitem.Click += new EventHandler(OnToolSelect);
            //mmitem.ShortcutKeyDisplayString = "";
            mmitem.Tag = "Capacitor";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.LineEditFuse(true));

            mmitem = m_menuItems.GetItem("Resistor");
            mmitem.Text = "Resistor";
            mmitem.ToolTipText = "Resistor";
            mmitem.Image = DrawToolsImagesExtra16x16.Image(DrawToolsImagesExtra16x16.eIndexes.Resistor);
            mmitem.Click += new EventHandler(OnToolSelect);
            mmitem.ShortcutKeyDisplayString = "R";
            mmitem.Tag = "Resistor";
            m_data.AddDrawTool(mmitem.Tag.ToString(), new DrawTools.LineEditFuse(true));

            Drawstrip = m_menuItems.GetStrip("draw");
            Drawstrip.Items.Add(m_menuItems.GetItem("Lines").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Circle2P").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("CircleCR").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Arc2P").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("ArcCR").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Arc3P132").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Arc3P123").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Fuse").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Capacitor").CreateButton());
            Drawstrip.Items.Add(m_menuItems.GetItem("Resistor").CreateButton());

            Drawmenu = m_menuItems.GetMenuStrip("draw");
            Drawmenu.Text = "Draw &Tools";
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Lines").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Line").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Circle2P").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("CircleCR").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Arc2P").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("ArcCR").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Arc3P132").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Arc3P123").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Fuse").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Capacitor").CreateMenuItem());
            Drawmenu.DropDownItems.Add(m_menuItems.GetItem("Resistor").CreateMenuItem());
            m_mainMenu.Items.Insert(2, Drawmenu);

            ToolStripPanel panel = m_menuItems.GetStripPanel(DockStyle.Top);

            panel.Join(m_menuItems.GetStrip("layer"));
            panel.Join(m_menuItems.GetStrip("draw"));
            panel.Join(m_menuItems.GetStrip("edit"));
            panel.Join(m_menuItems.GetStrip("file"));
            panel.Join(m_mainMenu);

            panel = m_menuItems.GetStripPanel(DockStyle.Left);
            panel.Join(m_menuItems.GetStrip("modify"));

            panel = m_menuItems.GetStripPanel(DockStyle.Bottom);
            panel.Join(m_menuItems.GetStatusStrip("status"));
        }

        ToolStripStatusLabel m_mousePosLabel = new ToolStripStatusLabel();
        ToolStripStatusLabel m_snapInfoLabel = new ToolStripStatusLabel();
        ToolStripStatusLabel m_drawInfoLabel = new ToolStripStatusLabel();
        ToolStripComboBox m_layerCombo = new ToolStripComboBox();

        void SetupLayerToolstrip()
        {
            status = m_menuItems.GetStatusStrip("status");
            m_mousePosLabel.AutoSize = true;
            m_mousePosLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            m_mousePosLabel.Size = new System.Drawing.Size(110, 17);
            status.Items.Add(m_mousePosLabel);

            m_snapInfoLabel.AutoSize = true;
            m_snapInfoLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            m_snapInfoLabel.Size = new System.Drawing.Size(200, 17);
            status.Items.Add(m_snapInfoLabel);

            //m_drawInfoLabel.AutoSize = true;
            m_drawInfoLabel.Spring = true;
            m_drawInfoLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Right;
            m_drawInfoLabel.TextAlign = ContentAlignment.MiddleLeft;
            m_drawInfoLabel.Size = new System.Drawing.Size(200, 17);
            status.Items.Add(m_drawInfoLabel);

            Layerstrip = m_menuItems.GetStrip("layer");
            Layerstrip.Items.Add(new ToolStripLabel("Active Layer"));

            m_layerCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            int index = 1;
            foreach (Layers.DrawingLayer layer in m_data.Layers)
            {
                string name = string.Format("({0}) - {1}", index, layer.Name);

                Utils.MenuItem mmitem = m_menuItems.GetItem(name);
                mmitem.Text = name;
                mmitem.Image = DrawToolsImages16x16.Image(DrawToolsImages16x16.eIndexes.ArcCR);
                mmitem.Click += new EventHandler(OnLayerSelect);
                mmitem.SingleKey = Keys.D0 + index;
                mmitem.Tag = new CommonTools.NameObject<Layers.DrawingLayer>(mmitem.Text, layer);

                m_layerCombo.Items.Add(new CommonTools.NameObject<Layers.DrawingLayer>(mmitem.Text, layer));
                m_layerCombo.SelectedIndexChanged += mmitem.Click;

                index++;
            }
            Layerstrip.Items.Add(m_layerCombo);
        }

        void SetupEditTools()
        {
            Utils.MenuItem item = m_menuItems.GetItem("Meet2Lines");
            item.Text = "Meet 2 Lines";
            item.ToolTipText = "Meet 2 Lines";
            item.Image = EditToolsImages16x16.Image(EditToolsImages16x16.eIndexes.Meet2Lines);
            item.Click += new EventHandler(OnEditToolSelect);
            item.Tag = "meet2lines";
            m_data.AddEditTool(item.Tag.ToString(), new EditTools.LinesMeetEditTool(this));

            item = m_menuItems.GetItem("ShrinkExtend");
            item.Text = "Shrink or Extend";
            item.ToolTipText = "Shrink or Extend";
            item.Image = EditToolsImages16x16.Image(EditToolsImages16x16.eIndexes.LineSrhinkExtend);
            item.Click += new EventHandler(OnEditToolSelect);
            item.Tag = "shrinkextend";
            m_data.AddEditTool(item.Tag.ToString(), new EditTools.LineShrinkExtendEditTool(this));

            EditToolsstrip = m_menuItems.GetStrip("modify");
            EditToolsstrip.Items.Add(m_menuItems.GetItem("Meet2Lines").CreateButton());
            EditToolsstrip.Items.Add(m_menuItems.GetItem("ShrinkExtend").CreateButton());
            m_toolHint = string.Empty;
        }

        public DataModel Model
        {
            get { return m_data; }
        }

        public CanvasCtrl Canvas
        {
            get { return m_canvas; }
        }

        void UpdateLayerUI()
        {
            CommonTools.NameObject<Layers.DrawingLayer> selitem = m_layerCombo.SelectedItem as CommonTools.NameObject<Layers.DrawingLayer>;
            if (selitem == null || selitem.Object != m_data.ActiveLayer)
            {
                foreach (CommonTools.NameObject<Layers.DrawingLayer> obj in m_layerCombo.Items)
                {
                    if (obj.Object == m_data.ActiveLayer)
                        m_layerCombo.SelectedItem = obj;
                }
            }
        }

        void UpdateData()
        {
            // update any additional properties of data which is not part of the interface
            m_data.CenterPoint = m_canvas.GetCenter();
        }

        void OnToolSelect(object sender, System.EventArgs e)
        {
            string toolid = string.Empty;
            bool fromKeyboard = false;
            if (sender is Utils.MenuItem) // from keyboard
            {
                toolid = ((Utils.MenuItem)sender).Tag.ToString();
                fromKeyboard = true;
            }
            if (sender is ToolStripItem) // from menu or toolbar
            {
                toolid = ((ToolStripItem)sender).Tag.ToString();
            }
            if (toolid == "select")
            {
                m_canvas.CommandEscape();
                return;
            }
            if (toolid == "pan")
            {
                m_canvas.CommandPan();
                return;
            }
            if (toolid == "move")
            {
                // if from keyboard then handle immediately, if from mouse click then only switch mode
                m_canvas.CommandMove(fromKeyboard);
                return;
            }
            m_canvas.CommandSelectDrawTool(toolid);
        }

        void OnEditToolSelect(object sender, System.EventArgs e)
        {
            string toolid = string.Empty;
            //bool fromKeyboard = false;
            if (sender is Utils.MenuItem) // from keyboard
            {
                toolid = ((Utils.MenuItem)sender).Tag.ToString();
                //fromKeyboard = true;
            }
            if (sender is ToolStripItem) // from menu or toolbar
            {
                toolid = ((ToolStripItem)sender).Tag.ToString();
            }
            m_canvas.CommandEdit(toolid);
        }

        void OnIdle(object sender, EventArgs e)
        {
            m_activeDocument = this;
            if (m_activeDocument != null)
                m_activeDocument.UpdateUI();
        }

        MainWinUC m_activeDocument = null;

        public void UpdateUI()
        {
            m_menuItems.GetItem("Undo").Enabled = m_data.CanUndo();
            m_menuItems.GetItem("Redo").Enabled = m_data.CanRedo();
            m_menuItems.GetItem("Move").Enabled = m_data.SelectedCount > 0;
        }

        #region Button Methods
        void OnUndo(object sender, System.EventArgs e)
        {
            if (m_data.DoUndo())
                m_canvas.DoInvalidate(true);
        }
        void OnRedo(object sender, System.EventArgs e)
        {
            if (m_data.DoRedo())
                m_canvas.DoInvalidate(true);
        }

        public void SaveAs()
        {
            UpdateData();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files (*.xml)|*.xml|Image Files (*.bmp)|*.bmp";
            dlg.FilterIndex = 1;
            dlg.OverwritePrompt = true;
            if (m_filename.Length > 0)
                dlg.FileName = m_filename;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (dlg.FilterIndex.Equals(1))
                {
                    m_filename = dlg.FileName;
                    m_data.Save(m_filename);
                    Text = m_filename;
                }
                if (dlg.FilterIndex.Equals(2))
                {
                    m_filename = dlg.FileName;
                    SaveImage(m_filename, m_canvas);
                }
            }
        }



        void OnLayerSelect(object sender, System.EventArgs e)
        {
            CommonTools.NameObject<Layers.DrawingLayer> obj = null;
            if (sender is ToolStripComboBox)
                obj = ((ToolStripComboBox)sender).SelectedItem as CommonTools.NameObject<Layers.DrawingLayer>;
            if (sender is Utils.MenuItem)
                obj = ((Utils.MenuItem)sender).Tag as CommonTools.NameObject<Layers.DrawingLayer>;
            if (obj == null)
                return;
            m_data.ActiveLayer = obj.Object as Layers.DrawingLayer;
            m_canvas.DoInvalidate(true);
            UpdateLayerUI();
        }

        private void OnFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML files (*.xml)|*.xml";
            if (dlg.ShowDialog(this) == DialogResult.OK)
                OpenDocument(dlg.FileName);
        }

        private void OnFileSave(object sender, EventArgs e)
        {
            MainWinUC doc = this;
            if (doc != null)
                doc.Save();
        }

        public void Save()
        {
            UpdateData();
            if (m_filename.Length == 0)
                SaveAs();
            else
                m_data.Save(m_filename);
        }

        private void OnFileNew(object sender, EventArgs e)
        {

            const string message = "Are you sure you want to create a new document?";
            const string caption = "Information";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OpenDocument(string.Empty);
            }

            if (result == DialogResult.No)
            {
                return;
            }
        }

        void OpenDocument(string filename)
        {
            Controls.Remove(m_canvas);
            m_canvas.Dispose();

            m_data = new DataModel();

            if (filename.Length > 0 && File.Exists(filename) && m_data.Load(filename))
            {
                Text = filename;
                m_filename = filename;
            }

            strip.Dispose();
            Editstrip.Dispose();
            Drawstrip.Dispose();
            Layerstrip.Dispose();
            EditToolsstrip.Dispose();
            status.Dispose();
            m_layerCombo.Dispose();
            menu.Dispose();
            menuitem.Dispose();
            Drawmenu.Dispose();

            m_canvas = new CanvasCtrl(this, m_data);
            m_canvas.Dock = DockStyle.Fill;
            Controls.Add(m_canvas);
            m_canvas.SetCenter(new Utils.UnitPoint(0, 0));

            m_layerCombo = new ToolStripComboBox();

            m_menuItems = new Utils.MenuItemManager(this);
            m_menuItems.SetupStripPanels();
            SetupToolbars();
            SetupLayerToolstrip();
            SetupEditTools();
            UpdateLayerUI();

        }

        private void OnFileSaveAs(object sender, EventArgs e)
        {
            MainWinUC doc = this;
            if (doc != null)
                doc.SaveAs();
        }

        private void OnUpdateMenuUI(object sender, EventArgs e)
        {


        }

        private void OnAbout(object sender, EventArgs e)
        {

        }

        public ToolStrip GetToolStrip(string id)
        {
            return m_menuItems.GetStrip(id);
        }

        private void OnOptions(object sender, EventArgs e)
        {
            MainWinUC doc = this;
            if (doc == null)
                return;

            Options.OptionsDlg dlg = new Options.OptionsDlg();
            dlg.Config.Grid.CopyFromLayer(doc.Model.GridLayer as Layers.GridLayer);
            dlg.Config.Background.CopyFromLayer(doc.Model.BackgroundLayer as Layers.BackgroundLayer);
            foreach (Layers.DrawingLayer layer in doc.Model.Layers)
                dlg.Config.Layers.Add(new Options.OptionsLayer(layer));

            ToolStripItem item = sender as ToolStripItem;
            dlg.SelectPage(item.Tag);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                dlg.Config.Grid.CopyToLayer((Layers.GridLayer)doc.Model.GridLayer);
                dlg.Config.Background.CopyToLayer((Layers.BackgroundLayer)doc.Model.BackgroundLayer);
                foreach (Options.OptionsLayer optionslayer in dlg.Config.Layers)
                {
                    Layers.DrawingLayer layer = (Layers.DrawingLayer)doc.Model.GetLayer(optionslayer.Layer.Id);
                    if (layer != null)
                        optionslayer.CopyToLayer(layer);
                    else
                    {
                        // delete layer
                    }
                }

                doc.Canvas.DoInvalidate(true);
            }
        }
        #endregion

        public void SaveImage(String filename, CanvasCtrl canvas)
        {
            Bitmap imageToSave = new Bitmap(canvas.ClientRectangle.Width, canvas.ClientRectangle.Height);

            Graphics g = Graphics.FromImage(imageToSave);

            PaintEventArgs pe = new PaintEventArgs(g, new Rectangle(0, 0, canvas.ClientRectangle.Width, canvas.ClientRectangle.Height));

            this.InvokePaintBackground(canvas, pe);
            this.InvokePaint(canvas, pe);


            Bitmap original = new Bitmap(imageToSave);
            Size size = new Size(original.Width * 2, original.Height * 2);
            Bitmap scaled = new Bitmap(original, size);
            scaled.Save(filename);
            /*using (Graphics graphics = Graphics.FromImage(scaled))
            {
                graphics.DrawImage(original, new Rectangle(0, 0, scaled.Width, scaled.Height));
            }*/

            g.Dispose();
            imageToSave.Dispose();
            original.Dispose();
            scaled.Dispose();
        }

        #region Image Resizing
        /// <summary>
        /// From http://stackoverflow.com/questions/249587/high-quality-image-scaling-c-sharp
        /// </summary>
        private static Dictionary<string, ImageCodecInfo> encoders = null;

        /// <summary>
        /// A quick lookup for getting image encoders
        /// </summary>
        public static Dictionary<string, ImageCodecInfo> Encoders
        {
            //get accessor that creates the dictionary on demand
            get
            {
                //if the quick lookup isn't initialised, initialise it
                if (encoders == null)
                {
                    encoders = new Dictionary<string, ImageCodecInfo>();
                }

                //if there are no codecs, try loading them
                if (encoders.Count == 0)
                {
                    //get all the codecs
                    foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                    {
                        //add each codec to the quick lookup
                        encoders.Add(codec.MimeType.ToLower(), codec);
                    }
                }

                //return the lookup
                return encoders;
            }
        }


        public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);
            //set the resolutions the same to avoid cropping due to resolution differences
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //draw the image into the target bitmap
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }

        public static void SaveJpeg(string path, Image image, int quality)
        {
            //ensure the quality is within the correct range
            if ((quality < 0) || (quality > 100))
            {
                //create the error message
                string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
                //throw a helpful exception
                throw new ArgumentOutOfRangeException(error);
            }

            //create an encoder parameter for the image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //get the jpeg codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            //create a collection of all parameters that we will pass to the encoder
            EncoderParameters encoderParams = new EncoderParameters(1);
            //set the quality parameter for the codec
            encoderParams.Param[0] = qualityParam;
            //save the image using the codec and the parameters
            image.Save(path, jpegCodec, encoderParams);
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            //do a case insensitive search for the mime type
            string lookupKey = mimeType.ToLower();

            //the codec to return, default to null
            ImageCodecInfo foundCodec = null;

            //if we have the encoder, get it to return
            if (Encoders.ContainsKey(lookupKey))
            {
                //pull the codec from the lookup
                foundCodec = Encoders[lookupKey];
            }

            return foundCodec;
        }
        #endregion

        #region Reading From XML For Image
        public static XmlAttribute CreateAttribute(XmlNode node, string name, object value)
        {
            XmlAttribute attribute = node.OwnerDocument.CreateAttribute(name);
            attribute.Value = value.ToString();
            node.Attributes.Append(attribute);
            return attribute;
        }

        public static XmlElement CreateTextElement(XmlNode node, string name, string value)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(sb)))
            {
                writer.WriteString(value);
            }
            XmlElement element = node.OwnerDocument.CreateElement(name, node.NamespaceURI);
            element.InnerText = sb.ToString();
            node.AppendChild(element);
            return element;
        }

        public static XmlElement CreateImageElement(XmlNode node, string name, Image image)
        {
            XmlElement imageElement;
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();
                String imageBase64String = Convert.ToBase64String(imageBytes);
                imageElement = CreateTextElement(node, name, imageBase64String);
            }
            return imageElement;
        }

        public static Image ReadImageElement(XmlElement node)
        {
            Image image;
            byte[] imageBytes = Convert.FromBase64String(node.InnerText);
            using (var stream = new MemoryStream(imageBytes))
            {
                image = Bitmap.FromStream(stream);
                return image;
            }
        }
        #endregion

        void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys != Keys.None)
                return;

            Utils.MenuItem item = m_menuItems.FindFromSingleKey(e.KeyCode);
            if (item != null && item.Click != null)
            {
                item.Click(item, null);
                e.Handled = true;
            }
        }

        #region ICanvasOwner Members
        public void SetPositionInfo(Utils.UnitPoint unitpos)
        {
            m_mousePosLabel.Text = unitpos.PosAsString();
            string s = string.Empty;
            if (m_data.SelectedCount == 1 || m_canvas.NewObject != null)
            {
                IDrawObject obj = m_data.GetFirstSelected();
                if (obj == null)
                    obj = m_canvas.NewObject;
                if (obj != null)
                    s = obj.GetInfoAsString();
            }
            if (m_toolHint.Length > 0)
                s = m_toolHint;
            if (s != m_drawInfoLabel.Text)
                m_drawInfoLabel.Text = s;
        }
        public void SetSnapInfo(ISnapPoint snap)
        {
            m_snapHint = string.Empty;
            if (snap != null)
                m_snapHint = string.Format("Snap@{0}, {1}", snap.SnapPoint.PosAsString(), snap.GetType());
            m_snapInfoLabel.Text = m_snapHint;
        }
        #endregion
        #region IEditToolOwner
        public void SetHint(string text)
        {
            m_toolHint = text;
            m_drawInfoLabel.Text = m_toolHint;
            //SetHint();
        }
        #endregion
        string m_toolHint = string.Empty;
        string m_snapHint = string.Empty;
        /*
        void SetHint()
        {
            if (m_toolHint.Length > 0)
                m_snapInfoLabel.Text = m_toolHint;
            else
                m_snapInfoLabel.Text = m_snapHint;
        }
        */
    }
}
