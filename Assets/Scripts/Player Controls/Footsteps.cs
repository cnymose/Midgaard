using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    //public AudioClip[] groundWalk;
    //public AudioClip[] groundRun;
    public AudioClip groundJump;
    public AudioClip groundLand;
    //public AudioClip[] woodWalk;
    //public AudioClip[] woodRun;
    private bool jump = false;
    private bool land = false;
    float audioStepLength = 0.10f;
    private PlayerMovement pM;
    private AudioSource source;
    CharacterController cc;
    public FootstepLibrary[] footstepLibraries;
    public PlayerMovement.MovementState movementState;
    public SoundState.SurfaceState surfaceState;


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
                Walk();
                break;
            case 2: //Run
                Run();
                break;
            case 3: //Jump
                Jump();
                break;
            case 4: //Land
                Land();
                break;
        }

    }

    public void SetSurface(SoundState.SurfaceState surface) {
        surfaceState = surface;
    }


    

    private void Walk()
    {
        if (!source.isPlaying)
        {
            source.clip = footstepLibraries[(int) surfaceState].walk[Random.Range(0, footstepLibraries[(int)surfaceState].walk.Length)];
            source.volume = .30f;
            source.Play();
        }


    }

    private void Run()
    {
        if (!source.isPlaying)
        {

            source.clip = footstepLibraries[(int)surfaceState].run[Random.Range(0, footstepLibraries[(int)surfaceState].run.Length)];
            source.volume = 0.15f;
            source.Play();
        }


    }

    private void Jump()
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

    private void Land()
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

    void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.transform.GetComponent<SoundState>() != null) 
        {
            SetSurface(other.transform.GetComponent<SoundState>().surface);
        }
    }

    

    /*void OnTriggerEnter(Collider other) {

        if (other.transform.GetComponent<SoundState>() != null)
        {
            SetSurface(other.transform.GetComponent<SoundState>().surface);
        }

    }*/



}
