using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksScript : MonoBehaviour
{
    public GameObject Rock;
    public int RockCount;

    public void StartRocks()
    {
        for(int i = 0; i < RockCount; i++)
        {
            Vector3 Spot = new Vector3(Random.Range(transform.position.x-7.5f, transform.position.x + 7.5f), transform.position.y, transform.position.z);
            Instantiate(Rock, Spot, Quaternion.identity);
            
        }
    }
}
