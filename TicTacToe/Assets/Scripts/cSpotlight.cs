using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class cSpotlight : MonoBehaviour
{
        // Start is called before the first frame update
        static cSpotlight _instance;
        public Light _spotLight;
        float _wideAngle = 100f;
        float _spotAngle = 16f;
        Transform _target;
        public float _lightSpeed = 1f;
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
                transform.LookAt(_target);
        }

        public void SetSpotWidth(bool wide)
        {
                if (wide)
                {
                        // set spotlight in middle, and wide-angle to light entire
                        // supergrid.
                        _spotLight.spotAngle = _wideAngle;
                        _target = cSuperGrid.Instance[4][4].transform;
                }
                else
                {
                        // set spotlight to narrow spot.
                        _spotLight.spotAngle = _spotAngle;
                }
        }
}
