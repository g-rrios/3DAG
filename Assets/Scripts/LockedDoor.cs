using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isOpen = false; // To determine current state of door
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null && playerInventory.hasKey)
            {
                // Open the door
                doorAnimator.SetTrigger("isOpen");
                isOpen = true;
                Debug.Log("Door opened!");
            }
            else
            {
                Debug.Log("You need a key to open this door.");
            }
        }
    }
}
