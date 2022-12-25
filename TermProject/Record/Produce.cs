using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Accord.Video.FFMPEG;
using System.Windows.Forms;

namespace TermProject
{
    public class Produce
    {

        /// <summary>
        /// 截屏工具
        /// </summary>
        private Accord.Video.ScreenCaptureStream screenShot;
        /// <summary>
        /// 截屏转视频工具
        /// </summary>
        private Accord.Video.FFMPEG.VideoFileWriter videoWriter;
        /// <summary>
        /// 录屏区域
        /// </summary>
        private int left;
        private int top;
        private int width;
        private int height;
        /// <summary>
        /// 存储路径
        /// </summary>
        private string path;
        private bool ison;
        /// <summary>
        /// 初始化屏幕截图工具
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="path"></param>
        public Produce(int left, int top, int width, int height, string path)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.path = path;
            screenShot = new Accord.Video.ScreenCaptureStream(new Rectangle(left, top, width, height));
            videoWriter = new Accord.Video.FFMPEG.VideoFileWriter();
        }
        /// <summary>
        /// 开始录屏
        /// </summary>
        public void start()
        {
            videoWriter.Open(path, width, height, 25, VideoCodec.MSMPEG4v3, 4000 * 1024);
            screenShot.FrameInterval = 40;
            screenShot.NewFrame += (s, e1) =>
            {
                videoWriter.WriteVideoFrame(e1.Frame);
            };
            screenShot.Start();
            ison=true;
        }
        /// <summary>
        /// 结束录屏
        /// </summary>
        public void stop()
        {
            screenShot.Stop();
            /*停止视频写入*/
            videoWriter.Close();
            ison=false;
        }
        /// <summary>
        /// 获取当前录制状态
        /// </summary>
        /// <returns></returns>
        public bool getstate() { return ison; } 
    }
}
