using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;  

public class JengaGenerator : MonoBehaviour
{
    public GameObject block;
    public const int max = 3;

    public int level_height;
    private float sizeX;
    private float sizeY;


    public Vector3 size;
    private MeshRenderer renderer;



    void Start()
    {

        Vector3 currentPosition = gameObject.transform.position;



        

        renderer = block.GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        sizeX = size.x;
        sizeY = size.y;
        Debug.Log("SIZE:  "+size);
        Debug.Log("SIZE: X ->  "+size.x);
        

        
        
        for(int k=0; k<level_height; k++){
            for (int i = 0; i < max; i++)
            {
                
                Vector3 position_NO1 = new Vector3(i * sizeX + currentPosition.x, currentPosition.y + sizeY*k, currentPosition.z);
                Vector3 position_NO2 = new Vector3( currentPosition.x+sizeX, currentPosition.y + sizeY*k, i * sizeX +currentPosition.z-sizeX);


                if (k % 2 == 0)
                {
                    GameObject newBlock = Instantiate(block, position_NO2, Quaternion.identity);
                    newBlock.transform.Rotate(Vector3.up, 90f);
                    if(i==0){
                    Renderer rend = newBlock.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                     }
                }
                else{
                    GameObject newBlock = Instantiate(block, position_NO1, Quaternion.identity);
                    if(i==0){
                    Renderer rend = newBlock.GetComponent<Renderer>();
                    rend.material.color = Color.blue;
                }
                }

            }
        }




        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
