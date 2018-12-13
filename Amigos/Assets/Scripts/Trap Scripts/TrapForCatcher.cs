﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapForCatcher : MonoBehaviour {

    float timer = 0.0f;
    bool timeStarted = false;
    int seconds;
    public AudioClip catcher_trigger_sound;
    //Set A Private Collider As The Collider We Want To Control
    private Collider current_collision;
    private Rigidbody current_rigi;
    private Vector3 _storedVelocity = Vector3.zero;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This Part Is To Set The Character Kinematic.
    private void OnTriggerEnter(Collider other)
    {
        //current_collision = null;
        
        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4")
        {

            timer = 0.0f;
            current_collision = other;

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<CharacterMovement_Physics>().set_canAim(false);

            other.GetComponent<AudioSource>().PlayOneShot(catcher_trigger_sound, (float)0.7);
        }

        animator.SetTrigger("tActivate");
    }
}
