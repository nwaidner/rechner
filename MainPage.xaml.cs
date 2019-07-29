using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taschenrechner
{
    public partial class MainPage : ContentPage
    {
        public MainPage(){ InitializeComponent();}

        public void ccc(object sender, EventArgs e)
        {
            string s = ef1.Text;
            if(Calc(s) != "N")
            {
                ef1.Text="";
            }
            else if (s.Length > 0)
            {
                s = s.Substring(0, s.Length - 1);
                ef1.Text = s;
            }
            else { ef1.Text = ""; }
        }
        public void cce(object sender, EventArgs e) { ef1.Text = ""; }
        public void open(object sender, EventArgs e) { ef1.Text = ef1.Text + "("; }
        public void close(object sender, EventArgs e) { ef1.Text = ef1.Text + ")"; }
        public void minus(object sender, EventArgs e) { ef1.Text =ef1.Text + "-"; }
        public void plus(object sender, EventArgs e) { ef1.Text = ef1.Text + "+"; }
        public void div(object sender, EventArgs e) { ef1.Text = ef1.Text + "/"; }
        public void seven(object sender, EventArgs e) { ef1.Text = ef1.Text + "7"; }
        public void eight(object sender, EventArgs e) { ef1.Text = ef1.Text + "8"; }
        public void nine(object sender, EventArgs e) { ef1.Text = ef1.Text + "9"; }
        public void zero(object sender, EventArgs e) { ef1.Text = ef1.Text + "0"; }
        public void multi(object sender, EventArgs e) { ef1.Text = ef1.Text + "*"; }
        public void four(object sender, EventArgs e) { ef1.Text = ef1.Text + "4"; }
        public void five(object sender, EventArgs e) { ef1.Text = ef1.Text + "5"; }
        public void six(object sender, EventArgs e) { ef1.Text = ef1.Text + "6"; }
        public void three(object sender, EventArgs e) { ef1.Text = ef1.Text + "3"; }
        public void two(object sender, EventArgs e) { ef1.Text = ef1.Text + "2"; }
        public void one(object sender, EventArgs e) { ef1.Text = ef1.Text + "1"; }
        public void dot(object sender, EventArgs e) { ef1.Text = ef1.Text + "."; }
        public void abs(object sender, EventArgs e) { ef1.Text = ef1.Text + "btr("; }
        public void pii(object sender, EventArgs e) { ef1.Text = ef1.Text + "pi"; }
        public void euler(object sender, EventArgs e) { ef1.Text = ef1.Text + "e"; }
        public void sinus(object sender, EventArgs e) { ef1.Text = ef1.Text + "sin("; }
        public void cosinus(object sender, EventArgs e) { ef1.Text = ef1.Text + "cos("; }
        public void tangens(object sender, EventArgs e) { ef1.Text = ef1.Text + "tan("; }
        public void wurzel(object sender, EventArgs e) { ef1.Text = ef1.Text + "sqrt("; }
        public void enter(object sender, EventArgs e)
        {
            TTL = 0;
            string s = ef1.Text;
            s = Rechnen(s);
            ef1.Text = s;
        }
        public static int TTL = 0;
        static void Main(string[] args)
        {
            string s;
            while (true)
            {
                TTL = 0;
                s = Console.ReadLine();
                s = Rechnen(s);
                Console.WriteLine(s);
            }
        }
        public static string Rechnen(string s)
        {
            while (Calc(s) == "N" && TTL < s.Length)
            {
                ++TTL;
                s = Parse(s);
            }
            if (TTL >= s.Length)
            {
                return "Error";
            }
            else
            {
                s = Calc(s);
                s = s.Replace(',', '.');
                return s;
            }
        }
        public static string Calc(string s)
        {
            var table = new DataTable();
            try
            {
                s = table.Compute(s, "").ToString();
            }
            catch (Exception)
            {
                s = "N";
            }
            return s;
        }
        public static string Parse(string s)
        {
            if (Search(s, "e"))
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == 'e')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 1; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z1 += "2.718281828";
                        z1 += z2;
                        return z1;
                    }
                }
            }
            else if (Search(s, "pi") == true)
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == 'p' && s[i + 1] == 'i')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 2; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z1 += "3.141592653";
                        z1 += z2;
                        return z1;
                    }
                }
            }
            else if (Search(s, "sin") == true)
            {
                for (int i = 0; i < s.Length - 3; ++i)
                {
                    if (s[i] == 's' && s[i + 1] == 'i' && s[i + 2] == 'n' && s[i + 3] == '(')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 3; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z2 = Rechnen(z2);
                        if (z2 == "Error") { return z2; }
                        double wert = Convert.ToDouble(z2);
                        z1 += Convert.ToString(Math.Sin(wert));
                        z1 = z1.Replace(',', '.');
                        return z1;
                    }
                }
            }
            else if (Search(s, "cos") == true)
            {
                for (int i = 0; i < s.Length - 3; ++i)
                {
                    if (s[i] == 'c' && s[i + 1] == 'o' && s[i + 2] == 's' && s[i + 3] == '(')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 3; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z2 = Rechnen(z2);
                        if (z2 == "Error") { return z2; }
                        double wert = Convert.ToDouble(z2);
                        z1 += Convert.ToString(Math.Cos(wert));
                        z1 = z1.Replace(',', '.');
                        return z1;
                    }
                }
            }
            else if (Search(s, "tan") == true)
            {
                for (int i = 0; i < s.Length - 3; ++i)
                {
                    if (s[i] == 't' && s[i + 1] == 'a' && s[i + 2] == 'n' && s[i + 3] == '(')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 3; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z2 = Rechnen(z2);
                        if (z2 == "Error") { return z2; }
                        double wert = Convert.ToDouble(z2);
                        z1 += Convert.ToString(Math.Tan(wert));
                        z1 = z1.Replace(',', '.');
                        return z1;
                    }
                }
            }
            else if (Search(s, "btr") == true)

            {
                for (int i = 0; i < s.Length - 3; ++i)
                {
                    if (s[i] == 'b' && s[i + 1] == 't' && s[i + 2] == 'r' && s[i + 3] == '(')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {

                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 3; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z2 = Rechnen(z2);
                        double wert = Convert.ToDouble(z2);
                        if (wert >= 0) { }
                        else { wert *= -1; }
                        z1 += Convert.ToString(wert);
                        z1 = z1.Replace(',', '.');
                        return z1;
                    }
                }
            }
            else if (Search(s, "sqrt") == true)
            {
                for (int i = 0; i < s.Length - 4; ++i)
                {
                    if (s[i] == 's' && s[i + 1] == 'q' && s[i + 2] == 'r' && s[i + 3] == 't')
                    {
                        string z1 = "";
                        for (int i2 = 0; i2 < i; ++i2)
                        {
                            z1 += s[i2];
                        }
                        string z2 = "";
                        for (int i3 = i + 4; i3 < s.Length; ++i3)
                        {
                            z2 += s[i3];
                        }
                        z2 = Rechnen(z2);
                        if (z2 == "Error") { return z2; }
                        double wert = Convert.ToDouble(z2);
                        z1 += Convert.ToString(Math.Sqrt(wert));
                        z1 = z1.Replace(',', '.');
                        return z1;
                    }
                }
            }
            return s;
        }
        public static bool Search(string s, string ges)
        {
            bool b = false;
            if (ges.Length == 1)
            {
                char c = ges[0];
                for (int i = 0; i <= s.Length - 1; ++i)
                {
                    if (s[i] == c)
                    {
                        b = true;
                    }
                }
            }
            else if (ges.Length == 2)
            {
                string g = "";
                for (int i = 0; i < s.Length - 1; ++i)
                {
                    g = "";
                    g += s[i];
                    g += s[i + 1];
                    if (g == ges)
                    {
                        b = true;
                    }
                }
            }
            else if (ges.Length == 3)
            {
                string g = "";
                for (int i = 0; i < s.Length - 2; ++i)
                {
                    g = "";
                    g += s[i];
                    g += s[i + 1];
                    g += s[i + 2];
                    if (g == ges)
                    {
                        b = true;
                    }
                }
            }
            else if (ges.Length == 4)
            {
                string g = "";
                for (int i = 0; i < s.Length - 3; ++i)
                {
                    g = "";
                    g += s[i];
                    g += s[i + 1];
                    g += s[i + 2];
                    g += s[i + 3];
                    if (g == ges)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }
    }
}
