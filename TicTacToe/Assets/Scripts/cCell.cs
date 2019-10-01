using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCell : MonoBehaviour
{
        int _gridNo;
        int _cellNo;

        private void OnMouseDown()
        {
                //string parent = this.GetComponentInParent<c3x3>().name;
                _gridNo = int.Parse(this.GetComponentInParent<c3x3>().name.Trim().Substring(1));
                _cellNo = int.Parse(this.name.Trim().Substring(1));
                print($"({_gridNo},{_cellNo})");
        }
}
