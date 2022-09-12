using System.Collections;
using UnityEngine;

public class Player : View
{
    [Header("Set in Inspector")]
    [SerializeField]
    private BoxCollider2D _colider;
    [SerializeField]
    private Animator _animator;

    private bool _takeDamage = true;

    protected override void Initialize()
    {
        base.Initialize();

        GameManager.Instance.Health += Death;
    }

    protected override void Disable()
    {
        base.Disable();

        GameManager.Instance.Health -= Death;
    }

    protected override void CollisionOrTriggerEnter2d(GameObject gameObject)
    {
        base.CollisionOrTriggerEnter2d(gameObject);

        CheckCollision(gameObject);
    }

    private void CheckCollision(GameObject gameObject)
    {
        if (gameObject.tag == "Enemy")
        {
            if (_takeDamage)
            {
                GameManager.Instance.TakeDamage();
                StartCoroutine(TakingDamage());
            }
        }
        if (gameObject.tag == "Fruit")
        {
            GameManager.Instance.UpdateScore(1);
            GameManager.Instance.Points.Invoke(1);
            Destroy(gameObject);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private IEnumerator TakingDamage()
    {
        _colider.isTrigger = true;
        _takeDamage = false;
        _animator.SetInteger("Damage", 1);

        yield return new WaitForSeconds(1.0f);

        _colider.isTrigger = false;
        _takeDamage = true;
        _animator.SetInteger("Damage", 0);
    }
}
