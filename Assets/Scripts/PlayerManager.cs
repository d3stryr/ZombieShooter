using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{

    public float health = 100;
    public TMP_Text playerHealth;
    public GameManager gameManager;
    public void Hit(float damage)
    {
        health -= damage;
        playerHealth.text = "Health : " + health;
        if (health<=0)
        {
            gameManager.EndGame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.text = "Health : " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
