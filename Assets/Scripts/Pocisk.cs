
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// using UnityEngine;

public class Pocisk : MonoBehaviour
{

    public Material colorr;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kolizja");

        if (collision.gameObject.CompareTag("Frog"))
        {
            Debug.Log("Kolizja z żabą");
            Frog frogScript = collision.gameObject.GetComponent<Frog>();
            if (frogScript != null)
            {
                frogScript.Death();
            }
            else
            {
                Debug.LogError("Frog script not found on the 'Frog' object.");
            }


            // Debug.Log("Kolizja z żabą");
            // Frog frogScript = collision.gameObject.GetComponent<Frog>();
            // if (frogScript != null)
            // {
            //     frogScript.setMaterial(colorr);
            // }
            // else
            // {
            //     Debug.LogError("Frog script not found on the 'Frog' object.");
            // }


        }
    }



}





