using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Location_De_Voiture.BL
{
    public static class TextBox
    {
        

        public static bool IsEmpty(this System.Windows.Forms.TextBox box)
        {
            var Value = box.Text;
            if (Value == "")
                return true;
            else
                return false;

        }
        public static bool IsEmptyCombobox(this ComboBox Box)
        {
            var Value = Box.SelectedValue;
            if (Value == null)
                return true;
            else
                return false;

        }
    }
}
