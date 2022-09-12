using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AbstactObjectController
{
    [Header("Set in Inspector")]
    [SerializeField]
    private Rigidbody2D _enemyRigidbody;
    [SerializeField]
    private float _speed;
    [SerializeField]

    private bool? _needToGo = null;
    private bool _completeWaitTime = false;
    private Vector2 _worldPosition;

    public bool? NeedToGo
    {
        set
        {
            _needToGo = value;
        }
    }

    protected override void ChangeRotationAndCheckDistance()
    {
        base.ChangeRotationAndCheckDistance();

        if (_needToGo == false)
        {
            float _xPosition = Random.Range(20, Screen.width - 20);
            float _yPosition = Random.Range(20, Screen.height - 250);

            Vector2 targetPosition = new Vector3(_xPosition, _yPosition, 0.0f);
            _worldPosition = Camera.main.ScreenToWorldPoint(targetPosition);

            Vector3 moveDirection = new Vector3(_worldPosition.x, _worldPosition.y, 0) - transform.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            _needToGo = true;

            StartCoroutine(Wait());
        }

        if (Vector2.Distance(transform.position, _worldPosition) < 0.01f)
        {
            _needToGo = false;
            _completeWaitTime = false;
        }
    }

    protected override void MoveObject()
    {
        base.MoveObject();

        if (_needToGo == true && _completeWaitTime)
        {
            _enemyRigidbody.MovePosition(Vector2.MoveTowards(transform.position, _worldPosition, _speed * Time.deltaTime));
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);

        _completeWaitTime = true;
    }
}
