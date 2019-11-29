using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefeb;
    public Vector3 center;
    public Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFoods();
        SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods(); SpawnFoods();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            SpawnFoods();
        }
        
    }
    public void SpawnFoods()
    {
        Vector3 pos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));

        Instantiate(foodPrefeb, pos, Quaternion.identity);
    }
    void OnDrawGizmosSeleced()
    {
        //Gizmos color = new Color(1, 10, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
    }
