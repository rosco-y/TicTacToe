using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cTriggerCell : MonoBehaviour
{
        int _eventCount = 0;

        private void OnTriggerEnter(Collider other)
        {
                if (other.tag == "TriggerCell")
                        _eventCount++;
        }

        private void OnMouseDown()
        {
                _eventCount++;
        }

}
