using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSpotlight : MonoBehaviour
{
        // Start is called before the first frame update
        static cSpotlight _instance;
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
                Vector3 direction = (this.transform.forward - _target.position).normalized;
                Vector3 tmpTarget = Vector3.Lerp(_target.position, direction, Time.deltaTime * _lightSpeed);
                this.transform.LookAt(tmpTarget);
                //''Quaternion lookRotation = Quaternion.LookRotation(direction);
                //this.transform.LookAt(Quaternion.Slerp((this.transform.rotation, lookRotation, Time.deltaTime * _lightSpeed));
                //this.transform.LookAt(Vector3.Lerp(_target.position, this.transform.forward, Time.deltaTime * _lightSpeed));
        }
}
