using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSuperGrid : MonoBehaviour
{
        public c3x3[] _grids;
        static cSuperGrid _instance;
        int _curGrid = -1; // not set

        private void Start()
        {
                _instance = this; 
        }

        public c3x3 this[int index]
        {
                get { return _grids[index]; }
                set { _grids[index] = value; }
        }

        public static cSuperGrid Instance
        {
                get { return _instance; }
                set { _instance = value; }
        }

        public int CurGrid
        {
                get { return _curGrid; }
                set { _curGrid = value; }
        }
               

}
