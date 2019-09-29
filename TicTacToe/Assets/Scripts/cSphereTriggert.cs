using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSphereTriggert : MonoBehaviour
{
        int _evenCount = 0;

        private void OnTriggerEnter(Collider other)
        {
                if (other.tag == "TriggerCell")
                        _evenCount++;
        }

        private void OnMouseDown()
        {
                _evenCount++;
        }
}
