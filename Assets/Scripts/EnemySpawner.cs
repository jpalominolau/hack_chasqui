using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Prefab del enemigo que se generará
    public GameObject enemyPrefab;

    // Intervalo de tiempo entre generaciones de enemigos
    public float spawnInterval = 5f;

    // Posición inicial donde se generarán los enemigos
    public Vector3 spawnPosition;

    // Contador interno para controlar el tiempo entre generaciones
    private float timer;

    void Start()
    {
        // Inicializar el temporizador
        timer = spawnInterval;
    }

    void Update()
    {
        // Reducir el temporizador con el tiempo
        timer -= Time.deltaTime;

        // Si el temporizador llega a cero o menos, generar un nuevo enemigo
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval; // Reiniciar el temporizador
        }
    }

    // Método para generar un nuevo enemigo
    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Instanciar el enemigo en la posición especificada
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Nuevo enemigo generado en: " + spawnPosition);
        }
        else
        {
            Debug.LogError("El prefab del enemigo no está asignado en el Spawner.");
        }
    }
}