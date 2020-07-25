using Correction.Classes;
using Microsoft.Win32;
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
    /// Логика взаимодействия для FramePage.xaml
    /// </summary>
    public partial class FramePage : Window
    {
        int id = -1;
        OpenFileDialog basic;
        OpenFileDialog dark;
        OpenFileDialog flat;
        LogicProgram LP;

        public FramePage()
        {
            InitializeComponent();
            this.Loaded += FramePage_Loaded1;
        }


        public FramePage(int Id)
        {
            id = Id;
            InitializeComponent();
            this.Loaded += FramePage_Loaded;
        }

        private void FramePage_Loaded1(object sender, RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
            Config();
        }

        private void Config()
        {
            SensorOfFrame.ItemsSource = LogicProgram.DataBase.sensors.Rows;
            SensorOfFrame.SelectedIndex = 0;

            basic = new OpenFileDialog();
            basic.Filter = "Image From Txt|*.txt";

            dark = new OpenFileDialog();
            dark.Filter = "Image From Txt|*.txt";

            flat = new OpenFileDialog();
            flat.Filter = "Image From Txt|*.txt";

            LP = new LogicProgram();
        }

        private void FramePage_Loaded(object sender, RoutedEventArgs e)
        {
            Config();
            int SensorId = LogicProgram.DataBase.frames.FindByIdFrame(id).IdSensors;
            NameFrame.Text = LogicProgram.DataBase.frames.FindByIdFrame(id).NameFile;
            SensorOfFrame.SelectedItem = LogicProgram.DataBase.sensors.FindByIdSensor(SensorId);
            DescriptionFrame.Text = LogicProgram.DataBase.frames.FindByIdFrame(id).Description;
            DateFrame.SelectedDate = LogicProgram.DataBase.frames.FindByIdFrame(id).DateAdd;

            BasicPathFrame.Text = LogicProgram.DataBase.frames.FindByIdFrame(id).PathFile;
            BasicBut.Background = new ImageBrush() { ImageSource = LP.GetImgBasic(id) };

            DarkPathFrame.Text = LogicProgram.DataBase.frames.FindByIdFrame(id).PathDarkFile;
            DarkBut.Background = new ImageBrush() { ImageSource = LP.GetImgDark(id) };

            FlatPathFrame.Text = LogicProgram.DataBase.frames.FindByIdFrame(id).PathFlatFile;
            FlatBut.Background = new ImageBrush() { ImageSource = LP.GetImgFlat(id) };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

                string Name = NameFrame.Text;
                int IdSensor = (SensorOfFrame.SelectedItem as DataBase.InfoSensDataSet.SensorsRow).IdSensor;
                string Description = DescriptionFrame.Text;
                DateTime DateAdd = DateFrame.SelectedDate.Value;
                string BasicPath = BasicPathFrame.Text;
                string DarkPath = DarkPathFrame.Text;
                string FlatPath = FlatPathFrame.Text;
                if(BasicPath.EndsWith(".txt") && DarkPath.EndsWith(".txt") && FlatPath.EndsWith(".txt"))
                { 
                    if (id == -1)
                    { 
                        LogicProgram.DataBase.AddRowFrames(Name, BasicPath,DarkPath,FlatPath, Description, DateAdd, IdSensor);
                    }
                    else 
                    {
                        LogicProgram.DataBase.ChangeRowFrames(id, Name, BasicPath,DarkPath,FlatPath, Description, DateAdd, IdSensor);
                    }
                    Close();
                }
                else 
                {
                    MessageBox.Show("Кадры должны быть заполнены!");
                }           
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LogicProgram.DataBase.DeleteRowFrames(id);
                Close();
            }
        }

        private void BasicBut_Click(object sender, RoutedEventArgs e)
        {
            basic.ShowDialog();
            BasicPathFrame.Text = string.IsNullOrEmpty(basic.FileName)? BasicPathFrame.Text : basic.FileName;
        }

        private void DarkBut_Click(object sender, RoutedEventArgs e)
        {       
            dark.ShowDialog();
            DarkPathFrame.Text = string.IsNullOrEmpty(dark.FileName) ? DarkPathFrame.Text : dark.FileName;
        }

        private void FlatBut_Click(object sender, RoutedEventArgs e)
        {
            flat.ShowDialog();
            FlatPathFrame.Text = string.IsNullOrEmpty(flat.FileName) ? FlatPathFrame.Text : flat.FileName;
        }
    }
}
