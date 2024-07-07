using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDestination : MonoBehaviour
{
    public Transform player;  // Refer�ncia ao transform do personagem
    public Transform target;  // Refer�ncia ao transform do alvo
    public float distanceFromPlayer = 1.0f;  // Dist�ncia da seta em rela��o ao personagem

    void Update()
    {
        if (target != null)
        {
            // Calcula a dire��o do player para o target
            Vector3 direction = target.position - player.position;
            direction.z = 0; // Mant�m a seta no plano 2D
            direction.Normalize();

            // Define a posi��o da seta em rela��o ao player
            transform.position = player.position + direction * distanceFromPlayer;

            // Rotaciona a seta para olhar na dire��o do target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
