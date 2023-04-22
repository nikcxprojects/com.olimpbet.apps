using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform outline;

    public void SelectLevel(int levelId)
    {
        var selectedLevel = EventSystem.current.currentSelectedGameObject;
        outline.position = selectedLevel.transform.position;

        UIManager.Instance.levelId = levelId;
    }
}
