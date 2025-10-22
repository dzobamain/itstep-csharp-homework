using System;
using System.Drawing;
using System.Windows.Forms;

namespace SketchBoard
{
    public partial class Form1 : Form
    {
        private string selectedShape = "Rectangle";
        private Color selectedColor = Color.Black;
        private int shapeWidth = 10;
        private int shapeHeight = 10;
        private bool isDrawing = false;

        public Form1()
        {
            InitializeComponent();

            ToolStrip toolStrip = new ToolStrip();

            // Forms
            ToolStripLabel formsLabel = new ToolStripLabel("Forms:");
            formsLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            toolStrip.Items.Add(formsLabel);

            ToolStripButton rectangleButton = new ToolStripButton("Rectangle");
            rectangleButton.Click += (s, e) => { selectedShape = "Rectangle"; };
            toolStrip.Items.Add(rectangleButton);

            ToolStripButton ellipseButton = new ToolStripButton("Ellipse");
            ellipseButton.Click += (s, e) => { selectedShape = "Ellipse"; };
            toolStrip.Items.Add(ellipseButton);

            ToolStripButton triangleButton = new ToolStripButton("Triangle");
            triangleButton.Click += (s, e) => { selectedShape = "Triangle"; };
            toolStrip.Items.Add(triangleButton);
            // ;

            // Tools
            ToolStripLabel toolsLabel = new ToolStripLabel("Tools:");
            toolsLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            toolStrip.Items.Add(toolsLabel);

            ToolStripButton colorButton = new ToolStripButton("Color");
            colorButton.Click += (s, e) =>
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedColor = colorDialog.Color;
                    }
                }
            };
            toolStrip.Items.Add(colorButton);

            ToolStripButton sizeButton = new ToolStripButton("Size");
            sizeButton.Click += (s, e) =>
            {
                using (Form sizeForm = new Form())
                {
                    sizeForm.Text = "Set Size";
                    sizeForm.Size = new Size(200, 150);

                    Label widthLabel = new Label() { Text = "Width:", Left = 10, Top = 10, Width = 50 };
                    TextBox widthBox = new TextBox() { Left = 70, Top = 10, Width = 100, Text = shapeWidth.ToString() };

                    Label heightLabel = new Label() { Text = "Height:", Left = 10, Top = 40, Width = 50 };
                    TextBox heightBox = new TextBox() { Left = 70, Top = 40, Width = 100, Text = shapeHeight.ToString() };

                    Button okButton = new Button() { Text = "OK", Left = 50, Top = 80, Width = 80 };
                    okButton.Click += (sender, ev) =>
                    {
                        if (int.TryParse(widthBox.Text, out int newWidth) && int.TryParse(heightBox.Text, out int newHeight))
                        {
                            shapeWidth = newWidth;
                            shapeHeight = newHeight;
                            sizeForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numbers for size.", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    sizeForm.Controls.Add(widthLabel);
                    sizeForm.Controls.Add(widthBox);
                    sizeForm.Controls.Add(heightLabel);
                    sizeForm.Controls.Add(heightBox);
                    sizeForm.Controls.Add(okButton);

                    sizeForm.ShowDialog();
                }
            };
            toolStrip.Items.Add(sizeButton);
            // ;

            Controls.Add(toolStrip);
            toolStrip.Dock = DockStyle.Top;

            this.Text = "SketchBoard";
            this.DoubleBuffered = true;
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            using (Graphics g = CreateGraphics())
            {
                Brush brush = new SolidBrush(selectedColor);

                switch (selectedShape)
                {
                    case "Rectangle":
                        g.FillRectangle(brush, e.X, e.Y, shapeWidth, shapeHeight);
                        break;
                    case "Ellipse":
                        g.FillEllipse(brush, e.X, e.Y, shapeWidth, shapeHeight);
                        break;
                    case "Triangle":
                        Point[] trianglePoints = new Point[]
                        {
                            new Point(e.X, e.Y),
                            new Point(e.X - shapeWidth / 2, e.Y + shapeHeight),
                            new Point(e.X + shapeWidth / 2, e.Y + shapeHeight)
                        };
                        g.FillPolygon(brush, trianglePoints);
                        break;
                }
            }
        }
    }
}
