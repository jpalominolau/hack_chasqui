using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f; // Cantidad de daño que hace el enemigo
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    private Transform player; // Referencia al jugador

    void Start()
    {
        // Buscar al jugador por su tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    // Método para mover al enemigo hacia el jugador
    private void MoveTowardsPlayer()
    {
        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        Debug.Log("Dirección: " + direction);

        // Mover al enemigo
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Forzar la posición final si está muy cerca
        if (Vector2.Distance(transform.position, player.position) < 0.1f)
        {
            transform.position = player.position;
        }
    }

    // Detectar colisión con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Hacer daño al jugador
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemigo tocó al jugador y le hizo daño.");
            }
        }
    }
}