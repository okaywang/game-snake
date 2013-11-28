using BasicLibrary;
using SimpleGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisLibrary;
using TetrisLibrary.Commands;
using TetrisLibrary.DataContext;
using TetrisLibrary.DataContext.Tetromino;
using WindowsFormsApplication1;

namespace WinFormTetris
{
    public partial class FrmTetrisView : Form, ITetrisGameView
    {
        private int[] _scoreIndicator = { 100, 200, 400, 800 };
        public FrmTetrisView()
        {
            InitializeComponent();
        }
        public void GameOver(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show("game over");
                this.btnPause.Enabled = false;
                this.btnRestart.Enabled = true;
            }));
        }

        public void RowsEliminatedHandler(object sender, EliminateRowsEventArgs e)
        {
            this.Invoke(new Action(() =>
              {
                  this.lblScore.Text = (Int32.Parse(this.lblScore.Text) + _scoreIndicator[e.EliminateRowsCount - 1]).ToString();
              }));
        }

        public void ClearObjects()
        {
            throw new NotImplementedException();
        }

        private Action _actionStart;
        public Action StartRequest
        {
            set { _actionStart = value; }
            protected get { return _actionStart; }
        }

        private Action _actionPause;
        public Action PauseRequest
        {
            set { _actionPause = value; }
            protected get { return _actionPause; }
        }

        private Action _actionReset;
        public Action ResetRequest
        {
            set { _actionReset = value; }
            protected get { return _actionReset; }
        }

        private Action _actionStop;
        public Action StopRequest
        {
            set { _actionStop = value; }
            protected get { return _actionStop; }
        }

        private Action<CommandOrientation> _actionOrientate;
        public Action<CommandOrientation> OrientationReqest
        {
            set { _actionOrientate = value; }
            protected get { return _actionOrientate; }
        }

        public void RenderMap(int rowCount, int columnCount)
        {
            this.tetrominoChest1.SetTetrominos(new Block[rowCount, columnCount]);
        }

        public void RenderScence(SimpleGame.IDataModel model)
        {
            var m = model as TetrisGameModel;

            var data = m.GetUnderlyingData();
            var spareTireData = m.GetUnderlyingDataSpareTire(5, 5);

            this.tetrominoChest2.SetTetrominos(spareTireData);
            this.tetrominoChest1.SetTetrominos(data);
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            this.StartRequest(); 
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            this.PauseRequest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PauseRequest();
        }
        private void FrmTetrisView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    OrientationReqest(new CommandUp());
                    break;
                case Keys.Down:
                    OrientationReqest(new CommandDown());
                    break;
                case Keys.Left:
                    OrientationReqest(new CommandLeft());
                    break;
                case Keys.Right:
                    OrientationReqest(new CommandRight());
                    break;
                case Keys.Space:
                    OrientationReqest(new CommandBlank());
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
