using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c3x3 : MonoBehaviour
{
        public cCell[] _cells;
        static c3x3 _instance;

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




}
