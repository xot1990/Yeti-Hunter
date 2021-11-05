using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class LendControler : MonoBehaviour
{
    public GameObject PartsSys;
    RocksScript rocksScript;
    CameraEffect cameraEffect;

    void Start()
    {
        rocksScript = FindObjectOfType<RocksScript>();
        cameraEffect = FindObjectOfType<CameraEffect>();
    }

    
    void Update()
    {
        
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.GetComponentInChildren<Animator>().SetBool("Enter", true);
            collision.transform.parent = transform;
        }
        if (collision.transform.CompareTag("Claw"))
        {
            StartCoroutine(cameraEffect.Shake());
            rocksScript.StartRocks();
            rocksScript.RockCount++;
            StartCoroutine(SpawnParts(PartsSys, collision.transform.position));
        }

    }
    

    public IEnumerator SpawnParts(GameObject obj, Vector3 V)
    {
        
        GameObject O = Instantiate(obj, new Vector3(V.x, V.y, -1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(O);
    }
}
