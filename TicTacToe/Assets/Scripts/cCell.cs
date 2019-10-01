﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCell : MonoBehaviour
{
        int _gridNo;
        int _cellNo;
        public Light _spotlight;

        private void OnMouseDown()
        {
                _gridNo = int.Parse(this.GetComponentInParent<c3x3>().name.Trim().Substring(1));
                _cellNo = int.Parse(this.name.Trim().Substring(1));
                //print($"({_gridNo},{_cellNo})");

                // look at center of grid selected by position of cell clicked.
                Transform target = cSuperGrid.Instance[_cellNo][4].transform;
                cSpotlight.Instance.LookAt(target);
        }
}
