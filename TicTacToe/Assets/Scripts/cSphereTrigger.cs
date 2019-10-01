using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSphereTrigger : MonoBehaviour
{
        int _evenCount = 0;

        public c3x3[] g3x3;
        bool allGridsInvisible = false;

        private void Start()
        {
                setActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.tag == "TriggerCell")
                {
                        //other.gameObject.SetActive(true);
                        print("ENTER");
                }
        }

        private void OnTriggerExit(Collider other)
        {
                if (other.tag == "TriggerCell")
                {
                        //setActive(false);
                        print("EXIT");
                }
        }

        void setActive(bool active)
        {
                foreach (c3x3 c in g3x3)
                {
                        c.gameObject.SetActive(active);
                }
        }

       


}
