using System;
using System.Collections.Generic;

namespace Arguello_ExamenP2
{
    public partial class MainPage : ContentPage
    {

        private readonly Dictionary<string, double> unitConversions = new Dictionary<string, double>
        {
            { "Metros cuadrados", 1 }, 
            { "Hectáreas", 0.0001 },
            { "Acres", 0.000247105 },
            { "Kilómetros cuadrados", 1e-6 },
            { "Centímetros cuadrados", 10000 }
        };

        public MainPage()
        {
            InitializeComponent();

            
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
