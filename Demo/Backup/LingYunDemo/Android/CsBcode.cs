using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;


namespace LingYunDemo.Android
{

    public enum BType
    {
        CODE39 = 1,
        EAN13 = 2,
        CODE128 = 3,
        CODE25 = 4,
        ITF25 = 5,
        UPCA = 6,
        EAN8 = 7,
        UPCE = 8,
        MATRIX25 = 9,
        EAN128 = 10,
        CODEBAR = 11,
        CODE93 = 12,
        FULLASCII39 = 13,
        PDF417 = 14,
        QRCODE = 15,
        CODE128M = 16,
        ADDON2 = 17,
        ADDON5 = 18,
        CODE128A = 19,
        CODE128B = 20,
        CODE128C = 21,
        DATAMATRIX = 22,
        GS1RSS = 23
    }

    public class Cscode
    {
        //public int Rotate=0;
        //public  int Height=100;
        public int Rotate;
        public int Height;
        //public BType type = BType.CODE39;
        public BType type;
        Bitmap bm;
        public string text;
        //**********2013.07.31*******************************
        public int Zoom;
        // public enum zoom { a = 2, b = 3 };
        // public zoom Zoom = zoom.b;
        //**************************************************

        public Cscode()
        {
        }

        public Cscode(int Rotate)
        {
            this.Rotate = Rotate;
        }
        public Cscode(int Rotate, int Height)
        {
            this.Rotate = Rotate;
            this.Height = Height;
        }
        Cscode(int Rotate, int Height, BType type)
        {
            this.Rotate = Rotate;
            this.Height = Height;
            this.type = type;
        }

        #region 从DLL中导入函数

        //  定义DLL中条码生成函数的接口

        //  生成一维条码
        [DllImport("Lap.dll", EntryPoint = "BC_MakeBarCode")]
        private static extern IntPtr DLL_MakeBarCode(int nBType, string lpszText, int nNarrow, int nWide, int nHeight, int nRotate, int nReadable, ref int err);

        //  生成 QR Code
        [DllImport("Lap.dll", EntryPoint = "BC_MakeQRCode")]
        private static extern IntPtr DLL_MakeQRCode(Byte[] lpData, int dwBytes, int nEccelvel, int nScale, int nRotate, ref int err);

        [DllImport("Lap.dll", EntryPoint = "BC_MakePDF417")]
        private static extern IntPtr DLL_MakePDF417(Byte[] lpData, int dwBytes, int nRows, int nCols, int nEccLevel, int nRotate, int xScale, int yScale, ref int err);

        [DllImport("Lap.dll", EntryPoint = "BC_MakeDMCode")]
        private static extern IntPtr DLL_MakeDMCode(Byte[] lpData, int dwBytes, int nEccelvel, int nScale, int nRotate, ref int err);

        [DllImport("Lap.dll", EntryPoint = "BC_MakeRSSCode")]
        private static extern IntPtr DLL_MakeRSSCode(Byte[] lpszText, int nNarrow, int nCurTail, int nHeight, int mode, int nRotate, int nReadable, ref int err);
        //  删除HBITMAP句柄
        /*
         * 条码生成函数的返回值全部是 HBITMAP，使用完后一定要显式的删除
         * 否则系统的GDI资源无法得到释放，最终会由于GDI资源耗尽而无法生成条码
         */
        [DllImport("Lap.dll", EntryPoint = "BC_DeleteHBitmap")]
        private static extern bool DLL_DeleteHBitmap(IntPtr hBitmap);

        #endregion

        #region 生成一维条码
        public static Bitmap MakeBarCode(BType type, string lpszText, int nNarrow, int nWide, int nHeight, int nRotate, int nReadable)
        {
            //  可在错误返回值，一般设置成0即可。如果需要函数弹出错误信息提示，可将此值设置为 3
            int err = 0;

            //  调用DLL，造成条码位图
            IntPtr hBitmap = DLL_MakeBarCode((int)type, lpszText, nNarrow, nWide, nHeight, nRotate, nReadable, ref err);

            //  需要判断返回句柄是否为空，如果为空，则表示生成位图失败
            if (hBitmap == IntPtr.Zero)
            {
                return null;
            }

            //  创建返回的Bitmap
            Bitmap bm = Bitmap.FromHbitmap(hBitmap);

            //  删除 HBITMAP句柄 （很重要，必需删除）
            DLL_DeleteHBitmap(hBitmap);

            return bm;
        }
        #endregion

        #region  生成 QRCode二维码
        public static Bitmap MakeQRCode(string lpszText, int nEccelvel, int nScale, int nRotate)
        {
            //  可在错误返回值，一般设置成0即可。如果需要函数弹出错误信息提示，可将此值设置为 3
            int err = 0;

            //  将字符串内容转换成GB2312内码字节数组
            /*
             * 下面的代码用于转换字符集
             * 由于二维码中可能包含汉字等信息，一般需要进行字符集编码的转换的处理，
             * 此处默认为使用ANSI字符集，也可以采用UTF8等形式，请根据你的实际应用进行选择
             */
            Encoding encoding = Encoding.Default;
            Byte[] bytes = encoding.GetBytes(lpszText);

            //  调用DLL，造成条码位图
            IntPtr hBitmap = DLL_MakeQRCode(bytes, bytes.Length, nEccelvel, nScale, nRotate, ref err);

            //  需要判断返回句柄是否为空，如果为空，则表示生成位图失败
            if (hBitmap == IntPtr.Zero)
            {
                return null;
            }

            //  创建返回的Bitmap
            Bitmap bm = Bitmap.FromHbitmap(hBitmap);

            //  删除 HBITMAP句柄 （很重要，必需删除）
            DLL_DeleteHBitmap(hBitmap);

            return bm;
        }
        #endregion

        #region 生成PDF417码
        public static Bitmap MakePDF417(string lpszText, int nRows, int nCols, int nEccLevel, int nRotate, int xScale, int yScale)
        {
            int err = 0;

            Encoding encoding = Encoding.Default;
            Byte[] bytes = encoding.GetBytes(lpszText);

            IntPtr hBitmap = DLL_MakePDF417(bytes, bytes.Length, nRows, nCols, nEccLevel, nRotate, xScale, yScale, ref err);
            if (hBitmap == IntPtr.Zero)
            {
                return null;
            }
            Bitmap bm = Bitmap.FromHbitmap(hBitmap);

            //  删除 HBITMAP句柄 （很重要，必需删除）
            DLL_DeleteHBitmap(hBitmap);

            return bm;

        }

        #endregion

        #region 生成DM码
        public static Bitmap MakeDMCode(string lpszText, int nEccelvel, int nScale, int nRotate)
        {
            int err = 0;
            Encoding encoding = Encoding.Default;
            Byte[] bytes = encoding.GetBytes(lpszText);

            IntPtr hBitmap = DLL_MakeDMCode(bytes, bytes.Length, nEccelvel, nScale, nRotate, ref err);

            if (hBitmap == IntPtr.Zero)
            {
                return null;
            }

            Bitmap bm = Bitmap.FromHbitmap(hBitmap);

            //  删除 HBITMAP句柄 （很重要，必需删除）
            DLL_DeleteHBitmap(hBitmap);

            return bm;
        }
        #endregion

        #region 生成RSS码
        public static Bitmap MakeRSSCode(string lpszText, int nNarrow, int nCurTail, int nHeight, int mode, int nRotate, int nReadable)
        {
            int err = 0;
            Encoding encoding = Encoding.Default;
            Byte[] bytes = encoding.GetBytes(lpszText);
            IntPtr hBitmap = DLL_MakeRSSCode(bytes, nNarrow, nCurTail, nHeight, mode, nRotate, nReadable, ref err);

            if (hBitmap == IntPtr.Zero)
            {
                return null;
            }

            //  创建返回的Bitmap
            Bitmap bm = Bitmap.FromHbitmap(hBitmap);

            //  删除 HBITMAP句柄 （很重要，必需删除）
            DLL_DeleteHBitmap(hBitmap);

            return bm;

        }
        #endregion

        #region  生成图片
        public Bitmap PictureShow(int nNarrow, int nWide, int nHeight)
        {
            // Rotate = 0;
            if (type == BType.CODE39 || type == BType.EAN13 || type == BType.CODE128 || type == BType.CODE25 || type == BType.ITF25 ||
                type == BType.UPCA || type == BType.EAN8 || type == BType.UPCE || type == BType.MATRIX25 || type == BType.EAN128 ||
                type == BType.CODEBAR || type == BType.CODE93 || type == BType.FULLASCII39 || type == BType.CODE128M ||
                type == BType.CODE128A || type == BType.CODE128B || type == BType.CODE128C || type == BType.ADDON2 || type == BType.ADDON5)
            {
                bm = MakeBarCode(type, this.text, nNarrow, nWide, nHeight, Rotate, 3);

            }
            if (type == BType.QRCODE)
            {
                //bm = MakeQRCode("翰扬条码技术有限公司12345678", 1, 4, Rotate);
                bm = MakeQRCode(this.text, 1, 4, Rotate);
            }
            if (type == BType.PDF417)
            {
                //bm = MakePDF417("翰扬条码技术有限公司12345678", 0, 0, 2, Rotate , 2, 2);
                bm = MakePDF417(this.text, 0, 0, 2, Rotate, 2, 2);
            }
            if (type == BType.DATAMATRIX)
            {
                //bm = MakeDMCode("翰扬条码技术有限公司12345678", 2, 4, Rotate );
                bm = MakeDMCode(this.text, 2, 4, Rotate);
            }
            if (type == BType.GS1RSS)
            {
                //bm = MakeRSSCode("12345678", 2, 0, Height , 0, Rotate, 3);
                bm = MakeRSSCode(this.text, 2, 0, Height, 0, Rotate, 3);
            }
            return bm;
        }
        #endregion


    }

}