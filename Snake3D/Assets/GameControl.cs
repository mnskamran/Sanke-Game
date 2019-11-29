using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public SnakeMovement sm;

    private void Update()
    {
        MoveFast()
    }
    public void MoveFast()
    {
        Debug.Log("Spped");

        sm.speed = 20;

    }
}
