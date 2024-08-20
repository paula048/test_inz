using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameShootFrog : MonoBehaviour
{
    public bool startTrigger = false;
    public GameObject frogModel;
    public int numberOfFrog = 20;
    public List<Material> frogColors;

    private int aliveFrogs;

    void Start()
    {
        if (startTrigger)
        {
            generateFrog();
        }
    }

    void Update()
    {
        
    }



private void HandleFrogDeath()
    {
        aliveFrogs--;

        if (aliveFrogs <= 0)
        {
            Debug.Log("You kill all FROGS");
        }
    }




    public void generateFrog()
    {
        aliveFrogs = numberOfFrog;

        for (int i = 0; i < numberOfFrog; i++)
        {
            GameObject thisFrog = Instantiate(frogModel, randPosition(), Quaternion.Euler(0f, randRotation(), 0f));
            Frog frogScript = thisFrog.GetComponent<Frog>();
            if (frogScript != null)
            {
                Material mat = randMaterial();
                frogScript.setMaterial(mat);

                // Subscribe to the frog's death event
                frogScript.OnDeath += HandleFrogDeath;

                // Get the Animator component
                Animator frogAnimator = thisFrog.GetComponent<Animator>();
                if(frogAnimator != null){
                    // Set a random start time for the animation
                    float randomStart = Random.Range(0f, frogAnimator.GetCurrentAnimatorStateInfo(0).length);
                    frogAnimator.Play(0, -1, randomStart); 
                }
                
            }
            else
            {
                Debug.LogError("Frog script not found on the instantiated 'Frog' object.");
            }
        }
    }





    private Vector3 randPosition()
    {
        return new Vector3(Random.Range(5.0f, 10.0f), 0.34f, Random.Range(-9.0f, 1.0f));
    }

    private float randRotation()
    {
        return Random.Range(0f, 360.0f);
    }

    private Material randMaterial()
    {
        int position = Random.Range(0, frogColors.Count);
        return frogColors[position];
    }





}
