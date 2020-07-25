using Correction.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace Correction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogicProgram LP = new LogicProgram();
        int idframe;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Sensors.ItemsSource = LogicProgram.DataBase.sensors.Rows;
            Frames.IsEnabled = false;
            ChangeSens.IsEnabled = false;
            ChangeFrame.IsEnabled = false;
            ButBefore.IsEnabled = false;
            ButAfter.IsEnabled = false;
        }

        private void RefreshItems()
        {
            Sensors.Items.Refresh();
            Sensors.SelectedItem = null;
            Frames.Items.Refresh();
            Frames.SelectedItem = null;
            Frames.IsEnabled = false;
            ChangeSens.IsEnabled = false;
            ChangeFrame.IsEnabled = false;
            pic.Source = null;
            ButBefore.IsEnabled = false;
            ButAfter.IsEnabled = false;
        }
        private void AddSens_Click(object sender, RoutedEventArgs e)
        {
            new Forms.SensorPage().ShowDialog();
            RefreshItems();
        }

        private void ChangeSens_Click(object sender, RoutedEventArgs e)
        {
            new Forms.SensorPage((Sensors.SelectedItem as DataBase.InfoSensDataSet.SensorsRow).IdSensor).ShowDialog();
            RefreshItems();
        }

        private void AddFrame_Click(object sender, RoutedEventArgs e)
        {
            new Forms.FramePage().ShowDialog();
            RefreshItems();
        }

        private void ChangeFrame_Click(object sender, RoutedEventArgs e)
        {
            new Forms.FramePage((Frames.SelectedItem as DataBase.InfoSensDataSet.FramesRow).IdFrame).ShowDialog();
            RefreshItems();
        }

        private void Sensors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Sensors.SelectedItem != null)
            {
                int SensorId = (Sensors.SelectedItem as DataBase.InfoSensDataSet.SensorsRow).IdSensor;
                Frames.ItemsSource = LogicProgram.DataBase.frames.ToList().FindAll(f => f.IdSensors == SensorId);

                if (Frames.Items.Count != 0)
                {
                    Frames.IsEnabled = true;
                }
                else
                {
                    Frames.IsEnabled = false;
                }

                ChangeSens.IsEnabled = true;
            }
        }

        private void Frames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Frames.SelectedItem != null)
            {
                idframe = (Frames.SelectedItem as DataBase.InfoSensDataSet.FramesRow).IdFrame;
                pic.Source = LP.GetImgBasic(idframe);
                ChangeFrame.IsEnabled = true;
                ButAfter.IsEnabled = true;
                ButBefore.IsEnabled = true;
            }
        }

        private void ButBefore_Click(object sender, RoutedEventArgs e)
        {
            idframe = (Frames.SelectedItem as DataBase.InfoSensDataSet.FramesRow).IdFrame;
            pic.Source = LP.GetImgBasic(idframe);
        }

        private void ButAfter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                idframe = (Frames.SelectedItem as DataBase.InfoSensDataSet.FramesRow).IdFrame;
                pic.Source = LP.GetCorrectImg(idframe);
            }
            catch 
            { 
                MessageBox.Show("Размеры кадров не совпадают, замените кадры!", "Ошибка");
            }
        }
    }
}
