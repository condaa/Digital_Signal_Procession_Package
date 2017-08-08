namespace DSPUI.Components
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using DSPAlgorithms.Algorithms;

    public abstract class ComponentAttributes
    {
    }

    public abstract class Component
    {
        #region UIsection
        private Point _Location = new Point(10, 10);
        public Point Location { get { return _Location; } set { _Location = value; } }
        public const int WIDTH = 100;
        public const int HEIGHT = 75;
        private const int INPUT_CIRCLE_START_X = 5;
        private const int INPUT_CIRCLE_START_Y = 5;
        private const int INPUT_CIRCLE_WIDTH = 20;
        private const int INPUT_CIRCLE_HEIGHT = 20;
        private const int OUTPUT_CIRCLE_START_X = 75;
        private const int OUTPUT_CIRCLE_START_Y = 50;
        private const int OUTPUT_CIRCLE_WIDTH = 20;
        private const int OUTPUT_CIRCLE_HEIGHT = 20;
        private const int WARNING_IMG_START_X = 75;
        private const int WARNING_IMG_START_Y = 5;
        private const int WARNING_IMG_WIDTH = 20;
        private const int WARNING_IMG_HEIGHT = 20;
       
        public Image GetDrawing()
        {
            Bitmap b = new Bitmap(WIDTH + 1, HEIGHT + 1);
            Graphics g = Graphics.FromImage(b);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            g.FillRectangle(Brushes.White, 0, 0, WIDTH, HEIGHT);
            
            var BorderPencil = new Pen(Brushes.Blue);
            
            if (ErrorMessage != "")
                BorderPencil = new Pen(Brushes.Red, 3);

            g.DrawRectangle(BorderPencil, 0, 0, WIDTH, HEIGHT);
            g.DrawString(ToString().PadLeft(11), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, 10, HEIGHT / 2 - 5);
            if (AcceptsInput())
                g.FillEllipse(Brushes.LightBlue, INPUT_CIRCLE_START_X, INPUT_CIRCLE_START_Y, INPUT_CIRCLE_WIDTH, INPUT_CIRCLE_HEIGHT);
            if (AcceptsOutput())
                g.FillEllipse(Brushes.LightBlue, OUTPUT_CIRCLE_START_X, OUTPUT_CIRCLE_START_Y, OUTPUT_CIRCLE_WIDTH, OUTPUT_CIRCLE_HEIGHT);
            if (ErrorMessage != "")
                g.DrawImage(new Bitmap(new Bitmap("Media/Warning.png"),new Size(WARNING_IMG_WIDTH, WARNING_IMG_WIDTH)), WARNING_IMG_START_X, WARNING_IMG_START_Y);
            return b;
        }
        public Point GetInputCenterPos()
        {
            return new Point
            {
                X = _Location.X + INPUT_CIRCLE_START_X + INPUT_CIRCLE_WIDTH / 2,
                Y = _Location.Y + INPUT_CIRCLE_START_Y + INPUT_CIRCLE_HEIGHT / 2
            };
        }
        public Point GetOutputCenterPos()
        {
            return new Point
            {
                X = _Location.X + OUTPUT_CIRCLE_START_X + OUTPUT_CIRCLE_WIDTH / 2,
                Y = _Location.Y + OUTPUT_CIRCLE_START_Y + OUTPUT_CIRCLE_HEIGHT / 2
            };
        }

        public bool PointOnInputConnection(Point point, bool relativePosition = false)
        {
            if (!AcceptsInput())
                return false;

            if (!relativePosition)
            {
                point.X = point.X - _Location.X;
                point.Y = point.Y - _Location.Y;
            }

            return point.X >= INPUT_CIRCLE_START_X && point.Y >= INPUT_CIRCLE_START_Y
                  && point.X <= INPUT_CIRCLE_START_X + INPUT_CIRCLE_WIDTH && point.Y <= INPUT_CIRCLE_START_Y + INPUT_CIRCLE_HEIGHT;
        }
        public bool PointOnOutputConnection(Point point, bool relativePosition = false)
        {
            if (!AcceptsOutput())
                return false;

            if (!relativePosition)
            {
                point.X = point.X - _Location.X;
                point.Y = point.Y - _Location.Y;
            }

            return point.X >= OUTPUT_CIRCLE_START_X && point.Y >= OUTPUT_CIRCLE_START_Y
                  && point.X <= OUTPUT_CIRCLE_START_X + OUTPUT_CIRCLE_WIDTH && point.Y <= OUTPUT_CIRCLE_START_Y + OUTPUT_CIRCLE_HEIGHT;
        }
        public bool PointOnWarningIcon(Point point, bool relativePosition = false)
        {
            if (ErrorMessage == "")
                return false;

            if (!relativePosition)
            {
                point.X = point.X - _Location.X;
                point.Y = point.Y - _Location.Y;
            }

            return point.X >= WARNING_IMG_START_X && point.Y >= WARNING_IMG_START_Y
                  && point.X <= WARNING_IMG_START_X + WARNING_IMG_WIDTH && point.Y <= WARNING_IMG_START_Y + WARNING_IMG_HEIGHT;
        }
        public bool ComponentContainsPoint(Point point)
        {
            return point.X >= Location.X && point.X <= Location.X + WIDTH && point.Y >= Location.Y && point.Y <= Location.Y + HEIGHT;
        }
        #endregion

        private int ReceivedInputs;

        public string Name;
        public string ErrorMessage = "";
        public int NumOfRequireInputsToFinish { get; set; }
        public List<Component> InputComponents { get; set; }
        public List<Component> OutputComponents { get; set; }
        public ComponentAttributes Data { get; set; }
        //public Algorithm Solver;

        public void NotifyInputReady()
        {
            if (++ReceivedInputs == NumOfRequireInputsToFinish)
            {
                ReceivedInputs = 0;
                StartJob();
            }
        }
        public void NotifyAllComponentOutputReady()
        {
            foreach (var c in this.OutputComponents)
            {
                Debug.WriteLine(" [" + this.Name + "] is notifying [" + c.Name + "] that input is ready.");
                c.NotifyInputReady();
            }
        }
        public void AddInputComponent(Component c)
        {
            if (this.InputComponents == null)
                this.InputComponents = new List<Component>();

            //if (c.GetType().Equals(typeof(FileInputSignal)))
                NumOfRequireInputsToFinish++;

            this.InputComponents.Add(c);

            if (c.OutputComponents == null)
                c.OutputComponents = new List<Component>();

            c.OutputComponents.Add(this);
        }
        public void RemoveInputComponent(Component c)
        {
            if (this.InputComponents == null)
                return;

            if (this.InputComponents.Remove(c))
            {
                if (c.GetType().Equals(typeof(FileInputSignal)))
                    NumOfRequireInputsToFinish--;

                if (c.OutputComponents != null)
                    c.OutputComponents.Remove(this);
            }
        }
        public void ClearInputOutputComponent()
        {
            foreach (var i in InputComponents)
            {
                i.OutputComponents.Remove(this);
            }
            InputComponents.Clear();

            foreach (var o in OutputComponents)
            {
                o.InputComponents.Remove(this);
            }
            OutputComponents.Clear();
        }

        public abstract bool IsValidInputComponent(Component c);
        public abstract bool ComponentReady();
        public abstract void StartJob();
        public abstract void ShowComponentsAttributesDialogue();
        public virtual bool AcceptsInput() 
        { 
            return true; 
        }
        public virtual bool AcceptsOutput() 
        { 
            return true; 
        }
    }
}