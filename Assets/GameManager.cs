using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector] public bool gameStart = false;
    [HideInInspector] public bool levelFnish = false;
    public GameObject passedPanel;
    public ParticleSystem successParticle, shotParticle;


    public GameObject gunObject;
    public GameObject finalWall;


    private void Start()
    {
        successParticle.Stop();
    }
    // Game Start with touch screen
    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            gameStart = true;
            PlayerController.Instance.Animator.SetBool("run", true);

        }
    }

    public void fnishCheck()
    {
        {
        //    passedPanel.SetActive(true);
            successParticle.Play();
            PlayerController.Instance.Animator.SetBool("cheer", true);
            Debug.Log("hehe");
            finalWall.transform.DOMoveY(1.05f, 2f);
            shoot();
        }
    }

    public void shoot()
    {
        gunObject.SetActive(true);
        PlayerController.Instance.Animator.SetBool("shoot", true);
        shotParticle.Play();


    }
    #region Scene Control
    public void nextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}
