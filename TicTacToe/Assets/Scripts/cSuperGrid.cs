using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSuperGrid : MonoBehaviour
{
        public c3x3[] _grids;
        static cSuperGrid _instance;

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
               

}
