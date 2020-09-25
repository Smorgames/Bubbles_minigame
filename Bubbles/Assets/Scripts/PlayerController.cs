using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _mousePosition;

    [SerializeField] [Header ("Mouse limits")] private float _xMouseLinit;
    [SerializeField] private float _yMouseLinit;

    [SerializeField] [Header("Player force rotate")] private float _coordinateToDivide;
    [SerializeField] private float _angle;
    private float[] _forceAngles;

    [SerializeField] private AreaEffector2D _areaEffector;

    private void Start()
    {
        _forceAngles = new float[] { 30f, 90f, 150f};
    }

    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MousePositionClamp();

        PlayerRotate();
    }

    private void MousePositionClamp()
    {
        _mousePosition.x = Mathf.Clamp(_mousePosition.x, -_xMouseLinit, _xMouseLinit);
        _mousePosition.y = Mathf.Clamp(_mousePosition.y, -_yMouseLinit, _yMouseLinit);

        transform.position = _mousePosition;
    }

    private void PlayerRotate()
    {
        if (transform.position.x < -_coordinateToDivide)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -_angle);
            _areaEffector.forceAngle = _forceAngles[0];
        }

        if (transform.position.x >= -_coordinateToDivide && transform.position.x <= _coordinateToDivide)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _areaEffector.forceAngle = _forceAngles[1];
        }

        if (transform.position.x > _coordinateToDivide)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, _angle);
            _areaEffector.forceAngle = _forceAngles[2];
        }
    }
}
