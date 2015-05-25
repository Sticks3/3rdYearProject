using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DesktopApp.CAD_Program.Options
{
	public partial class OptionsDlg : CommonTools.PropertyDialog
	{
		Options.OptionsConfig m_config = new Options.OptionsConfig();
		public OptionsConfig Config
		{
			get { return m_config; }
		}

		public OptionsDlg()
		{
			InitializeComponent();
			BeforeLoadPages();
			AddPage("Grid", new GridPage(), m_config);
			AddPage("Layers", new LayersPage(), m_config);
			AfterLoadPages();
		}
	}
}