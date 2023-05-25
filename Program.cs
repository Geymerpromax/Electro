using System;
using System.Numerics; // скачать библиотеку 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Threading;
using System.Timers;


// синусы и минусы
namespace Electro
{
    public class ComplexFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg,
                             IFormatProvider provider)
        {
            if (arg is Complex)
            {
                Complex c1 = (Complex)arg;
                // Check if the format string has a precision specifier.
                int precision;
                string fmtString = String.Empty;
                if (format.Length > 1)
                {
                    try
                    {
                        precision = Int32.Parse(format.Substring(1));
                    }
                    catch (FormatException)
                    {
                        precision = 0;
                    }
                    fmtString = "N" + precision.ToString();
                }
                if (format.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase))
                    return c1.Real.ToString(fmtString) + " + " + "i " + c1.Imaginary.ToString(fmtString);
                else if (format.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase))
                    return c1.Real.ToString(fmtString) + " + " + "j " + c1.Imaginary.ToString(fmtString);
                else
                    return c1.ToString(format, provider);
            }
            else
            {
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, provider);
                else if (arg != null)
                    return arg.ToString();
                else
                    return String.Empty;
            }
        }
    }
    internal class Program
    {
     
        static void Main(string[] args)
        {           
            Grafick rg = new Grafick();
            Application.Run(rg);
        }

    }
}
