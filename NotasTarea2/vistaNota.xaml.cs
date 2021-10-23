using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotasTarea2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vistaNota : ContentPage
    {
        public vistaNota(string usuario)
        {
            InitializeComponent();
            txtEstudiante.Text = usuario;
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double notaSeguimiento1 = txtNotaSegP1.Text != "" ? Convert.ToDouble(txtNotaSegP1.Text) : 0;
                double examen1 = txtExaSegP1.Text != "" ? Convert.ToDouble(txtExaSegP1.Text) : 0;

                double notaSeguimiento2 = txtNotaSegP2.Text != "" ? Convert.ToDouble(txtNotaSegP2.Text) : 0;
                double examen2 = txtExaSegP2.Text != "" ? Convert.ToDouble(txtExaSegP2.Text) : 0;

                if (verfRango(notaSeguimiento1, txtNotaSegP1) && verfRango(examen1, txtExaSegP1) && verfRango(notaSeguimiento2, txtNotaSegP2) && verfRango(examen2, txtExaSegP2))
                {
                    double parcial1 = calcularParcial(notaSeguimiento1, examen1, txtConvNotaSegP1, txtConvExaSegP1);
                    double parcial2 = calcularParcial(notaSeguimiento2, examen2, txtConvNotaSegP2, txtConvExaSegP2);

                    double notaFinal = parcial1 + parcial2;
                    txtParcial.Text = parcial1.ToString();
                    txtParcial2.Text = parcial2.ToString();
                    txtFinal.Text = notaFinal.ToString();
                    txtEstado.Text = convertEstado(notaFinal);
                }
                else
                {
                    DisplayAlert("ERROR", "Los valores ingresados deben estar entre 0 y 10 ", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string convertEstado(double nota)
        {
            Console.WriteLine(nota.ToString());
            if (nota >= 7.5 && nota <= 10)
            {
                return "APROBADO";
            }
            else if (nota > 4 && nota <= 7.4)
            {
                return "COMPLEMENTARIO";
            }
            else
            {
                return "REPROBADO";
            }
        }

        private double calcularParcial(double notaSeguimiento, double examen, Entry txtNotaSegP1, Entry txtNotaSegP2)
        {
            return convertirNotasSegumiento(notaSeguimiento, txtNotaSegP1) + convertirNotasExamen(examen, txtNotaSegP2);
        }

        private double convertirNotasSegumiento(double nota, Entry txtNotaSegP1)
        {
            double notaConv = (nota * 3) / 10;
            txtNotaSegP1.Text = notaConv.ToString();
            return notaConv;
        }

        private double convertirNotasExamen(double nota, Entry txtNotaSegP1)
        {
            double notaConv = (nota * 2) / 10;
            txtNotaSegP1.Text = notaConv.ToString();
            return notaConv;
        }

        private Boolean verfRango(double valor, Entry txtNotaSegP1)
        {
            Boolean b = true;

            if (valor < 0)
            {
                b = false;
                txtNotaSegP1.Text = "";
            }

            if (valor > 10)
            {
                b = false;
                txtNotaSegP1.Text = "";
            }

            return b;
        }
    }
}