using System;
using Unity.VisualScripting;
using UnityEngine;

public class MenuBlock : MonoBehaviour
{
    private bool isDestroyed = false;
    private float startTime;
    [SerializeField] private float timeToRespawn = 3f;
    [SerializeField] private GameObject menuBlock;

    private void Update()
    {
        RespawnAfterBeingDestroyed();
        Debug.Log(startTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bunny"))
        {
            gameObject.SetActive(false);
            isDestroyed = true;
        }
    }

    private void RespawnAfterBeingDestroyed()
    {
        if (!isDestroyed) return;
        if (Time.time - startTime < timeToRespawn) return;
        Instantiate(menuBlock, transform.position, Quaternion.identity);
        startTime = Time.time;
    }
}
