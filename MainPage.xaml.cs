using System;
using System.Collections.Generic;

namespace Arguello_ExamenP2
{
    public partial class MainPage : ContentPage
    {
        // Diccionario para conversiones
        private readonly Dictionary<string, double> unitConversions = new Dictionary<string, double>
        {
            { "Metros", 1 },
            { "Kilómetros", 0.001 },
            { "Centímetros", 100 },
            { "Milímetros", 1000 },
            { "Pulgadas", 39.3701 },
            { "Pies", 3.28084 }
        };

        public MainPage()
        {
            InitializeComponent();

            // Poblamos los pickers con las unidades
            foreach (var unit in unitConversions.Keys)
            {
                FromUnitPicker.Items.Add(unit);
                ToUnitPicker.Items.Add(unit);
            }
        }

        private void OnConvertClicked(object sender, EventArgs e)
        {
            
            if (FromUnitPicker.SelectedItem == null || ToUnitPicker.SelectedItem == null || string.IsNullOrEmpty(InputEntry.Text))
            {
                ResultLabel.Text = "Por favor, selecciona las unidades y proporciona una cantidad.";
                return;
            }

            if (!double.TryParse(InputEntry.Text, out double inputValue))
            {
                ResultLabel.Text = "Por favor, ingresa un número válido.";
                return;
            }

            string fromUnit = FromUnitPicker.SelectedItem.ToString();
            string toUnit = ToUnitPicker.SelectedItem.ToString();

            double baseValue = inputValue / unitConversions[fromUnit]; 
            double convertedValue = baseValue * unitConversions[toUnit]; 

            ResultLabel.Text = $"{inputValue} {fromUnit} = {convertedValue:F2} {toUnit}";
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            
            FromUnitPicker.SelectedIndex = -1; 
            ToUnitPicker.SelectedIndex = -1;   
            InputEntry.Text = string.Empty;    
            ResultLabel.Text = string.Empty;   
        }


    }
}
