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
        float _spotAngle = 15.975f;
        Transform _target;
        Transform _prevTarget;
        public float _lightSpeed = .0001f;
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
                set
                {
                        _target = value;
                        _prevTarget = _target;

                }
        }


        private void Update()
        {
                
                Vector3 prevTarget = Vector3.Lerp(_prevTarget.position, _target.position, Time.deltaTime * _lightSpeed);
                transform.LookAt(_prevTarget);
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
