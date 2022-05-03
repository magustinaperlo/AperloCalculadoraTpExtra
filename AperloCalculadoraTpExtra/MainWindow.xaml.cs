using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AperloCalculadoraTpExtra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_limpiar(object sender, RoutedEventArgs e)
        {
         _numOperador1 = 0;
         _numOperador2 = 0;
         _numTexto1 = "";
         _numTexto2 = "";
         _operador = "";
         pantalla.Text = "";
         }

        private void btn_numeros(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(_operador =="" && _numTexto2== "")
            {
                _numTexto1 = _numTexto1 + (string)btn.Content;
                _numOperador1 = double.Parse(_numTexto1);

                MostrarPantalla(_numTexto1);
            }
            else
            {
                _numTexto2 = _numTexto2 + (string)btn.Content;
                _numOperador2 = double.Parse(_numTexto2);

                MostrarPantalla(_numTexto1,_numTexto2);
            }
        }

        private void btn_punto(object sender, RoutedEventArgs e)
        {
            if (_operador=="" && _numTexto1 != "" && _numOperador1%1 ==0)
            {
                _numTexto1 = _numTexto1 + ".";
                MostrarPantalla(_numTexto1);
            }
            if(_operador !="" && _numTexto2 != "" && _numOperador2 % 1 == 0)
            {
                _numTexto2 = _numTexto2 + ".";
                MostrarPantalla(_numTexto1, _numTexto2 );
            }
        }

        private void btn_operadores(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(_operador=="" && _numTexto2 == "")
            {
                _operador = (string)btn.Content;
                MostrarPantalla(_numTexto1);
            }
         }

        private void btn_igual(object sender, RoutedEventArgs e)
        {
            if(_operador != "")
            {
                switch (_operador)
                {
                    case "+":
                        _resultado = Convert.ToString(_numOperador1 + _numOperador2);
                        break;
                    case "/":
                        _resultado = Convert.ToString(_numOperador1 / _numOperador2);
                        break;
                    case "*":
                        _resultado = Convert.ToString(_numOperador1 * _numOperador2);
                        break;
                    case "-":
                        _resultado = Convert.ToString(_numOperador1 - _numOperador2);
                        break;
                }
            }
            _numTexto1 = _resultado;
            _numOperador1 = double.Parse(_numTexto1);

            _numTexto2 = "";
            _numOperador2 = 0;
            _operador = "";
            _resultado = "";

            MostrarPantalla(_numTexto1, _numTexto2);
        }

        private void btn_signos(object sender, RoutedEventArgs e)
        {
            _numOperador1 = _numOperador1 * (-1);
            _numTexto1 = Convert.ToString(_numOperador1);
            MostrarPantalla(_numTexto1);
        }

        private void MostrarPantalla(Object numero, Object numero2 = null)
        {
            if(_resultado == "")
            {
                if (_operador == "")
                {
                    pantalla.Text = Convert.ToString(numero);
                }
                else
                {
                    pantalla.Text = "(" + Convert.ToString(numero) + ")" + _operador + "("+ Convert.ToString(numero2) + ")";
                }
            }
            else
            {
                pantalla.Text = "Resultado: " + _resultado;
            }
        }

        private double _numOperador1 = 0;
        private double _numOperador2 = 0;
        private string _numTexto1 = "";
        private string _numTexto2 ="";
        private string _resultado = "";
        private string _operador = "";

    }
}
