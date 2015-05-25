using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DesktopApp.CAD_Program
{
    public struct CanvasWrapper : ICanvas
    {
        CanvasCtrl m_canvas;
        Graphics m_graphics;
        Rectangle m_rect;


        public CanvasWrapper(CanvasCtrl canvas)
        {
            m_canvas = canvas;
            m_graphics = null;
            m_rect = new Rectangle();
        }
        public CanvasWrapper(CanvasCtrl canvas, Graphics graphics, Rectangle clientrect)
        {
            m_canvas = canvas;
            m_graphics = graphics;
            m_rect = clientrect;
        }
        public IModel Model
        {
            get { return m_canvas.Model; }
        }
        public CanvasCtrl CanvasCtrl
        {
            get { return m_canvas; }
        }
        public void Dispose()
        {
            m_graphics = null;
        }
        #region ICanvas Members
        public IModel DataModel
        {
            get { return m_canvas.Model; }
        }
        public Utils.UnitPoint ScreenTopLeftToUnitPoint()
        {
            return m_canvas.ScreenTopLeftToUnitPoint();
        }
        public Utils.UnitPoint ScreenBottomRightToUnitPoint()
        {
            return m_canvas.ScreenBottomRightToUnitPoint();
        }
        public PointF ToScreen(Utils.UnitPoint unitpoint)
        {
            return m_canvas.ToScreen(unitpoint);
        }
        public float ToScreen(double unitvalue)
        {
            return m_canvas.ToScreen(unitvalue);
        }
        public double ToUnit(float screenvalue)
        {
            return m_canvas.ToUnit(screenvalue);
        }
        public Utils.UnitPoint ToUnit(PointF screenpoint)
        {
            return m_canvas.ToUnit(screenpoint);
        }
        public Graphics Graphics
        {
            get { return m_graphics; }
        }
        public Rectangle ClientRectangle
        {
            get { return m_rect; }
            set { m_rect = value; }
        }
        public Pen CreatePen(Color color, float unitWidth)
        {
            return m_canvas.CreatePen(color, unitWidth);
        }
        public void DrawLine(ICanvas canvas, Pen pen, Utils.UnitPoint p1, Utils.UnitPoint p2)
        {
            m_canvas.DrawLine(canvas, pen, p1, p2);
        }

        public void DrawFuse(ICanvas canvas, Pen pen, Utils.UnitPoint TopRectP1, Utils.UnitPoint TopRectP2)
        {
            m_canvas.DrawFuse(canvas, pen, TopRectP1, TopRectP2);
        }
        public void DrawArc(ICanvas canvas, Pen pen, Utils.UnitPoint center, float radius, float beginangle, float angle)
        {
            m_canvas.DrawArc(canvas, pen, center, radius, beginangle, angle);
        }
        public void Invalidate()
        {
            m_canvas.DoInvalidate(false);
        }
        public IDrawObject CurrentObject
        {
            get { return m_canvas.NewObject; }
        }
        #endregion


        public void SetPositionInfo(Utils.UnitPoint unitpos)
        {
            throw new NotImplementedException();
        }

        public void SetSnapInfo(ISnapPoint snap)
        {
            throw new NotImplementedException();
        }
    }
    public partial class CanvasCtrl : UserControl
    {
        enum eCommandType
        {
            select,
            pan,
            move,
            draw,
            edit,
            editNode,
        }

        ICanvasOwner m_owner;
        Resources.CursorCollection m_cursors = new Resources.CursorCollection();
        IModel m_model;
        Utils.MoveHelper m_moveHelper = null;
        Utils.NodeMoveHelper m_nodeMoveHelper = null;
        CanvasWrapper m_canvaswrapper;
        eCommandType m_commandType = eCommandType.select;
        bool m_runningSnaps = true;
        Type[] m_runningSnapTypes = null;
        PointF m_mousedownPoint;
        IDrawObject m_newObject = null;
        IEditTool m_editTool = null;
        Utils.SelectionRectangle m_selection = null;
        string m_drawObjectId = string.Empty;
        string m_editToolId = string.Empty;
        Bitmap m_staticImage = null;
        bool m_staticDirty = true;
        ISnapPoint m_snappoint = null;

        public int fuse, resistor, capacitor;

        public Type[] RunningSnaps
        {
            get { return m_runningSnapTypes; }
            set { m_runningSnapTypes = value; }
        }
        public bool RunningSnapsEnabled
        {
            get { return m_runningSnaps; }
            set { m_runningSnaps = value; }
        }

        System.Drawing.Drawing2D.SmoothingMode m_smoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode
        {
            get { return m_smoothingMode; }
            set { m_smoothingMode = value; }
        }

        public IModel Model
        {
            get { return m_model; }
            set { m_model = value; }
        }
        public CanvasCtrl(ICanvasOwner owner, IModel datamodel)
        {
            m_canvaswrapper = new CanvasWrapper(this);
            m_owner = owner;
            m_model = datamodel;

            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            m_commandType = eCommandType.select;
            m_cursors.AddCursor(eCommandType.select, Cursors.Arrow);
            m_cursors.AddCursor(eCommandType.draw, Cursors.Cross);
            m_cursors.AddCursor(eCommandType.pan, Cursors.Hand);
            m_cursors.AddCursor(eCommandType.move, Cursors.SizeAll);
            m_cursors.AddCursor(eCommandType.edit, Cursors.Cross);
            UpdateCursor();

            m_moveHelper = new Utils.MoveHelper(this);
            m_nodeMoveHelper = new Utils.NodeMoveHelper(m_canvaswrapper);
        }
        public Utils.UnitPoint GetMousePoint()
        {
            Point point = this.PointToClient(Control.MousePosition);
            return ToUnit(point);
        }
        public void SetCenter(Utils.UnitPoint unitPoint)
        {
            PointF point = ToScreen(unitPoint);
            m_lastCenterPoint = unitPoint;
            SetCenterScreen(point, false);
        }
        public void SetCenter()
        {
            Point point = this.PointToClient(Control.MousePosition);
            SetCenterScreen(point, true);
        }
        public Utils.UnitPoint GetCenter()
        {
            return ToUnit(new PointF(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2));
        }
        protected void SetCenterScreen(PointF screenPoint, bool setCursor)
        {
            float centerX = ClientRectangle.Width / 2;
            m_panOffset.X += centerX - screenPoint.X;

            float centerY = ClientRectangle.Height / 2;
            m_panOffset.Y += centerY - screenPoint.Y;

            if (setCursor)
                Cursor.Position = this.PointToScreen(new Point((int)centerX, (int)centerY));
            DoInvalidate(true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            CommonTools.Tracing.StartTrack(Program.TracePaint);
            ClearPens();
            e.Graphics.SmoothingMode = m_smoothingMode;
            CanvasWrapper dc = new CanvasWrapper(this, e.Graphics, ClientRectangle);
            Rectangle cliprectangle = e.ClipRectangle;
            if (m_staticImage == null)
            {
                cliprectangle = ClientRectangle;
                m_staticImage = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                m_staticDirty = true;
            }
            RectangleF r = Utils.ScreenUtils.ToUnitNormalized(dc, cliprectangle);
            if (float.IsNaN(r.Width) || float.IsInfinity(r.Width))
            {
                r = Utils.ScreenUtils.ToUnitNormalized(dc, cliprectangle);
            }
            if (m_staticDirty)
            {
                m_staticDirty = false;
                CanvasWrapper dcStatic = new CanvasWrapper(this, Graphics.FromImage(m_staticImage), ClientRectangle);
                dcStatic.Graphics.SmoothingMode = m_smoothingMode;
                m_model.BackgroundLayer.Draw(dcStatic, r);
                if (m_model.GridLayer.Enabled)
                    m_model.GridLayer.Draw(dcStatic, r);

                PointF nullPoint = ToScreen(new Utils.UnitPoint(0, 0));
                dcStatic.Graphics.DrawLine(Pens.Blue, nullPoint.X - 10, nullPoint.Y, nullPoint.X + 10, nullPoint.Y);
                dcStatic.Graphics.DrawLine(Pens.Blue, nullPoint.X, nullPoint.Y - 10, nullPoint.X, nullPoint.Y + 10);

                ICanvasLayer[] layers = m_model.Layers;
                for (int layerindex = layers.Length - 1; layerindex >= 0; layerindex--)
                {
                    if (layers[layerindex] != m_model.ActiveLayer && layers[layerindex].Visible)
                        layers[layerindex].Draw(dcStatic, r);
                }
                if (m_model.ActiveLayer != null)
                    m_model.ActiveLayer.Draw(dcStatic, r);

                dcStatic.Dispose();
            }
            e.Graphics.DrawImage(m_staticImage, cliprectangle, cliprectangle, GraphicsUnit.Pixel);

            foreach (IDrawObject drawobject in m_model.SelectedObjects)
                drawobject.Draw(dc, r);

            if (m_newObject != null)
                m_newObject.Draw(dc, r);

            if (m_snappoint != null)
                m_snappoint.Draw(dc);

            if (m_selection != null)
            {
                m_selection.Reset();
                m_selection.SetMousePoint(e.Graphics, this.PointToClient(Control.MousePosition));
            }
            if (m_moveHelper.IsEmpty == false)
                m_moveHelper.DrawObjects(dc, r);

            if (m_nodeMoveHelper.IsEmpty == false)
                m_nodeMoveHelper.DrawObjects(dc, r);
            dc.Dispose();
            ClearPens();
            CommonTools.Tracing.EndTrack(Program.TracePaint, "OnPaint complete");
        }
        void RepaintStatic(Rectangle r)
        {
            if (m_staticImage == null)
                return;
            Graphics dc = Graphics.FromHwnd(Handle);
            if (r.X < 0) r.X = 0;
            if (r.X > m_staticImage.Width) r.X = 0;
            if (r.Y < 0) r.Y = 0;
            if (r.Y > m_staticImage.Height) r.Y = 0;

            if (r.Width > m_staticImage.Width || r.Width < 0)
                r.Width = m_staticImage.Width;
            if (r.Height > m_staticImage.Height || r.Height < 0)
                r.Height = m_staticImage.Height;
            dc.DrawImage(m_staticImage, r, r, GraphicsUnit.Pixel);
            dc.Dispose();
        }
        void RepaintSnappoint(ISnapPoint snappoint)
        {
            if (snappoint == null)
                return;
            CanvasWrapper dc = new CanvasWrapper(this, Graphics.FromHwnd(Handle), ClientRectangle);
            snappoint.Draw(dc);
            dc.Graphics.Dispose();
            dc.Dispose();
        }
        void RepaintObject(IDrawObject obj)
        {
            if (obj == null)
                return;
            CanvasWrapper dc = new CanvasWrapper(this, Graphics.FromHwnd(Handle), ClientRectangle);
            RectangleF invalidaterect = Utils.ScreenUtils.ConvertRect(Utils.ScreenUtils.ToScreenNormalized(dc, obj.GetBoundingRect(dc)));
            obj.Draw(dc, invalidaterect);
            dc.Graphics.Dispose();
            dc.Dispose();
        }
        public void DoInvalidate(bool dostatic, RectangleF rect)
        {
            if (dostatic)
                m_staticDirty = true;
            Invalidate(Utils.ScreenUtils.ConvertRect(rect));
        }
        public void DoInvalidate(bool dostatic)
        {
            if (dostatic)
                m_staticDirty = true;
            Invalidate();
        }
        public IDrawObject NewObject
        {
            get { return m_newObject; }
        }
        protected void HandleSelection(List<IDrawObject> selected)
        {
            bool add = Control.ModifierKeys == Keys.Shift;
            bool toggle = Control.ModifierKeys == Keys.Control;
            bool invalidate = false;
            bool anyoldsel = false;
            int selcount = 0;
            if (selected != null)
                selcount = selected.Count;
            foreach (IDrawObject obj in m_model.SelectedObjects)
            {
                anyoldsel = true;
                break;
            }
            if (toggle && selcount > 0)
            {
                invalidate = true;
                foreach (IDrawObject obj in selected)
                {
                    if (m_model.IsSelected(obj))
                        m_model.RemoveSelectedObject(obj);
                    else
                        m_model.AddSelectedObject(obj);
                }
            }
            if (add && selcount > 0)
            {
                invalidate = true;
                foreach (IDrawObject obj in selected)
                    m_model.AddSelectedObject(obj);
            }
            if (add == false && toggle == false && selcount > 0)
            {
                invalidate = true;
                m_model.ClearSelectedObjects();
                foreach (IDrawObject obj in selected)
                    m_model.AddSelectedObject(obj);
            }
            if (add == false && toggle == false && selcount == 0 && anyoldsel)
            {
                invalidate = true;
                m_model.ClearSelectedObjects();
            }

            if (invalidate)
                DoInvalidate(false);
        }
        void FinishNodeEdit()
        {
            m_commandType = eCommandType.select;
            m_snappoint = null;
        }
        protected virtual void HandleMouseDownWhenDrawing(Utils.UnitPoint mouseunitpoint, ISnapPoint snappoint)
        {
            if (m_commandType == eCommandType.draw)
            {
                if (m_newObject == null)
                {
                    m_newObject = m_model.CreateObject(m_drawObjectId, mouseunitpoint, snappoint);
                    DoInvalidate(false, m_newObject.GetBoundingRect(m_canvaswrapper));
                }
                else
                {
                    if (m_newObject != null)
                    {
                        eDrawObjectMouseDown result = m_newObject.OnMouseDown(m_canvaswrapper, mouseunitpoint, snappoint);
                        switch (result)
                        {
                            case eDrawObjectMouseDown.Done:
                                m_model.AddObject(m_model.ActiveLayer, m_newObject);
                                m_newObject = null;
                                DoInvalidate(true);
                                break;
                            case eDrawObjectMouseDown.DoneRepeat:
                                m_model.AddObject(m_model.ActiveLayer, m_newObject);
                                m_newObject = m_model.CreateObject(m_newObject.Id, m_newObject.RepeatStartingPoint, null);
                                DoInvalidate(true);
                                break;
                            case eDrawObjectMouseDown.Continue:
                                break;
                        }
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_mousedownPoint = new PointF(e.X, e.Y); // used when panning
            m_dragOffset = new PointF(0, 0);

            Utils.UnitPoint mousepoint = ToUnit(m_mousedownPoint);
            if (m_snappoint != null)
                mousepoint = m_snappoint.SnapPoint;

            if (m_commandType == eCommandType.editNode)
            {
                bool handled = false;
                if (m_nodeMoveHelper.HandleMouseDown(mousepoint, ref handled))
                {
                    FinishNodeEdit();
                    base.OnMouseDown(e);
                    return;
                }
            }
            if (m_commandType == eCommandType.select)
            {
                bool handled = false;
                if (m_nodeMoveHelper.HandleMouseDown(mousepoint, ref handled))
                {
                    m_commandType = eCommandType.editNode;
                    m_snappoint = null;
                    base.OnMouseDown(e);
                    return;
                }
                m_selection = new Utils.SelectionRectangle(m_mousedownPoint);
            }
            if (m_commandType == eCommandType.move)
            {
                m_moveHelper.HandleMouseDownForMove(mousepoint, m_snappoint);
            }
            if (m_commandType == eCommandType.draw)
            {
                HandleMouseDownWhenDrawing(mousepoint, null);
                DoInvalidate(true);
            }
            if (m_commandType == eCommandType.edit)
            {
                if (m_editTool == null)
                    m_editTool = m_model.GetEditTool(m_editToolId);
                if (m_editTool != null)
                {
                    if (m_editTool.SupportSelection)
                        m_selection = new Utils.SelectionRectangle(m_mousedownPoint);

                    eDrawObjectMouseDown mouseresult = m_editTool.OnMouseDown(m_canvaswrapper, mousepoint, m_snappoint);
                    /*
                    if (mouseresult == eDrawObjectMouseDown.Continue)
                    {
                        if (m_editTool.SupportSelection)
                            m_selection = new SelectionRectangle(m_mousedownPoint);
                    }
                     * */
                    if (mouseresult == eDrawObjectMouseDown.Done)
                    {
                        m_editTool.Finished();
                        m_editTool = m_model.GetEditTool(m_editToolId); // continue with new tool
                        //m_editTool = null;

                        if (m_editTool.SupportSelection)
                            m_selection = new Utils.SelectionRectangle(m_mousedownPoint);
                    }
                }
                DoInvalidate(true);
                UpdateCursor();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (m_commandType == eCommandType.pan)
            {
                m_panOffset.X += m_dragOffset.X;
                m_panOffset.Y += m_dragOffset.Y;
                m_dragOffset = new PointF(0, 0);
            }

            List<IDrawObject> hitlist = null;
            Rectangle screenSelRect = Rectangle.Empty;
            if (m_selection != null)
            {
                screenSelRect = m_selection.ScreenRect();
                RectangleF selectionRect = m_selection.Selection(m_canvaswrapper);
                if (selectionRect != RectangleF.Empty)
                {
                    // is any selection rectangle. use it for selection
                    hitlist = m_model.GetHitObjects(m_canvaswrapper, selectionRect, m_selection.AnyPoint());
                    DoInvalidate(true);
                }
                else
                {
                    // else use mouse point
                    Utils.UnitPoint mousepoint = ToUnit(new PointF(e.X, e.Y));
                    hitlist = m_model.GetHitObjects(m_canvaswrapper, mousepoint);
                }
                m_selection = null;
            }
            if (m_commandType == eCommandType.select)
            {
                if (hitlist != null)
                    HandleSelection(hitlist);
            }
            if (m_commandType == eCommandType.edit && m_editTool != null)
            {
                Utils.UnitPoint mousepoint = ToUnit(m_mousedownPoint);
                if (m_snappoint != null)
                    mousepoint = m_snappoint.SnapPoint;
                if (screenSelRect != Rectangle.Empty)
                    m_editTool.SetHitObjects(mousepoint, hitlist);
                m_editTool.OnMouseUp(m_canvaswrapper, mousepoint, m_snappoint);
            }
            if (m_commandType == eCommandType.draw && m_newObject != null)
            {
                Utils.UnitPoint mousepoint = ToUnit(m_mousedownPoint);
                if (m_snappoint != null)
                    mousepoint = m_snappoint.SnapPoint;
                m_newObject.OnMouseUp(m_canvaswrapper, mousepoint, m_snappoint);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (m_selection != null)
            {
                Graphics dc = Graphics.FromHwnd(Handle);
                m_selection.SetMousePoint(dc, new PointF(e.X, e.Y));
                dc.Dispose();
                return;
            }

            if (m_commandType == eCommandType.pan && e.Button == MouseButtons.Left)
            {
                m_dragOffset.X = -(m_mousedownPoint.X - e.X);
                m_dragOffset.Y = -(m_mousedownPoint.Y - e.Y);
                m_lastCenterPoint = CenterPointUnit();
                DoInvalidate(true);
            }
            Utils.UnitPoint mousepoint;
            Utils.UnitPoint unitpoint = ToUnit(new PointF(e.X, e.Y));
            if (m_commandType == eCommandType.draw || m_commandType == eCommandType.move || m_nodeMoveHelper.IsEmpty == false)
            {
                Rectangle invalidaterect = Rectangle.Empty;
                ISnapPoint newsnap = null;
                mousepoint = GetMousePoint();
                if (RunningSnapsEnabled)
                    newsnap = m_model.SnapPoint(m_canvaswrapper, mousepoint, m_runningSnapTypes, null);
                if (newsnap == null)
                    newsnap = m_model.GridLayer.SnapPoint(m_canvaswrapper, mousepoint, null);
                if ((m_snappoint != null) && ((newsnap == null) || (newsnap.SnapPoint != m_snappoint.SnapPoint) || m_snappoint.GetType() != newsnap.GetType()))
                {
                    invalidaterect = Utils.ScreenUtils.ConvertRect(Utils.ScreenUtils.ToScreenNormalized(m_canvaswrapper, m_snappoint.BoundingRect));
                    invalidaterect.Inflate(2, 2);
                    RepaintStatic(invalidaterect); // remove old snappoint
                    m_snappoint = newsnap;
                }
                if (m_commandType == eCommandType.move)
                    Invalidate(invalidaterect);

                if (m_snappoint == null)
                    m_snappoint = newsnap;
            }

            //canvasThing.SetPositionInfo(unitpoint);
            //canvasThing.SetSnapInfo(m_snappoint);
            m_owner.SetPositionInfo(unitpoint);
            m_owner.SetSnapInfo(m_snappoint);


            //UnitPoint mousepoint;
            if (m_snappoint != null)
                mousepoint = m_snappoint.SnapPoint;
            else
                mousepoint = GetMousePoint();

            if (m_newObject != null)
            {
                Rectangle invalidaterect = Utils.ScreenUtils.ConvertRect(Utils.ScreenUtils.ToScreenNormalized(m_canvaswrapper, m_newObject.GetBoundingRect(m_canvaswrapper)));
                invalidaterect.Inflate(2, 2);
                RepaintStatic(invalidaterect);

                m_newObject.OnMouseMove(m_canvaswrapper, mousepoint);
                RepaintObject(m_newObject);
            }
            if (m_snappoint != null)
                RepaintSnappoint(m_snappoint);

            if (m_moveHelper.HandleMouseMoveForMove(mousepoint))
                Refresh(); //Invalidate();

            RectangleF rNoderect = m_nodeMoveHelper.HandleMouseMoveForNode(mousepoint);
            if (rNoderect != RectangleF.Empty)
            {
                Rectangle invalidaterect = Utils.ScreenUtils.ConvertRect(Utils.ScreenUtils.ToScreenNormalized(m_canvaswrapper, rNoderect));
                RepaintStatic(invalidaterect);

                CanvasWrapper dc = new CanvasWrapper(this, Graphics.FromHwnd(Handle), ClientRectangle);
                dc.Graphics.Clip = new Region(ClientRectangle);
                //m_nodeMoveHelper.DrawOriginalObjects(dc, rNoderect);
                m_nodeMoveHelper.DrawObjects(dc, rNoderect);
                if (m_snappoint != null)
                    RepaintSnappoint(m_snappoint);

                dc.Graphics.Dispose();
                dc.Dispose();
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Utils.UnitPoint p = GetMousePoint();
            float wheeldeltatick = 120;
            float zoomdelta = (1.25f * (Math.Abs(e.Delta) / wheeldeltatick));
            if (e.Delta < 0)
                m_model.Zoom = m_model.Zoom / zoomdelta;
            else
                m_model.Zoom = m_model.Zoom * zoomdelta;
            SetCenterScreen(ToScreen(p), true);
            DoInvalidate(true);
            base.OnMouseWheel(e);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (m_lastCenterPoint != Utils.UnitPoint.Empty && Width != 0)
                SetCenterScreen(ToScreen(m_lastCenterPoint), false);
            m_lastCenterPoint = CenterPointUnit();
            m_staticImage = null;
            DoInvalidate(true);
        }

        Utils.UnitPoint m_lastCenterPoint;
        PointF m_panOffset = new PointF(25, -25);
        PointF m_dragOffset = new PointF(0, 0);
        float m_screenResolution = 96;

        PointF Translate(Utils.UnitPoint point)
        {
            return point.Point;
        }
        float ScreenHeight()
        {
            return (float)(ToUnit(this.ClientRectangle.Height) / m_model.Zoom);
            //return (float)(ToUnit(this.ClientRectangle.Height) / 1);
        }

        #region ICanvas
        public Utils.UnitPoint CenterPointUnit()
        {
            Utils.UnitPoint p1 = ScreenTopLeftToUnitPoint();
            Utils.UnitPoint p2 = ScreenBottomRightToUnitPoint();
            Utils.UnitPoint center = new Utils.UnitPoint();
            center.X = (p1.X + p2.X) / 2;
            center.Y = (p1.Y + p2.Y) / 2;
            m_model.Zoom = 1;
            return center;
        }

        public Utils.UnitPoint ScreenTopLeftToUnitPoint()
        {
            return ToUnit(new PointF(0, 0));
        }
        public Utils.UnitPoint ScreenBottomRightToUnitPoint()
        {
            return ToUnit(new PointF(this.ClientRectangle.Width, this.ClientRectangle.Height));
        }
        public PointF ToScreen(Utils.UnitPoint point)
        {
            PointF transformedPoint = Translate(point);
            transformedPoint.Y = ScreenHeight() - transformedPoint.Y;
            transformedPoint.Y *= m_screenResolution * m_model.Zoom;
            transformedPoint.X *= m_screenResolution * m_model.Zoom;
            //transformedPoint.Y *= m_screenResolution * 1;
            //transformedPoint.X *= m_screenResolution * 1;


            transformedPoint.X += m_panOffset.X + m_dragOffset.X;
            transformedPoint.Y += m_panOffset.Y + m_dragOffset.Y;
            return transformedPoint;
        }
        public float ToScreen(double value)
        {
            return (float)(value * m_screenResolution * m_model.Zoom);
            //return (float)(value * m_screenResolution * 1);
        }
        public double ToUnit(float screenvalue)
        {
            return (double)screenvalue / (double)(m_screenResolution * m_model.Zoom);
            //return (double)screenvalue / (double)(m_screenResolution * 1);
        }
        public Utils.UnitPoint ToUnit(PointF screenpoint)
        {
            float panoffsetX = m_panOffset.X + m_dragOffset.X;
            float panoffsetY = m_panOffset.Y + m_dragOffset.Y;
            float xpos = (screenpoint.X - panoffsetX) / (m_screenResolution * m_model.Zoom);
            float ypos = ScreenHeight() - ((screenpoint.Y - panoffsetY)) / (m_screenResolution * m_model.Zoom);
            //float xpos = (screenpoint.X - panoffsetX) / (m_screenResolution * 1);
            //float ypos = ScreenHeight() - ((screenpoint.Y - panoffsetY)) / (m_screenResolution * 1);

            return new Utils.UnitPoint(xpos, ypos);
        }
        public Pen CreatePen(Color color, float unitWidth)
        {
            return GetPen(color, ToScreen(unitWidth));
        }
        public void DrawLine(ICanvas canvas, Pen pen, Utils.UnitPoint p1, Utils.UnitPoint p2)
        {
            PointF tmpp1 = ToScreen(p1);
            PointF tmpp2 = ToScreen(p2);
            canvas.Graphics.DrawLine(pen, tmpp1, tmpp2);
        }

        public void DrawFuse(ICanvas canvas, Pen pen, Utils.UnitPoint TopRectP1, Utils.UnitPoint TopRectP2)
        {
            PointF p1 = ToScreen(TopRectP1);
            PointF p2 = ToScreen(TopRectP2);
            PointF p3 = new PointF();
            PointF p4 = new PointF();
            PointF p5 = new PointF();

            p3.X = (float)getDistanceP2X(p2);
            p3.Y = p2.Y;

            p4.X = p3.X;
            p4.Y = (float)getDistanceP1Y(p3);

            PointF midpointP1P2 = GetCenterPoint(p1, p2);
            double distanceFromP4Mid = getDistance(p4, midpointP1P2);

            p5.Y = p3.Y;
            p5.X = (float)P5X(midpointP1P2, p3, distanceFromP4Mid);


            PointF centerP1P3 = GetCenterPoint(p1, p3);
            PointF centerP2P4 = GetCenterPoint(p2, p4);

            double m = GetSlope(p1, p2);
            double intersectTop = GetIntersect(p1, p2);

            /*PointF l1_p1 = new PointF(TopLeft.X, TopLeft.Y);
            PointF l1_p2 = new PointF(TopRight.X, TopRight.Y);
            PointF l2_p1 = GetCenterPoint(l1_p1, l1_p2);
            PointF l2_p2;
            if (GetIntersect(l1_p1, l1_p2) == 0)
                l2_p2 = new PointF(0, l2_p1.Y);
            else
                l2_p2 = new PointF(0, GetIntersect(l1_p1, l1_p2));*/

            PointF rotatePoint = new PointF(p1.X, p1.Y);

            double angle = getAngle(p1, p2);
            //canvas.Graphics.DrawLine(pen, p1, p2);
            //canvas.Graphics.DrawRectangle(pen, getRectangle(p1, p2));

            Matrix myMatrix = new Matrix();
            //myMatrix.RotateAt((int)angle, centerP1P3, MatrixOrder.Prepend);

            //canvas.Graphics.Transform = myMatrix;
            canvas.Graphics.DrawLine(pen, p1, p2);
            //canvas.Graphics.DrawLine(pen, centerP1P3, centerP2P4);
            //canvas.Graphics.DrawRectangle(pen, getRectangle(p5, p4));

        }

        private double getAngle(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
        }

        private Rectangle getRectangle(PointF p1, PointF p2)
        {
            //return new Rectangle((int)Math.Min(p1.X, p2.X), (int)Math.Min(p1.Y, p2.Y), (int)Math.Abs(p1.X - p2.X), (int)Math.Abs(p1.Y - p2.Y));
            int top = (int)Math.Min(p1.Y, p2.Y);
            int bottom = (int)Math.Max(p1.Y, p2.Y);
            int left = (int)Math.Min(p1.X, p2.X);
            int right = (int)Math.Max(p1.X, p2.X);

            Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);
            return rect;
        }

        public static RectangleF GetRectangle(PointF p1, PointF p2)
        {
            float top = Math.Min(p1.Y, p2.Y);
            float bottom = Math.Max(p1.Y, p2.Y);
            float left = Math.Min(p1.X, p2.X);
            float right = Math.Max(p1.X, p2.X);

            RectangleF rect = RectangleF.FromLTRB(left, top, right, bottom);

            return rect;
        }

        private double GetSlope(PointF p1, PointF p2)
        {
            if ((p2.Y - p1.Y) != 0)
                return (p1.X - p2.X) / (p2.Y - p1.Y);
            else return double.PositiveInfinity;
        }

        private float GetIntersect(PointF p1, PointF p2)
        {
            double slope = GetSlope(p1, p2);
            PointF center = GetCenterPoint(p1, p2);
            if (double.IsPositiveInfinity(slope))
                return 0;
            return (float)(center.Y - (slope * center.X));
        }

        private PointF GetCenterPoint(PointF p1, PointF p2)
        {
            return new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
        }

        private double getDistance(PointF p1, PointF p2)
        {
            double d = Math.Sqrt((p2.Y - p1.Y) - (p2.X - p1.X));
            return d;
        }

        private double getDistanceP2X(PointF p1)
        {
            double z = p1.X - 100;
            return z;
        }

        private double getDistanceP1Y(PointF p3)
        {
            double z = p3.Y - 50;
            return z;
        }

        private double getOtherDis(PointF p1, double D)
        {
            double b = Math.Sqrt(Math.Pow(D, 2) - Math.Pow(50, 2));
            return b;
        }

        private double P5X(PointF p1, PointF p2, double D)
        {
            double c = p2.Y - Math.Sqrt(Math.Pow(D, 2) - Math.Pow((p2.Y - p1.Y), 2));
            return c;
        }

        public void DrawArc(ICanvas canvas, Pen pen, Utils.UnitPoint center, float radius, float startAngle, float sweepAngle)
        {
            PointF p1 = ToScreen(center);
            radius = (float)Math.Round(ToScreen(radius));
            RectangleF r = new RectangleF(p1, new SizeF());
            r.Inflate(radius, radius);
            if (radius > 0 && radius < 1e8f)
                canvas.Graphics.DrawArc(pen, r, -startAngle, -sweepAngle);
        }

        #endregion

        Dictionary<float, Dictionary<Color, Pen>> m_penCache = new Dictionary<float, Dictionary<Color, Pen>>();
        Pen GetPen(Color color, float width)
        {
            if (m_penCache.ContainsKey(width) == false)
                m_penCache[width] = new Dictionary<Color, Pen>();
            if (m_penCache[width].ContainsKey(color) == false)
                m_penCache[width][color] = new Pen(color, width);
            return m_penCache[width][color];
        }
        void ClearPens()
        {
            m_penCache.Clear();
        }

        void UpdateCursor()
        {
            Cursor = m_cursors.GetCursor(m_commandType);
        }

        Dictionary<Keys, Type> m_QuickSnap = new Dictionary<Keys, Type>();
        public void AddQuickSnapType(Keys key, Type snaptype)
        {
            m_QuickSnap.Add(key, snaptype);
        }

        public void CommandSelectDrawTool(string drawobjectid)
        {
            CommandEscape();
            m_model.ClearSelectedObjects();
            m_commandType = eCommandType.draw;
            m_drawObjectId = drawobjectid;
            UpdateCursor();
        }
        public void CommandEscape()
        {
            bool dirty = (m_newObject != null) || (m_snappoint != null);
            m_newObject = null;
            m_snappoint = null;
            if (m_editTool != null)
                m_editTool.Finished();
            m_editTool = null;
            m_commandType = eCommandType.select;
            m_moveHelper.HandleCancelMove();
            m_nodeMoveHelper.HandleCancelMove();
            DoInvalidate(dirty);
            UpdateCursor();
        }
        public void CommandPan()
        {
            if (m_commandType == eCommandType.select || m_commandType == eCommandType.move)
                m_commandType = eCommandType.pan;
            UpdateCursor();
        }
        public void CommandMove(bool handleImmediately)
        {
            if (m_model.SelectedCount > 0)
            {
                if (handleImmediately && m_commandType == eCommandType.move)
                    m_moveHelper.HandleMouseDownForMove(GetMousePoint(), m_snappoint);
                m_commandType = eCommandType.move;
                UpdateCursor();
            }
        }
        public void CommandDeleteSelected()
        {
            m_model.DeleteObjects(m_model.SelectedObjects);
            m_model.ClearSelectedObjects();
            DoInvalidate(true);
            UpdateCursor();
        }
        public void CommandEdit(string editid)
        {
            CommandEscape();
            m_model.ClearSelectedObjects();
            m_commandType = eCommandType.edit;
            m_editToolId = editid;
            m_editTool = m_model.GetEditTool(m_editToolId);
            UpdateCursor();
        }
        void HandleQuickSnap(KeyEventArgs e)
        {
            if (m_commandType == eCommandType.select || m_commandType == eCommandType.pan)
                return;
            ISnapPoint p = null;
            Utils.UnitPoint mousepoint = GetMousePoint();
            if (m_QuickSnap.ContainsKey(e.KeyCode))
                p = m_model.SnapPoint(m_canvaswrapper, mousepoint, null, m_QuickSnap[e.KeyCode]);
            if (p != null)
            {
                if (m_commandType == eCommandType.draw)
                {
                    HandleMouseDownWhenDrawing(p.SnapPoint, p);
                    if (m_newObject != null)
                        m_newObject.OnMouseMove(m_canvaswrapper, GetMousePoint());
                    DoInvalidate(true);
                    e.Handled = true;
                }
                if (m_commandType == eCommandType.move)
                {
                    m_moveHelper.HandleMouseDownForMove(p.SnapPoint, p);
                    e.Handled = true;
                }
                if (m_nodeMoveHelper.IsEmpty == false)
                {
                    bool handled = false;
                    m_nodeMoveHelper.HandleMouseDown(p.SnapPoint, ref handled);
                    FinishNodeEdit();
                    e.Handled = true;
                }
                if (m_commandType == eCommandType.edit)
                {
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            HandleQuickSnap(e);

            if (m_nodeMoveHelper.IsEmpty == false)
            {
                m_nodeMoveHelper.OnKeyDown(m_canvaswrapper, e);
                if (e.Handled)
                    return;
            }
            base.OnKeyDown(e);
            if (e.Handled)
            {
                UpdateCursor();
                return;
            }
            if (m_editTool != null)
            {
                m_editTool.OnKeyDown(m_canvaswrapper, e);
                if (e.Handled)
                    return;
            }
            if (m_newObject != null)
            {
                m_newObject.OnKeyDown(m_canvaswrapper, e);
                if (e.Handled)
                    return;
            }
            foreach (IDrawObject obj in m_model.SelectedObjects)
            {
                obj.OnKeyDown(m_canvaswrapper, e);
                if (e.Handled)
                    return;
            }

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.KeyCode == Keys.G)
                {
                    m_model.GridLayer.Enabled = !m_model.GridLayer.Enabled;
                    DoInvalidate(true);
                }
                if (e.KeyCode == Keys.S)
                {
                    RunningSnapsEnabled = !RunningSnapsEnabled;
                    if (!RunningSnapsEnabled)
                        m_snappoint = null;
                    DoInvalidate(false);
                }
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                CommandEscape();
            }
            if (e.KeyCode == Keys.P)
            {
                CommandPan();
            }
            if (e.KeyCode == Keys.S)
            {
                RunningSnapsEnabled = !RunningSnapsEnabled;
                if (!RunningSnapsEnabled)
                    m_snappoint = null;
                DoInvalidate(false);
            }
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                int layerindex = (int)e.KeyCode - (int)Keys.D1;
                if (layerindex >= 0 && layerindex < m_model.Layers.Length)
                {
                    m_model.ActiveLayer = m_model.Layers[layerindex];
                    DoInvalidate(true);
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                CommandDeleteSelected();
            }
            if (e.KeyCode == Keys.O)
            {
                CommandEdit("linesmeet");
            }
            UpdateCursor();
        }
    }
}
