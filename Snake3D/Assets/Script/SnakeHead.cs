using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public SnakeMovement movement;
    public SpawnFood sp;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "food")
        {
            movement.AddBodyPart();
            Destroy(other.gameObject);
            sp.SpawnFoods(); sp.SpawnFoods(); 

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        
        if (collision.collider.tag == "Untagged")
        {
            

        }
        else
        {
            if (collision.transform != movement.bodyParts[1] && movement.isAlive)
            {
                if (Time.time - movement.timeFromLastTry > 5)
                    movement.Die();

            }
        }


       
    }
}
