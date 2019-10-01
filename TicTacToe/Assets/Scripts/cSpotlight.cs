using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSpotlight : MonoBehaviour
{
        // Start is called before the first frame update
        static cSpotlight _instance;
        Transform _target;
        void Start()
        {
                _instance = this;
        }

        public static cSpotlight Instance
        {
                get { return _instance; }
                set { _instance = value; }
        }

        public Transform Target
        {
                set { _target = value; }
        }


        private void FixedUpdate()
        {
                this.transform.LookAt(_target);
        }
}
