using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DesktopApp.CAD_Program.Resources
{
    class ImagesUtil
    {
        
        public static ImageList GetToolbarImageList(Type type, string resourceName, Size imageSize, Color transparentColor)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(resourceName);
            ImageList imageList = new ImageList();
            imageList.ImageSize = imageSize;
            imageList.TransparentColor = transparentColor;
            imageList.Images.AddStrip(bitmap);
            imageList.ColorDepth = ColorDepth.Depth24Bit;
            return imageList;
        }
    }

    public class MenuImages16x16
    {
        static private ImageList m_imageList = null;

        public enum eIndexes
        {
            Undo = 0,
            Redo,
            NewDocument,
            OpenDocument,
            SaveDocument,
        }
        static public ImageList ImageList()
        {
            Type t = typeof(MenuImages16x16);
            if (m_imageList == null)
                m_imageList = ImagesUtil.GetToolbarImageList(t, "CAD Program/Resources/menuimages.bmp", new Size(16, 16), Color.White);
            return m_imageList;
        }
        static public Image Image(eIndexes index)
        {
            return ImageList().Images[(int)index];
        }
    }
    public class DrawToolsImages16x16
    {
        static private ImageList m_imageList = null;

        public enum eIndexes
        {
            Select,
            Pan,
            Move,
            Line,
            CircleCR,
            Circle2P,
            ArcCR,
            Arc2P,
            Arc3P132,
            Arc3P123,
        }
        static public ImageList ImageList()
        {
            Type t = typeof(MenuImages16x16);
            if (m_imageList == null)
                m_imageList = ImagesUtil.GetToolbarImageList(t, "CAD Program/Resources/drawtoolimages.bmp", new Size(16, 16), Color.White);
            return m_imageList;
        }
        static public Image Image(eIndexes index)
        {
            return ImageList().Images[(int)index];
        }
    }

    public class DrawToolsImagesExtra16x16
    {
        static private ImageList m_imageList = null;

        public enum eIndexes
        {
            Fuse,
            Capacitor,
            Resistor,
        }
        static public ImageList ImageList()
        {
            Type t = typeof(MenuImages16x16);
            if (m_imageList == null)
                m_imageList = ImagesUtil.GetToolbarImageList(t, "CAD Program/Resources/DrawExtraTools.bmp", new Size(16, 16), Color.White);
            return m_imageList;
        }
        static public Image Image(eIndexes index)
        {
            return ImageList().Images[(int)index];
        }

    }
    public class EditToolsImages16x16
    {
        static private ImageList m_imageList = null;

        public enum eIndexes
        {
            Meet2Lines,
            LineSrhinkExtend,
        }
        static public ImageList ImageList()
        {
            Type t = typeof(MenuImages16x16);
            if (m_imageList == null)
                m_imageList = ImagesUtil.GetToolbarImageList(t, "CAD Program/Resources/edittoolimages.bmp", new Size(16, 16), Color.White);
            return m_imageList;
        }
        static public Image Image(eIndexes index)
        {
            return ImageList().Images[(int)index];
        }
    }
}
