using HomeWork1.Properties;

namespace HomeWork1
{
    public partial class Form1 : Form
    {

        private bool checkDraw;
        private Point startPoint;
        private Point endPoint;
        private int rectangleCount;
        private List<Rectangle> rectangles;
        public Form1()
        {
            InitializeComponent();
            checkDraw = false;
            rectangles = new List<Rectangle>();
            rectangleCount = 0;
        }
        //Task 1
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                checkDraw = true;
                startPoint = e.Location;
                endPoint = e.Location;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkDraw)
            {
                endPoint = e.Location;
                Refresh();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                checkDraw = false;
                Rectangle rectangle = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                if (rectangle.Width < 10 || rectangle.Height < 10)
                {
                    checkDraw = false;
                }
                else
                {
                    rectangleCount++;
                    rectangles.Add(rectangle);

                }
                Refresh();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            int rectCount = 0;
            foreach (Rectangle rectangle in rectangles)
            {
                rectCount++;
                e.Graphics.DrawRectangle(Pens.Red, rectangle);
                e.Graphics.DrawString(rectCount.ToString(), Font, Brushes.Blue, rectangle.Location);
            }

            if (checkDraw)
            {
                Rectangle currentRectangle = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                e.Graphics.DrawRectangle(Pens.Red, currentRectangle);
                e.Graphics.DrawString(rectangleCount.ToString(), Font, Brushes.Blue, currentRectangle.Location);
            }
        }


        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle clickedRectangle = FindClickedRectangle(e.Location);
                if (clickedRectangle != Rectangle.Empty)
                {
                    rectangles.Remove(clickedRectangle);
                    Refresh();
                }
            }
        }

        private Rectangle FindClickedRectangle(Point clickLocation)
        {
            foreach (Rectangle rectangle in rectangles)
            {
                if (rectangle.Contains(clickLocation))
                {
                    return rectangle;
                }
            }
            return Rectangle.Empty;
        }
        //Task 2
        private void label1_MouseHover(object sender, EventArgs e)
        {

            label1.Location = new Point(Random.Shared.Next(1000), Random.Shared.Next(1000));

        }

        // Task 3
        private void button1_Click(object sender, EventArgs e)
        {

            BackgroundImage = Resources.Baku;
            DateTime dateTime = DateTime.Now;
            MessageBox.Show(dateTime.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackgroundImage = Resources.London;
            DateTime dateTime = DateTime.UtcNow;
            MessageBox.Show(dateTime.ToString());
        }

    }


}