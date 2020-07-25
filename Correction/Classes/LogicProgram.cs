using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Correction.Classes
{
    class LogicProgram
    {
       public static DataBaseLogic DataBase = new DataBaseLogic();
       CreateImg Creating = new CreateImg();

        /// <summary>
        /// Возращает откалиброванный массив байтов
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       private byte[] CorrectionFrame(int Id) 
       {
            string[] BasicS = Creating.ConverterFromFile(DataBase.frames.FindByIdFrame(Id).PathFile);
            string[] DarkS = Creating.ConverterFromFile(DataBase.frames.FindByIdFrame(Id).PathDarkFile);
            string[] FlatS = Creating.ConverterFromFile(DataBase.frames.FindByIdFrame(Id).PathFlatFile);

            float[] BasicF = Creating.ConvertToFloat(BasicS);
            float[] DarkF = Creating.ConvertToFloat(DarkS);
            float[] FlatF = Creating.ConvertToFloat(FlatS);


            float m = (FlatF.Sum() - DarkF.Sum()) / BasicF.Length; 


            float[] Correct = new float[BasicS.Length];
            float s;
            for (int i = 0; i < BasicF.Length; i++)
            {
                s = ((BasicF[i] - DarkF[i]) * m) / (FlatF[i] - DarkF[i]);

                Correct[i] = s < 0? 0:s;
            }


            try 
            {
                return Creating.ConvertToBytes(Correct);
            }
            catch 
            {
                return Creating.ConvertToBytes(Correct,63);
            }
        }

        /// <summary>
        /// Возращает изображение по пути
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
       public BitmapSource GetImg(string Path)
        {
            return Creating.GetImg(Path);
        }

        /// <summary>
        /// Возращает Light изображение по Номеру кадра
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BitmapSource GetImgBasic(int Id)
       {
            string path = DataBase.frames.FindByIdFrame(Id).PathFile;
            return Creating.GetImg(path);
       }

        /// <summary>
        /// Возращает Dark изображение по Номеру кадра
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BitmapSource GetImgDark(int Id)
        {
            string path = DataBase.frames.FindByIdFrame(Id).PathDarkFile;
            return Creating.GetImg(path);
        }

        /// <summary>
        /// Возращает Flat изображение по Номеру кадра
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BitmapSource GetImgFlat(int Id)
       {
            string path = DataBase.frames.FindByIdFrame(Id).PathFlatFile;
            return Creating.GetImg(path);
       }

        /// <summary>
        /// Возращает откалиброванное изображение по Номеру кадра
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BitmapSource GetCorrectImg(int Id) 
       {
            return Creating.GetImg(CorrectionFrame(Id));
       }
    }
}
