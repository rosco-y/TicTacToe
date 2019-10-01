using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCell : MonoBehaviour
{
        int _eventCount = 0;

        private void OnMouseDown()
        {
                _eventCount++;
                print("Mouse Event");
        }
}
