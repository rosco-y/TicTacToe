using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSuperGrid : MonoBehaviour
{
        public c3x3[] _grids;
        static cSuperGrid _instance;
        int _curGrid = -1; // not set

        public void SetNewGameValues()
        {
                _curGrid = -1;
                foreach (c3x3 grid in _grids)
                {
                        grid.SetNewGameValues();

                }
        }
        private void Awake()
        {
                _instance = this;
        }

        private void Start()
        {
        }

        public c3x3 this[int index]
        {
                get { return _grids[index]; }
                set { _grids[index] = value; }
        }

        public static cSuperGrid Instance
        {
                get
                {
                        if (_instance == null)
                        {
                                GameObject go = new GameObject();
                                go.AddComponent<cSuperGrid>();
                        }
                        return _instance;
                }
        }

        public int CurGrid
        {
                get { return _curGrid; }
                set
                {
                        _curGrid = value;
                        cSpotlight.Instance.SetSpotWidth(
                                _curGrid < 0 ? true : false);   
                }
        }

        public void ColorSuperGridWinner(Material color)
        {
                foreach (c3x3 grid in _grids)
                {
                        grid.ColorWonGrid(color);
                }
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
                        cGameManager.GameOver();
                }
                // cSpotlight.Instance.SetSpotWidth(true);
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
                                aValues[i, j] = _grids[i * width + j].GridValue;
                        }
                }
                return aValues;
        }

        public bool Rotate
        {
                set
                {
                        foreach (c3x3 grid in _grids)
                        {
                                grid.Rotate = value;
                        }
                }
        }

        public void NewGameSettings()
        {
                _curGrid = -1; // not set
                foreach (c3x3 grid in _grids)
                {
                        grid.GridValue = 0;
                        grid.NewGameSettings();
                }
        }


}
