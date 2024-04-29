using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    private Vector2 playerDirection;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.red;

        StartCoroutine(ShootCoroutine());
    }
    void Update()
    {
        Vector2 playerPos = playerRb.position;
        playerDirection = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        transform.up = playerDirection;
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(4f);
            Debug.DrawRay(transform.position, playerDirection, Color.red,100f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, Mathf.Infinity, LayerMask.GetMask("Player"));

            Vector3 endPoint = hit ? hit.point : transform.position;

            // Atualizar a posição da linha
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, endPoint);

        }
    }
}
