using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    public AudioClip[] groundWalk;
    public AudioClip[] groundRun;
    public AudioClip groundJump;
    public AudioClip groundLand;
    private bool jump = true;
    private bool step = true;
    private bool hasJustLanded = true;
    private bool land = true;
    float audioStepLength = 0.10f;
    PlayerMovement pM;
    private AudioSource source;
    CharacterController cc;

	// Use this for initialization
	void Start () {

        pM = GetComponent<PlayerMovement>();
        source = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (pM.grounded && pM.moveDirection.magnitude > 5 && pM.moveDirection.magnitude < 7 && step == true && source.isPlaying == false)
        {

            WalkOnGround();
            Debug.Log("I am walking");

        }

        else if (pM.grounded && pM.moveDirection.magnitude > 7 && pM.moveDirection.magnitude < 12 && step == true && source.isPlaying == false)
        {
            RunOnGround();
            Debug.Log("I am Running");
        }

        else if (!pM.grounded && pM.moveDirection.y > 4 && pM.moveDirection.y < 9 && jump == true) {

            JumpOnGround();
            Debug.Log("I am jumping");
        }

        if (pM.grounded && land == true) {
            if (!hasJustLanded) {
                hasJustLanded = true;
                Debug.Log("I just landed");
                LandOnGround();
            }
        }
        else
        {
            Debug.Log("Not landed");
            hasJustLanded = false;
        }

        //cc.GetComponent<Collider>(). == "Ground"

    }

    void WalkOnGround() {
        step = false;
        source.clip = groundWalk[Random.Range(0, 7)];
        source.volume = .60f;
        source.Play();
        step = true;


    }

    void RunOnGround() {
        step = false;
        source.clip = groundRun[Random.Range(0, 7)];
        source.volume = 0.10f;
        source.Play();
        step = true;

    }

    void JumpOnGround() {
        jump = false;
        source.clip = groundJump;
        source.pitch = Random.Range(0.75f, 1.10f);
        source.volume = 0.80f;
        source.Play();
        jump = true;
    }

    void LandOnGround() {
        land = false;
        source.clip = groundLand;
        source.pitch = Random.Range(0.75f, 1.10f);
        source.volume = 0.80f;
        source.PlayOneShot(groundLand);
        land = true;
    }

    

}
