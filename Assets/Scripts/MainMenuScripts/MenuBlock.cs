using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class MenuBlock : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int timeToRespawn = 4000;
    [SerializeField] private Sprite blockSprite1;
    [SerializeField] private Sprite blockSprite2;
    [SerializeField] private Sprite blockSprite3;
    private List<Sprite> listOfSpriteRenderers = new List<Sprite>();

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        listOfSpriteRenderers.Add(blockSprite1);
        listOfSpriteRenderers.Add(blockSprite2);
        listOfSpriteRenderers.Add(blockSprite3);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bunny"))
        {
            RespawnAfterBeingDestroyed();
        }
    }

    private async void RespawnAfterBeingDestroyed()
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        int ranNum = UnityEngine.Random.Range(0, listOfSpriteRenderers.Count);
        spriteRenderer.sprite = listOfSpriteRenderers[ranNum];
        await Task.Delay(timeToRespawn);
        if (boxCollider == null || spriteRenderer == null) return;
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
    }
}
