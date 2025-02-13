using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MenuBlock : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int timeToRespawn = 4000;
    [SerializeField] private GameObject menuBlock;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        await Task.Delay(timeToRespawn);
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
    }
}
