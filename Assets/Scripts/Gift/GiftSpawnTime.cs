using UnityEngine;

public class GiftSpawnTime : MonoBehaviour
{
    private const float Delay = 30f;
    private const float PositionY = 15f;
    private const float MinPositionX = 2f;
    private const float MaxPositionX = 19f;
    private const float MinPositionZ = -6f;
    private const float MaxPositionZ = 5f;

    [SerializeField] private RobotSpawner _robotSpawner;

    private Gift _gift;
    private float _lastSpawnTime;

    private void Awake()
    {
        _gift = GetComponentInChildren<Gift>();
        _gift.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_robotSpawner.IsFull == false)
            gameObject.SetActive(false);

        if (_gift.gameObject.activeSelf)
            return;

        _lastSpawnTime += Time.deltaTime;

        if (_lastSpawnTime > Delay)
        {
            if (_gift.gameObject.activeSelf == false)
            {
                _lastSpawnTime = 0;
                _gift.transform.position = new Vector3(Random.Range(MinPositionX, MaxPositionX), PositionY, Random.Range(MinPositionZ, MaxPositionZ));
                _gift.gameObject.SetActive(true);
            }
        }
    }
}
