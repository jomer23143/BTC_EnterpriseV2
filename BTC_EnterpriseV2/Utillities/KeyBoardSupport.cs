using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MRPPO
{
    public static class KeyBoardSupport
    {
        public static void ForCurrencyOnly_Keypress(Object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = ".0123456789".IndexOf(s.ToUpper());
            if (result == -1) e.Handled = true;
          
        }
        public static void ForNumericOnly_KeyPress(Object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = "0123456789".IndexOf(s.ToUpper());
            if (result == -1) e.Handled = true;
        }
        public static void ForLettersOnly_KeyPress(Object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = ".ABCDEFGHIJKLMNOPQRTSUVWXYZ?_ ".IndexOf(s.ToUpper());
            if (result == -1) e.Handled = true;
        }
        public static void ForLettersOnlyUpper_KeyPress(Object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = ".ABCDEFGHIJKLMNOPQRTSUVWXYZ?_ ".IndexOf(s.ToUpper());
            if (result == -1)
                e.Handled = true;
            else
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        public static void ForAlhpaNumeric_KeyPress(Object sender, KeyPressEventArgs e)
        {
            String s = e.KeyChar.ToString();
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = "0123456789ABCDEFGHIJKLMNOPQRTSUVWXYZ.,?!#%/';_-() ".IndexOf(s.ToUpper());
            if (result == -1) e.Handled = true;
        }
        public static void ForAlhpaNumericUpper_KeyPress(Object sender, KeyPressEventArgs e)
        {
            
            String s = e.KeyChar.ToString().ToUpper();
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = "0123456789ABCDEFGHIJKLMNOPQRTSUVWXYZ.,?!#%/';_- ".IndexOf(s);
            if (result == -1)
                e.Handled = true;
            else
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        public static void ForEmpty_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 8) return;
            int result = "".IndexOf(e.KeyChar);
            if (result == -1) e.Handled = true;
        }
    }
}
