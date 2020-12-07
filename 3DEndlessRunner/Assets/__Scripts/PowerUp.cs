using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
            Pickup(); 
        }
    }

    // references boolean from PlayerController and makes the player immune to damage
    void Pickup()
    {
        // Apply effect to player
        GameObject.Find("Player").GetComponent<PlayerController>().isInvincible = true;
       
        // remove power up
        Destroy(gameObject);
        //Debug.Log("PICKED IT UP");
    }

    
}
