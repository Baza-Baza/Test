using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : View
{
    [SerializeField]
    private List<Image> _hearts;
    [SerializeField]
    private Color _damage;

    public void TakeDamage(int value)
    {
        _hearts[value].color = _damage;
    }
}
