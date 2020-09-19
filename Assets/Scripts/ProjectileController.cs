using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Shape, IKillable
{
    public Vector2 projectileDirection;
    public float projectileSpeed;


    protected override void Start()
    {
        base.Start();
        SetColor(0, 255, 0);
    }
    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileDirection, Space.World);
        float top = transform.position.y + halfHeight;

        if(top > gameSceneController.screenBound.y)
        {
            Destroy(gameObject);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
