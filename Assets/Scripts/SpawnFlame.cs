using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlame : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [System.Serializable]
    public class SpawnSettings
    {
        public GameObject objectToSpawn;
        public float minSpawnInterval = 1f;
        public float maxSpawnInterval = 3f;
    }

    public List<SpawnSettings> objectsToSpawn;

    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = GetRandomSpawnInterval();
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= GetRandomSpawnInterval())
        {
            if (_gameManager.isGameActive)
            {
                SpawnObject();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    private void SpawnObject()
    {
        // Проверяем, есть ли префабы для спауна
        if (objectsToSpawn.Count == 0)
        {
            Debug.LogWarning("No objects to spawn!");
            return;
        }
        float randomX = Random.Range(-1.23f, 2.16f);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        // Выбираем случайный префаб из списка
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        GameObject selectedPrefab = objectsToSpawn[randomIndex].objectToSpawn;

        // Создаем новый объект, используя выбранный префаб
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }

    private float GetRandomSpawnInterval()
    {
        // Получаем случайный интервал времени из диапазона для спауна объектов
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        float minInterval = objectsToSpawn[randomIndex].minSpawnInterval;
        float maxInterval = objectsToSpawn[randomIndex].maxSpawnInterval;
        return Random.Range(minInterval, maxInterval);
    }
}
