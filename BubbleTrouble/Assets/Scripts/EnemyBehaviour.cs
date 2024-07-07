using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject enemyBubble;
    [SerializeField] private float shootInterval = 4f;
    [SerializeField] private float bubbleForce = 1f;

    private bool isPlayerInRange = false;
    private Coroutine shootCoroutine;

    void Update()
    {
        if(playerRb != null)
        {
            Vector2 playerPos = playerRb.position;
            Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
            transform.up = direction;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (shootCoroutine == null)
            {
                shootCoroutine = StartCoroutine(ShootCoroutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (shootCoroutine != null)
            {
                StopCoroutine(shootCoroutine);
                shootCoroutine = null;
            }
        }
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            if (isPlayerInRange)
            {
                Vector2 playerPos = playerRb.position;
                Vector2 direction = playerPos - (Vector2)transform.position;
                GameObject bubble = Instantiate(enemyBubble, transform.position, Quaternion.identity);
                bubble.GetComponent<Rigidbody2D>().AddForce(direction * bubbleForce, ForceMode2D.Impulse);
            }
        }
    }
}
