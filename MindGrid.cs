using MindGrid.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class MindGrid : Form
    {

        //Enumrations 
        enum enTurnPlayers
        {
            ekPLAYER_ONE = 1,
            ekPLAYER_TWO = 2
        }

        enum enWinnerGame
        {
            ekPLAYER_ONE = 1 , 
            ekPALYER_TWO = 2 , 
            ekDRAW = 3 , 
            ekIN_PROSSES = 4 
        }

        private string howTurnToGame(enTurnPlayers whatPlayer)
        {
            if (whatPlayer == enTurnPlayers.ekPLAYER_ONE) {

               labelHowTurnNow.ForeColor = Color.FromArgb(255, 140, 250); 
                return "Player1";
            }
            else
            {
                labelHowTurnNow.ForeColor = Color.FromArgb(212, 255, 114);
                return "Player2";
            }

        }
       
        private void changeTheImageAccordingTheTurnPlay (string whoTurnPlayRound)
        {
            if (whoTurnPlayRound == "Player1")
                PictureBoxTurnImage.Image = Resources.X_Image_Tic_Tac_Toe;
            else if (whoTurnPlayRound == "Player2")
                PictureBoxTurnImage.Image = Resources.O_Image_Tic_Tac_Toe;
            else
                PictureBoxTurnImage.Image = Resources.game_over_Image_; 


        }
     
        private void changeTheImageAccordingTheWinnerGame(string whoWinnerRound)
        {
            if (whoWinnerRound == "Player1")
                PictureBoxHowWinnerImage.Image = Resources.X_Image_Tic_Tac_Toe;
            else if (whoWinnerRound == "Player2")
                PictureBoxHowWinnerImage.Image = Resources.O_Image_Tic_Tac_Toe;
            else if (whoWinnerRound == "Draw")
                PictureBoxHowWinnerImage.Image = Resources.game_over_Image_;

            else
                PictureBoxHowWinnerImage.Image = Resources.In_Process1;

        }

        //Constant Game
        private const ushort _NUMBER_ROW_ARRAY = 3;
        private const ushort _NUMBER_COLUMN_ARRAY = 3;
        private  bool _FLAG_IS_ALL_CONTROL_INITIAL_SETTING = true; 

        //Private Variable 
        private ushort countGame = 0;         
        private PictureBox[,] arrayPictureBoxMindGrid = new PictureBox[_NUMBER_ROW_ARRAY, _NUMBER_COLUMN_ARRAY];
        private enTurnPlayers startFirstGame = enTurnPlayers.ekPLAYER_ONE;


        private void InitialSettingMindGrid()
        {
            startFirstGame = enTurnPlayers.ekPLAYER_ONE;
            labelWhoWinnerGame.ForeColor = Color.White;
            labelWhoWinnerGame.Text = "In Process";
            ResetPictureBoxControl();
            labelHowTurnNow.Text = howTurnToGame(startFirstGame);
            changeTheImageAccordingTheTurnPlay(labelHowTurnNow.Text);
            InitializationArrayPictureBoxies();
            PictureBoxHowWinnerImage.Image = Resources.In_Process1;
            countGame = 0;
     
        }
    
        private void InitializationArrayPictureBoxies()
        {

            arrayPictureBoxMindGrid[0, 0] = pictureBox1;
            arrayPictureBoxMindGrid[0, 1] = pictureBox2;
            arrayPictureBoxMindGrid[0, 2] = pictureBox3;
            arrayPictureBoxMindGrid[1, 0] = pictureBox4;
            arrayPictureBoxMindGrid[1, 1] = pictureBox5;
            arrayPictureBoxMindGrid[1, 2] = pictureBox6;
            arrayPictureBoxMindGrid[2, 0] = pictureBox7;
            arrayPictureBoxMindGrid[2, 1] = pictureBox8;
            arrayPictureBoxMindGrid[2, 2] = pictureBox9;

        }
      
        private enWinnerGame WhoWinnerGame()
        {
            for (int counter = 0; counter < _NUMBER_ROW_ARRAY; counter++)
            {
                //Row
                if (
                       ((string)arrayPictureBoxMindGrid[counter, 0].Tag == "X" && (string)arrayPictureBoxMindGrid[counter, 1].Tag == "X" && (string)arrayPictureBoxMindGrid[counter, 2].Tag == "X") ||
                        ((string)arrayPictureBoxMindGrid[0, counter].Tag == "X" && (string)arrayPictureBoxMindGrid[1, counter].Tag == "X" && (string)arrayPictureBoxMindGrid[2, counter].Tag == "X")
                    ) return enWinnerGame.ekPLAYER_ONE;

                //Column
                if (
                      ((string)arrayPictureBoxMindGrid[counter, 0].Tag == "O" && (string)arrayPictureBoxMindGrid[counter, 1].Tag == "O" && (string)arrayPictureBoxMindGrid[counter, 2].Tag == "O") ||
                       ((string)arrayPictureBoxMindGrid[0, counter].Tag == "O" && (string)arrayPictureBoxMindGrid[1, counter].Tag == "O" && (string)arrayPictureBoxMindGrid[2, counter].Tag == "O")
                   ) return enWinnerGame.ekPALYER_TWO;
            }

            //Diagonal
            if (((string)arrayPictureBoxMindGrid[0, 2].Tag == "X" && (string)arrayPictureBoxMindGrid[1, 1].Tag == "X" && (string)arrayPictureBoxMindGrid[2, 0].Tag == "X") ||
                ((string)arrayPictureBoxMindGrid[0, 0].Tag == "X" && (string)arrayPictureBoxMindGrid[1, 1].Tag == "X" && (string)arrayPictureBoxMindGrid[2, 2].Tag == "X")
                ) return enWinnerGame.ekPLAYER_ONE;

            if (((string)arrayPictureBoxMindGrid[0, 2].Tag == "O" && (string)arrayPictureBoxMindGrid[1, 1].Tag == "O" && (string)arrayPictureBoxMindGrid[2, 0].Tag == "O") ||
             ((string)arrayPictureBoxMindGrid[0, 0].Tag == "O" && (string)arrayPictureBoxMindGrid[1, 1].Tag == "O" && (string)arrayPictureBoxMindGrid[2, 2].Tag == "O")
         ) return enWinnerGame.ekPALYER_TWO;



            return enWinnerGame.ekIN_PROSSES;
        }

        private string WhoWinnerInGame(enWinnerGame whowinner)
        {
            if (whowinner == enWinnerGame.ekPLAYER_ONE) return "Player1";
            else if (whowinner == enWinnerGame.ekPALYER_TWO) return "Player2";
            else if (countGame == 9) return "Draw";

            return "In Process";
        }

        private void changeImagesPictureBoxAndTurnGame ( ref PictureBox PB , ushort row , ushort column/* , PictureBox[,] arrayPictureBoxies */ )
        {

            if (startFirstGame == enTurnPlayers.ekPLAYER_ONE)
            {
                PB.Image = Resources.X_Image_Tic_Tac_Toe;
                PB.Tag = "X";
                startFirstGame = enTurnPlayers.ekPLAYER_TWO;
                labelHowTurnNow.Text = howTurnToGame(startFirstGame);
                changeTheImageAccordingTheTurnPlay(labelHowTurnNow.Text);
            }
            else
            {
                PB.Image = Resources.O_Image_Tic_Tac_Toe;
                PB.Tag = "O";
                startFirstGame = enTurnPlayers.ekPLAYER_ONE;
                labelHowTurnNow.Text = howTurnToGame(startFirstGame);
                changeTheImageAccordingTheTurnPlay(labelHowTurnNow.Text);
            }

            countGame++;
            PB.Enabled = false;
            labelWhoWinnerGame.Text =  WhoWinnerInGame(WhoWinnerGame());
            changeTheImageAccordingTheWinnerGame(labelWhoWinnerGame.Text);
            ShowMessageBoxAfterWinner(labelWhoWinnerGame.Text);
            _FLAG_IS_ALL_CONTROL_INITIAL_SETTING = false;
        }

        private void ResetPictureBoxControl()
        {
            foreach (Control outterControl in this.Controls )
            {
                if (outterControl is PictureBox PB)
                {
                        PB.Image = Resources.NOT_Image;
                        PB.Tag = "";
                        PB.Enabled = true;

                }
            }
        }
     
        private void setSettingTurnAfterAnyPlayerWinner()
        {
            labelHowTurnNow.ForeColor = Color.FromArgb(155, 213, 255);
            labelHowTurnNow.Text = "Game Over";
            changeTheImageAccordingTheTurnPlay(labelHowTurnNow.Text);

        }

        private void ShowMessageBoxAfterWinner (string wordWinner)
        {
            bool flagIsWin = false; 
            if (wordWinner == "Player1")
            {
                setSettingTurnAfterAnyPlayerWinner();
                labelWhoWinnerGame.ForeColor = Color.FromArgb(255, 140, 250);
                MessageBox.Show
                    ($"The Winner this Round Game [ {wordWinner} ] "
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                flagIsWin = true; 
            }

            if (wordWinner == "Player2")
            {
                setSettingTurnAfterAnyPlayerWinner();
                labelWhoWinnerGame.ForeColor = Color.FromArgb(212, 255, 114);
                MessageBox.Show
                    ($"The Winner this Round Game [ {wordWinner} ] "
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                flagIsWin = true;
            }

            if (countGame == 9 && wordWinner == "Draw")
            {
                setSettingTurnAfterAnyPlayerWinner();
                labelWhoWinnerGame.ForeColor = Color.FromArgb(155, 213, 255);
                MessageBox.Show
                    ($"No The Winner [ Draw ] this Round Game"
                    , "Who Winner Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                flagIsWin = true;
            }

            if(flagIsWin)
            foreach (Control outterControl in this.Controls)
            {
                if (outterControl is PictureBox PB)
                {
                    PB.Enabled = false;
                }
            }

        }
 
        public MindGrid()
        {
            InitializeComponent();
            InitialSettingMindGrid();
        }

        private void DrawLinesTicTacToeGrid(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.White, 8))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                // الخطوط العمودية (مزاحة للشمال)
                e.Graphics.DrawLine(pen, new Point(1100, 190), new Point(1100, 830)); // كان 1160
                e.Graphics.DrawLine(pen, new Point(1390, 190), new Point(1390, 830)); // كان 1450

                // الخطوط الأفقية (مزاحة للشمال)
                e.Graphics.DrawLine(pen, new Point(900, 370), new Point(1654, 370)); // كان 960 و 1714
                e.Graphics.DrawLine(pen, new Point(900, 610), new Point(1654, 610)); // نفس التعديل
            }
        }



        private void MindGrid_Paint(object sender, PaintEventArgs e)
        {
            DrawLinesTicTacToeGrid(e); 
        }

        // Events Picture
        private void pictureBoxMindGridGame_Click(object sender, EventArgs e)
        {
            PictureBox PB = sender as PictureBox; 

            changeImagesPictureBoxAndTurnGame( ref PB, 0, 1 /*arrayPictureBoxMindGrid*/);

        }

        //Start Section Control Buttons 
        private void GButtonExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GButtonRestartGame_Click(object sender, EventArgs e)
        {
            if (!_FLAG_IS_ALL_CONTROL_INITIAL_SETTING )
            InitialSettingMindGrid();
            else
                MessageBox.Show
                    ("The Game Already is Reset All Setting\nPlease Go To Play Mind Grid"
                    , "Note Mind Grid Restart Game"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);

            //Change Value Flag After Restart 
            _FLAG_IS_ALL_CONTROL_INITIAL_SETTING = true; 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimeNow.Text = DateTime.Now.ToString();
        }
    }
}
