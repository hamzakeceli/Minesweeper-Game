using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mine
{
    public partial class MineForm : Form
    {
        

        public MineForm()
        {
            InitializeComponent();
            
        }
        
        public int buttonNumber = 10, mineNumber = 10, openedButtonNumber;
        Button[,] buttons;       
        Random random = new Random();
        ButtonInformation[,] buttoninfoArray;
       


        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[buttonNumber, buttonNumber];
            buttoninfoArray = new ButtonInformation[buttonNumber, buttonNumber];

            CreateButton();
            CreateMine();
        }

        //Buttonları oluşturma
        public void CreateButton()
        {
            for (int i = 0; i < buttonNumber; i++)
            {
                for (int j = 0; j < buttonNumber; j++)
                {
                    Button newbutton = new Button();
                    ButtonInformation buttonInformation = new ButtonInformation();

                    buttonInformation.location = new Point(i, j);
                    newbutton.Top = i * ButtonInformation.size;
                    newbutton.Left = j * ButtonInformation.size;
                    newbutton.BackColor = Color.Green;
                    newbutton.Size = new Size(ButtonInformation.size, ButtonInformation.size);
                    newbutton.Tag = buttonInformation;

                    
                    buttons[j, i] = newbutton;
                    buttoninfoArray[j, i] = buttonInformation;
                    Panel.Controls.Add(newbutton);

                    newbutton.Click += new EventHandler(ClickAdd);                    

                }
            }
        }

        //Mayınları oluşturma
        public void CreateMine()
        {
            int mineX, mineY;


            for (int i = 0; i < mineNumber; i++)
            {
                mineX = random.Next(0, buttonNumber);
                mineY = random.Next(0, buttonNumber);

                //farklı lokasyon bulana kadar yeniden lokasyon üret
                while (buttoninfoArray[mineX, mineY].isMine == true)
                {
                    mineX = random.Next(0, buttonNumber);
                    mineY = random.Next(0, buttonNumber);
                }

                buttoninfoArray[mineX, mineY].isMine = true;
                buttons[mineX, mineY].BackColor = Color.Red;

            }

        }       
       
        
        //butona tıklandığında ek olarak  yapılacaklar
        public void ClickAdd(object sender, EventArgs e)
        {                                

            Button clickedButton = sender as Button;
            int locationX = clickedButton.Location.X / ButtonInformation.size;
            int locationY = clickedButton.Location.Y / ButtonInformation.size;
           

            int neighborMineCount;
            neighborMineCount= NeighborMineCount(locationX, locationY);

            //tıklanan buton mayınsa
            if (buttoninfoArray[locationX, locationY].isMine)
            {
                /*SoundPlayer player = new SoundPlayer();
                string path = "E:\\Kalimba.mp3";        // Müzik adresi
                player.SoundLocation = path;
                player.Play(); //play it
                */

                DialogResult resultMessage = MessageBox.Show("Mayına Bastınız yeniden oynamak istiyor musunuz?", "KAYBETTİNİZ", MessageBoxButtons.YesNo);
                EndGameMessage(resultMessage);
            }
            //mayın değilse
            else
            {       //komşumayın 0 sa tüm bağlı 0ları bul
                if (neighborMineCount == 0)
                {
                    OpenZeroNeighbor(locationX, locationY);
                }
                else
                {
                    buttons[locationX, locationY].Text = neighborMineCount.ToString();
                  //  Color c = Colors
;                    //buttons[locationX, locationY].BackColor=Colors.
                    buttons[locationX, locationY].BackColor = Color.WhiteSmoke;
                    

                }

            }

            int notMineButtonNumber = (buttonNumber * buttonNumber) - mineNumber;
            if (CountOpenedButton(buttons) >=notMineButtonNumber )
            {
                DialogResult resultMessage = MessageBox.Show("Tebrikler kazandınız yeniden oynamak istiyor musunuz?", "KAZANDINIZ", MessageBoxButtons.YesNo);
                EndGameMessage(resultMessage);
            }                    
            lblOpenedButonCount.Text = CountOpenedButton(buttons).ToString();

        }

        //Oyun kazanınca yada kaybeddince tamammı devammı mesajı
        private static void EndGameMessage(DialogResult resultMessage)
        {
            if (resultMessage == DialogResult.Yes)
            {
                Application.Restart();

            }
            else
            {
                //this.Close();
                Application.Exit();
            }
        }

        //komşusunda kaç tane mayın var
        public int NeighborMineCount(int X, int Y)
        {
          
            int[,] NeighborButton = {{ X, Y - 1 }, { X, Y+ 1 },
                                    { X-1, Y - 1 }, { X-1, Y },{ X-1, Y + 1 },
                                    { X+1, Y - 1 }, { X+1, Y }, { X+1, Y + 1 },};
                       

            for (int i = 0; i < 8; i++)
            {

               int butonX= NeighborButton[i, 0];
               int butonY= NeighborButton[i, 1];
                //sınırlar içindeyse
                if(butonX>=0 && butonY>=0 && butonX < buttonNumber && butonY<buttonNumber)
                {
                   
                    if (buttoninfoArray[butonX, butonY].isMine == true)
                    {
                        buttoninfoArray[X, Y].neigboardMine++;
                    }
                }     
            }


            if (buttoninfoArray[X, Y].neigboardMine != 0)
            {
                buttons[X, Y].Enabled = false;
                buttons[X, Y].BackColor = Color.WhiteSmoke;
                //openedButtonNumber++;
            }
            buttons[X, Y].Text = buttoninfoArray[X, Y].neigboardMine.ToString();            

            return buttoninfoArray[X, Y].neigboardMine;
        }

         //komşu 0 olanları bulana kadar devam et
        public void OpenZeroNeighbor(int X, int Y)
        {
            if (X >= 0 && Y >= 0 && X < buttonNumber && Y < buttonNumber)
            {
                if (NeighborMineCount(X, Y) == 0 && buttons[X, Y].Enabled == true)
                {

                  
                    buttons[X, Y].BackColor = Color.WhiteSmoke;
                    buttons[X, Y].Enabled = false;
                   // openedButtonNumber++;
                         
                    OpenZeroNeighbor(X + 1, Y);                   
                    OpenZeroNeighbor(X - 1, Y);                  
                    OpenZeroNeighbor(X, Y+1);                   
                    OpenZeroNeighbor(X, Y-1);
                    
                }
            }            

        }

        //açılan buttonları say
        public int CountOpenedButton(Button[,] buttons)
            
        {
            openedButtonNumber = 0;
            for (int i = 0; i < buttonNumber; i++)
            {
                for (int j = 0; j < buttonNumber; j++)
                {
                    if (buttons[i, j].Enabled == false)
                        openedButtonNumber++;
                }
            }

            //MessageBox.Show(Colors.);

            return openedButtonNumber ;
        }
       
        
        
    }
    enum Colors
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Black = 3,
        Yellow = 4,
        Gray = 5


    };
}
