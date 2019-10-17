using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

/*
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
        bool _wide = true; // game starts in wide angle
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
                        _spotLightSet = false;

                }
        }


        bool _spotLightSet = false;
        float _epsilon = .01f;  // precision to consider spotlight finished lerping
        private void Update()
        {

                if (!_spotLightSet)
                {
                        if (!_wide)
                        {
                                Vector3 prevTarget = Vector3.Lerp(_prevTarget.position, _target.position, Time.deltaTime * _lightSpeed);
                                transform.LookAt(_prevTarget);
                                if (Vector3.SqrMagnitude(_target.position - prevTarget) <= _epsilon)
                                        _spotLightSet = true;

                        }
                        else
                        {
                                transform.LookAt(_target);
                                _spotLightSet = true;
                                _wide = false;
                        }
                }
        }


        public void SetSpotWidth(bool wide)
        {
                _wide = wide;
                if (_wide)
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
//*/