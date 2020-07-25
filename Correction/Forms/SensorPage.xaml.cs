using Correction.Classes;
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
using System.Windows.Shapes;

namespace Correction.Forms
{
    /// <summary>
    /// Логика взаимодействия для SensorPage.xaml
    /// </summary>
    public partial class SensorPage : Window
    {
        int id = -1;
        public SensorPage()
        {
            InitializeComponent();
            Delete.IsEnabled = false;
        }
        public SensorPage(int Id)
        {
            id = Id;
            InitializeComponent();
            this.Loaded += SensorPage_Loaded;
        }

        private void SensorPage_Loaded(object sender, RoutedEventArgs e)
        {
            NameSensor.Text = LogicProgram.DataBase.sensors.FindByIdSensor(id).NameSensor;
            ResolutionSensor.Text = LogicProgram.DataBase.sensors.FindByIdSensor(id).Resolution.ToString();
            SerialNumberSensor.Text = LogicProgram.DataBase.sensors.FindByIdSensor(id).SerialNumber;
            DescriptionSensor.Text = LogicProgram.DataBase.sensors.FindByIdSensor(id).Description;
            DateSensor.SelectedDate = LogicProgram.DataBase.sensors.FindByIdSensor(id).DateAdd;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string Name = NameSensor.Text;
                int.TryParse(ResolutionSensor.Text,out int Resolution);
                string SerialNumber = SerialNumberSensor.Text;
                string Description = DescriptionSensor.Text;
                DateTime DateAdd = DateSensor.SelectedDate.Value;

                if (id == -1)
                    LogicProgram.DataBase.AddRowSensors(Name, Resolution, SerialNumber, Description, DateAdd);
                else
                    LogicProgram.DataBase.ChangeRowSensors(id, Name, Resolution, SerialNumber, Description, DateAdd);
                Close();
            }
            catch 
            {
                MessageBox.Show("Проверьте введённые данные!", "Ошибка");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены?","Предупреждение",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            { 
                LogicProgram.DataBase.DeleteRowSensors(id);
                Close();
            }
           
        }
    }
}
