using System;
using Correction.DataBase;
using Correction.DataBase.InfoSensDataSetTableAdapters;

namespace Correction.Classes
{
    class DataBaseLogic
    {

        public InfoSensDataSet.SensorsDataTable sensors = new InfoSensDataSet.SensorsDataTable();
        SensorsTableAdapter sensorsAdapte = new SensorsTableAdapter();

        public InfoSensDataSet.FramesDataTable frames = new InfoSensDataSet.FramesDataTable();
        FramesTableAdapter framesAdapte = new FramesTableAdapter();


        public DataBaseLogic() 
        {
            sensorsAdapte.Fill(sensors);
            framesAdapte.Fill(frames);
        }

        /// <summary>
        /// Добавление строки в таблицу sensors
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Resolution"></param>
        /// <param name="SerialNumber"></param>
        /// <param name="Description"></param>
        /// <param name="DateAdd"></param>
        public void AddRowSensors(string Name, int Resolution, string SerialNumber,string Description, DateTime DateAdd) 
        {    
            sensorsAdapte.InsertRow(Name, Resolution, SerialNumber, Description, DateAdd);
            sensorsAdapte.Update(sensors);
            sensorsAdapte.Fill(sensors);
        }

        /// <summary>
        /// Удаление строки из таблицы sensors
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteRowSensors(int Id) 
        {
            sensorsAdapte.DeleteRow(Id);
            sensorsAdapte.Update(sensors);
            sensorsAdapte.Fill(sensors);
        }

        /// <summary>
        /// Обновление строки в таблице sensors
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Resolution"></param>
        /// <param name="SerialNumber"></param>
        /// <param name="Description"></param>
        /// <param name="DateAdd"></param>
        public void ChangeRowSensors(int Id,string Name, int Resolution, string SerialNumber,string Description, DateTime DateAdd)
        {
            sensorsAdapte.UpdateRow(Name, Resolution, SerialNumber, Description, DateAdd,Id);
            sensorsAdapte.Update(sensors);
            sensorsAdapte.Fill(sensors);
        }

        /// <summary>
        /// Добавление строки в таблицу frames
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="PathBasic"></param>
        /// <param name="PathDark"></param>
        /// <param name="PathFlat"></param>
        /// <param name="Description"></param>
        /// <param name="DateAdd"></param>
        /// <param name="IdSensor"></param>
        public void AddRowFrames(string Name, string PathBasic,string PathDark,string PathFlat ,string Description, DateTime DateAdd, int IdSensor)
        {
            framesAdapte.InsertRow(Name, PathBasic, Description, DateAdd, IdSensor,PathDark,PathFlat);
            framesAdapte.Update(frames);
            framesAdapte.Fill(frames);
        }

        /// <summary>
        /// Удаление строки из таблицы frames
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="PathBasic"></param>
        /// <param name="PathDark"></param>
        /// <param name="PathFlat"></param>
        /// <param name="Description"></param>
        /// <param name="DateAdd"></param>
        /// <param name="IdSensor"></param>
        public void DeleteRowFrames(int Id)
        {
            framesAdapte.DeleteRow(Id);
            framesAdapte.Update(frames);
            framesAdapte.Fill(frames);
        }

        /// <summary>
        /// Обновление строки в таблице frames
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="PathBasic"></param>
        /// <param name="PathDark"></param>
        /// <param name="PathFlat"></param>
        /// <param name="Description"></param>
        /// <param name="DateAdd"></param>
        /// <param name="IdSensor"></param>
        public void ChangeRowFrames(int Id,string Name, string PathBasic, string PathDark,string PathFlat, string Description, DateTime DateAdd, int IdSensor)
        {
            framesAdapte.UpdateRow(Name, PathBasic, Description, DateAdd, IdSensor,PathDark,PathFlat,Id);
            framesAdapte.Update(frames);
            framesAdapte.Fill(frames);
        }

    }
}
