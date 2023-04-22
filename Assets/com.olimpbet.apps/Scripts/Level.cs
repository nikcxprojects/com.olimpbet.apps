using UnityEngine;

public class Level : MonoBehaviour
{
    private void Start()
    {
        transform.position = Vector2.left * 13.0f;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, 45.0f * Time.deltaTime);
    }
}
