using System.Media;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        private SoundPlayer Music;
        

        public List<List<PictureBox>> picture = new List<List<PictureBox>>();
        private string path = @"C:\SnakeScores";

        public Form1()
        {
            InitializeComponent();

            // запись рекорда в файл
            Directory.CreateDirectory(path); // создание папки
            path += @"\MaxScores.txt";
            if (!File.Exists(path)) // —уществует ли уже файл
            {
                using (StreamWriter streamW = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.UTF8))
                {
                    streamW.Write("0");
                }
            }

            Music = new SoundPlayer(assembly.GetManifestResourceStream(@"WinFormsApp1.Sounds.wav"));
            Music.PlayLooping();

            // начальные позиции всех элементов
            ClientSize = new System.Drawing.Size(MAIN_SNAKE.Width * 27, MAIN_SNAKE.Height * 15);
            MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Width * 5, MAIN_SNAKE.Height * 3);

            int IMG = 0;
            int pictTabIndx = 10;
            // фон
            for (int i = 0; i < 15; i++)
            {
                picture.Add(new List<PictureBox>());
                for (int j = 0; j < 27; j++)
                {
                    picture[i].Add(new PictureBox());
                    if (IMG == 0 || IMG == 1) picture[i][j].BackgroundImage = oakIMG.BackgroundImage;
                    else if (IMG == 2 || IMG == 3) picture[i][j].BackgroundImage = BirchIMG.BackgroundImage;
                    IMG++;
                    if (IMG > 3) IMG = 0;
                    picture[i][j].Location = new Point(MAIN_SNAKE.Width * j, MAIN_SNAKE.Height * i);
                    picture[i][j].Name = $"oakIMG{i}.{j}";
                    picture[i][j].Size = new System.Drawing.Size(50, 50);
                    picture[i][j].TabIndex = pictTabIndx++;
                    picture[i][j].TabStop = false;

                    Controls.Add(picture[i][j]);
                }
            }

            // позиции €блок
            var rand = new Random();
            APPLE1.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width/2 - APPLE1.Width/2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height/2 - APPLE1.Height/2 + 4);
            APPLE2.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width/2 - APPLE2.Width/2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height/2 - APPLE2.Height/2 + 4);
            APPLE3.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width/2 - APPLE3.Width/2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height/2 - APPLE3.Height/2 + 4);
            AppleBG();

            timer1.Start();
            KeyPreview = true; // работа считывани€ нажатий клавиш
        }

        private void AppleBG() // фон дл€ €блок
        {
            for (int i = 0; i < picture.Count; i++)
                for (int jojo = 0; jojo < picture[i].Count; jojo++)
                {
                    if (APPLE1.Location.X - (MAIN_SNAKE.Width - APPLE1.Width) / 2 == picture[i][jojo].Location.X &&
                        APPLE1.Location.Y - (MAIN_SNAKE.Height - APPLE1.Height) / 2 == picture[i][jojo].Location.Y + 4)
                    {
                        APPLE1.BackgroundImage = picture[i][jojo].BackgroundImage;
                    }
                    if (APPLE2.Location.X - (MAIN_SNAKE.Width - APPLE2.Width) / 2 == picture[i][jojo].Location.X &&
                        APPLE2.Location.Y - (MAIN_SNAKE.Height - APPLE2.Height) / 2 == picture[i][jojo].Location.Y + 4)
                    {
                        APPLE2.BackgroundImage = picture[i][jojo].BackgroundImage;
                    }
                    if (APPLE3.Location.X - (MAIN_SNAKE.Width - APPLE3.Width) / 2 == picture[i][jojo].Location.X &&
                        APPLE3.Location.Y - (MAIN_SNAKE.Height - APPLE3.Height) / 2 == picture[i][jojo].Location.Y + 4)
                    {
                        APPLE3.BackgroundImage = picture[i][jojo].BackgroundImage;
                    }
                }
        }

        private int MaxScore = 0;

        public static List<Button> snake = new List<Button>(); // хвосты
        public List<int> history = new List<int>(); // истори€ головы дл€ позиций хвоста
        public int[] tempHistory = new int[2];

        private string side = "Right"; 
        private bool G = false;
        private int Red = 250;
        private int Green = 0;
        private int Blue = 0;
        private int colorStep = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // насто€щие координаты головы
            tempHistory[0] = MAIN_SNAKE.Location.X;
            tempHistory[1] = MAIN_SNAKE.Location.Y;

            var rand = new Random();
            // перемещение MAIN_SNAKE
            if (!G)
            {
                if (side == "Right")
                {
                    if (MAIN_SNAKE.Location.X + MAIN_SNAKE.Width <= ClientSize.Width - MAIN_SNAKE.Width)
                        for (int i = 0; i < MAIN_SNAKE.Width; i++)
                            MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X + 1, MAIN_SNAKE.Location.Y);
                    else
                        MAIN_SNAKE.Location = new Point(0, MAIN_SNAKE.Location.Y);

                    for (int i = 0; i < snake.Count * 2; i += 2)
                        if (MAIN_SNAKE.Location.X == history[i] &&
                            MAIN_SNAKE.Location.Y == history[i + 1])
                            G = true;
                }
                else if (side == "Down")
                {
                    if (MAIN_SNAKE.Location.Y + MAIN_SNAKE.Height <= ClientSize.Height - MAIN_SNAKE.Height)
                        for (int i = 0; i < MAIN_SNAKE.Height; i++)
                            MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X, MAIN_SNAKE.Location.Y + 1);
                    else
                        MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X, 0);

                    for (int i = 0; i < snake.Count * 2; i += 2)
                        if (MAIN_SNAKE.Location.X == history[i] &&
                            MAIN_SNAKE.Location.Y == history[i + 1])
                            G = true;
                }
                else if (side == "Left")
                {
                    if (MAIN_SNAKE.Location.X - MAIN_SNAKE.Width >= 0)
                        for (int i = 0; i < MAIN_SNAKE.Width; i++)
                            MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X - 1, MAIN_SNAKE.Location.Y);
                    else
                        MAIN_SNAKE.Location = new Point(ClientSize.Width - MAIN_SNAKE.Width, MAIN_SNAKE.Location.Y);

                    for (int i = 0; i < snake.Count * 2; i += 2)
                        if (MAIN_SNAKE.Location.X == history[i] &&
                            MAIN_SNAKE.Location.Y == history[i + 1])
                            G = true;
                }
                else if (side == "Up")
                {
                    if (MAIN_SNAKE.Location.Y - MAIN_SNAKE.Height >= 0)
                        for (int i = 0; i < MAIN_SNAKE.Height; i++)
                            MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X, MAIN_SNAKE.Location.Y - 1);
                    else
                        MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Location.X, ClientSize.Height - MAIN_SNAKE.Height);

                    for (int i = 0; i < snake.Count * 2; i += 2)
                        if (MAIN_SNAKE.Location.X == history[i] &&
                            MAIN_SNAKE.Location.Y == history[i + 1])
                            G = true;
                }
            }
            else 
            { // Game over
                timer1.Stop();

                if (!cheatHis)
                    using (StreamReader readerW = File.OpenText(path)) // чтение рекорда
                    {
                        MaxScore = Convert.ToInt32(readerW.ReadToEnd());
                    }

                if (snake.Count > MaxScore) // обновление рекорда
                {
                    using (StreamWriter streamW = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.UTF8))
                    {
                        streamW.Write($"{snake.Count}");
                    }
                }
                MessageBox.Show($"—чет: {snake.Count}\n–екорд: {MaxScore}", "»гра окончена!", MessageBoxButtons.OK, MessageBoxIcon.Information);




                AppleBG(); // фон дл€ €блок

                for (int i = 0; i < snake.Count; i++)
                {
                    snake[i].Location = new Point(-50, 0);
                }

                snake = new List<Button>(); // хвосты
                history = new List<int>(); // истори€ головы дл€ позиций хвоста
                tempHistory = new int[2];

                side = "Right";
                cheats = false;
                G = false;
                Red = 250;
                Green = 0;
                Blue = 0;
                colorStep = 0;
                // начальные позиции всех элементов
                ClientSize = new System.Drawing.Size(MAIN_SNAKE.Width * 27, MAIN_SNAKE.Height * 15);
                MAIN_SNAKE.BackColor = Color.FromArgb(250, 0, 0);
                MAIN_SNAKE.ForeColor = Color.FromArgb(0, 250, 250);
                MAIN_SNAKE.Location = new Point(MAIN_SNAKE.Width * 5, MAIN_SNAKE.Height * 3);
                APPLE1.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE1.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE1.Height / 2 + 4);
                APPLE2.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE2.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE2.Height / 2 + 4);
                APPLE3.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE3.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE3.Height / 2 + 4);
                AppleBG(); // фон дл€ €блок
                timer1.Start();
            }

            // столкновение с €блоком
            bool F = false;
            if (APPLE1.Location.X + APPLE1.Width > MAIN_SNAKE.Location.X && APPLE1.Location.X < MAIN_SNAKE.Location.X + MAIN_SNAKE.Width)
                if (APPLE1.Location.Y + APPLE1.Height > MAIN_SNAKE.Location.Y && APPLE1.Location.Y < MAIN_SNAKE.Location.Y + MAIN_SNAKE.Height)
                {
                    while (true)
                    {
                        APPLE1.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE1.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE1.Height / 2 + 4);
                        for (int i = 0; i < snake.Count; i++)
                            if (APPLE1.Location.X - MAIN_SNAKE.Width / 2 + APPLE1.Width / 2 == snake[i].Location.X - 5 &&
                                APPLE1.Location.Y - MAIN_SNAKE.Height / 2 + APPLE1.Height / 2 == snake[i].Location.Y - 5)
                            {
                                F = true;
                                break;
                            }
                        if (F) F = false;
                        else break;
                    }
                    F = true;
                }
            if (APPLE2.Location.X + APPLE2.Width > MAIN_SNAKE.Location.X && APPLE2.Location.X < MAIN_SNAKE.Location.X + MAIN_SNAKE.Width)
                if (APPLE2.Location.Y + APPLE2.Height > MAIN_SNAKE.Location.Y && APPLE2.Location.Y < MAIN_SNAKE.Location.Y + MAIN_SNAKE.Height)
                {
                    while (true)
                    {
                        APPLE2.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE2.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE2.Height / 2 + 4);
                        for (int i = 0; i < snake.Count; i++)
                            if (APPLE2.Location.X - MAIN_SNAKE.Width / 2 + APPLE2.Width / 2 == snake[i].Location.X - 5 &&
                                APPLE2.Location.Y - MAIN_SNAKE.Height / 2 + APPLE2.Height / 2 == snake[i].Location.Y - 5)
                            {
                                F = true;
                                break;
                            }
                        if (F) F = false;
                        else break;
                    }
                    F = true;
                }
            if (APPLE3.Location.X + APPLE3.Width > MAIN_SNAKE.Location.X && APPLE3.Location.X < MAIN_SNAKE.Location.X + MAIN_SNAKE.Width)
                if (APPLE3.Location.Y + APPLE3.Height > MAIN_SNAKE.Location.Y && APPLE3.Location.Y < MAIN_SNAKE.Location.Y + MAIN_SNAKE.Height)
                {
                    while (true)
                    {
                        APPLE3.Location = new Point(rand.Next(0, 27) * MAIN_SNAKE.Width + MAIN_SNAKE.Width / 2 - APPLE3.Width / 2, rand.Next(0, 15) * MAIN_SNAKE.Height + MAIN_SNAKE.Height / 2 - APPLE3.Height / 2 + 4);
                        for (int i = 0; i < snake.Count; i++)
                            if (APPLE3.Location.X - MAIN_SNAKE.Width / 2 + APPLE3.Width / 2 == snake[i].Location.X - 5 &&
                                APPLE3.Location.Y - MAIN_SNAKE.Height / 2 + APPLE3.Height / 2 == snake[i].Location.Y - 5)
                            {
                                F = true;
                                break;
                            }
                        if (F) F = false;
                        else break;
                    }
                    F = true;
                }
            if (cheats) F = true;
            if (F)
            { // столкновение с €блоком
                AppleBG(); // фон дл€ €блок

                history.Add(tempHistory[0]);
                history.Add(tempHistory[1]);

                snake.Add(new Button());
            }

            List<int> tempHis = new List<int>();
            tempHis.Add(tempHistory[0]);
            tempHis.Add(tempHistory[1]);
            // вывод хвоста
            if (!G)
            { // создание нового хвоста
                for (int i = 0, j = snake.Count - 1; i < snake.Count * 2; i += 2, j--)
                {
                    tempHis.Add(history[i]);
                    tempHis.Add(history[i + 1]);
                    snake[j].Location = new Point(tempHis[i] + 5, tempHis[i + 1] + 5);
                }
                if (F)
                {
                    snake[snake.Count - 1].Name = $"SNAKE{snake.Count}";
                    snake[snake.Count - 1].Text = $"";
                    snake[snake.Count - 1].Size = new Size(40, 40);
                    snake[snake.Count - 1].FlatStyle = FlatStyle.Flat;
                    snake[snake.Count - 1].TabIndex = 0;
                    snake[snake.Count - 1].UseVisualStyleBackColor = true;
                    snake[snake.Count - 1].BackColor = Color.FromArgb(Red, Green, Blue);
                    snake[snake.Count - 1].BringToFront();
                    Controls.Add(snake[snake.Count - 1]);
                    snake[snake.Count - 1].BringToFront();

                    MAIN_SNAKE.BackColor = Color.FromArgb(Red, Green, Blue);
                    MAIN_SNAKE.ForeColor = Color.FromArgb(250 - Red, 250 - Green, 250 - Blue);

                    // изменение цвета 
                    if (colorStep == 0)
                        if (Green < 250) Green += 10;
                        else colorStep = 1;
                    if (colorStep == 1)
                        if (Red > 0)  Red -= 10;
                        else colorStep = 2;
                    if (colorStep == 2)
                        if (Blue < 250) Blue += 10;
                        else colorStep = 3;
                    if (colorStep == 3)
                        if (Green > 0) Green -= 10;
                        else colorStep = 4;
                    if (colorStep == 4)
                        if (Red < 250) Red += 10;
                        else colorStep = 5;
                    if (colorStep == 5)
                        if (Blue > 0) Blue -= 10;
                        else colorStep = 0;
                }
                history = tempHis;
            }
        }


        private bool pause = false;
        private bool cheats = false;
        private bool cheatHis = false;
        //считывание нажати€ клавиш
        public void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // управление
            if (e.KeyValue == (char)Keys.W)
            {
                if (MAIN_SNAKE.Location.Y - MAIN_SNAKE.Height != history[1] &&
                    MAIN_SNAKE.Location.X != history[0]) side = "Up";
            }
            if (e.KeyValue == (char)Keys.D)
            {
                if (MAIN_SNAKE.Location.X + MAIN_SNAKE.Width != history[0] &&
                    MAIN_SNAKE.Location.Y != history[1]) side = "Right";
            }
            if (e.KeyValue == (char)Keys.A)
            {
                if (MAIN_SNAKE.Location.X - MAIN_SNAKE.Width != history[0] &&
                    MAIN_SNAKE.Location.Y != history[1]) side = "Left";
            }
            if (e.KeyValue == (char)Keys.S)
            {
                if (MAIN_SNAKE.Location.Y + MAIN_SNAKE.Height != history[1] &&
                    MAIN_SNAKE.Location.X != history[0]) side = "Down";
            }

            // читы
            if (e.KeyValue == (char)Keys.P)
            {
                cheats = !cheats;
                cheatHis = true;
            }

            // пауза
            if (e.KeyValue == (char)Keys.Escape)
            {
                if (!pause)
                {
                    timer1.Stop();
                    DialogResult a = MessageBox.Show($"—чет: {snake.Count}\nЌажмите Esc/ќ  дл€ продолжени€", "ѕауза", MessageBoxButtons.OK, MessageBoxIcon.None);
                    if (a == DialogResult.OK) timer1.Start();
                    pause = true;
                }
                else
                {
                    timer1.Start();
                    pause = false;
                }
            }
        }
    }
}