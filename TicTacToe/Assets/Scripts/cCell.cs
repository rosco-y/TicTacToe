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
        Transform _originalTransform;
        static float _rotX, _rotY, _rotZ;
        public bool Rotate { get; set; }
        public float _rotateSpeed = 1f;
        static float _rotationDirectionSetter = 1f;
        float _rotationDir;
        static bool _rotationSaved;
        static Material _white;
        int _cellValue = 0;


        private void Start()
        {
                if (!_rotationSaved)
                {
                        saveRotation();
                        _rotationSaved = true;
                        _white = this.GetComponent<Renderer>().material;
                }
                _rotationDir = _rotationDirectionSetter;
                _rotationDirectionSetter *= -1f;
                
        }

        public static Material White
        {
                get { return _white; }
        }

        void saveRotation()
        {
                _rotX = this.transform.eulerAngles.x;
                _rotY = this.transform.eulerAngles.y;
                _rotZ = this.transform.eulerAngles.z;
        }

        void restoreRotation()
        {
                transform.eulerAngles = new Vector3(_rotX, _rotY, _rotZ);
        }

        private void Update()
        {
                if (Rotate)
                {
                        transform.Rotate(new Vector3(_rotationDir * 15, _rotationDir * 30, _rotationDir * 45) * Time.deltaTime * _rotateSpeed);
                }
                else
                {
                        restoreRotation();
                }
        }

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
                if(cSuperGrid.Instance[_gridNo].CheckForWinner())
                {
                        cSuperGrid.Instance[_gridNo].ColorWonGrid(curMaterial());
                        // grid is won.
                        if (cSuperGrid.Instance.CheckForWinner())
                        {
                                if (cGameManager.REDTURN)
                                        cGameManager.Instance.RedScore++;
                                else
                                        cGameManager.Instance.GreenScore++;

                                cSuperGrid.Instance.ColorSuperGridWinner(curMaterial());
                                //cSpotlight.Instance.SetSpotWidth(true);
                        }
                }

                if (!cGameManager.GameOverFlag && !cSuperGrid.Instance[_cellNo].GridIsWon)
                        cSuperGrid.Instance.CurGrid = _cellNo;
                else
                        cSuperGrid.Instance.CurGrid = -1;
                //cSpotlight.Instance.Target = target;

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
