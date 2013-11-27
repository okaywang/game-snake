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
            this.tetrominoChest1.SetTetrominos(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RenderMap(5, 3);

            var model = new TetrisGameModel();
            var floors = new Floor[5];
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i] = new Floor(5, 3);
            }
            model.Apartment = new TetrisLibrary.DataContext.Apartment(floors);
            model.Tetromino = new T_Tetromino();
            model.ActiveRowIndex = -1;
            RenderScence(model);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.StartRequest();
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
         
    }
}
