using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;

    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public TMP_Text roundText;

    public GameObject endScreen;

    public TMP_Text roundsSurvived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive==0)
        {
            round++;
            roundText.text = "ROUND " + round;
            NextWave(round);
        }
    }

    public void NextWave(int round)
    {
        for(int x=0;x<round;x++)
        {
            GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawn = Instantiate(enemyPrefab, spawnpoint.transform.position, Quaternion.identity);
            enemySpawn.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        roundsSurvived.text = round.ToString();
        endScreen.SetActive(true);
    }
}
