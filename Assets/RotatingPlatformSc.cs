using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  
public class RotatingPlatformSc : MonoBehaviour
{

    [SerializeField] private float maxAngle = -360;
    [SerializeField] private float CompSpeed = 1;

    void Start()
    {
        transform.DORotate (new Vector3(0, 0, maxAngle), CompSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
