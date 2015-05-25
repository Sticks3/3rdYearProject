using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

namespace DesktopApp.CAD_Program.DrawTools
{
    class DrawFuseTool : INodePoint
    {
        public enum ePointFuse
        {
            Poi1,
            Poi2,
            TopRectP1,
            TopRectP2,
            BotRectP1,
            BotRectP2,
        }
        static bool m_angleLocked = false;
        LineFuse m_owner;
        LineFuse m_clone;
        Utils.UnitPoint m_originalPoint;
        Utils.UnitPoint m_endPoint;
        Utils.UnitPoint m_topRectOriPoint;
        Utils.UnitPoint m_topRectEndPoint;
        Utils.UnitPoint m_botRectOriPoint;
        Utils.UnitPoint m_botRectEndPoint;
        ePointFuse m_pointId;

        public DrawFuseTool(LineFuse owner, ePointFuse id)
        {
            m_owner = owner;
            m_clone = m_owner.Clone() as LineFuse;
            m_pointId = id;
            m_originalPoint = GetPoint(m_pointId);
            m_topRectOriPoint = GetPoint(m_pointId);
            m_botRectOriPoint = GetPoint(m_pointId);
        }

        #region INodePointFuse Members
        public IDrawObject GetClone()
        {
            return m_clone;
        }
        public IDrawObject GetOriginal()
        {
            return m_owner;
        }
        public void SetPosition(Utils.UnitPoint pos)
        {
            if (Control.ModifierKeys == Keys.Control)
                pos = Utils.HitUtil.OrthoPointD(OtherPoint(m_pointId), pos, 45);
            if (m_angleLocked || Control.ModifierKeys == (Keys)(Keys.Control | Keys.Shift))
                //pos = Utils.HitUtil.NearestPointOnLine(m_owner.Poi1, m_owner.Poi2, pos, true);
            pos = Utils.HitUtil.NearestPointOnLine(m_owner.TopRectP1, m_owner.TopRectP2, pos, true);
            SetPoint(m_pointId, pos, m_clone);
        }
        public void Finish()
        {
            m_endPoint = GetPoint(m_pointId);
            m_topRectEndPoint = GetPoint(m_pointId);
            m_botRectEndPoint = GetPoint(m_pointId);
            m_owner.Poi1 = m_clone.Poi1;
            m_owner.Poi2 = m_clone.Poi2;
            m_owner.TopRectP1 = m_clone.TopRectP1;
            m_owner.TopRectP2 = m_clone.TopRectP2;
            m_owner.BotRectP1 = m_clone.BotRectP1;
            m_owner.BotRectP2 = m_clone.BotRectP2;
        }
        public void Cancel()
        {
        }
        public void Undo()
        {
            SetPoint(m_pointId, m_originalPoint, m_owner);
            SetPoint(m_pointId, m_topRectOriPoint, m_owner);
            SetPoint(m_pointId, m_botRectOriPoint, m_owner);
        }
        public void Redo()
        {
            SetPoint(m_pointId, m_endPoint, m_owner);
            SetPoint(m_pointId, m_topRectEndPoint, m_owner);
            SetPoint(m_pointId, m_botRectEndPoint, m_owner);
        }
        public void OnKeyDown(ICanvas canvas, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L)
            {
                m_angleLocked = !m_angleLocked;
                e.Handled = true;
            }
        }
        #endregion
        protected Utils.UnitPoint GetPoint(ePointFuse pointid)
        {
            if (pointid == ePointFuse.Poi1)
                return m_clone.Poi1;
            if (pointid == ePointFuse.Poi2)
                return m_clone.Poi2;
            if (pointid == ePointFuse.TopRectP1)
                return m_clone.TopRectP1;
            if (pointid == ePointFuse.TopRectP2)
                return m_clone.TopRectP2;
            if (pointid == ePointFuse.BotRectP1)
                return m_clone.BotRectP1;
            if (pointid == ePointFuse.BotRectP2)
                return m_clone.BotRectP2;
            return m_owner.Poi1;
        }
        protected Utils.UnitPoint OtherPoint(ePointFuse currentpointid)
        {
            //if (currentpointid == ePointFuse.Poi1)
                //return GetPoint(ePointFuse.Poi2);
            if (currentpointid == ePointFuse.TopRectP1)
                return GetPoint(ePointFuse.TopRectP2);
            if (currentpointid == ePointFuse.BotRectP1)
                return GetPoint(ePointFuse.BotRectP2);
            return GetPoint(ePointFuse.Poi1);
        }
        protected void SetPoint(ePointFuse pointid, Utils.UnitPoint point, LineFuse line)
        {
            if (pointid == ePointFuse.Poi1)
                line.Poi1 = point;
            if (pointid == ePointFuse.Poi2)
                line.Poi2 = point;
            if (pointid == ePointFuse.TopRectP1)
                line.TopRectP1 = point;
            if (pointid == ePointFuse.TopRectP2)
                line.TopRectP2 = point;
            if (pointid == ePointFuse.BotRectP1)
                line.BotRectP1 = point;
            if (pointid == ePointFuse.BotRectP2)
                line.BotRectP2 = point;
        }
    }
    class LineFuse : DrawObjectBase, IDrawObject, Utils.ISerialize
    {
        protected Utils.UnitPoint m_poi1, m_poi2, m_TopRectP1, m_TopRectP2, m_BotRectP1, m_BotRectP2;

        [Utils.XmlSerializable]
        public Utils.UnitPoint Poi1
        {
            get { return m_poi1; }
            set { m_poi1 = value; }
        }
        [Utils.XmlSerializable]
        public Utils.UnitPoint Poi2
        {
            get { return m_poi2; }
            set { m_poi2 = value; }
        }
        [Utils.XmlSerializable]
        public Utils.UnitPoint TopRectP1
        {
            get { return m_TopRectP1; }
            set { m_TopRectP1 = value; }
        }
        [Utils.XmlSerializable]
        public Utils.UnitPoint TopRectP2
        {
            get { return m_TopRectP2; }
            set { m_TopRectP2 = value; }
        }
        [Utils.XmlSerializable]
        public Utils.UnitPoint BotRectP1
        {
            get { return m_BotRectP1; }
            set { m_BotRectP1 = value; }
        }
        [Utils.XmlSerializable]
        public Utils.UnitPoint BotRectP2
        {
            get { return m_BotRectP2; }
            set { m_BotRectP2 = value; }
        }

        public static string ObjectType
        {
            get { return "fuse"; }
        }
        public LineFuse()
        {
        }
        public LineFuse(Utils.UnitPoint point, Utils.UnitPoint endpoint, float width, Color color)
        {
            Poi1 = point;
            Poi2 = endpoint;
            Width = width;
            Color = color;
            Selected = false;
        }

        public LineFuse(Utils.UnitPoint point, Utils.UnitPoint endpoint, Utils.UnitPoint ToprectP1, Utils.UnitPoint ToprectP2, float width, Color color)
        {
            Poi1 = point;
            Poi2 = endpoint;
            TopRectP1 = ToprectP1;
            TopRectP2 = ToprectP2;
            Width = width;
            Color = color;
            Selected = false;
        }
        /*public override void InitializeFromModel(Utils.UnitPoint point, Utils.UnitPoint point1, Utils.UnitPoint point2, DrawingLayer layer, ISnapPoint snap)
        {

            Poi1 = Poi2 = point;
            TopRectP1 = TopRectP2 = point1;
            BotRectP1 = BotRectP2 = point2;
            Width = layer.Width;
            Color = layer.Color;
            Selected = true;
        }*/

        public override void InitializeFromModel(Utils.UnitPoint point, Layers.DrawingLayer layer, ISnapPoint snap)
        {
            //Poi1 = Poi2 = point;
            TopRectP1 = TopRectP2 = point;
            Width = layer.Width;
            Color = layer.Color;
            Selected = true;
        }

        static int ThresholdPixel = 6;
        static float ThresholdWidth(ICanvas canvas, float objectwidth)
        {
            return ThresholdWidth(canvas, objectwidth, ThresholdPixel);
        }
        public static float ThresholdWidth(ICanvas canvas, float objectwidth, float pixelwidth)
        {
            double minWidth = canvas.ToUnit(pixelwidth);
            double width = Math.Max(objectwidth / 2, minWidth);
            return (float)width;
        }
        public virtual void Copy(LineFuse acopy)
        {
            base.Copy(acopy);
            m_poi1 = acopy.m_poi1;
            m_poi2 = acopy.m_poi2;
            m_TopRectP1 = acopy.m_TopRectP1;
            m_TopRectP2 = acopy.m_TopRectP2;
            m_BotRectP1 = acopy.m_BotRectP1;
            m_BotRectP2 = acopy.m_BotRectP2;
            Selected = acopy.Selected;
        }
        #region IDrawObject Members
        public virtual string Id
        {
            get { return ObjectType; }
        }
        public virtual IDrawObject Clone()
        {
            LineFuse l = new LineFuse();
            l.Copy(this);
            return l;
        }
        public RectangleF GetBoundingRect(ICanvas canvas)
        {
            float thWidth = ThresholdWidth(canvas, Width);
            //return Utils.ScreenUtils.GetRect(m_poi1, m_poi2, thWidth);
            return Utils.ScreenUtils.GetRect(m_TopRectP1, m_TopRectP2, thWidth);
        }

        Utils.UnitPoint MidPoint(ICanvas canvas, Utils.UnitPoint p1, Utils.UnitPoint p2, Utils.UnitPoint hitpoint)
        {
            Utils.UnitPoint mid = Utils.HitUtil.LineMidpoint(p1, p2);
            float thWidth = ThresholdWidth(canvas, Width);
            if (Utils.HitUtil.CircleHitPoint(mid, thWidth, hitpoint))
                return mid;
            return Utils.UnitPoint.Empty;
        }
        public bool PointInObject(ICanvas canvas, Utils.UnitPoint point)
        {
            float thWidth = ThresholdWidth(canvas, Width);
            //return Utils.HitUtil.IsPointInLine(m_poi1, m_poi2, point, thWidth);
            return Utils.HitUtil.IsPointInLine(m_TopRectP1, m_TopRectP2, point, thWidth);
        }
        public bool ObjectInRectangle(ICanvas canvas, RectangleF rect, bool anyPoint)
        {
            RectangleF boundingrect = GetBoundingRect(canvas);
            if (anyPoint)
                //return Utils.HitUtil.LineIntersectWithRect(m_poi1, m_poi2, rect);
            return Utils.HitUtil.LineIntersectWithRect(m_TopRectP1, m_TopRectP2, rect);
            return rect.Contains(boundingrect);
        }
        public virtual void Draw(ICanvas canvas, RectangleF unitrect)
        {
            Color color = Color;
            Pen pen = canvas.CreatePen(color, Width);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            canvas.DrawLine(canvas, pen, m_poi1, m_poi2);
            canvas.DrawFuse(canvas, pen, m_TopRectP1, m_TopRectP2);
            if (Highlighted)
                //canvas.DrawLine(canvas, pen, m_poi1, m_poi2);
                canvas.DrawFuse(canvas, pen, m_TopRectP1, m_TopRectP2);
            if (Selected)
            {
                //canvas.DrawLine(canvas, pen, m_poi1, m_poi2);
                canvas.DrawFuse(canvas, pen, m_TopRectP1, m_TopRectP2);
                if (m_TopRectP1.IsEmpty == false)
                    DrawUtils.DrawNode(canvas, m_TopRectP1);
                if (m_TopRectP2.IsEmpty == false)
                    DrawUtils.DrawNode(canvas, m_TopRectP2);
                if (m_BotRectP1.IsEmpty == false)
                    DrawUtils.DrawNode(canvas, m_BotRectP1);
                if (m_BotRectP2.IsEmpty == false)
                    DrawUtils.DrawNode(canvas, m_BotRectP2);
            }
        }
        public virtual void OnMouseMove(ICanvas canvas, Utils.UnitPoint point)
        {
            if (Control.ModifierKeys == Keys.Control)
                //point = Utils.HitUtil.OrthoPointD(m_poi1, point, 45);
            point = Utils.HitUtil.OrthoPointD(m_TopRectP1, point, 45);
            //m_poi2 = point;
            m_TopRectP2 = point;
        }
        public virtual eDrawObjectMouseDown OnMouseDown(ICanvas canvas, Utils.UnitPoint point, ISnapPoint snappoint)
        {
            Selected = false;
            if (snappoint is PerpendicularSnapPoint && snappoint.Owner is LineFuse)
            {
                LineFuse src = snappoint.Owner as LineFuse;
                //m_poi2 = Utils.HitUtil.NearestPointOnLine(src.Poi1, src.Poi2, m_poi1, true);
                m_TopRectP2 = Utils.HitUtil.NearestPointOnLine(src.TopRectP1, src.TopRectP2, m_TopRectP1, true);
                return eDrawObjectMouseDown.DoneRepeat;
            }
            if (snappoint is PerpendicularSnapPoint && snappoint.Owner is Arc)
            {
                Arc src = snappoint.Owner as Arc;
                //m_poi2 = Utils.HitUtil.NearestPointOnCircle(src.Center, src.Radius, m_poi1, 0);
                m_TopRectP2 = Utils.HitUtil.NearestPointOnCircle(src.Center, src.Radius, m_TopRectP1, 0);
                return eDrawObjectMouseDown.DoneRepeat;
            }
            if (Control.ModifierKeys == Keys.Control)
                //point = Utils.HitUtil.OrthoPointD(m_poi1, point, 45);
            point = Utils.HitUtil.OrthoPointD(m_TopRectP1, point, 45);
            //m_poi2 = point;
            m_TopRectP2 = point;
            return eDrawObjectMouseDown.DoneRepeat;
        }
        public void OnMouseUp(ICanvas canvas, Utils.UnitPoint point, ISnapPoint snappoint)
        {
        }
        public virtual void OnKeyDown(ICanvas canvas, KeyEventArgs e)
        {
        }
        /*public Utils.UnitPoint RepeatStartingPoint
        {
            get { return m_poi2; }
        }*/

        public Utils.UnitPoint RepeatStartingPoint
        {
            get { return m_TopRectP2; }
        }
        public INodePoint NodePoint(ICanvas canvas, Utils.UnitPoint point)
        {
            float thWidth = ThresholdWidth(canvas, Width);
            if (Utils.HitUtil.CircleHitPoint(m_poi1, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.Poi1);
            if (Utils.HitUtil.CircleHitPoint(m_poi2, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.Poi2);
            if (Utils.HitUtil.CircleHitPoint(m_TopRectP1, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.TopRectP1);
            if (Utils.HitUtil.CircleHitPoint(m_TopRectP2, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.TopRectP2);
            if (Utils.HitUtil.CircleHitPoint(m_BotRectP1, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.BotRectP1);
            if (Utils.HitUtil.CircleHitPoint(m_BotRectP2, thWidth, point))
                return new DrawFuseTool(this, DrawFuseTool.ePointFuse.BotRectP2);
            return null;
        }
        public ISnapPoint SnapPoint(ICanvas canvas, Utils.UnitPoint point, List<IDrawObject> otherobjs, Type[] runningsnaptypes, Type usersnaptype)
        {
            float thWidth = ThresholdWidth(canvas, Width);
            if (runningsnaptypes != null)
            {
                foreach (Type snaptype in runningsnaptypes)
                {
                    if (snaptype == typeof(VertextSnapPoint))
                    {
                        if (Utils.HitUtil.CircleHitPoint(m_poi1, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_poi1);
                        if (Utils.HitUtil.CircleHitPoint(m_poi2, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_poi2);
                        if (Utils.HitUtil.CircleHitPoint(m_TopRectP1, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_TopRectP1);
                        if (Utils.HitUtil.CircleHitPoint(m_TopRectP2, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_TopRectP2);
                        if (Utils.HitUtil.CircleHitPoint(m_BotRectP1, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_BotRectP1);
                        if (Utils.HitUtil.CircleHitPoint(m_BotRectP2, thWidth, point))
                            return new VertextSnapPoint(canvas, this, m_BotRectP2);
                    }
                    if (snaptype == typeof(MidpointSnapPoint))
                    {
                        //Utils.UnitPoint p = MidPoint(canvas, m_poi1, m_poi2, point);
                        Utils.UnitPoint p = MidPoint(canvas, m_TopRectP1, m_TopRectP2, point);
                        if (p != Utils.UnitPoint.Empty)
                            return new MidpointSnapPoint(canvas, this, p);
                    }
                    if (snaptype == typeof(IntersectSnapPoint))
                    {
                        LineFuse otherline = Utils.Utils.FindObjectTypeInList(this, otherobjs, typeof(LineFuse)) as LineFuse;
                        if (otherline == null)
                            continue;
                        //Utils.UnitPoint p = Utils.HitUtil.LinesIntersectPoint(m_poi1, m_poi2, otherline.m_poi1, otherline.m_poi2);
                        Utils.UnitPoint p = Utils.HitUtil.LinesIntersectPoint(m_TopRectP1, m_TopRectP2, otherline.m_TopRectP1, otherline.m_TopRectP2);
                        if (p != Utils.UnitPoint.Empty)
                            return new IntersectSnapPoint(canvas, this, p);
                    }
                }
                return null;
            }

            if (usersnaptype == typeof(MidpointSnapPoint))
                //return new MidpointSnapPoint(canvas, this, Utils.HitUtil.LineMidpoint(m_poi1, m_poi2));
            return new MidpointSnapPoint(canvas, this, Utils.HitUtil.LineMidpoint(m_TopRectP1, m_TopRectP2));
            if (usersnaptype == typeof(IntersectSnapPoint))
            {
                LineFuse otherline = Utils.Utils.FindObjectTypeInList(this, otherobjs, typeof(LineFuse)) as LineFuse;
                if (otherline == null)
                    return null;
                //Utils.UnitPoint p = Utils.HitUtil.LinesIntersectPoint(m_poi1, m_poi2, otherline.m_poi1, otherline.m_poi2);
                Utils.UnitPoint p = Utils.HitUtil.LinesIntersectPoint(m_TopRectP1, m_TopRectP2, otherline.m_TopRectP1, otherline.m_TopRectP2);
                if (p != Utils.UnitPoint.Empty)
                    return new IntersectSnapPoint(canvas, this, p);
            }
            if (usersnaptype == typeof(VertextSnapPoint))
            {
                //double d1 = Utils.HitUtil.Distance(point, m_poi1);
                //double d2 = Utils.HitUtil.Distance(point, m_poi2);
                double d1 = Utils.HitUtil.Distance(point, m_TopRectP1);
                double d2 = Utils.HitUtil.Distance(point, m_TopRectP2);
                if (d1 <= d2)
                    //return new VertextSnapPoint(canvas, this, m_poi1);
                //return new VertextSnapPoint(canvas, this, m_poi2);
                return new VertextSnapPoint(canvas, this, m_TopRectP1);
                return new VertextSnapPoint(canvas, this, m_TopRectP2);

            }
            if (usersnaptype == typeof(NearestSnapPoint))
            {
                //Utils.UnitPoint p = Utils.HitUtil.NearestPointOnLine(m_poi1, m_poi2, point);
                Utils.UnitPoint p = Utils.HitUtil.NearestPointOnLine(m_TopRectP1, m_TopRectP2, point);
                if (p != Utils.UnitPoint.Empty)
                    return new NearestSnapPoint(canvas, this, p);
            }
            if (usersnaptype == typeof(PerpendicularSnapPoint))
            {
                //Utils.UnitPoint p = Utils.HitUtil.NearestPointOnLine(m_poi1, m_poi2, point);
                Utils.UnitPoint p = Utils.HitUtil.NearestPointOnLine(m_TopRectP1, m_TopRectP2, point);
                if (p != Utils.UnitPoint.Empty)
                    return new PerpendicularSnapPoint(canvas, this, p);
            }
            return null;
        }
        public void Move(Utils.UnitPoint offset)
        {
            m_poi1.X += offset.X;
            m_poi1.Y += offset.Y;
            m_poi2.X += offset.X;
            m_poi2.Y += offset.Y;
            m_TopRectP1.X += offset.X;
            m_TopRectP1.Y += offset.Y;
            m_TopRectP2.X += offset.X;
            m_TopRectP2.Y += offset.Y;
            m_BotRectP1.X += offset.X;
            m_BotRectP1.Y += offset.Y;
            m_BotRectP2.X += offset.X;
            m_BotRectP2.Y += offset.Y;

        }
        public string GetInfoAsString()
        {
            return string.Format("Fuse@{0},{1} - L={2:f4}<{3:f4}",
                Poi1.PosAsString(),
                Poi2.PosAsString(),
                Utils.HitUtil.Distance(Poi1, Poi2),
                Utils.HitUtil.RadiansToDegrees(Utils.HitUtil.LineAngleR(Poi1, Poi2, 0)));
        }
        #endregion
        #region ISerialize
        public void GetObjectData(XmlWriter wr)
        {
            wr.WriteStartElement("Fuse");
            Utils.XmlUtil.WriteProperties(this, wr);
            wr.WriteEndElement();
        }
        public void AfterSerializedIn()
        {
        }
        #endregion

        public void ExtendLineToPoint(Utils.UnitPoint newpoint)
        {
            /*Utils.UnitPoint newlinepoint = Utils.HitUtil.NearestPointOnLine(Poi1, Poi2, newpoint, true);
            if (Utils.HitUtil.Distance(newlinepoint, Poi1) < Utils.HitUtil.Distance(newlinepoint, Poi2))
                Poi1 = newlinepoint;
            else
                Poi2 = newlinepoint;*/

            Utils.UnitPoint newlinepoint = Utils.HitUtil.NearestPointOnLine(TopRectP1, TopRectP2, newpoint, true);
            if (Utils.HitUtil.Distance(newlinepoint, TopRectP1) < Utils.HitUtil.Distance(newlinepoint, TopRectP2))
                TopRectP1 = newlinepoint;
            else
                TopRectP2 = newlinepoint;
        }
    }
    class LineEditFuse : LineFuse, IObjectEditInstance
    {
        protected PerpendicularSnapPoint m_perSnap;
        protected TangentSnapPoint m_tanSnap;
        protected bool m_tanReverse = false;
        protected bool m_singleLineSegment = true;

        public override string Id
        {
            get
            {
                if (m_singleLineSegment)
                    return "fuse";
                return "fuses";
            }
        }
        public LineEditFuse(bool singleLine)
            : base()
        {
            m_singleLineSegment = singleLine;
        }

        /*public override void InitializeFromModel(Utils.UnitPoint point, Utils.UnitPoint point1, Utils.UnitPoint point2, DrawingLayer layer, ISnapPoint snap)
        {
            base.InitializeFromModel(point, point1, point2, layer, snap);
            m_perSnap = snap as PerpendicularSnapPoint;
            m_tanSnap = snap as TangentSnapPoint;
        }*/

        public override void InitializeFromModel(Utils.UnitPoint point, Layers.DrawingLayer layer, ISnapPoint snap)
        {
            base.InitializeFromModel(point, layer, snap);
            m_perSnap = snap as PerpendicularSnapPoint;
            m_tanSnap = snap as TangentSnapPoint;
        }
        public override void OnMouseMove(ICanvas canvas, Utils.UnitPoint point)
        {
            if (m_perSnap != null)
            {
                MouseMovePerpendicular(canvas, point);
                return;
            }
            if (m_tanSnap != null)
            {
                MouseMoveTangent(canvas, point);
                return;
            }
            base.OnMouseMove(canvas, point);
        }
        public override eDrawObjectMouseDown OnMouseDown(ICanvas canvas, Utils.UnitPoint point, ISnapPoint snappoint)
        {
            if (m_tanSnap != null && Control.MouseButtons == MouseButtons.Right)
            {
                ReverseTangent(canvas);
                return eDrawObjectMouseDown.Continue;
            }

            if (m_perSnap != null || m_tanSnap != null)
            {
                if (snappoint != null)
                    point = snappoint.SnapPoint;
                OnMouseMove(canvas, point);
                if (m_singleLineSegment)
                    return eDrawObjectMouseDown.Done;
                return eDrawObjectMouseDown.DoneRepeat;
            }
            eDrawObjectMouseDown result = base.OnMouseDown(canvas, point, snappoint);
            if (m_singleLineSegment)
                return eDrawObjectMouseDown.Done;
            return eDrawObjectMouseDown.DoneRepeat;
        }
        public override void OnKeyDown(ICanvas canvas, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && m_tanSnap != null)
            {
                ReverseTangent(canvas);
                e.Handled = true;
            }
        }
        protected virtual void MouseMovePerpendicular(ICanvas canvas, Utils.UnitPoint point)
        {
            if (m_perSnap.Owner is LineFuse)
            {
                LineFuse src = m_perSnap.Owner as LineFuse;
                //m_poi1 = Utils.HitUtil.NearestPointOnLine(src.Poi1, src.Poi2, point, true);
                //m_poi2 = point;
                m_TopRectP1 = Utils.HitUtil.NearestPointOnLine(src.TopRectP1, src.TopRectP2, point, true);
                m_TopRectP2 = point;
            }
            if (m_perSnap.Owner is IArc)
            {
                IArc src = m_perSnap.Owner as IArc;
                //m_poi1 = Utils.HitUtil.NearestPointOnCircle(src.Center, src.Radius, point, 0);
                //m_poi2 = point;
                m_TopRectP1 = Utils.HitUtil.NearestPointOnCircle(src.Center, src.Radius, point, 0);
                m_TopRectP2 = point;
            }
        }
        protected virtual void MouseMoveTangent(ICanvas canvas, Utils.UnitPoint point)
        {
            if (m_tanSnap.Owner is IArc)
            {
                IArc src = m_tanSnap.Owner as IArc;
                /*m_poi1 = Utils.HitUtil.TangentPointOnCircle(src.Center, src.Radius, point, m_tanReverse);
                m_poi2 = point;
                if (m_poi1 == Utils.UnitPoint.Empty)
                    m_poi2 = m_poi1 = src.Center;
                */
                m_TopRectP1 = Utils.HitUtil.TangentPointOnCircle(src.Center, src.Radius, point, m_tanReverse);
                m_TopRectP2 = point;
                if (m_TopRectP1 == Utils.UnitPoint.Empty)
                    m_TopRectP2 = m_TopRectP1 = src.Center;
            }
        }
        protected virtual void ReverseTangent(ICanvas canvas)
        {
            m_tanReverse = !m_tanReverse;
            //MouseMoveTangent(canvas, m_poi2);
            MouseMoveTangent(canvas, m_TopRectP2);
            canvas.Invalidate();
        }

        public void Copy(LineEditFuse acopy)
        {
            base.Copy(acopy);
            m_perSnap = acopy.m_perSnap;
            m_tanSnap = acopy.m_tanSnap;
            m_tanReverse = acopy.m_tanReverse;
            m_singleLineSegment = acopy.m_singleLineSegment;
        }
        public override IDrawObject Clone()
        {
            LineEditFuse l = new LineEditFuse(false);
            l.Copy(this);
            return l;
        }

        #region IObjectEditInstance
        public IDrawObject GetDrawObject()
        {
            return new LineFuse(Poi1, Poi2, TopRectP1, TopRectP2, Width, Color);
        }
        #endregion
    }
}
