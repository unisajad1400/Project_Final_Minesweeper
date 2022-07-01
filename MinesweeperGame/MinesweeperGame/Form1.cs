namespace MinesweeperGame
{
    public partial class Form1 : Form
    {
        Label[,] choiceBoard;
        public Form1()
        {
            InitializeComponent();

            choiceBoard = new Label[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    choiceBoard[i, j] = new Label();
                    choiceBoard[i, j].Font = new Font("Tahoma", 16);
                    choiceBoard[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                    tableLayoutPanel1.Controls.Add(choiceBoard[i, j]);
                }
            }


            makeBombs();
            makeNumberHelpRow();
            makeNumberHelpCloumn();
            hiddenBomb();
            hiddenNumbers();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    choiceBoard[i, j].Click += new EventHandler(label_Click);

                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;

        }

        private void makeBombs()
        {
            int numberBombs = 15;

            Random rowNumber = new Random();
            Random cloumnNumber = new Random();

            for (int i = 0; i < numberBombs; i++)
            {
                int x = rowNumber.Next(0, 10);
                int y = cloumnNumber.Next(0, 10);

                choiceBoard[x, y].Text = "B";
            }

        }

        private void label_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Label lable = (Label)sender;

                if (lable.Text == "B")
                {
                    showBomb();
                }

                if (lable.Text == "1" || lable.Text == "2" || lable.Text == "3")
                {
                    lable.Font = new Font("Tahoma", 16);
                }
            }
        }

        private void hiddenBomb()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (choiceBoard[i, j].Text == "B")
                    {
                        choiceBoard[i, j].Font = new Font("Tahoma", 1);
                    }
                }
            }
        }

        private void hiddenNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (choiceBoard[i, j].Text == "1" || choiceBoard[i, j].Text == "2" || choiceBoard[i, j].Text == "3")
                    {
                        choiceBoard[i, j].Font = new Font("Tahoma", 1);
                    }
                }
            }
        }

        private void showBomb()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (choiceBoard[i, j].Text == "B")
                    {
                        choiceBoard[i, j].Font = new Font("Tahoma", 16);
                        choiceBoard[i, j].BackColor = Color.Pink;
                    }
                }
            }
        }

        private void makeNumberHelpRow()
        {
            int countBomb = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (choiceBoard[i, j].Text == "B" && j < 9)
                    {
                        countBomb++;
                        choiceBoard[i, j + 1].Text = countBomb.ToString();

                        if (j < 9 && choiceBoard[i, j + 1].Text == "B")
                        {
                            countBomb++;
                            choiceBoard[i, j].Text = countBomb.ToString();
                        }

                        if (j < 7 && choiceBoard[i, j + 2].Text == "B")
                        {
                            countBomb++;
                            choiceBoard[i, j + 1].Text = countBomb.ToString();
                        }
                    }
                    countBomb = 0;
                }
            }
        }

        private void makeNumberHelpCloumn()
        {
            int countBomb = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (choiceBoard[j, i].Text == "B" && j < 9)
                    {
                        countBomb++;
                        choiceBoard[j + 1, i].Text = countBomb.ToString();

                        if (j < 9 && choiceBoard[j + 1, i].Text == "B")
                        {
                            countBomb++;
                            choiceBoard[j, i].Text = countBomb.ToString();
                        }

                        if (j < 7 && choiceBoard[j + 2, i].Text == "B")
                        {
                            countBomb++;
                            choiceBoard[j + 1, i].Text = countBomb.ToString();
                        }

                    }
                    countBomb = 0;
                }
            }
        }

    }    
}