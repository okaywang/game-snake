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
using TetrisLibrary.DataContext;
using WindowsFormsApplication1;

namespace WinFormTetris
{
    public partial class FrmTetrisView : Form, ITetrisGameView
    {
        public FrmTetrisView()
        {
            InitializeComponent();
        }

        public void ClearObjects()
        {
            throw new NotImplementedException();
        }

        public Action StartRequest
        {
            set { throw new NotImplementedException(); }
        }

        public Action PauseRequest
        {
            set { throw new NotImplementedException(); }
        }

        public Action ResetRequest
        {
            set { throw new NotImplementedException(); }
        }

        public Action StopRequest
        {
            set { throw new NotImplementedException(); }
        }

        public Action<SimpleGame.CommandOrientation> OrientationReqest
        {
            set { throw new NotImplementedException(); }
        }

        public void RenderMap(int rowCount, int columnCount)
        {
            this.tetrominoChest1.SetTetrominos(new bool[rowCount, columnCount]);
        }

        public void RenderScence(SimpleGame.IDataModel model)
        {
            var m = model as TetrisGameModel;

            var data = m.GetUnderlyingData();
            this.tetrominoChest1.SetTetrominos(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RenderMap(20, 10);

            var model = new TetrisGameModel();
            var floors = new Floor[20];
            for (int i = 0; i < floors.Length; i++)
            {
                floors[i] = new Floor(20, 10);
            }
            model.Apartment = new TetrisLibrary.DataContext.Apartment(floors);
            model.Tetromino = new I_Tetromino();
            RenderScence(model);
        }
    }
}
