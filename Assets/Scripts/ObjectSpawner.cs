using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Vector3 _spawnPosition = new Vector3();
    [SerializeField] private Transform _spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var instObject = GameObject.Instantiate(_prefabToSpawn, _spawnPoint.position, Quaternion.identity);
            var instObjectRenderer = instObject.GetComponent<Renderer>();
            instObjectRenderer.material.color = Random.ColorHSV(0f, 1f);
        }
    }
}
