using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int id;
    public float DamageArmor;
    public float DamageShield;
    public bool shootplayer;
    public Rigidbody2D body;
    public Animator anim;
    
    

    void Start ()
    {
        body = GetComponentInParent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ProjectileData.Projectile projectile = ProjectileData.ProjectileList.Projectiles.Find(Projectile => Projectile.Id == id);
        DamageArmor = projectile.Power * projectile.ArmorDamageMod;
        DamageShield = projectile.Power * projectile.ShieldDamageMod;

        StartCoroutine(LifeTime());
    }
   
    void Update()
    {
        
    }
    
   

    public void DelGo()
    {
        Destroy(transform.parent.gameObject);
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(transform.parent.gameObject);
    }
}
