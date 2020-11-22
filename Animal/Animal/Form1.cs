using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal
{
    public partial class Form1 : Form
    {
        int value = 0;
        int value2 = 0;
        int number = 0;
        int number2 = 0;

        int select = 0;//判断选中状态

        int camp = 0;
        int camp2 = 0;//判断阵营

        int isclose = 0;//判断格子是否相邻
        int order = 1;//判断先后顺序

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Piece_Load();
        }

        private void Piece_Load()
        {
            for(int i=1;i<64;i++)
            {
                String T = i.ToString();
                PictureBox X = (PictureBox)Controls["pictureBox" + T];
                X.Image = null;
                X.Tag= "0";
            }

            pictureBox1.Image = Properties.Resources.狮2;
            pictureBox1.Tag = "蓝狮";
            pictureBox7.Image = Properties.Resources.虎2;
            pictureBox7.Tag = "蓝虎";
            pictureBox9.Image = Properties.Resources.狗2;
            pictureBox9.Tag = "蓝狗";
            pictureBox13.Image = Properties.Resources.猫2;
            pictureBox13.Tag = "蓝猫";
            pictureBox15.Image = Properties.Resources.鼠2;
            pictureBox15.Tag = "蓝鼠";
            pictureBox17.Image = Properties.Resources.豹2;
            pictureBox17.Tag = "蓝豹";
            pictureBox19.Image = Properties.Resources.狼2;
            pictureBox19.Tag = "蓝狼";
            pictureBox21.Image = Properties.Resources.象2;
            pictureBox21.Tag = "蓝象";

            pictureBox63.Image = Properties.Resources.狮;
            pictureBox63.Tag = "红狮";
            pictureBox57.Image = Properties.Resources.虎;
            pictureBox57.Tag = "红虎";
            pictureBox55.Image = Properties.Resources.狗;
            pictureBox55.Tag = "红狗";
            pictureBox51.Image = Properties.Resources.猫;
            pictureBox51.Tag = "红猫";
            pictureBox49.Image = Properties.Resources.鼠;
            pictureBox49.Tag = "红鼠";
            pictureBox47.Image = Properties.Resources.豹;
            pictureBox47.Tag = "红豹";
            pictureBox45.Image = Properties.Resources.狼;
            pictureBox45.Tag = "红狼";
            pictureBox43.Image = Properties.Resources.象;
            pictureBox43.Tag = "红象";
        }

        private int closed(int t,int u)//判断是否可以通行
        {
            String T = t.ToString();
            PictureBox X = (PictureBox)Controls["pictureBox" + T];

            int r1 = t + 7;
            int r2 = t + 14;
            int r3 = t + 21;
            int r4 = t - 7;
            int r5 = t - 14;
            int r6 = t - 21;
            int r7 = t + 1;
            int r8 = t + 2;
            int r9 = t - 1;
            int r10 = t - 2;

            if (t % 7 == 1)
            {
                if (u == t + 1|| u == t + 7 || u == t - 7)
                {
                    isclose = 1;
                }
                else
                {
                    isclose = 0;
                }
            }

            else if(t % 7 == 0)
            {
                if (u == t - 1 || u == t + 7 || u == t - 7)
                {
                    isclose = 1;
                }
                else
                {
                    isclose = 0;
                }
            }

            else
            {
                if (u == t + 1 || u == t - 1 || u == t + 7 || u == t - 7)
                {
                    isclose = 1;
                }
                else
                {
                    isclose = 0;
                }
            }

            if (isclose == 1)
            {
                if (u == 23 || u == 24 || u == 30 || u == 31 || u == 37 || u == 38 || u == 26 || u == 27 || u == 33 || u == 34 || u == 40 || u == 41)//老鼠过河
                {
                    if ((string)X.Tag == "蓝鼠" || (string)X.Tag == "红鼠")
                    {
                        isclose = 1;
                    }
                    else
                    {
                        isclose = 0;
                    }
                }
            }

            if (t == 16 && u == 44 || t == 17 && u == 45 || t == 19 && u == 47 || t == 20 && u == 48 )
            {
                String R1 = r1.ToString();
                PictureBox V1 = (PictureBox)Controls["pictureBox" + R1];

                String R2 = r2.ToString();
                PictureBox V2 = (PictureBox)Controls["pictureBox" + R2];

                String R3 = r3.ToString();
                PictureBox V3 = (PictureBox)Controls["pictureBox" + R3];

                if (V1.Image == null && V2.Image == null && V3.Image == null)
                {
                    if ((string)X.Tag == "蓝狮" || (string)X.Tag == "红狮" || (string)X.Tag == "蓝虎" || (string)X.Tag == "红虎")
                    {
                        isclose = 1;
                    }
                    else
                    {
                        isclose = 0;
                    }
                }
            }

            if (t == 44 && u == 16 || t == 45 && u == 17 || t == 47 && u == 19 || t == 48 && u == 20)
            {
                String R4 = r4.ToString();
                PictureBox V4 = (PictureBox)Controls["pictureBox" + R4];

                String R5 = r5.ToString();
                PictureBox V5 = (PictureBox)Controls["pictureBox" + R5];

                String R6 = r6.ToString();
                PictureBox V6 = (PictureBox)Controls["pictureBox" + R6];

                if (V4.Image == null && V5.Image == null && V6.Image == null)
                {
                    if ((string)X.Tag == "蓝狮" || (string)X.Tag == "红狮" || (string)X.Tag == "蓝虎" || (string)X.Tag == "红虎")
                    {
                        isclose = 1;
                    }
                    else
                    {
                        isclose = 0;
                    }
                }

            }

            if (t == 22 && u == 25 || t == 29 && u == 32 || t == 36 && u == 39|| t == 25 && u == 28 || t == 32 && u == 35 || t == 39 && u == 42)
            {
                String R7 = r7.ToString();
                PictureBox V7 = (PictureBox)Controls["pictureBox" + R7];

                String R8 = r8.ToString();
                PictureBox V8 = (PictureBox)Controls["pictureBox" + R8];

                if (V7.Image == null && V8.Image == null)
                {
                    if ((string)X.Tag == "蓝狮" || (string)X.Tag == "红狮" || (string)X.Tag == "蓝虎" || (string)X.Tag == "红虎")
                    {
                        isclose = 1;
                    }
                    else
                    {
                        isclose = 0;
                    }
                }

            }

            if (t == 25 && u == 22 || t == 29 && u == 32 || t == 39 && u == 36 || t == 28 && u == 25 || t == 35 && u == 32 || t == 42 && u == 39)
            {
                String R9 = r9.ToString();
                PictureBox V9 = (PictureBox)Controls["pictureBox" + R9];

                String R10 = r10.ToString();
                PictureBox V10 = (PictureBox)Controls["pictureBox" + R10];

                if (V9.Image == null && V10.Image == null)
                {
                    if ((string)X.Tag == "蓝狮" || (string)X.Tag == "红狮" || (string)X.Tag == "蓝虎" || (string)X.Tag == "红虎")
                    {
                        isclose = 1;
                    }
                    else
                    {
                        isclose = 0;
                    }
                }

            }

            return isclose;

        }
        private void Piece_Select(int t)//判断选中状态
        {
            String T = t.ToString();
            PictureBox X = (PictureBox)Controls["pictureBox" + T];

            if(X.Image != null)
            {
                if (select < 2)// select==0 未选中 select==1 选中一个棋子 select==2 选中两个棋子
                {
                    select++;
                }
                else
                {
                    select = 0;
                }
            }

        }

        private void Piece_Get(int t) //获取第一个选中棋子的信息
        {
            String T = t.ToString();
            PictureBox X = (PictureBox)Controls["pictureBox" + T];

            if (X.Image != null)
            {
                if ((string)X.Tag == "蓝象")
                {
                    value = 8;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝狮")
                {
                    value = 7;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝虎")
                {
                    value = 6;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝豹")
                {
                    value = 5;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝狼")
                {
                    value = 4;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝狗")
                {
                    value = 3;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝猫")
                {
                    value = 2;
                    camp = 2;
                }

                else if ((string)X.Tag == "蓝鼠")
                {
                    value = 1;
                    camp = 2;
                }

                else if ((string)X.Tag == "红象")
                {
                    value = 8;
                    camp = 1;
                }

                else if ((string)X.Tag == "红狮")
                {
                    value = 7;
                    camp = 1;
                }

                else if ((string)X.Tag == "红虎")
                {
                    value = 6;
                    camp = 1;
                }

                else if ((string)X.Tag == "红豹")
                {
                    value = 5;
                    camp = 1;
                }

                else if ((string)X.Tag == "红狼")
                {
                    value = 4;
                    camp = 1;
                }

                else if ((string)X.Tag == "红狗")
                {
                    value = 3;
                    camp = 1;
                }

                else if ((string)X.Tag == "红猫")
                {
                    value = 2;
                    camp = 1;
                }

                else if ((string)X.Tag == "红鼠")
                {
                    value = 1;
                    camp = 1;
                }

                if (select < 2)
                {

                    if (camp == 1)
                    {
                        Graphics pictureborder = X.CreateGraphics();
                        Pen pen = new Pen(Color.Red, 7);
                        pictureborder.DrawRectangle(pen, X.ClientRectangle.X, X.ClientRectangle.Y, X.ClientRectangle.X + X.ClientRectangle.Width, X.ClientRectangle.Y + X.ClientRectangle.Height);
                    }

                    else if (camp == 2)
                    {
                        Graphics pictureborder = X.CreateGraphics();
                        Pen pen = new Pen(Color.Blue, 7);
                        pictureborder.DrawRectangle(pen, X.ClientRectangle.X, X.ClientRectangle.Y, X.ClientRectangle.X + X.ClientRectangle.Width, X.ClientRectangle.Y + X.ClientRectangle.Height);
                    }

                }

            }

        }

        private void Piece_Get2(int t) //获取第二个选中棋子的信息
        {
            String T = t.ToString();
            PictureBox X = (PictureBox)Controls["pictureBox" + T];

            if (X.Image != null)
            {
                if ((string)X.Tag == "蓝象")
                {
                    value2 = 8;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝狮")
                {
                    value2 = 7;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝虎")
                {
                    value2 = 6;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝豹")
                {
                    value2 = 5;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝狼")
                {
                    value2 = 4;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝狗")
                {
                    value2 = 3;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝猫")
                {
                    value2 = 2;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "蓝鼠")
                {
                    value2 = 1;
                    camp2 = 2;
                }

                else if ((string)X.Tag == "红象")
                {
                    value2 = 8;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红狮")
                {
                    value2 = 7;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红虎")
                {
                    value2 = 6;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红豹")
                {
                    value2 = 5;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红狼")
                {
                    value2 = 4;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红狗")
                {
                    value2 = 3;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红猫")
                {
                    value2 = 2;
                    camp2 = 1;
                }

                else if ((string)X.Tag == "红鼠")
                {
                    value2 = 1;
                    camp2 = 1;
                }
                else
                {

                }

                if (t==3||t==5||t==11)//陷阱
                {
                    if (camp2 == 1)
                    {
                        value2 = 0;
                    }
                }

                if (t == 53 || t == 59 || t == 61)//陷阱
                {
                    if (camp2 == 2)
                    {
                        value2 = 0;
                    }
                }

                if (camp2 == 1)
                {
                    Graphics pictureborder = X.CreateGraphics();
                    Pen pen = new Pen(Color.Red, 7);
                    pictureborder.DrawRectangle(pen, X.ClientRectangle.X, X.ClientRectangle.Y, X.ClientRectangle.X + X.ClientRectangle.Width, X.ClientRectangle.Y + X.ClientRectangle.Height);
                }

                else if (camp2 == 2)
                {
                    Graphics pictureborder = X.CreateGraphics();
                    Pen pen = new Pen(Color.Blue, 7);
                    pictureborder.DrawRectangle(pen, X.ClientRectangle.X, X.ClientRectangle.Y, X.ClientRectangle.X + X.ClientRectangle.Width, X.ClientRectangle.Y + X.ClientRectangle.Height);
                }

            }
        }

        private void Piece_Judge(int t,int u)//移动棋子
        {
            String T = t.ToString();
            PictureBox X = (PictureBox)Controls["pictureBox" + T];
            int a = closed(t, u);

            if (a != 1)
            {
                X.Invalidate();
                number = 0;
                camp = 0;
                value = 0;
                select = 0;
            }

            if (camp == camp2)
            {
                String U = number2.ToString();
                PictureBox Y = (PictureBox)Controls["pictureBox" + U];

                X.Invalidate();
                Y.Invalidate();

                number = 0;
                number2 = 0;
                camp = 0;
                value = 0;
                camp2 = 0;
                value2 = 0;
                select = 0;

            }

            if (value2 > value)
            {
                if (value2 != 8 || value != 1)
                {
                    String U = number2.ToString();
                    PictureBox Y = (PictureBox)Controls["pictureBox" + U];

                    X.Invalidate();
                    Y.Invalidate();

                    number = 0;
                    number2 = 0;
                    camp = 0;
                    value = 0;
                    camp2 = 0;
                    value2 = 0;
                    select = 0;
                }
            }

            else if (camp != camp2 && value == 8 && value2 == 1)
            {

                String U = number2.ToString();
                PictureBox Y = (PictureBox)Controls["pictureBox" + U];

                X.Invalidate();
                Y.Invalidate();

                number = 0;
                number2 = 0;
                camp = 0;
                value = 0;
                camp2 = 0;
                value2 = 0;
                select = 0;

            }

            if (select == 0)
            {

            }

            if (select == 1 && u != 0 && t != u && a == 1)
            {

                String U = number2.ToString();
                PictureBox Y = (PictureBox)Controls["pictureBox" + U];

                Y.Image = X.Image;
                Y.Tag = X.Tag;
                X.Image = null;
                X.Tag = "0";
                string s = Y.Tag + " 从 " + number + " 移动到 " + number2;
                listBox1.Items.Add(s);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;

                number = 0;
                number2 = 0;
                camp = 0;
                value = 0;
                camp2 = 0;
                value2 = 0;
                select = 0;

                if (order == 1)
                {
                    order = 2;
                    label2.Text = "蓝方";
                    label2.ForeColor =  Color.Blue;
                }
                else
                {
                    order = 1;
                    label2.Text = "红方";
                    label2.ForeColor = Color.Red;
                }

            }

            if (select == 2 && u != 0 && a == 1)
            {
                String U = number2.ToString();
                PictureBox Y = (PictureBox)Controls["pictureBox" + U];

                if (camp != camp2 && value > value2 && value - value2 != 7)
                {
                    string s = X.Tag + " 从 " + number + " 移动到 " + number2 + "，吃掉了 " + Y.Tag;
                    listBox1.Items.Add(s);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = -1;

                    Y.Image = X.Image;
                    Y.Tag = X.Tag;
                    X.Image = null;
                    X.Tag = "0";

                    number = 0;
                    number2 = 0;
                    camp = 0;
                    value = 0;
                    camp2 = 0;
                    value2 = 0;
                    select = 0;

                    if (order == 1)
                    {
                        order = 2;
                        label2.Text = "蓝方";
                        label2.ForeColor = Color.Blue;
                    }
                    else
                    {
                        order = 1;
                        label2.Text = "红方";
                        label2.ForeColor = Color.Red;
                    }

                }

                else if (camp != camp2 && value - value2 == -7)
                {
                    string s = X.Tag + " 从 " + number + " 移动到 " + number2 + "，吃掉了 " + Y.Tag;
                    listBox1.Items.Add(s);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = -1;

                    Y.Image = X.Image;
                    Y.Tag = X.Tag;
                    X.Image = null;
                    X.Tag = "0";

                    number = 0;
                    number2 = 0;
                    camp = 0;
                    value = 0;
                    camp2 = 0;
                    value2 = 0;
                    select = 0;

                    if (order == 1)
                    {
                        order = 2;
                        label2.Text = "蓝方";
                        label2.ForeColor = Color.Blue;
                    }
                    else
                    {
                        order = 1;
                        label2.Text = "红方";
                        label2.ForeColor = Color.Red;
                    }

                }

                else if (camp != camp2 && value == value2)
                {
                    string s = X.Tag + " 从 " + number + " 移动到 " + number2 + "，吃掉了 " + Y.Tag;
                    listBox1.Items.Add(s);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = -1;

                    Y.Image = null;
                    Y.Tag = "0";
                    X.Image = null;
                    X.Tag = "0";

                    number = 0;
                    number2 = 0;
                    camp = 0;
                    value = 0;
                    camp2 = 0;
                    value2 = 0;
                    select = 0;

                    if (order == 1)
                    {
                        order = 2;
                        label2.Text = "蓝方";
                        label2.ForeColor = Color.Blue;
                    }
                    else
                    {
                        order = 1;
                        label2.Text = "红方";
                        label2.ForeColor = Color.Red;
                    }
                }
            }
            if (pictureBox4.Image !=null)
            {
                string s = "恭喜红方获得胜利";
                listBox1.Items.Add(s);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;
                MessageBox.Show("恭喜红方获得胜利");
            }

            if (pictureBox60.Image != null)
            {
                string s = "恭喜蓝方获得胜利";
                listBox1.Items.Add(s);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;
                MessageBox.Show("恭喜蓝方获得胜利");
            }

        }

        private void Piece_Move(int x, PictureBox X)//移动棋子
        {
            if (select == 0)//在此之前未选中其他棋子
            {
                number = x;
                Piece_Get(number);//获取该棋子信息
                if (camp == order)
                {
                    Piece_Select(number);
                }
                else
                {
                    X.Invalidate();
                    number = 0;
                    camp = 0;
                    value = 0;
                    select = 0;
                }
            }

            else//在此之前选中了其他棋子
            {
                number2 = x;//等于自身编号

                Piece_Select(number2);//判断能否选中

                if (select == 1)
                {
                    Piece_Judge(number, number2);
                }

                if (select == 2)
                {
                    Piece_Get2(number2);//获取该棋子信息
                    Piece_Judge(number, number2);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)//最小化
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//最小化 最大化
        {
            if (this.WindowState == FormWindowState.Maximized) //若最大化
            {
                this.WindowState = FormWindowState.Normal; //则正常化
            }
            else if (this.WindowState == FormWindowState.Normal) //若正常化
            {
                this.WindowState = FormWindowState.Maximized; //则最大化
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox X = (PictureBox)sender;
            int x = Convert.ToInt32(X.Name.Split('x')[1]);
            Piece_Move(x, X);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (order == 1)
            {
                string s = "红方认输，恭喜蓝方获得胜利";
                listBox1.Items.Add(s);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;
                MessageBox.Show("红方认输，恭喜蓝方获得胜利");
            }
            else
            {
                string s = "蓝方认输，恭喜红方获得胜利";
                listBox1.Items.Add(s);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;
                MessageBox.Show("蓝方认输，恭喜红方获得胜利");
            }

            Piece_Load();
            value = 0;
            value2 = 0;
            number = 0;
            number2 = 0;
            select = 0;//判断选中状态
            camp = 0;
            camp2 = 0;//判断阵营
            isclose = 0;//判断格子是否相邻
            order = 1;//判断先后顺序
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Piece_Load();
            value = 0;
            value2 = 0;
            number = 0;
            number2 = 0;
            select = 0;
            camp = 0;
            camp2 = 0;
            isclose = 0;
            order = 1;
            listBox1.Items.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = "玩家："+ textBox1.Text;
            listBox2.Items.Add(s);
            listBox2.SelectedIndex = listBox1.Items.Count - 1;
            listBox2.SelectedIndex = -1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            for(int i = 1; i < 64; i++)
            {
                String T = i.ToString();
                PictureBox X = (PictureBox)Controls["pictureBox" + T];
                string s = (string)X.Tag;

                StreamWriter sw = new StreamWriter(@"D:\test.txt", true);
                sw.Write(s+"\n");
                sw.Flush();
                sw.Close();
            }

            MessageBox.Show("保存成功");
        }
    }
}
