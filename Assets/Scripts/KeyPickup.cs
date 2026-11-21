using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the hasKey variable in PlayerInventory to true
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.hasKey = true;
                Debug.Log("Player has picked up the key!");
            }
            // Destroy the key object after pickup
            Destroy(gameObject);
        }
    }
}
