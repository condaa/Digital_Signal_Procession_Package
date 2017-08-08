using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSPUI
{
    using System.Drawing.Drawing2D;
    using DSPUI.Components;

    public partial class DSPToolbox : Form
    {
        public DSPToolbox()
        {
            InitializeComponent();
            LoadComponentsPNL();

            //SimulateExample();
        }

        private void SimulateExample()
        {
            // simulating input
            DSPUI.Components.Component sig1 = new FileInputSignal();
            sig1.Data = new FileSignalAttributes() { FilePath = @"..\..\Signal1.txt" };
            DSPUI.Components.Component sig2 = new FileInputSignal();
            sig2.Data = new FileSignalAttributes() { FilePath = @"..\..\Signal1.txt" };
            DSPUI.Components.Component adder = new Adder();
            adder.AddInputComponent(sig1);
            adder.AddInputComponent(sig2);
            //sig1.AddOutputComponent(adder);
            //sig2.AddOutputComponent(adder);
            ComponentsGraph.Add(sig1);
            ComponentsGraph.Add(sig2);
            ComponentsGraph.Add(adder);
            RunBTN_Click(null, null);
        }

        private void LoadComponentsPNL()
        {
            // Get all types in the Algorithm assembly.
            var assemblyTypes = Assembly.GetAssembly(typeof(DSPUI.Components.Component)).GetTypes();
            // Filter to the types that inherite from the abstract class Algorithm.
            var componentsTypes = assemblyTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(DSPUI.Components.Component)));
            // Loop on them..
            foreach (var component in componentsTypes)
            {
                // Initialize instances of the algorithm-based class and add them into the combobox.
                AddInToolsPNL((DSPUI.Components.Component)Activator.CreateInstance(component));
            }
        }

        List<DSPUI.Components.Component> ComponentsGraph = new List<Component>();

        int y = 0;

        private void AddInToolsPNL(DSPUI.Components.Component c)
        {
            Button b;
            ToolsPNL.Controls.Add(b = new Button()
            {
                Text = c.ToString(),
                Location = new Point(3, y == 0 ? 3 : y),
                Size = new Size(68, 22),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Tag = c.GetType()
            });

            b.Click += ComponentBTNClicked;

            y += 30;
        }

        private void ComponentBTNClicked(object sender, EventArgs e)
        {
            var buttonSender = (Button)sender;
            Component c = (DSPUI.Components.Component)Activator.CreateInstance((Type)buttonSender.Tag);
            c.Location = new Point(CanvasPBX.Width / 2 - DSPUI.Components.Component.WIDTH / 2, CanvasPBX.Height / 2 - DSPUI.Components.Component.HEIGHT / 2);
            //Image i = c.GetDrawing();
            //g.DrawImage(i, c.Location.X, c.Location.Y, DSPUI.Components.Component.WIDTH, DSPUI.Components.Component.HEIGHT);
            ComponentsGraph.Add(c);
            CanvasPBX.Invalidate();
        }

        private void RunBTN_Click(object sender, EventArgs e)
        {
            bool hasErrors = false; 

            foreach (var c in ComponentsGraph)
            {
                if (!c.ComponentReady())
                {
                    hasErrors = true;
                }
            }

            if (hasErrors)
            {
                CanvasPBX.Invalidate();
                MessageBox.Show("Kindly enter the attributes and/or inputs for the marked components.");
                return;
            }

            foreach (var c in ComponentsGraph)
            {
                if (c.GetType().Equals(typeof(FileInputSignal)))
                {
                    c.StartJob();
                }
            }
        }

        private int GetComponentContainingPoint(Point point)
        {
            for (int i = ComponentsGraph.Count - 1; i >= 0; i--)
            {
                if (ComponentsGraph[i].ComponentContainsPoint(point))
                {
                    return i;
                }
            }

            return -1;
        }

        private void CanvasPBX_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            foreach (var c in ComponentsGraph)
            {
                DrawComponent(g, c);
            }

            foreach (var c in ComponentsGraph)
            {
                foreach (var outputComponent in c.OutputComponents)
                {
                    DrawConnection(g, c.GetOutputCenterPos(), outputComponent.GetInputCenterPos());
                }
            }

            if (newConnection != null)
            {
                if (newConnection.isInputToOutput)
                {
                    DrawConnection(e.Graphics, newConnection.currentMouseLocation, newConnection.c.GetInputCenterPos());
                }
                else if (newConnection.isOutputToInput)
                {
                    DrawConnection(e.Graphics, newConnection.c.GetOutputCenterPos(), newConnection.currentMouseLocation);
                }
            }
        }

        private void DrawComponent(Graphics g, Component c)
        {
            Image i = c.GetDrawing();
            g.DrawImage(i, c.Location.X, c.Location.Y, DSPUI.Components.Component.WIDTH, DSPUI.Components.Component.HEIGHT);
        }

        private void DrawConnection(Graphics g, Point from, Point to)
        {
            Pen p = new Pen(Color.Crimson, 5);
            p.EndCap = LineCap.DiamondAnchor;
            p.StartCap = LineCap.RoundAnchor;
            g.DrawLine(p, from, to);
        }

        private void DeleteComponentFromGraph(int ind)
        {
            ComponentsGraph[ind].ClearInputOutputComponent();
            ComponentsGraph.RemoveAt(ind);
        }

        MouseDownNewConnectionInfo newConnection = null;

        private void CanvasPBX_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var ind = GetComponentContainingPoint(e.Location);

                if (ind != -1)
                {
                    DeleteComponentFromGraph(ind);
                }

                List<Component> comFrom;
                List<Component> comTo;

                GetLinesContainingPoint(e.Location, out comFrom, out comTo);

                for (int i = 0; i < comFrom.Count; i++)
                {
                    comTo[i].RemoveInputComponent(comFrom[i]);
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (newConnection != null)
                {
                    int ind = GetComponentContainingPoint(e.Location);
                    if (ind != -1)
                    {
                        if (ComponentsGraph[ind] != newConnection.c)
                        {
                            if (ComponentsGraph[ind].PointOnOutputConnection(e.Location) && newConnection.isInputToOutput)
                            {
                                if (!ComponentsGraph[ind].OutputComponents.Contains(newConnection.c) 
                                    && newConnection.c.IsValidInputComponent(ComponentsGraph[ind]))
                                {
                                    newConnection.c.AddInputComponent(ComponentsGraph[ind]);
                                }
                            }
                            else if (ComponentsGraph[ind].PointOnInputConnection(e.Location) 
                                && newConnection.isOutputToInput)
                            {
                                if (!newConnection.c.OutputComponents.Contains(ComponentsGraph[ind]) && ComponentsGraph[ind].IsValidInputComponent(newConnection.c))
                                {
                                    ComponentsGraph[ind].AddInputComponent(newConnection.c);
                                }
                            }
                        }
                    }
                }
            }

            CanvasPBX.Invalidate();
            newConnection = null;
        }

        private void GetLinesContainingPoint(Point point, out List<Component> comFrom, out List<Component> comTo)
        {
            comFrom = new List<Component>();
            comTo = new List<Component>();

            foreach (var compNode1 in ComponentsGraph)
            {
                foreach (var compNode2 in compNode1.OutputComponents)
                {
                    var p1 = compNode1.GetOutputCenterPos();
                    var p2 = compNode2.GetInputCenterPos();
                    
                    if ((point.X >= p1.X && point.X < p2.X || point.X >= p2.X && point.X < p1.X)
                        && ((point.Y >= p1.Y && point.Y < p2.Y || point.Y >= p2.Y && point.Y < p1.Y)))
                    {
                        float m = (p2.Y - p1.Y) / (float)(p2.X - p1.X);
                        float c = p1.Y - m * p1.X;

                        if ((m * point.X + c - point.Y < 2))
                        {
                            comFrom.Add(compNode1);
                            comTo.Add(compNode2);
                        }
                    }
                }
            }
        }

        private void CanvasPBX_MouseDown(object sender, MouseEventArgs e)
        {
            if (newConnection == null)
            {
                int ind = GetComponentContainingPoint(e.Location);

                if (ind != -1)
                {
                    if (ComponentsGraph[ind].PointOnInputConnection(e.Location))
                    {
                        newConnection = new MouseDownNewConnectionInfo()
                        {
                            isInputToOutput = true,
                            isOutputToInput = false,
                            isComponentToMove = false,
                            c = ComponentsGraph[ind]
                        };
                    }
                    else if (ComponentsGraph[ind].PointOnOutputConnection(e.Location))
                    {
                        newConnection = new MouseDownNewConnectionInfo()
                        {
                            isInputToOutput = false,
                            isOutputToInput = true,
                            isComponentToMove = false,
                            c = ComponentsGraph[ind]
                        };
                    }
                    else
                    {
                        newConnection = new MouseDownNewConnectionInfo()
                        {
                            isInputToOutput = false,
                            isOutputToInput = false,
                            isComponentToMove = true,
                            lastMouseLocation = e.Location,
                            c = ComponentsGraph[ind]
                        };
                    }
                }
            }

        }

        private void CanvasPBX_MouseMove(object sender, MouseEventArgs e)
        {
            if (newConnection != null)
            {
                if (newConnection.isComponentToMove)
                {
                    int dispX = e.Location.X - newConnection.lastMouseLocation.X;
                    int dispY = e.Location.Y - newConnection.lastMouseLocation.Y;
                    newConnection.c.Location = new Point(newConnection.c.Location.X + dispX, newConnection.c.Location.Y + dispY);
                    newConnection.lastMouseLocation = e.Location;
                }

                newConnection.currentMouseLocation = e.Location;
                CanvasPBX.Invalidate();
            }
        }

        private void CanvasPBX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ind = GetComponentContainingPoint(e.Location);
            ComponentsGraph[ind].ShowComponentsAttributesDialogue();
        }

        ToolTip t = new ToolTip();

        private void CanvasPBX_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = CanvasPBX.PointToClient(Cursor.Position);
            var ind = GetComponentContainingPoint(p);

            if (ind != -1)
            {
                if (ComponentsGraph[ind].PointOnWarningIcon(p))
                {
                    t.Show(ComponentsGraph[ind].ErrorMessage, CanvasPBX, p.X, p.Y, 2000);
                }
            }
        }
    }

    class MouseDownNewConnectionInfo
    {
        public bool isInputToOutput;
        public bool isOutputToInput;
        public bool isComponentToMove;
        public Point currentMouseLocation;
        public Point lastMouseLocation;
        public Component c;
    }
}