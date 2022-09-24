using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FCUI
{
    public partial class UCBase : UserControl
    {
        public UCBase()
        {
            InitializeComponent();
        }

        public string langcode { get; set; }

        public static Dictionary<string, string> LagDictinary;


        public List<Control> GetAllControls(IList ctrls)
        {
            List<Control> RetCtrls = new List<Control>();
            foreach (Control ctl in ctrls)
            {
                RetCtrls.Add(ctl);
                List<Control> SubCtrls = GetAllControls(ctl.Controls);
                RetCtrls.AddRange(SubCtrls);
            }
            return RetCtrls;
        }


        public virtual bool SetLanguage()
        {
            try
            {
                langcode = Properties.Settings.Default.langcode;

                List<Control> lstControls = GetAllControls(this.Controls);

                foreach (var uicontrol in lstControls)
                {
                    if (uicontrol is Label)
                    {
                        var obj = uicontrol as Label;
                        string langval = LagDictinary.Where(p => p.Key.Equals(obj.Text)).FirstOrDefault().Value.Trim();
                        if (!string.IsNullOrEmpty(langval))
                        {
                            (uicontrol as Label).Text = langval;
                            (uicontrol as Label).Update();
                        }
                    }
                }


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
