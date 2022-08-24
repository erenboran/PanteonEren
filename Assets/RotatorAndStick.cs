using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RotatorAndStick : MonoBehaviour
{

    [SerializeField] private float maxAngle = 360;
    [SerializeField] private float CompSpeed = 4;
    void Start()
    {
        transform.DORotate(new Vector3(0, maxAngle, 0), CompSpeed, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }


}
