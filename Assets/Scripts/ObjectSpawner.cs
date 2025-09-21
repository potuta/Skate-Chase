using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs;      // list of things to spawn (platforms, coins, enemies)
    public float spawnInterval = 2f;  // seconds between spawns
    public float spawnYMin = -2f;     // min Y position
    public float spawnYMax = 2f;      // max Y position
    public float spawnXOffset = 15f;  // how far in front of the camera/player to spawn

    private float timer;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        if (prefabs.Length == 0) return;

        // pick random prefab
        int index = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[index];

        // pick random Y
        float y = Random.Range(spawnYMin, spawnYMax);

        // spawn just in front of the camera
        Vector3 spawnPos = new Vector3(cam.transform.position.x + spawnXOffset, y, 0f);

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
