using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public sealed class Game : MonoBehaviourService<Game>
{
    public GameObject menu;
    public bool isPause;

    protected override void OnCreateService()
    {
        ProjectileData.ProjectileList.Initialize();
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
