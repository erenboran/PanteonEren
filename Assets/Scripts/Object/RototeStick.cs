using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RototeStick : MonoBehaviour
{

    [Header("HorizontalStick")]
    public GameObject horizontalObstacle, horizontalObstacle2;

    [Tooltip("'-1' For going right - '1' For going left")]
    public float Stick;


    private void Start()
    {
        horizontalObstacle.transform.DOMoveX(-1, 3f).SetLoops(-1, LoopType.Yoyo);
        horizontalObstacle.transform.DORotate(new Vector3(0, 90, 0), 5f, RotateMode.LocalAxisAdd).SetLoops(-1);
    }

    void Update()
    {

    }
}
