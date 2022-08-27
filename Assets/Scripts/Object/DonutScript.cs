using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DonutScript : MonoBehaviour
{
    [Header("Donut Moving Stick Child Object")]
    public GameObject movingStick;
    public float stickDistance = 0.1f;
    public float stickSpeed = 4f;

    void Start()
    {
        movingStick.transform.DOMoveX(stickDistance + 1, stickSpeed).SetLoops(-1, LoopType.Yoyo);    
    }

}
