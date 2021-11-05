using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator anim;

    LayerMask LayerMask;
    public Transform Point;
    RaycastHit2D hit2D;


    void Start()
    {
        StartCoroutine(check());
        anim = GetComponent<Animator>();
        
        int layerMaskOnlyPlayer = 1 << 11;
        LayerMask = ~layerMaskOnlyPlayer;
    }

   

    public IEnumerator check()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            
            hit2D = Physics2D.Raycast(Point.transform.position, Vector2.down, 30f,LayerMask,Mathf.Infinity,Mathf.Infinity);

            if (!hit2D.transform.CompareTag("Lend") && !hit2D.transform.CompareTag("Borders"))
            {

                anim.SetBool("onDown", true);
                yield break;
            }
        }
    }

    

    void Update()
    {
        
    }
}
