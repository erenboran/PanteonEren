using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerController PlayerController { get; private set; }

    public ParticleSystem downParticle { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    public Animator Animator { get; private set; }


    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();

        downParticle = GetComponentInChildren<ParticleSystem>();

        Rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Animator = GetComponentInChildren<Animator>();
    }


}
