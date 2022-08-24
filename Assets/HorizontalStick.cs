using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalStick : MonoBehaviour
{

    [Header("HorizontalStick")]
    [Tooltip("'-1' For going right / '1' For going left")]
    public float StickMove = -1f;


    private void Start()
    {
        transform.DOMoveX(StickMove, 3f).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 90, 0), 5f, RotateMode.LocalAxisAdd).SetLoops(-1);
    }

}
