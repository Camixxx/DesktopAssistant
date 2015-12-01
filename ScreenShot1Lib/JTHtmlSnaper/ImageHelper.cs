using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenShot1Lib
{
    public static class ImageHelper
    {
 
        /// <summary>
        /// ��ȡ����ͼ
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image GetThumbnailImage(Image image, int width, int height)
        {
            if (image == null || width < 1 || height < 1)
                return null;

            // �½�һ��bmpͼƬ
            //
            Image bitmap = new System.Drawing.Bitmap(width, height);

            // �½�һ������
            //
            using (Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            {

                // ���ø�������ֵ��
                //
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // ���ø�����,���ٶȳ���ƽ���̶�
                //
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                
                // �����������ٶȸ���
                //
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // ��ջ�������͸������ɫ���
                //
                g.Clear(Color.Transparent);

                // ��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
                //
                g.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height),
                    GraphicsUnit.Pixel);

                return bitmap;
            }
        }

        /// <summary>
        /// ��������ͼ���������ݺ��
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>��������ͼ�����</returns>
        public static Image GetThumbnailImageKeepRatio(Image image, int width, int height)
        {
            Size imageSize = GetImageSize(image, width, height);
            return GetThumbnailImage(image, imageSize.Width, imageSize.Height);
        }

        /// <summary>
        /// ���ݰٷֱȻ�ȡͼƬ�ĳߴ�
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static Size GetImageSize(Image picture, int percent)
        {
            if (picture == null || percent < 1)
                return Size.Empty;

            int width = picture.Width * percent / 100;
            int height = picture.Height * percent / 100;

            return GetImageSize(picture, width, height);
        }

        /// <summary>
        /// �����趨�Ĵ�С����ͼƬ�Ĵ�С������ͼƬ����ı�������
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Size GetImageSize(Image picture, int width, int height)
        {
            if (picture == null || width < 1 || height < 1)
                return Size.Empty;

            Size imageSize;

            imageSize = new Size(width, height);

            double heightRatio = (double)picture.Height / picture.Width;
            double widthRatio = (double)picture.Width / picture.Height;

            int desiredHeight = imageSize.Height;
            int desiredWidth = imageSize.Width;


            imageSize.Height = desiredHeight;
            if (widthRatio > 0)
                imageSize.Width = Convert.ToInt32(imageSize.Height * widthRatio);

            if (imageSize.Width > desiredWidth)
            {
                imageSize.Width = desiredWidth;
                imageSize.Height = Convert.ToInt32(imageSize.Width * heightRatio);
            }

            return imageSize;
        }


        /// <summary>
        /// ��ȡͼ���������������������Ϣ
        /// </summary>
        /// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) ���͵��ַ���</param>
        /// <returns>����ͼ���������������������Ϣ</returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo icf in encoders)
            {
                if (icf.FormatID == format.Guid)
                {
                    return icf;
                }
            }

            return null;
        }

        public static void SaveImage(Image image, string savePath, ImageFormat format)
        {
            SaveImage(image, savePath, GetImageCodecInfo(format));
        }

        /// <summary>
        /// ����������ͼƬ
        /// </summary>
        /// <param name="image"></param>
        /// <param name="savePath"></param>
        /// <param name="ici"></param>
        private static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            // ���� ԭͼƬ ����� EncoderParameters ����
            //
            EncoderParameters parms = new EncoderParameters(1);
            EncoderParameter parm = new EncoderParameter(Encoder.Quality, ((long)95));
            parms.Param[0] = parm;

            image.Save(savePath, ici, parms);
            parms.Dispose();
        }

    }
}
