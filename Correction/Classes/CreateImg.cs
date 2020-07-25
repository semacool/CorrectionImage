using Correction.DataBase.InfoSensDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Correction.Classes
{
    class CreateImg
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        string path { get; set; }
       
        public CreateImg() 
        {
        }

        /// <summary>
        /// Вернуть изображение
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public BitmapSource GetImg(string Path) 
        {
            path = Path;
            byte[] Arr;
            int Size;
            try 
            {
                Arr = ConvertToBytes(ConvertToFloat(ConverterFromFile(Path)));
            }
            catch 
            {
                Arr = ConvertToBytes(ConvertToFloat(ConverterFromFile(Path)),63);
            }

            Size = (int)Math.Sqrt(Arr.Length);
            return BitmapSource.Create(Size, Size, Size, Size, PixelFormats.Gray8,null, Arr, Size);
        }

        /// <summary>
        /// Вернуть массив строк из файла
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string[] ConverterFromFile(string Path) 
        {
            path = Path;
            string[] pixelS = File.ReadAllText(path).Replace('.', ',').Split(' ');
            return pixelS;
        }

        /// <summary>
        /// Вернуть изображение из массива байтов
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        public BitmapSource GetImg(byte[] Arr)
        {
            int Size = (int)Math.Sqrt(Arr.Length);
            return BitmapSource.Create(Size, Size, Size, Size, PixelFormats.Gray8, null, Arr, Size);
        }

        /// <summary>
        /// Вернуть массив Float из массива строк
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public float[] ConvertToFloat(string[] pixels) 
        {
            float[] Arr = new float[pixels.Length];

            for (int i = 0; i < pixels.Length; i++)
            {
                Arr[i] = float.Parse(pixels[i]);
            }

            return Arr;
        }

        /// <summary>
        /// Вернуть массив байтов из массива Float
        /// </summary>
        /// <param name="raw"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(float[] raw, int max =1)
        {
            byte[] arr = new byte[raw.Length];

            for (int j = 0; j < raw.Length; j++)
            {
                arr[j] = byte.Parse(Math.Round(raw[j] * 255 / max).ToString());
            }

            return arr;
        }
    }
}
