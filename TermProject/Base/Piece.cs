using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 棋子类，属性包括位置和颜色
    /// </summary>
    [Serializable]
    public class Piece
    {
        private Color color;
        private int x;
        private int y;
        //构造函数
        public Piece(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }
        //设置及获取颜色
        public Color getcolor() { return color; }
        public Color getoppositecolor()
        {
            if (color == Color.Black)
                return Color.White;
            else if (color == Color.White)
                return Color.Black;
            return Color.Black;
        }
        public void setcolor(Color color) { this.color = color; }
        public void setcolor(string color) 
        {
            switch (color) 
            {
                case "White":
                    this.color = Color.White;
                    break;
                case "Black":
                    this.color = Color.Black;
                    break;
                case "None":
                    this.color = Color.None;
                    break;
            }

        }
        //获取位置
        public int getx() { return x; }
        public int gety() { return y; }
        //清除
        public void clear()
        {
            this.color = Color.None;
        }
        //打印
        public override string ToString()
        {
            string s = ""+x.ToString()+","+y.ToString()+","+color.ToString();
            return s;
        }
    }
    /// <summary>
    /// 棋子颜色的枚举类型（无色/黑色/白色）
    /// </summary>
    public enum Color
    { 
        None, Black, White
    }
    /// <summary>
    /// 克隆，防止某些函数调用时改变传入的引用类型参数
    /// </summary>
    public class Clone
    {
        public static object clone(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            ms.Seek(0, 0);
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
}
