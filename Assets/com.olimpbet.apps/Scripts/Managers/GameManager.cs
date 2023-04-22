using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Color color;
    private Coroutine drawing;

    [SerializeField] Transform outline;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(origin, Vector2.zero, Mathf.Infinity);
            if(hit.collider != null && hit.collider.CompareTag("start"))
            {
                color = hit.collider.GetComponent<Ball>().color;
                StartLine();
            }
        }
        
        if(drawing != null && Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
    }

    private void StartLine()
    {
        if(drawing != null)
        {
            StopCoroutine(drawing);
        }

        drawing = StartCoroutine(nameof(DrawLine));
    }

    private void FinishLine()
    {
        StopCoroutine(drawing);
    }

    private IEnumerator DrawLine()
    {
        var linePrefab = Resources.Load<LineRenderer>("line");
        var line = Instantiate(linePrefab);


        line.startColor = line.endColor = color;
        line.positionCount = 0;

        while(true)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);

            yield return null;
        }
    }

    public void SelectLevel(int levelId)
    {
        var selectedLevel = EventSystem.current.currentSelectedGameObject;
        outline.position = selectedLevel.transform.position;

        UIManager.Instance.levelId = levelId;
    }
}
