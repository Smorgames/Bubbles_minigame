using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }
}
