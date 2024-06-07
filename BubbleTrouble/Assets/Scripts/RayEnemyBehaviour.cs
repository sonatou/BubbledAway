using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEnemyBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject searchRay;
    [SerializeField] private GameObject deathRay;

    [Header("Variables")]
    [SerializeField] private float timeOfSearch = 3f;
    [SerializeField] private float timeOfCharge = 2f;
    [SerializeField] private float timeOfDeathRay = 2f;


    private bool findingPlayer = true;


    private void Start()
    {
        StartCoroutine(ShootRayCoroutine());
    }

    private void Update()
    {
        if (playerRb != null && findingPlayer)
        {
            Vector2 playerPos = playerRb.position;
            Vector2 direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
            transform.up = direction;
        }
    }

    IEnumerator ShootRayCoroutine()
    {
        while (true)
        {
            searchRay.SetActive(true);
            yield return new WaitForSeconds(timeOfSearch);
            findingPlayer = false;
            searchRay.SetActive(false);
            yield return new WaitForSeconds(timeOfCharge);
            deathRay.SetActive(true);
            yield return new WaitForSeconds(timeOfDeathRay);
            findingPlayer = true;
            deathRay.SetActive(false);           
        }
    }
}
