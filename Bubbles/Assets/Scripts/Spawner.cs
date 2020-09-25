using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    private float _countdowner;

    [SerializeField] private GameObject[] _spanwPrefabs;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        Time.timeScale = 1f;
        _countdowner = _spawnRate - 1f;
    }

    private void Update()
    {
        _countdowner += Time.deltaTime;

        if (_countdowner > _spawnRate)
        {
            GameObject spawnObject = (GameObject)Instantiate(_spanwPrefabs[Random.Range(0, _spanwPrefabs.Length)],
            _spawnPoint.position, Quaternion.identity); // spawn probability equall for all

            Rigidbody2D spawnObjectRB = spawnObject.GetComponent<Rigidbody2D>();
            Vector2[] randomForce = new Vector2[] { new Vector2(1, 2).normalized, new Vector2(-1, 2).normalized,
            new Vector2(1, 1).normalized, new Vector2(-1, 1).normalized };

            spawnObjectRB.AddForce(randomForce[Random.Range(0, randomForce.Length)], ForceMode2D.Impulse);

            _countdowner = 0f;
        }
    }
}
