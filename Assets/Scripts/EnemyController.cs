using System;
using UnityEngine;
public delegate void EnemyEscapedHandler(EnemyController enemy);

public class EnemyController : Shape, IKillable
{
    public event EnemyEscapedHandler enemyEscapedHandler;
    public event Action<int> enemyKilled;

    protected override void Start()
    {
        base.Start();

        SetColor(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = transform.position.y - halfHeight;

        if (bottom < -gameSceneController.screenBound.y)
        {
            if (enemyEscapedHandler != null)
            {
                enemyEscapedHandler(this);
            }
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        enemyKilled?.Invoke(10);
        Destroy(other.gameObject);
        Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
