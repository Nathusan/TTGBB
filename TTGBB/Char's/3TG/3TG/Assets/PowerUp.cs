using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }      
    }

    void PickUp(Collider player)
    {
        //Spawn cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the player


        //Remove power up object
        Destroy(gameObject);
    }
}
