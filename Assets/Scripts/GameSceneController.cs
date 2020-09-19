using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextHandler (string text);

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBound;
    public EnemyController enemyPrefab;
    private HUDController hUDController;
    private int totalPoints;
    // Start is called before the first frame update
    void Start()
    {
        hUDController = FindObjectOfType<HUDController>(); 
        playerSpeed = 10;
        screenBound = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while(true)
        {
            float horizontalPosition = Random.Range(-screenBound.x, screenBound.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBound.y);

            var enemy =  Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.enemyEscapedHandler += EnemyAtBottom;
            enemy.enemyKilled += EnemyKilled;

            yield return wait;
        }
    }

    private void EnemyKilled(int point)
    {
        totalPoints += point;
        hUDController.scoreText.text = totalPoints.ToString();
    }

    public void KillObject(IKillable killable)
    {
        killable.Kill();
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        KillObject(enemy);
        OutputText("Enemy escaped");
    }

    public void OutputText(string text)
    {
        Debug.Log(text);
    }
}
