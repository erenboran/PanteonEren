using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : PlayerManager
{
    //Player Controller Finish
    public Transform fnishCenter;

    public Animator anim;

    [Header("Player Settings")]
    public static float speed = 1.1f;
    public float swipeSpeed;

    [Header("JumpSettings")]
    public Vector3 endPos;
    public float jumpPower;
    public float duration;


    private void Start()
    {
        PlayerManager.Instance.downParticle.Stop();     
        this.anim = this.GetComponentInChildren<Animator>() ?? this.GetComponent<Animator>();

    }

    #region Movement
    private void FixedUpdate()
    {
        if (GameManager.Instance.gameStart && GameManager.Instance.levelFnish != true)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

            if (Input.GetButton("Fire1"))
            {
                Move();
            }
        }
    }

    public void Move() // For sliding.
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.localPosition.z;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 150))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            hitPoint.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, hitPoint, Time.deltaTime * swipeSpeed);
        }
    }


    #endregion

    #region Obstacle System
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {   
            transform.DOMoveZ(transform.position.z - -0.75f, 0.5f);
            
        }
        if (collision.gameObject.tag.Equals("Stick"))
        {
            Rigidbody.AddForce (transform.position * 0.2f , ForceMode.Impulse);
        }


        #endregion
        #region Fnish System


        //Finish Controller
        if (collision.gameObject.CompareTag("finish"))
        {
            GameManager.Instance.levelFnish = true;
            {

                GameManager.Instance.fnishCheck();
                transform.DOJump(endPos, jumpPower, 1, duration);

            }
        }

    }
    #endregion

}
