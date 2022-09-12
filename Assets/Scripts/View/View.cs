using UnityEngine;

public abstract class View : MonoBehaviour
{
    private void Awake()
    {
        Initialize();
    }

    private void OnDisable()
    {
        Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionOrTriggerEnter2d(collision.gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionOrTriggerEnter2d(collision.gameObject);
    }

    protected virtual void Initialize()
    {
    }

    protected virtual void Disable()
    {
    }

    protected virtual void CollisionOrTriggerEnter2d(GameObject gameObject)
    {
    }
}
