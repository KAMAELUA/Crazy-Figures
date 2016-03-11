using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.ComponentModel;

namespace Work_Project_1_Figures
{
    static class Localization
    {
        
        public static String GetLocalizedString(String key)
        {
            ResourceManager LocRM = new ResourceManager("Work_Project_1_Figures.Languages.MainForm", typeof(MainForm).Assembly);
            String str = "error";
            try
            {
                str = LocRM.GetString(key);
            }
            catch(Exception) { }
            return str;
        }
        public static void ChangeLocale(String locale)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);

        }
        public static Dictionary<String, String> GetSupportedLanguages()
        {
            Dictionary<String, String> listOfLangs = new Dictionary<string, string>(); 
           
            ResourceManager LocRM = new ResourceManager("Work_Project_1_Figures.Languages.MainForm", typeof(MainForm).Assembly);

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                try
                {
                    ResourceSet rs = LocRM.GetResourceSet(culture, true, false);
                    if (rs != null)
                    {
                        listOfLangs.Add(culture.ToString(), culture.DisplayName);
                    }
                    
                }
                catch (CultureNotFoundException){}
            }

            return listOfLangs;
        }

        public static void ApplyLicalizationForControl(Form f)
        {
            ComponentResourceManager resources = new ComponentResourceManager(f.GetType());

            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            ApplyResourceToControl(resources, f, culture);
            resources.ApplyResources(f, "$this");
        }

        private static void ApplyResourceToControl(ComponentResourceManager res, Control control, CultureInfo lang)
        {
            if (control.GetType() == typeof(MenuStrip))  // See if this is a menuStrip
            {
                MenuStrip strip = (MenuStrip)control;

                ApplyResourceToToolStripItemCollection(strip.Items, res, lang);
            }

            foreach (Control c in control.Controls) // Apply to all sub-controls
            {
                ApplyResourceToControl(res, c, lang);
                res.ApplyResources(c, c.Name, lang);
            }

            // Apply to self
            res.ApplyResources(control, control.Name, lang);
        }
        private static void ApplyResourceToToolStripItemCollection(ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang)
        {
            for (int i = 0; i < col.Count; i++)     // Apply to all sub items
            {
                ToolStripItem item = (ToolStripMenuItem)col[i];

                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                    ApplyResourceToToolStripItemCollection(menuitem.DropDownItems, res, lang);
                }

                res.ApplyResources(item, item.Name, lang);
            }
        }
    }
}
