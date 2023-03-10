using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    /// <summary>
    /// 绘图类
    /// </summary>
    public class Draw
    {
        private Board board;
        private Strategy mode;
        private Graphics g;
        private int unit = 20;//棋盘格边长
        private int size;
        int lefttop;//棋盘顶点位置（x=y）
        int r;//棋子半径
        public Draw(Board board,Graphics g) 
        { 
            this.board = board; 
            this.size = board.getsize();
            this.mode = board.getstrategy();
            this.g = g;
            g.CompositingMode = CompositingMode.SourceCopy;
            lefttop =220 - (size - 1) * unit / 2;
            r = 5;
        }
        /// <summary>
        /// 棋盘更新
        /// </summary>
        public void update()
        {
            this.size = board.getsize();
            this.mode = board.getstrategy();
            lefttop = 220 - (size - 1) * unit / 2;
            g.Clear(System.Drawing.Color.LightSteelBlue);
        }
        /// <summary>
        /// 绘制棋盘
        /// </summary>
        public void drawboard()
        {
            //创建粗笔和细笔
            Pen thickPen = new Pen(System.Drawing.Color.Black, 2);
            Pen thinPen = new Pen(System.Drawing.Color.Black, (float)1.5);
            //绘制粗外边框
            int lefttopx = lefttop;
            int lefttopy = lefttopx;
            if (mode is ReversiStrategy)
                size++;
            g.DrawRectangle(thickPen, new Rectangle(lefttopx,lefttopy, (size - 1) * unit, (size - 1) * unit));
            //绘制横轴竖轴            
            for (int i = 1; i < size; i++)
            {
                g.DrawLine(thinPen, new Point(lefttopx, lefttopy + i * unit),
                                   new Point(lefttopx + (size-1) * unit, lefttopy + i * unit));
            }
            for (int i = 1; i < size; i++)
            {
                g.DrawLine(thinPen, new Point(lefttopx + i*unit, lefttopy),
                                   new Point(lefttopx + i * unit, lefttopy+(size-1)*unit));
            }
            if (mode is ReversiStrategy)
                size--;
            //绘制棋子
            SolidBrush brushblack = new SolidBrush(System.Drawing.Color.Black);
            SolidBrush brushwhite = new SolidBrush(System.Drawing.Color.White);
            g.FillEllipse(brushblack, 170, 430, 20, 20);
            g.FillEllipse(brushwhite, 270, 430, 20, 20);
            drawpieces();
            showturn(board.getturns());
        }
        /// <summary>
        /// 指示当前执棋方
        /// </summary>
        /// <param name="turns"></param>
        public void showturn(int turns)
        {
            SolidBrush brushb = new SolidBrush(System.Drawing.Color.Blue);
            SolidBrush brushw = new SolidBrush(System.Drawing.Color.White);
            Pen bluePen = new Pen(System.Drawing.Color.Blue, 2);
            Pen whitePen = new Pen(System.Drawing.Color.White, 2);
            //指示轮到白子
            if (turns%2!=0)
            {                
                Point[] points = new Point[3] { new Point(280, 455), new Point(278, 465), new Point(282, 465) };
                g.FillClosedCurve(brushb, points);
                points = new Point[3] { new Point(180, 455), new Point(177, 465), new Point(183, 465) };
                g.FillClosedCurve(brushw, points);
                g.DrawLine(bluePen,432, 323, 432, 323+50+4);
                g.DrawLine(whitePen, 432, 263, 432, 263+50 + 4);
            }
            else//轮到黑子
            {                
                Point[] points = new Point[3] { new Point(180, 455), new Point(177, 465), new Point(183, 465) };
                g.FillClosedCurve(brushb, points);
                points = new Point[3] { new Point(280, 455), new Point(278, 465), new Point(282, 465) };
                g.FillClosedCurve(brushw, points);
                g.DrawLine(whitePen, 432, 323, 432, 323 + 50 + 4);
                g.DrawLine(bluePen, 432, 263, 432, 263 + 50 + 4);
            }

        }
        /// <summary>
        /// 绘制棋子
        /// </summary>
        /// <param name="p"></param>
        /// <param name="g"></param>
        public void drawpiece(int x,int y,Color color)
        {
            int X;
            int Y;
            getcoordinate(x, y, out X, out Y);
            //画黑棋
            if (color== Color.Black)
            {
                SolidBrush brushblack = new SolidBrush(System.Drawing.Color.Black);
                g.FillEllipse(brushblack, X, Y, 2*r,2*r);
            }
            else if(color== Color.White)//画白棋
            {
                SolidBrush brushwhite = new SolidBrush(System.Drawing.Color.White);
                g.FillEllipse(brushwhite, X, Y, 2 * r, 2 * r);
            }
            else if(color == Color.None)//无子覆盖
            {
                
                SolidBrush brushcover = new SolidBrush(System.Drawing.Color.LightSteelBlue);
                g.FillEllipse(brushcover, X, Y, 2 * r, 2 * r);
            }
        }
        public void drawpiece(Piece piece)
        {
            int x = piece.getx();
            int y = piece.gety();
            Color color = piece.getcolor();
            drawpiece(x, y, color);
        }
        /// <summary>
        /// 绘制当前棋局
        /// </summary>
        public void drawpieces()
        {
            Piece[,] pieces = board.getpieces();
            Piece temp;
            SolidBrush brushblack = new SolidBrush(System.Drawing.Color.Black);
            SolidBrush brushwhite = new SolidBrush(System.Drawing.Color.White);
            for (int i =0;i<size;i++)
            {
                for(int j = 0; j<size;j++)
                {
                    temp = pieces[i, j]; 
                    drawpiece(temp);
                }
            }
        }
        public void drawpieces(List<Piece> pieces)
        {
            if (pieces == null)
                return;
            if(pieces.Count == 0) return;
            foreach (Piece p in pieces)
                drawpiece(p);
        }
        /// <summary>
        /// 判断点是否在棋盘内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool withinboard(int x, int y)
        {
            bool inboard = false;
            int lefttopx = lefttop;
            int lefttopy = lefttopx;
            int rightbottomx = lefttopx+ (mode is ReversiStrategy?size:size-1)*unit;
            int rightbottomy = rightbottomx;
            if(x>=lefttopx&& x<=rightbottomx&&y>=lefttopy&&y<=rightbottomy)
            {
                inboard = true;
            }
            return inboard;
        }
        /// <summary>
        /// 获取拾取点最近棋盘格点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void getlocation(int x, int y, out int X, out int Y)
        {
            X = 0;Y = 0;
            int x_ = x- lefttop;
            int xc = x_/unit;
            double xd = ((double)x_ )/ unit;
            int y_ = y - lefttop;
            int yc = y_ / unit;
            double yd = ((double)y_) / unit;
            double[] ds = new double[4];
            //黑白棋是看落在（0，0）到（7，7）哪个格内
            if(mode is ReversiStrategy)
            {
                X=xc; Y=yc;return;
            }
            //围棋/五子棋看选点离哪个角点最近
            ds[0] = (xd - (double)xc)* (xd - (double)xc)+ (yd - (double)yc)* (yd - (double)yc);
            ds[1] = (xd - (double)xc-1.0)* (xd - (double)xc - 1.0)+ (yd - (double)yc) * (yd - (double)yc);
            ds[2] = (xd - (double)xc - 1.0) * (xd - (double)xc - 1.0)+ (yd - (double)yc - 1.0)* (yd - (double)yc - 1.0);
            ds[3] = (xd - (double)xc) * (xd - (double)xc)+(yd - (double)yc - 1.0) * (yd - (double)yc - 1.0);
            int min = 0;
            for(int i = 0;i<4;i++)
            {
                if (ds[i] == ds.Min())
                {
                    min = i;
                    break;
                }
            }
            switch (min)
            {
                case 0:
                    {
                        X = xc; Y = yc;
                        break;
                    }
                case 1:
                    {
                        X = xc + 1; Y = yc;
                        break;
                    }
                case 2:
                    {
                        X = xc + 1; Y = yc + 1;
                        break;
                    }
                case 3:
                    {
                        X = xc; Y = yc + 1;
                        break;
                    }
            }
        }
        public void getcoordinate(int x, int y, out int X, out int Y)
        {
            if(mode is ReversiStrategy)
            {
                X = (2 * x + 1) * unit / 2 + lefttop-r;
                Y = (2 * y + 1) * unit / 2 + lefttop-r;
                return;
            }
            X = x * unit + lefttop - r;
            Y = y * unit + lefttop - r;
        }
    }
 }
