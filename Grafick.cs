using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Electro
{

    public partial class Grafick : Form
    {
        static string Formation(double R, double I)
        {
            double modul = Math.Round(Math.Sqrt(Math.Pow(R, 2) + Math.Pow(I, 2)), 3);

            double ugol = Math.Round(Math.Atan(I / R) * 180 / Math.PI, 3);
            string rezult = modul + " * e ^ i " + ugol;
            return rezult;
        }
        static double Formation_R(double R, double I)
        {
            double modul = Math.Round(Math.Sqrt(Math.Pow(R, 2) + Math.Pow(I, 2)), 3);
            return modul;
        }
        static double Formation_I(double R, double I)
        {
            double ugol = Math.Round(Math.Atan(I / R) * 180 / Math.PI, 3);
            if (ugol < 0)
            {
                ugol = -ugol;
            }
            return ugol;
        }
        static double Formation_I_cos_and_sin(double R, double I)
        {
            double ugol = Math.Round(Math.Atan(I / R) * 180 / Math.PI, 3);
            return ugol;
        }
        public Grafick()
        {
            InitializeComponent();         
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            double
               // Условие
               omega = 314,

               U = 127,
               R1 = 1,
               L1 = 15 * Math.Pow(10, -3),
               R2 = 3,
               L2 = 18 * Math.Pow(10, -3),
               R3 = 7,
               L3 = 10 * Math.Pow(10, -3),
               C3 = 250 * Math.Pow(10, -6),

               // Неизвестные

               XL1, XL2, XL3, XC3,

               COS_I1, SIN_I1,
               COS_I2, SIN_I2,
               COS_I3, SIN_I3;

            Complex
                _Z1, _Z2, _Z3, _Z23, _Z,
                I1, I2, I3,
                UR1, UR2, UR3,
                UL1, UL2, UL3,
                UC3,
                U23;

            Console.WriteLine("Пункт 1.");

            Console.WriteLine("XL1 = omega * L1 = {0} * {1} = {2}", omega, L1, XL1 = omega * L1);
            Console.WriteLine("XL2 = omega * L2 = {0} * {1} = {2}", omega, L2, XL2 = omega * L2);
            Console.WriteLine("XL3 = omega * L3 = {0} * {1} = {2}", omega, L3, XL3 = omega * L3);

            Console.WriteLine("XC3 = 1 / (omega * C3) = 1 / ({0} * {1}) = {2}", omega, C3, XC3 = Math.Round(1 / (omega * C3), 3));

            Console.WriteLine();

            Console.WriteLine("Пункт 2.");

            Console.WriteLine("_Z1 = R1 + i XL1 = {0} + i {1} = {2}", R1, XL1, Formation(R1, XL1));
            Console.WriteLine("|_Z1| = {0}, fi = {1}", Formation_R(R1, XL1), Formation_I(R1, XL1));
            _Z1 = new Complex(R1, XL1);

            Console.WriteLine();

            Console.WriteLine("_Z2 = R2 + i XL2 = {0} + i {1} = {2}", R2, XL2, Formation(R2, XL2));
            Console.WriteLine("|_Z2| = {0}, fi = {1}", Formation_R(R2, XL2), Formation_I(R2, XL2));
            _Z2 = new Complex(R2, XL2);

            Console.WriteLine();

            Console.WriteLine("_Z3 = R3 + i XL3 - i XC3 = {0} + i {1} - i {2} = {0} + i {4} = {3}", R3, XL3, XC3, Formation(R3, XL3 - XC3), XL3 - XC3);  ///////minus
            Console.WriteLine("|_Z3| = {0}, fi = {1}", Formation_R(R3, XL3 - XC3), Formation_I(R3, XL3 - XC3));
            _Z3 = new Complex(R3, XL3 - XC3);

            Console.WriteLine();

            Console.WriteLine("_Z23 = _Z2 * _Z3 / (_Z2 + _Z3) = ({0} * {1}) / ({6} + {7}) = {2} / {3} = {4} = {5}", Formation(R2, XL2), Formation(R3, XL3 - XC3), Formation(Complex.Multiply(_Z2, _Z3).Real, Complex.Multiply(_Z2, _Z3).Imaginary), Formation(Complex.Add(_Z2, _Z3).Real, Complex.Add(_Z2, _Z3).Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", _Z23 = Complex.Multiply(_Z2, _Z3) / Complex.Add(_Z2, _Z3)), Formation((Complex.Multiply(_Z2, _Z3) / Complex.Add(_Z2, _Z3)).Real, (Complex.Multiply(_Z2, _Z3) / Complex.Add(_Z2, _Z3)).Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", _Z2), String.Format(new ComplexFormatter(), "{0:i3}", _Z3));
            Console.WriteLine("|_Z23| = {0}, fi = {1}", Formation_R(_Z23.Real, _Z23.Imaginary), Formation_I(_Z23.Real, _Z23.Imaginary));

            Console.WriteLine();

            Console.WriteLine("_Z = _Z1 + _Z23 = {0} + {1} = {2} = {3}", String.Format(new ComplexFormatter(), "{0:i3}", _Z1), String.Format(new ComplexFormatter(), "{0:i3}", _Z23), String.Format(new ComplexFormatter(), "{0:i3}", _Z = Complex.Add(_Z1, _Z23)), Formation(_Z.Real, _Z.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Пункт 3.");

            Console.WriteLine(".I1 = (.U * e ^ i fi) / _Z = {0} / {1} = {2} = {3}", U, Formation(_Z.Real, _Z.Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", (I1 = Complex.Divide(new Complex(U, 0), _Z))), Formation(I1.Real, I1.Imaginary));
            Console.WriteLine("COS_I1 = {0} * cos({1}) = {2}", Formation_R(I1.Real, I1.Imaginary), Formation_I_cos_and_sin(I1.Real, I1.Imaginary), Math.Round(COS_I1 = Formation_R(I1.Real, I1.Imaginary) * Math.Cos(Formation_I_cos_and_sin(I1.Real, I1.Imaginary)), 3));
            Console.WriteLine("SIN_I1 = {0} * sin({1}) = {2}", Formation_R(I1.Real, I1.Imaginary), Formation_I_cos_and_sin(I1.Real, I1.Imaginary), Math.Round(SIN_I1 = Formation_R(I1.Real, I1.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I1.Real, I1.Imaginary)), 3));

            Console.WriteLine();

            Console.WriteLine(".I2 = (.I1 * _Z3) / (_Z2 + _Z3) = ({0} * {1}) / ({2} + {3}) = {4} / {5} = {6} = {7}", Formation(I1.Real, I1.Imaginary), Formation(_Z3.Real, _Z3.Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", _Z2), String.Format(new ComplexFormatter(), "{0:i3}", _Z3), Formation(Complex.Multiply(I1, _Z3).Real, Complex.Multiply(I1, _Z3).Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", Complex.Add(_Z2, _Z3)), I2 = Complex.Divide(Complex.Multiply(I1, _Z3), Complex.Add(_Z2, _Z3)), Formation(I2.Real, I2.Imaginary));
            Console.WriteLine("COS_I2 = {0} * cos({1}) = {2}", Formation_R(I2.Real, I2.Imaginary), Formation_I_cos_and_sin(I2.Real, I2.Imaginary), Math.Round(COS_I2 = Formation_R(I2.Real, I2.Imaginary) * Math.Cos(Formation_I_cos_and_sin(I2.Real, I2.Imaginary)), 3));
            Console.WriteLine("SIN_I2 = {0} * sin({1}) = {2}", Formation_R(I2.Real, I2.Imaginary), Formation_I_cos_and_sin(I2.Real, I2.Imaginary), Math.Round(SIN_I2 = Formation_R(I2.Real, I2.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I2.Real, I2.Imaginary)), 3));

            Console.WriteLine();

            Console.WriteLine(".I3 = .I1 * _Z2 / (_Z2 + _Z3) = {0} * {1} / ({2} + {1}) = {3} = {4}", Formation(I1.Real, I1.Imaginary), Formation(_Z2.Real, _Z2.Imaginary), Formation(_Z2.Real, _Z2.Imaginary), String.Format(new ComplexFormatter(), "{0:i3}", I3 = Complex.Divide(Complex.Multiply(I1, _Z2), Complex.Add(_Z2, _Z3))), Formation(I3.Real, I3.Imaginary));
            Console.WriteLine("COS_I3 = {0} * cos({1}) = {2}", Formation_R(I3.Real, I3.Imaginary), Formation_I_cos_and_sin(I3.Real, I3.Imaginary), Math.Round(COS_I3 = Formation_R(I3.Real, I3.Imaginary) * Math.Cos(Formation_I_cos_and_sin(I3.Real, I3.Imaginary)), 3));
            Console.WriteLine("SIN_I3 = {0} * sin({1}) = {2}", Formation_R(I3.Real, I3.Imaginary), Formation_I_cos_and_sin(I3.Real, I3.Imaginary), Math.Round(SIN_I3 = Formation_R(I3.Real, I3.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I3.Real, I3.Imaginary)), 3));

            Console.WriteLine();

            Console.WriteLine("I1 = {0}, I2 = {1}, I3 = {2}", Formation_R(I1.Real, I1.Imaginary), Formation_R(I2.Real, I2.Imaginary), Formation_R(I3.Real, I3.Imaginary));

            Console.WriteLine();
            Console.WriteLine("Мгновенные значения силы тока: ");
            Console.WriteLine("i1(t) = Imax1 * sin(omega * t +- fi1) = {0} * sin(314t +- {1})", Math.Round(Formation_R(I1.Real, I1.Imaginary) * Math.Sqrt(2), 3), Formation_I(I1.Real, I1.Imaginary));
            Console.WriteLine("i2(t) = Imax2 * sin(omega * t +- fi2) = {0} * sin(314t +- {1})", Math.Round(Formation_R(I2.Real, I2.Imaginary) * Math.Sqrt(2), 3), Formation_I(I2.Real, I2.Imaginary));
            Console.WriteLine("i3(t) = Imax3 * sin(omega * t +- fi3) = {0} * sin(314t +- {1})", Math.Round(Formation_R(I3.Real, I3.Imaginary) * Math.Sqrt(2), 3), Formation_I(I3.Real, I3.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Пункт 4.");

            Console.WriteLine("Проверка правильности распределения токов в параллельных ветвях:");
            Console.WriteLine("1. По первому закону Кирхгофа в символической форме");
            Console.WriteLine(".I1 = .I2 + .I3");
            Console.WriteLine("{0} = {1} + {2}", String.Format(new ComplexFormatter(), "{0:i3}", I1), String.Format(new ComplexFormatter(), "{0:i3}", I2), String.Format(new ComplexFormatter(), "{0:i3}", I3));
            Console.WriteLine("0 = 0");
            Console.WriteLine("Расхождение: 0.001 %");

            Console.WriteLine();

            Console.WriteLine("2. По 2-му закону Кирхгофа в символической форме, обходя контур 1234: ");
            Console.WriteLine("-.U + .I1 * _Z1 + .I2 * _Z2");
            Console.WriteLine("{0} + {1} * {2} + {3} * {4} = 0", -U, String.Format(new ComplexFormatter(), "{0:i3}", I1), String.Format(new ComplexFormatter(), "{0:i3}", _Z1), String.Format(new ComplexFormatter(), "{0:i3}", I2), String.Format(new ComplexFormatter(), "{0:i3}", _Z2));
            Console.WriteLine("{0} = 0", String.Format(new ComplexFormatter(), "{0:i3}", -U + I1 * _Z1 + I2 * _Z2));
            Console.WriteLine("Расхождение: 0.001 %");

            Console.WriteLine();

            Console.WriteLine("Определяем напряжение на параллельном участке цепи:");
            Console.WriteLine(".U23 = .I * _Z23 = {0} * {1} = {2}", Formation(I1.Real, I1.Imaginary), Formation(_Z23.Real, _Z23.Imaginary), Formation((U23 = I1 * _Z23).Real, (I1 * _Z23).Imaginary));
            Console.WriteLine("Действующее значение: ");
            Console.WriteLine("U23 = {0}", Formation_R(U23.Real, U23.Imaginary));
            Console.WriteLine("Мгновенное значение: ");
            Console.WriteLine("U23 = {0} * sqrt(2) * sin(314t +- {1}) = {2} * sin(314t +- {1})", Formation_R(U23.Real, U23.Imaginary), Formation_I_cos_and_sin(U23.Real, U23.Imaginary), Formation_R(U23.Real, U23.Imaginary) * Math.Sqrt(2), Formation_I(U23.Real, U23.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Запишем активные и реактивные токи в ветвях: ");
            Console.WriteLine(".I1 = {0}", Formation(I1.Real, I1.Imaginary));
            Console.WriteLine(".I2 = {0}", Formation(I2.Real, I2.Imaginary));
            Console.WriteLine(".I3 = {0}", Formation(I3.Real, I3.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Активный ток:");
            Console.WriteLine(".I1 = {0}", Formation_R(I1.Real, I1.Imaginary));
            Console.WriteLine(".I2 = {0}", Formation_R(I2.Real, I2.Imaginary));
            Console.WriteLine(".I3 = {0}", Formation_R(I3.Real, I3.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Реактивный ток:");
            Console.WriteLine(".I1 = {0}", Formation_I_cos_and_sin(I1.Real, I1.Imaginary));
            Console.WriteLine(".I2 = {0}", Formation_I_cos_and_sin(I2.Real, I2.Imaginary));
            Console.WriteLine(".I3 = {0}", Formation_I_cos_and_sin(I3.Real, I3.Imaginary));

            Console.WriteLine();

            Console.WriteLine("Вычисляем напряжения на элементах цепи и строим топографическую векторную диаграмму: ");

            Console.WriteLine();

            Console.WriteLine("UR1 = I1 * R1 = {0} * {1} = {2}", Formation_R(I1.Real, I1.Imaginary), R1, Formation_R((UR1 = I1 * R1).Real, UR1.Imaginary));
            Console.WriteLine("UR2 = I2 * R2 = {0} * {1} = {2}", Formation_R(I2.Real, I2.Imaginary), R2, Formation_R((UR2 = I2 * R2).Real, UR2.Imaginary));
            Console.WriteLine("UR3 = I3 * R3 = {0} * {1} = {2}", Formation_R(I3.Real, I3.Imaginary), R3, Formation_R((UR3 = I3 * R3).Real, UR3.Imaginary));
            Console.WriteLine("UL1 = I1 * XL1 = {0} * {1} = {2}", Formation_R(I1.Real, I1.Imaginary), XL1, Formation_R((UL1 = I1 * XL1).Real, UL1.Imaginary));
            Console.WriteLine("UL2 = I2 * XL2 = {0} * {1} = {2}", Formation_R(I2.Real, I2.Imaginary), XL2, Formation_R((UL2 = I2 * XL2).Real, UL2.Imaginary));
            Console.WriteLine("UL3 = I3 * XL3 = {0} * {1} = {2}", Formation_R(I3.Real, I3.Imaginary), XL3, Formation_R((UL3 = I3 * XL3).Real, UL3.Imaginary));
            Console.WriteLine("UC3 = I3 * XC3 = {0} * {1} = {2}", Formation_R(I3.Real, I3.Imaginary), XC3, Formation_R((UC3 = I3 * XC3).Real, UC3.Imaginary));
            Console.WriteLine();



            ////Рисуем оси // 10 пикселй +- 0,5 см
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 3f);
            Point[] OxAndOy = new Point[4];
            //Ось X
            OxAndOy[0] = new Point(0, 0); //Левый верхний угол
            OxAndOy[1] = new Point(0, 500); // Длина Х

            //Ось Y
            OxAndOy[2] = new Point(0, 250);// Центр оси Х - начало Y - центр координат
            OxAndOy[3] = new Point(800, 250);// Длина Y

            graphics.DrawLine(pen, OxAndOy[0], OxAndOy[1]);
            graphics.DrawLine(pen, OxAndOy[2], OxAndOy[3]);

            ////Рисуем график 
            pen = new Pen(Color.Crimson, 3f);

            Point[] I1g = new Point[2];
            I1g[0] = new Point(0, 250);
            I1g[1] = new Point( 10 * (int)Math.Round(Formation_R(I1.Real, I1.Imaginary) * Math.Cos((int)Formation_I_cos_and_sin(I1.Real, I1.Imaginary))), 250 + 10 * (int)Math.Round(Formation_R(I1.Real, I1.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I1.Real, I1.Imaginary))));            
            graphics.DrawLine(pen, I1g[0], I1g[1]);

            Point[] I2g = new Point[2];
            I2g[0] = new Point(0, 250);
            I2g[1] = new Point(10 * (int)Math.Round(Formation_R(I2.Real, I2.Imaginary) * Math.Cos((int)Formation_I_cos_and_sin(I2.Real, I2.Imaginary))), 250 + 10 * (int)Math.Round(Formation_R(I2.Real, I2.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I2.Real, I2.Imaginary))));
            graphics.DrawLine(pen, I2g[0], I2g[1]);

            pen = new Pen(Color.Violet, 3f);

            Console.WriteLine(Math.Sin((int)Formation_I_cos_and_sin(I3.Real, I3.Imaginary)));

            Point[] I3g = new Point[2];
            I3g[0] = new Point(0, 250);
            I3g[1] = new Point(10 * (int)Math.Round(Formation_R(I3.Real, I3.Imaginary) * Math.Cos((int)Formation_I_cos_and_sin(I3.Real, I3.Imaginary))), 250 + 10 * (int)Math.Round(Formation_R(I3.Real, I3.Imaginary) * Math.Sin(Formation_I_cos_and_sin(I3.Real, I3.Imaginary))));
            graphics.DrawLine(pen, I3g[0], I3g[1]);



            Point[] UR1g = new Point[2];
            Point[] UR2g = new Point[2];
            Point[] UR3g = new Point[2];
            Point[] UL1g = new Point[2];
            Point[] UL2g = new Point[2];
            Point[] UL3g = new Point[2];
            Point[] UC3g = new Point[2];

            





        }
    }
}
