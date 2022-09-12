using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstactObjectController : MonoBehaviour
{
    private void Update()
    {
        ChangeRotationAndCheckDistance();
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    protected virtual void ChangeRotationAndCheckDistance()
    {
    }

    protected virtual void MoveObject()
    {
    }
}
