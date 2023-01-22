using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace InfinityRun.UI
{
    public class RotateGear : MonoBehaviour
    {
        [SerializeField] GameObject gear;
        [SerializeField] float timeRotate;
        [SerializeField] int rotateAngle;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Rotate()
        {
           gear.transform.transform.DORotate(new Vector3(0, 0, rotateAngle), timeRotate);
        }
    }
}

