using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public sealed class Game : MonoBehaviourService<Game>
{
    public GameObject menu;
    public bool isPause;
    public LayerMask layerMaskGround;
    public LayerMask layerMaskEnemy;
    public LayerMask layerMaskLava;

    protected override void OnCreateService()
    {
        ProjectileData.ProjectileList.Initialize();
        layerMaskEnemy = LayerMask.GetMask("Enemy");
        layerMaskGround = LayerMask.GetMask("Ground");
        layerMaskLava = LayerMask.GetMask("Lava");
    }

    protected override void OnDestroyService()
    {

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeInHierarchy) menu.SetActive(false);
            else menu.SetActive(true);
        }
    }
    
}
