/****************************************************************************
*BSD 3 - Clause License
*
*Copyright(C) 2023, DaGoose
*All rights reserved.
*
*Redistribution and use in source and binary forms, with or without
*modification, are permitted provided that the following conditions are met:
*
*1.Redistributions of source code must retain the above copyright notice, this
*   list of conditions and the following disclaimer.
*
*2. Redistributions in binary form must reproduce the above copyright notice,
*   this list of conditions and the following disclaimer in the documentation
*   and/or other materials provided with the distribution.
*
*3. Neither the name of the copyright holder nor the names of its
*   contributors may be used to endorse or promote products derived from
*   this software without specific prior written permission.
*
*THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
*AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
*IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
*DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
*FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
*DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
*SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
*CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
*OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
*OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
****************************************************************************/

using System.Drawing;
using System.Windows.Forms;

namespace EncodeProg
{
    public partial class ProgressBarLabel : ProgressBar
    {
        /// <summary>
        /// The text to write to the ProgressBar.
        /// </summary>
        private string progressText;

        /// <summary>
        /// The color of the text in the ProgressBar.
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// The text to write to the ProgressBar.
        /// </summary>
        public string ProgressText
        {
            get
            {
                return progressText;
            }
            set
            {
                if (progressText != value)
                {
                    Invalidate();
                    progressText = value;
                }
            }
        }

        /// <summary>
        /// Overrides the message from the control.
        /// </summary>
        /// <param name="m">The message.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case 15:
                    using (var graphics = Graphics.FromHwnd(Handle))
                    {
                        DrawText(graphics);
                    }

                    break;
            }
        }

        /// <summary>
        /// Draws the text to go on the progress bar.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawText(Graphics graphics)
        {
            if (!string.IsNullOrEmpty(ProgressText))
            {
                var font = new Font("Arial", 8.25F, FontStyle.Regular,
                            GraphicsUnit.Point, 0);

                var size = graphics.MeasureString(ProgressText, font);
                var point = new PointF(Width / 2 - size.Width / 2.0F, Height / 2 - size.Height / 2.0F + 1);

                graphics.DrawString(ProgressText, font, new SolidBrush(TextColor), point);
            }
        }

        /// <summary>
        /// Overrides the WS_EX_COMPOSITED parameters to prevent the control from blinking. 
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams result = base.CreateParams;
                result.ExStyle |= 0x02000000;

                return result;
            }
        }

        /// <summary>
        /// Configuration.
        /// </summary>
        public ProgressBarLabel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
