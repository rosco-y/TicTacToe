using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3x3 : MonoBehaviour
{
        public cCell[] _cells;
        
        static c3x3 _instance;
        int _gridValue = 0; // indicates winner of this grid
        private void Start()
        {
                _instance = this;                
        }

        public cCell[] Cells
        {
                get { return _cells; }
        }
        public static c3x3 Instance
        {
                get { return _instance; }
                set { _instance = value; }
        }

        public cCell this[int index]
        {
                get { return _cells[index]; }
                set { _cells[index] = value; }
        }

        public int GridValue
        {
                // TODO: PROBABLY WILL BE READ-ONLY (VALUE MAY BE SET IN A "CheckWin()" routine
                set { _gridValue = value; }
                get { return _gridValue; }
        }

        public bool CheckForWinner()
        {
                bool winner = false;
                int[,] values = make2dValuesArray();
                int redSum = cGameManager.REDVALUE * 3;
                int greenSum = cGameManager.GREENVALUE * 3;
                int sum = 0;
                // 1) CHECK ROWS
                for (int row = 0; row < cGameManager.GRIDSIZE; row++)
                {
                        sum = 0;
                        for (int col = 0; col < cGameManager.GRIDSIZE; col++)
                        {
                                sum += values[row, col];
                        }
                        winner = (sum == redSum || sum == greenSum);
                        if (winner)
                                break;

                }
                if (!winner)
                {
                        // 2) CHECK COLS
                        for (int col = 0; col < cGameManager.GRIDSIZE; col++)
                        {
                                sum = 0;
                                for (int row = 0; row < cGameManager.GRIDSIZE; row++)
                                {
                                        sum += values[row, col];
                                }
                                winner = (sum == redSum || sum == greenSum);
                                if (winner)
                                        break;
                        }
                        if (!winner)
                        {
                                // 3) CHECK DIAG TOP-LEFT TO BOT-RIGHT
                                sum = 0;
                                sum += values[2, 0];
                                sum += values[1, 1];
                                sum += values[0, 2];
                                winner = (sum == redSum || sum == greenSum);

                                if (!winner)
                                {
                                        // 4) CHECK DIAG BOT-LEFT TO TOP-RIGHT
                                        sum = 0;
                                        sum += values[0, 0];
                                        sum += values[1, 1];
                                        sum += values[2, 2];
                                        winner = (sum == redSum || sum == greenSum);
                                }
                        }
                }
                if (winner)
                {
                        // set winner value for grid.
                        this._gridValue = cGameManager.REDTURN ? cGameManager.REDVALUE : cGameManager.GREENVALUE;
                }
                return winner;
        }

        int[,] make2dValuesArray()
        {
                int width = cGameManager.GRIDSIZE;
                int height = cGameManager.GRIDSIZE;
                int[,] aValues = new int[width, height];
                for (int i = 0; i < width; i++)
                {
                        for (int j = 0; j < height; j++)
                        {
                                aValues[i, j] = _cells[i * width + j].CellValue;
                        }
                }
                return aValues;
        }

        public void ColorWonGrid(Material color)
        {
                foreach (cCell cell in _cells)
                {
                        cell.GetComponent<Renderer>().material = color;
                }
        }

        public  bool GridIsWon
        {
                get { return _gridValue != 0; }
        }




}
