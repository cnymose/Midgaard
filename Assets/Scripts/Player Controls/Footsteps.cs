using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public AudioClip[] groundWalk;
    public AudioClip[] groundRun;
    public AudioClip groundJump;
    public AudioClip groundLand;
    private bool jump = false;
    private bool land = false;
    float audioStepLength = 0.10f;
    private PlayerMovement pM;
    private AudioSource source;
    CharacterController cc;
    
    public PlayerMovement.MovementState movementState;
    // Use this for initialization
    void Start()
    {

        pM = GetComponent<PlayerMovement>();
        source = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementState = pM.movementState;

        switch ((int) movementState)
        {
            case 0: //Idle
                break;
            case 1: //Walk
                WalkOnGround();
                break;
            case 2: //Run
                RunOnGround();
                break;
            case 3: //Jump
                JumpOnGround();
                break;
            case 4: //Land
                LandOnGround();
                break;
        }

    }

    

    private void WalkOnGround()
    {
        if (!source.isPlaying)
        {
            source.clip = groundWalk[Random.Range(0, 7)];
            source.volume = .60f;
            source.Play();
        }


    }

    private void RunOnGround()
    {
        if (!source.isPlaying)
        {

            source.clip = groundRun[Random.Range(0, 7)];
            source.volume = 0.10f;
            source.Play();
        }


    }

    private void JumpOnGround()
    {
        if (!jump)
        {
            land = false;
            jump = true;
            source.clip = groundJump;
            source.pitch = Random.Range(.075f, 1.10f);
            source.volume = 0.80f;
            source.Play();
        }

    }

    private void LandOnGround()
    {
        if (!land)
        {
            land = true;
            jump = false;

            source.clip = groundLand;
            source.pitch = Random.Range(0.75f, 1.10f);
            source.volume = 0.80f;
            source.PlayOneShot(groundLand);
        }
        

    }



}
