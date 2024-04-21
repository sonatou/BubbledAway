using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject enemyBubble;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }
    void Update()
    {
        if(playerRb != null)
        {
            Vector2 playerPos = playerRb.position;
            Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
            transform.up = direction;
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Vector2 playerPos = playerRb.position;
            Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
            GameObject bubble = Instantiate(enemyBubble, transform.position, Quaternion.identity);
            bubble.GetComponent<Rigidbody2D>().AddForce(direction * 0.5f, ForceMode2D.Impulse);
        }
    }
}
