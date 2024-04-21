using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyBubble());
        }
    }

    IEnumerator DestroyBubble()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
