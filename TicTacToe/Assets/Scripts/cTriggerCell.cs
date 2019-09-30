using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cTriggerCell : MonoBehaviour
{
        int _eventCount = 0;
        public GameObject _sphere;

        private void OnMouseDown()
        {
                _eventCount++;
                _sphere.transform.position = this.transform.position;
        }

}
