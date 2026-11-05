using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Door Animator
    [SerializeField] private GameObject door; // An open slot in the Ispector to drag the hinge object into
    
    private Animator doorAnimator;

    // Door timer
    [Header("Door timer")]
    private bool startDoorTimer = false;
    private float doorTimer = 0.0f;
    [SerializeField] private float doorOpenTime = 3.0f;

    // Door sounds
    [SerializeField] private AudioClip doorOpenSound; 
    [SerializeField] private AudioClip doorShutSound;
    private new AudioSource audio; // Will hold the AudioSource Component

    private bool doorIsOpen = false; // To determine current state of door

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        doorAnimator = door.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Run a door timer
        if(startDoorTimer)
        {
            doorTimer += Time.deltaTime;
        }

        //Automatically shut door after timer
        if(doorTimer >= doorOpenTime)
        {
          ShutDoor(); //This calls the custom method below

           doorTimer = 0.0f;
        }
    }

    // Collision detection
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player hits an object with the houseDoor tag
        if(hit.gameObject.CompareTag("houseDoor"))
        {
           // print(Hit the door!");
        }  OpenDoor();
    }

    // Custom open door method
    private void OpenDoor()
    {
        if(!doorIsOpen)
        {
            audio.PlayOneShot(doorOpenSound);

            doorIsOpen = true;
        }
        

        // Set Animator parameter
        doorAnimator.SetBool("doorOpen", true);

        startDoorTimer = true;
    }


    //Custom shut door method
    private void ShutDoor()
    {
        if(doorIsOpen)
        {
             audio.PlayOneShot(doorShutSound);

             doorIsOpen = false;
        }
       
        // Set Animator parameter
        doorAnimator.SetBool("doorOpen", false);
    }
}
