using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCell : MonoBehaviour
{
        int _gridNo;
        int _cellNo;
        public Light _spotlight;
        public float lightSpeed = 1f;
        public Material _red;
        public Material _green;
        int _cellValue;
        private void OnMouseDown()
        {

                _gridNo = int.Parse(this.GetComponentInParent<c3x3>().name.Trim().Substring(1));

                int curGrid = cSuperGrid.Instance.CurGrid;
                if (!(curGrid == _gridNo || curGrid < 0))
                {
                        return; // have to click on current grid.
                }
                _cellNo = int.Parse(this.name.Trim().Substring(1));

                // look at center of grid selected by position of cell clicked.
                Transform target = cSuperGrid.Instance[_cellNo][4].transform;
                // set the value of the cell to either 3 or 5, to indicate who it belongs to.
                _cellValue = cGameManager.REDTURN ? cGameManager.REDVALUE : cGameManager.GREENVALUE;
                // colorize to make the game playable.
                this.GetComponent<Renderer>().material = cGameManager.REDTURN ? _red : _green;
                // take turns.
                cGameManager.REDTURN = !cGameManager.REDTURN;
                cSuperGrid.Instance.CurGrid = _cellNo;
                cSpotlight.Instance.Target = target;
        }

        public int CellValue
        {
                set { _cellValue = value; }
                get { return _cellValue; }
        }

}
