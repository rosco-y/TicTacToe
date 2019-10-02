using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3x3 : MonoBehaviour
{
        public cCell[] _cells;
        static c3x3 _instance;
        int _gridValue; // indicates winner of this grid
        private void Start()
        {
                _instance = this;
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




}
