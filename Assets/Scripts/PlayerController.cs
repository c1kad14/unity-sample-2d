using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    public ProjectileController projectilePrefab;

    protected override void Start()
    {
        base.Start();

        SetColor(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if(Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += transform.position.x;

            float right = gameSceneController.screenBound.x - halfWidth;
            float left = -right;

            float limit = Mathf.Clamp(horizontalMovement, left, right);
            transform.position = new Vector2(limit, transform.position.y);
        }
    }

    private void Fire()
    {
        Vector2 spawnPosition = transform.position;

        ProjectileController projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        projectile.projectileSpeed = 2;
        projectile.projectileDirection = Vector2.up;
    }
}
