using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace LingYunDemo.Android
{
    class CsPrint
    {
        PrintPageEventHandler printpage;
        public List<string> bartext;
        protected int numOfEveryLabel = 1;
        private int j = 0;

        private int labelNumX = 1;
        private int labelNumY = 4;

        public void print()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdm = new PrintDocument();

            printpage += doprint;
            pdm.PrintPage += new PrintPageEventHandler(printpage);
            pd.Document = pdm;
            pd.ShowDialog();
            pdm.Print();
        }

        private void doprint(object sender, PrintPageEventArgs e)
        {
            Cscode cscode = new Cscode();
            Bitmap BarCodeImg;
            cscode.text = "A1011";
            cscode.type = BType.CODE39;
            cscode.Height = 200;
            int nAccuracy = 10;
            int nZoom = 3;
            int n_Narrow = (int)(nAccuracy * 0.254);
            if (n_Narrow < 1)
            {
                n_Narrow = 1;
            }
            int n_Wide = n_Narrow * nZoom;

            //行列条码个数
            int x = 0;
            int y = labelNumY;
            bool a = false;
            bool b = true;

        mylabelT:
            foreach (string tx in bartext)
            {
                cscode.text = tx;
                BarCodeImg = cscode.PictureShow(n_Narrow, n_Wide, cscode.Height);
                //e.Graphics.DrawImageUnscaled(BarCodeImg, 10, 10);
                int PaperLeft = 30;
                int PaperTop = 30;
                int labelHeight = BarCodeImg.Height;
                int labelWidth = BarCodeImg.Width;
                int labelDisY = 30;
                int labelDisX = 30;


                //计算当前标签还该打印的次数
                int count = numOfEveryLabel - j;
                for (int i = 0; i < count; i++)
                {

                    #region 只能打一列的时候
                    if (labelNumX == 1 && y >= 1)
                    {
                        e.Graphics.DrawImage(BarCodeImg, PaperLeft, (int)((y - 1) * (labelHeight + labelDisY)) + PaperTop, labelWidth, labelHeight);
                        y--;
                        j++;

                        //当前打印完 
                        if (j == numOfEveryLabel)
                        {
                            //移除当前记录
                            bartext.Remove(tx);

                            //当前打印完 且行没打完，直接打印
                            if (y != 0)
                            {
                                j = 0;
                                goto mylabelT;
                            }

                            //当前打印完，且行打印完 换页
                            else
                            {
                                j = 0;
                                e.HasMorePages = true;
                                return;
                            }
                        }

                        //当前还没打印完
                        else
                        {
                            //当前没打印完但是行用完
                            if (y == 0)
                            {
                                e.HasMorePages = true;
                                return;
                            }
                            //

                        }

                    }
                    #endregion

                    #region 能打印多列
                    if (labelNumX > 1)
                    {
                        if (b == true)
                        {
                            while (y >= 0)
                            {
                                e.Graphics.DrawImage(BarCodeImg, x * (labelWidth + labelDisX) + PaperLeft, (int)((y - 1) * (labelHeight + labelDisY)) + PaperTop, labelWidth, labelHeight);
                                j++;
                                x++;

                                #region 该类打印完
                                if (j == numOfEveryLabel)
                                {
                                    j = 0;
                                    bartext.Remove(tx);

                                    //该类打印完且列打印完
                                    if (x == labelNumX)
                                    {
                                        x = 0;
                                        a = false;
                                        b = true;
                                        y++;
                                        if (y == 0)
                                        {
                                            y = labelNumY;
                                            e.HasMorePages = true;
                                            return;
                                        }
                                        goto mylabelT;
                                    }

                                    //该类打完 列未打完
                                    else
                                    {
                                        a = true;
                                        b = false;
                                        goto mylabelT;
                                    }
                                }
                                #endregion

                                #region 该类没打印完
                                else
                                {   //该类未打完 列打完                        
                                    if (x == labelNumX)
                                    {
                                        x = 0;
                                        a = false;
                                        b = true;
                                        y--;
                                        //行打完
                                        if (y == 0)
                                        {
                                            y = labelNumY;
                                            e.HasMorePages = true;
                                            return;
                                        }
                                    }
                                    //类没打完 列没打完
                                    else
                                    {
                                        a = true;
                                        b = false;
                                    }
                                }
                                #endregion

                                break;
                            }

                        }


                        if (a == true)
                        {
                            while (x <= labelNumX)
                            {


                                e.Graphics.DrawImage(BarCodeImg, (int)(x * (labelWidth + labelDisX)) + PaperLeft, (int)((y - 1) * (labelHeight + labelDisY)) + PaperTop, labelWidth, labelHeight);
                                j++;
                                x++;

                                #region 该类标签打印完
                                if (j == numOfEveryLabel)
                                {

                                    j = 0;


                                    bartext.Remove(tx);

                                    //该类打印完且列打印完
                                    if (x == labelNumX)
                                    {
                                        x = 0;
                                        a = false;
                                        b = true;
                                        y--;
                                        if (y == 0)
                                        {
                                            y = labelNumY;
                                            e.HasMorePages = true;
                                            return;
                                        }
                                        goto mylabelT;

                                    }
                                    //该类打印完 列未打印完
                                    else
                                    {
                                        a = true;
                                        b = false;
                                        goto mylabelT;
                                    }
                                }
                                #endregion

                                #region 该类没打印完
                                else
                                {
                                    //该类没打印完 但是列打印完
                                    if (x == labelNumX)
                                    {
                                        x = 0;
                                        a = false;
                                        b = true;
                                        y--;
                                        if (y == 0)
                                        {
                                            y = labelNumY;
                                            e.HasMorePages = true;
                                            return;
                                        }
                                    }
                                    //类没打完 列没打完
                                    else
                                    {
                                        a = true;
                                        b = false;
                                    }
                                }
                                #endregion

                                break;
                            }

                        }





                    }
                    #endregion

                }


            }


        }

        public void printpreview()
        {
            PrintPreviewDialog ppv = new PrintPreviewDialog();
            PrintDocument pdm = new PrintDocument();
            pdm.PrintPage += new PrintPageEventHandler(doprint);
            printpage += doprint;
            ppv.Document = pdm;
            ppv.ShowDialog();
        }

    }
}
