using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDestination : MonoBehaviour
{
    public Transform player;  // Referência ao transform do personagem
    public Transform target;  // Referência ao transform do alvo
    public float distanceFromPlayer = 1.0f;  // Distância da seta em relação ao personagem

    void Update()
    {
        if (target != null)
        {
            // Calcula a direção do player para o target
            Vector3 direction = target.position - player.position;
            direction.z = 0; // Mantém a seta no plano 2D
            direction.Normalize();

            // Define a posição da seta em relação ao player
            transform.position = player.position + direction * distanceFromPlayer;

            // Rotaciona a seta para olhar na direção do target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
