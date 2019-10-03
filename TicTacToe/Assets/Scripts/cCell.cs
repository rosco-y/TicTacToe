using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCell : MonoBehaviour
{
        int _gridNo;
        int _cellNo;
        //public Light _spotlight;
        public GameObject _turnIndicator;
        public float lightSpeed = 1f;
        public Material _red;
        public Material _green;
        int _cellValue;
        private void OnMouseDown()
        {

                if (cGameManager.GameOverFlag)
                        return;

                _gridNo = int.Parse(this.GetComponentInParent<c3x3>().name.Trim().Substring(1));

                int curGrid = cSuperGrid.Instance.CurGrid;
                if (!(curGrid == _gridNo || curGrid < 0))
                {
                        return; // have to click on current grid.
                }
                if (cSuperGrid.Instance[_gridNo].GridIsWon)
                {
                        return; // no clicking on a won grid.
                }

                _cellNo = int.Parse(this.name.Trim().Substring(1));

                if (this._cellValue > 0)
                        return; // don't try to change the owner of a cell.

                // look at center of grid selected by position of cell clicked.
                Transform target = cSuperGrid.Instance[_cellNo][4].transform;
                // set the value of the cell to either 3 or 5, to indicate who it belongs to.
                _cellValue = cGameManager.REDTURN ? cGameManager.REDVALUE : cGameManager.GREENVALUE;
                // colorize to make the game playable.
                this.GetComponent<Renderer>().material = curMaterial();
                // take turns.
                if(cSuperGrid.Instance[_gridNo].CheckForWinner())
                {
                        cSuperGrid.Instance[_gridNo].ColorWonGrid(curMaterial());
                        // grid is won.
                        if (cSuperGrid.Instance.CheckForWinner())
                        {
                                cSuperGrid.Instance.ColorSuperGridWinner(curMaterial());
                                cSpotlight.Instance.SetSpotWidth(true);
                        }
                }

                if (!cSuperGrid.Instance[_cellNo].GridIsWon)
                        cSuperGrid.Instance.CurGrid = _cellNo;
                else
                        cSuperGrid.Instance.CurGrid = -1;
                cSpotlight.Instance.Target = target;

                // change player turn
                cGameManager.REDTURN = !cGameManager.REDTURN;
                _turnIndicator.GetComponent<Renderer>().material = curMaterial();
        }

        Material curMaterial()
        {
                return cGameManager.REDTURN ? _red : _green;
        }

        public int CellValue
        {
                set { _cellValue = value; }
                get { return _cellValue; }
        }

}
