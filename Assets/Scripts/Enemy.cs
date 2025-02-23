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

    // Método para mover al enemigo hacia el jugador solo en el eje X
    private void MoveTowardsPlayer()
    {
        // Mover solo en el eje X hacia el jugador
        float newX = Mathf.MoveTowards(transform.position.x, player.position.x, moveSpeed * Time.deltaTime);
        transform.position = new Vector2(newX, transform.position.y);
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

            // Destruir al enemigo después de hacer daño
            Destroy(gameObject);
        }
    }
}