using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _decreaseTimeValue;
    [SerializeField] private float _increaseTimeValue;
    [SerializeField] private int _scoreAddValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            GAME_MANAGER.instance.ChangeCountdowner(_decreaseTimeValue);
            Destroy(gameObject);
        }

        if (collision.tag == "WinZone")
        {
            GAME_MANAGER.instance.AddScore(_scoreAddValue);
            GAME_MANAGER.instance.ChangeCountdowner(-_increaseTimeValue);
            Destroy(gameObject);
        }
    }
}
