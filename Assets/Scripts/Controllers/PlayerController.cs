using UnityEngine;

public class PlayerController : AbstactObjectController
{
    [Header("Set in Inspector")]
    [SerializeField]
    private Rigidbody2D _playerRigidbody;
    [SerializeField]
    private float _speed;

    private bool _needToGo = false;
    private Vector2 _worldPos;
    private float _yMax = Screen.height - 250f;

    protected override void ChangeRotationAndCheckDistance()
    {
        base.ChangeRotationAndCheckDistance();

        if (Input.GetMouseButtonUp(0))
        {
            _playerRigidbody.constraints = RigidbodyConstraints2D.None;
            _playerRigidbody.freezeRotation = true;

            Vector2 mousePosition = Input.mousePosition;

            if (mousePosition.y > _yMax)
            {
                mousePosition.y = _yMax;
            }

            _worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 moveDirection = new Vector3(_worldPos.x, _worldPos.y, 0) - transform.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            _needToGo = true;
        }

        if (Vector2.Distance(transform.position, _worldPos) < 0.01f)
        {
            _needToGo = false;
            _playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    protected override void MoveObject()
    {
        base.MoveObject();

        if (_needToGo)
        {
            _playerRigidbody.MovePosition(Vector2.MoveTowards(transform.position, _worldPos, _speed * Time.deltaTime));
        }
    }
}
