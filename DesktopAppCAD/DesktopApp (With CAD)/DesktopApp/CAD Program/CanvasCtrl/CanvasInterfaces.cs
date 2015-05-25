using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopApp
{
    public interface ICanvasOwner
    {
        void SetPositionInfo(CAD_Program.Utils.UnitPoint unitpos);
        void SetSnapInfo(ISnapPoint snap);
    }

    public interface ICanvas
    {
        IModel DataModel { get; }
        CAD_Program.Utils.UnitPoint ScreenTopLeftToUnitPoint();
        CAD_Program.Utils.UnitPoint ScreenBottomRightToUnitPoint();
        PointF ToScreen(CAD_Program.Utils.UnitPoint unitpoint);
        float ToScreen(double unitvalue);
        double ToUnit(float screenvalue);
        CAD_Program.Utils.UnitPoint ToUnit(PointF screenpoint);

        void Invalidate();
        IDrawObject CurrentObject { get; }

        Rectangle ClientRectangle { get; }
        Graphics Graphics { get; }
        Pen CreatePen(Color color, float unitWidth);
        void DrawLine(ICanvas canvas, Pen pen, CAD_Program.Utils.UnitPoint p1, CAD_Program.Utils.UnitPoint p2);
        void DrawFuse(ICanvas canvas, Pen pen, CAD_Program.Utils.UnitPoint TopRectP1, CAD_Program.Utils.UnitPoint TopRectP2);
        void DrawArc(ICanvas canvas, Pen pen, CAD_Program.Utils.UnitPoint center, float radius, float beginangle, float angle);
    }
    public interface IModel
    {
        float Zoom { get; set; }
        ICanvasLayer BackgroundLayer { get; }
        ICanvasLayer GridLayer { get; }
        ICanvasLayer[] Layers { get; }
        ICanvasLayer ActiveLayer { get; set; }
        ICanvasLayer GetLayer(string id);
        IDrawObject CreateObject(string type, CAD_Program.Utils.UnitPoint point, ISnapPoint snappoint);
        void AddObject(ICanvasLayer layer, IDrawObject drawobject);
        void DeleteObjects(IEnumerable<IDrawObject> objects);
        void MoveObjects(CAD_Program.Utils.UnitPoint offset, IEnumerable<IDrawObject> objects);
        void CopyObjects(CAD_Program.Utils.UnitPoint offset, IEnumerable<IDrawObject> objects);
        void MoveNodes(CAD_Program.Utils.UnitPoint position, IEnumerable<INodePoint> nodes);

        IEditTool GetEditTool(string id);
        void AfterEditObjects(IEditTool edittool);

        List<IDrawObject> GetHitObjects(ICanvas canvas, RectangleF selection, bool anyPoint);
        List<IDrawObject> GetHitObjects(ICanvas canvas, CAD_Program.Utils.UnitPoint point);
        bool IsSelected(IDrawObject drawobject);
        void AddSelectedObject(IDrawObject drawobject);
        void RemoveSelectedObject(IDrawObject drawobject);
        IEnumerable<IDrawObject> SelectedObjects { get; }
        int SelectedCount { get; }
        void ClearSelectedObjects();

        ISnapPoint SnapPoint(ICanvas canvas, CAD_Program.Utils.UnitPoint point, Type[] runningsnaptypes, Type usersnaptype);

        bool CanUndo();
        bool DoUndo();
        bool CanRedo();
        bool DoRedo();
    }
    public interface ICanvasLayer
    {
        string Id { get; }
        void Draw(ICanvas canvas, RectangleF unitrect);
        ISnapPoint SnapPoint(ICanvas canvas, CAD_Program.Utils.UnitPoint point, List<IDrawObject> otherobj);
        IEnumerable<IDrawObject> Objects { get; }
        bool Enabled { get; set; }
        bool Visible { get; }
    }
    public interface ISnapPoint
    {
        IDrawObject Owner { get; }
        CAD_Program.Utils.UnitPoint SnapPoint { get; }
        RectangleF BoundingRect { get; }
        void Draw(ICanvas canvas);
    }
    public enum eDrawObjectMouseDown
    {
        Done,		// this draw object is complete
        DoneRepeat,	// this object is complete, but create new object of same type
        Continue,	// this object requires additional mouse inputs
    }
    public interface INodePoint
    {
        IDrawObject GetClone();
        IDrawObject GetOriginal();
        void Cancel();
        void Finish();
        void SetPosition(CAD_Program.Utils.UnitPoint pos);
        void Undo();
        void Redo();
        void OnKeyDown(ICanvas canvas, KeyEventArgs e);
    }
    public interface IDrawObject
    {
        string Id { get; }
        IDrawObject Clone();
        bool PointInObject(ICanvas canvas, CAD_Program.Utils.UnitPoint point);
        bool ObjectInRectangle(ICanvas canvas, RectangleF rect, bool anyPoint);
        void Draw(ICanvas canvas, RectangleF unitrect);
        RectangleF GetBoundingRect(ICanvas canvas);
        void OnMouseMove(ICanvas canvas, CAD_Program.Utils.UnitPoint point);
        eDrawObjectMouseDown OnMouseDown(ICanvas canvas, CAD_Program.Utils.UnitPoint point, ISnapPoint snappoint);
        void OnMouseUp(ICanvas canvas, CAD_Program.Utils.UnitPoint point, ISnapPoint snappoint);
        void OnKeyDown(ICanvas canvas, KeyEventArgs e);
        CAD_Program.Utils.UnitPoint RepeatStartingPoint { get; }
        INodePoint NodePoint(ICanvas canvas, CAD_Program.Utils.UnitPoint point);
        ISnapPoint SnapPoint(ICanvas canvas, CAD_Program.Utils.UnitPoint point, List<IDrawObject> otherobj, Type[] runningsnaptypes, Type usersnaptype);
        void Move(CAD_Program.Utils.UnitPoint offset);

        string GetInfoAsString();
    }
    public interface IEditTool
    {
        IEditTool Clone();

        bool SupportSelection { get; }
        void SetHitObjects(CAD_Program.Utils.UnitPoint mousepoint, List<IDrawObject> list);

        void OnMouseMove(ICanvas canvas, CAD_Program.Utils.UnitPoint point);
        eDrawObjectMouseDown OnMouseDown(ICanvas canvas, CAD_Program.Utils.UnitPoint point, ISnapPoint snappoint);
        void OnMouseUp(ICanvas canvas, CAD_Program.Utils.UnitPoint point, ISnapPoint snappoint);
        void OnKeyDown(ICanvas canvas, KeyEventArgs e);
        void Finished();
        void Undo();
        void Redo();
    }
    public interface IEditToolOwner
    {
        void SetHint(string text);
    }
}
