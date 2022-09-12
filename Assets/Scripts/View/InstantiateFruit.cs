using UnityEngine;

public class InstantiateFruit : View
{
    [Header("Set in Inspector")]
    [SerializeField]
    private GameObject _fruitPrefab;

    protected override void Initialize()
    {
        base.Initialize();

        GenerateFruit(5);
    }

    public void GenerateFruit(int value)
    {
        for (int i = 0; i < value; i++)
        {
            float _xPosition = Random.Range(100, Screen.width-100);
            float _yPosition = Random.Range(100, Screen.height-250);

            Vector2 targetPosition = new Vector3(_xPosition, _yPosition, 0.0f);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(targetPosition);

            GameObject go = Instantiate(_fruitPrefab,worldPosition, transform.rotation);
            go.transform.localScale = Vector3.one * 0.35f;
        }
    }
}
