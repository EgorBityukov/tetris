using tetris.Models;
using tetris.Service;

namespace tetris
{
    public partial class MainWindow : Form
    {
        private IConfigService _cfgService { get; set; }

        private const int maxRec = 8;
        private int recInFugure = 0;

        public List<Shape> shapes = new List<Shape>();

        public int width = 15, height = 20, k = 20;
        public int[,] shape = new int[2, 8];
        public int[,] field;
        public Bitmap bitfield;
        public Graphics gr;
        public int[,] newShape = new int[4, 4];

        public MainWindow(IConfigService cfgService)
        {
            _cfgService = cfgService;
            var list = _cfgService.GetShapes();

            if (list == null || list.Count == 0)
            {
                shapes = new List<Shape>() {
                        new Shape()
                        {
                        Positions = new List<int> { 1, 2, 3, 4, 2, 2, 2, 2 }
                        },
                        new Shape()
                        {
                        Positions = new List<int> { 1, 2, 1, 2, 2, 2, 3, 3 }
                        },
                        new Shape()
                        {
                            Positions = new List<int> { 1, 2, 3, 3, 2, 2, 2, 3 }
                        },
                        new Shape()
                        {
                            Positions = new List<int> { 1, 2, 3, 3, 2, 2, 2, 1 }
                        },
                        new Shape()
                        {
                            Positions = new List<int> { 2, 2, 3, 3, 1, 2, 2, 3 }
                        },
                        new Shape()
                        {
                            Positions = new List<int> { 2, 2, 3, 3, 3, 2, 2, 1 }
                        },
                        new Shape()
                        {
                            Positions = new List<int> { 2, 3, 3, 3, 2, 1, 2, 3 }
                        }
                };

                _cfgService.SaveCfg(shapes);
            }
            else
            {
                shapes = _cfgService.GetShapes();
            }

            InitializeComponent();
        }

        public void FillField()
        {
            gr.Clear(Color.Black);
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    if (field[x, y] == 1)
                    {
                        gr.FillRectangle(Brushes.Gray, x * k, y * k, k, k);
                        gr.DrawRectangle(Pens.Black, x * k, y * k, k, k);
                    }
            for (int i = 0; i < shape.GetLength(1); i++)
            {
                gr.FillRectangle(Brushes.Red, shape[1, i] * k, shape[0, i] * k, k, k);
                gr.DrawRectangle(Pens.Black, shape[1, i] * k, shape[0, i] * k, k, k);
            }
            pictureBox1.Image = bitfield;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    for (int i = 0; i < shape.GetLength(1); i++)
                        shape[1, i]--;
                    if (FindMistake())
                        for (int i = 0; i < shape.GetLength(1); i++)
                            shape[1, i]++;
                    break;
                case Keys.D:
                    for (int i = 0; i < shape.GetLength(1); i++)
                        shape[1, i]++;
                    if (FindMistake())
                        for (int i = 0; i < shape.GetLength(1); i++)
                            shape[1, i]--;
                    break;
                case Keys.W:
                    var shapeT = new int[shape.GetLength(0), shape.GetLength(1)];
                    Array.Copy(shape, shapeT, shape.Length);
                    int maxx = 0, maxy = 0;
                    for (int i = 0; i < shape.GetLength(1); i++)
                    {
                        if (shape[0, i] > maxy)
                            maxy = shape[0, i];
                        if (shape[1, i] > maxx)
                            maxx = shape[1, i];
                    }
                    for (int i = 0; i < shape.GetLength(1); i++)
                    {
                        int temp = shape[0, i];
                        shape[0, i] = maxy - (maxx - shape[1, i]) - 1;
                        shape[1, i] = maxx - (3 - (maxy - temp)) + 1;
                    }
                    if (FindMistake())
                        Array.Copy(shapeT, shape, shape.GetLength(1));
                    break;
            }
        }

        private void MainWindowStart()
        {
            heightL.Visible = true;
            widthL.Visible = true;

            RecL.Visible = false;
            RecP.Visible = false;

            heightTB.Visible = true;
            heightTB.ReadOnly = false;
            heightTB.Enabled = true;
            widthTB.Visible = true;
            widthTB.ReadOnly = false;
            widthTB.Enabled = true;

            saveFigureB.Visible = false;
            stopBT.Visible = false;
            playB.Visible = true;
            createFigureB.Visible = true;

            pictureBox1.Visible = false;

            timer1.Enabled = false;

            newShape = new int[4, 4];
            recInFugure = 0;

            RecP.Text = recInFugure.ToString() + "/" + maxRec.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (field[8, 3] == 1)
                MainWindowStart();
            for (int i = 0; i < shape.GetLength(1); i++)
                shape[0, i]++;
            for (int i = height - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, field.GetLength(0)).Select(j => field[j, i]).ToArray() where t == 1 select t).Count();
                if (cross == width)
                    for (int k = i; k > 1; k--)
                        for (int l = 1; l < width - 1; l++)
                            field[l, k] = field[l, k - 1];
            }
            if (FindMistake())
            {
                for (int i = 0; i < shape.GetLength(1); i++)
                    field[shape[1, i], --shape[0, i]]++;
                SetShape();
            }
            FillField();
        }

        private void playB_Click(object sender, EventArgs e)
        {
            height = Convert.ToInt32(heightTB.Text);
            width = Convert.ToInt32(widthTB.Text);

            if (height >= 20 && height <= 30 && width >= 15 && width <= 30)
            {

                heightL.Visible = false;
                widthL.Visible = false;

                heightTB.Visible = false;
                heightTB.ReadOnly = true;
                heightTB.Enabled = false;
                widthTB.Visible = false;
                widthTB.ReadOnly = true;
                widthTB.Enabled = false;

                stopBT.Visible = true;
                playB.Visible = false;
                createFigureB.Visible = false;

                pictureBox1.Visible = true;

                timer1.Enabled = true;

                field = new int[width, height];
                bitfield = new Bitmap(k * (width) + 1, k * (height) + 1);
                pictureBox1.Size = new Size(bitfield.Width, bitfield.Height);
                pictureBox1.Location = new Point(ClientSize.Width / 2 - pictureBox1.Width / 2, ClientSize.Height / 2 - pictureBox1.Height / 2);

                gr = Graphics.FromImage(bitfield);
                for (int x = 0; x < width; x++)
                    field[x, height - 1] = 1;
                for (int y = 0; y < height; y++)
                {
                    field[0, y] = 1;
                    field[width - 1, y] = 1;
                }
                SetShape();
            }
            else
            {
                if (height > 30)
                {
                    heightTB.Text = "30";
                }
                else
                if (height < 20)
                {
                    heightTB.Text = "20";
                }
                if (width > 30)
                {
                    widthTB.Text = "30";
                }
                else
                if (width < 15)
                {
                    widthTB.Text = "15";
                }
            }
        }

        private void heightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void widthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void createFigureB_Click(object sender, EventArgs e)
        {
            heightL.Visible = false;
            widthL.Visible = false;

            RecL.Visible = true;
            RecP.Visible = true;

            heightTB.Visible = false;
            heightTB.ReadOnly = true;
            heightTB.Enabled = false;
            widthTB.Visible = false;
            widthTB.ReadOnly = true;
            widthTB.Enabled = false;

            stopBT.Visible = true;
            saveFigureB.Visible = true;
            playB.Visible = false;
            createFigureB.Visible = false;

            pictureBox1.Visible = true;

            saveFigureB.Enabled = false;

            field = new int[4, 4];
            bitfield = new Bitmap(k * (4), k * (4));

            gr = Graphics.FromImage(bitfield);

            gr.Clear(Color.Black);

            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    gr.FillRectangle(Brushes.Gray, x * k, y * k, k, k);
                    gr.DrawRectangle(Pens.Black, x * k, y * k, k, k);
                }

            pictureBox1.Image = bitfield;
            pictureBox1.Size = new Size(bitfield.Width, bitfield.Height);
            pictureBox1.Location = new Point(ClientSize.Width / 2 - pictureBox1.Width / 2, ClientSize.Height / 2 - pictureBox1.Height / 2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (saveFigureB.Visible == true)
            {
                var lx = e.Location.X;
                var ly = e.Location.Y;

                if (newShape[lx / k, ly / k] == 0)
                {
                    if (recInFugure < maxRec)
                    {
                        newShape[lx / k, ly / k] = 1;
                        recInFugure += 1;
                    }
                }
                else
                {
                    newShape[lx / k, ly / k] = 0;
                    recInFugure -= 1;
                }

                for (int x = 0; x < 4; x++)
                    for (int y = 0; y < 4; y++)
                    {
                        if (newShape[x, y] == 1)
                        {
                            gr.FillRectangle(Brushes.Green, x * k, y * k, k, k);
                            gr.DrawRectangle(Pens.Black, x * k, y * k, k, k);
                        }
                        else
                        {
                            gr.FillRectangle(Brushes.Gray, x * k, y * k, k, k);
                            gr.DrawRectangle(Pens.Black, x * k, y * k, k, k);
                        }
                    }

                bool validateRec = ValidateShape(newShape, recInFugure);

                //for (int x = 1; x < 3; x++)
                //    for (int y = 1; y < 3; y++)
                //        if (newShape[x, y] == 1)
                //            if (newShape[x - 1, y] != 1 && newShape[x + 1, y] != 1 && newShape[x, y - 1] != 1 && newShape[x, y + 1] != 1)
                //            {
                //                validateRec = false;
                //            }



                //if (newShape[x, y] == 1)
                //{
                //    if(x == 0 && y == 0)
                //    {
                //        if (newShape[x + 1, y] != 1 && newShape[x, y + 1] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (x == 0 && y > 0 && y != 3) 
                //    {
                //        if (newShape[x + 1, y] != 1 && newShape[x, y - 1] != 1 && newShape[x, y + 1] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (x == 0 && y == 3)
                //    {
                //        if (newShape[x + 1, y] != 1 && newShape[x, y - 1] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (y == 0 && x > 0 && x != 3)
                //    {
                //        if (newShape[x, y + 1] != 1 && newShape[x - 1, y] != 1 && newShape[x + 1, y] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (x>0 && y>0 && x!=3 && y!=3)
                //    {
                //        if (newShape[x, y - 1] != 1 && newShape[x, y + 1] != 1 && newShape[x - 1, y] != 1 && newShape[x + 1, y] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (y == 0 && x == 3)
                //    {
                //        if (newShape[x, y + 1] != 1 && newShape[x - 1, y] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    if (x == 3 && y == 3)
                //    {
                //        if (newShape[x - 1, y] != 1 && newShape[x, y - 1] != 1)
                //        {
                //            validateRec = false;
                //        }
                //    }
                //    else
                //    {
                //        var wtf = 0;
                //    }
                //}

                if (recInFugure > 1 && validateRec)
                {
                    saveFigureB.Enabled = true;
                }
                else
                {
                    saveFigureB.Enabled = false;
                }

                RecP.Text = recInFugure.ToString() + "/" + maxRec.ToString();
                pictureBox1.Image = bitfield;
            }
        }

        private bool ValidateShape(int[,] vShape, int count)
        {
            int[,] validateField = new int[vShape.GetLength(0) + 2, vShape.GetLength(1) + 2];
            bool validateRec = true;
            int x1 = 0, y1 = 0;

            for (int x = 1; x < vShape.GetLength(0) + 1; x++)
                for (int y = 1; y < vShape.GetLength(1) + 1; y++)
                {
                    validateField[x, y] = vShape[x - 1, y - 1];
                }

            for (int y = 0; y < validateField.GetLength(0); y++)
            {
                for (int x = 0; x < validateField.GetLength(1); x++)
                {
                    if (validateField[x, y] == 1)
                    {
                        x1 = x;
                        y1 = y;
                        break;
                    }
                }

                if (x1 != 0 && y1 != 0)
                {
                    break;
                }
            }

            int countK = 0;

            if (x1 != 0 && y1 != 0)
            {
                countK = CountValidePoints(ref validateField, x1, y1, 1);
            }

            if(countK != recInFugure && countK != 0)
            {
                validateRec = false;
            }

            return validateRec;
        }

        private int CountValidePoints(ref int[,] vFigure, int x, int y, int k)
        {
            vFigure[x, y] = 2;

            if (vFigure[x + 1, y] == 1)
            {
                k = CountValidePoints(ref vFigure, x + 1, y, ++k);
            }
            if (vFigure[x, y + 1] == 1)
            {
                k = CountValidePoints(ref vFigure, x, y + 1, ++k);
            }
            if (vFigure[x - 1, y] == 1)
            {
                k = CountValidePoints(ref vFigure, x - 1, y, ++k);
            }
            if (vFigure[x, y - 1] == 1)
            {
                k = CountValidePoints(ref vFigure, x, y - 1, ++k);
            }

            return k;
        }

        private void stopBT_Click(object sender, EventArgs e)
        {
            MainWindowStart();
        }

        public void SetShape()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            shape = shapes[r.Next(shapes.Count)].GetCoordinates();

            for (int y = 0; y < shape.GetLength(1); y++)
            {
                if (shape[1, y] != 0)
                    shape[1, y] += width / 2 - 1;
            }
        }

        private void saveFigureB_Click(object sender, EventArgs e)
        {
            List<int> newPositionsX = new List<int>();
            List<int> newPositionsY = new List<int>();

            for (int y = 0; y < newShape.GetLength(0); y++)
                for (int x = 0; x < newShape.GetLength(1); x++)
                {
                    if (newShape[y, x] == 1)
                    {
                        newPositionsX.Add(x + 1);
                        newPositionsY.Add(y + 1);
                    }
                }

            var newFigure = new Shape()
            {
                Positions = newPositionsX.Concat(newPositionsY).ToList(),
            };

            shapes.Add(newFigure);

            _cfgService.SaveCfg(shapes);

            MainWindowStart();
        }

        public bool FindMistake()
        {
            for (int i = 0; i < shape.GetLength(1); i++)
                if (shape[1, i] >= width || shape[0, i] >= height ||
                    shape[1, i] <= 0 || shape[0, i] <= 0 ||
                    field[shape[1, i], shape[0, i]] == 1)
                    return true;
            return false;
        }
    }
}