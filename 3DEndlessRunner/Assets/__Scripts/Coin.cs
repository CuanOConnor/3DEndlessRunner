using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("CoinPickup"); // play coin sound on contact
            GameManager.score += 10;
            Destroy(gameObject);
        }
    }
}
