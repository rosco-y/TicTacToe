using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSphereTrigger : MonoBehaviour
{
        int _evenCount = 0;

        private void OnTriggerEnter(Collider other)
        {
                if (other.tag == "TriggerCell")
                        _evenCount++;
        }                       

   
}
