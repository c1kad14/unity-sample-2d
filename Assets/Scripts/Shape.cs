using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public string Name;
    protected GameSceneController gameSceneController;
    protected float halfHeight;
    protected float halfWidth;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
    }

    protected void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    protected void SetColor(float red, float green, float blue)
    {
        Debug.Log($"{red} - {green} - {blue}");
        spriteRenderer.color = new Color(red, green, blue);
    }
}
