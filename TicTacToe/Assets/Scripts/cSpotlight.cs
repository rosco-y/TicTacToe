using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSpotlight : MonoBehaviour
{
        // Start is called before the first frame update
        static cSpotlight _instance;

        void Start()
        {
                _instance = this;
        }

        public static cSpotlight Instance
        {
                get { return _instance; }
                set { _instance = value; }
        }


        public void LookAt(Transform target)
        {
                this.transform.LookAt(target);
        }
}
