using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactList : MonoBehaviour
{
    public static LayerMask layerMaskPlayer;
    public static LayerMask layerMaskGround;
    public static LayerMask layerMaskEnemy;

    public static ContactFilter2D contactFilterPlayer;
    public static ContactFilter2D contactFilterGround;
    public static ContactFilter2D contactFilterEnemy;


    private void Awake()
    {
        layerMaskGround = LayerMask.GetMask("Ground");
        layerMaskPlayer = LayerMask.GetMask("Player");
        layerMaskEnemy = LayerMask.GetMask("Enemy");

        contactFilterGround = new ContactFilter2D();
        contactFilterGround.SetLayerMask(layerMaskGround);
        contactFilterPlayer = new ContactFilter2D();
        contactFilterPlayer.SetLayerMask(layerMaskPlayer);
        contactFilterEnemy = new ContactFilter2D();
        contactFilterEnemy.SetLayerMask(layerMaskEnemy);
    }
    
}
