using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float damage = 20f;
    public float range = 100f;
    public Animator fpsAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fpsAnimator.GetBool("isFiring"))
        {
            fpsAnimator.SetBool("isFiring", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;

        fpsAnimator.SetBool("isFiring", true);
        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit,range))
        {


            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager!=null)
            {
                enemyManager.Hit(damage);
            }
            
        }
    }
}
