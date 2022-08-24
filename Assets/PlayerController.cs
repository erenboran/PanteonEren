using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : PlayerManager
{
    //Player Controller Finish
    public Transform fnishCenter;

    public Animator anim;
    
    [Header("Borders")]
    private float minXBound = -15f;
    private float maxXBound = 15f;


    [Header("Player Settings")]
    public static float speed = 1f;
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

           // transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXBound, maxXBound), transform.position.y, transform.position.z); // Determine the borders for sliding.
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
        //if (collision.gameObject.tag.Equals("Platform"))
        //{
        //    transform.DOMoveX(transform.position.x + 0.3f, 0.4f).SetRelative(true).SetEase(Ease.Linear);
        //    collision.gameObject.tag = "Untagged";
        //}
        if (collision.gameObject.tag.Equals("PlatformL"))
        {
            transform.DOMoveX(transform.position.x + -0.3f, 0.4f).SetRelative(true).SetEase(Ease.Linear);
            collision.gameObject.tag = "Untagged";
        }
        //Finish Controller
        if (collision.gameObject.tag.Equals("finish"))
        {
            GameManager.Instance.levelFnish = true;
            {

                GameManager.Instance.fnishCheck();
                transform.DOJump(endPos, jumpPower, 1, duration);

            }
        }

    }
    #endregion

    #region Fnish System

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag.Equals("finish"))
    //    {
    //        GameManager.Instance.levelFnish = true;
    //        {
                
    //            GameManager.Instance.fnishCheck();
    //        }
    //    }
    //}

    #endregion
}
