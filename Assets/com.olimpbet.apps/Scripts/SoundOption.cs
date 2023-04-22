using UnityEngine.UI;
using UnityEngine;

public class SoundOption : MonoBehaviour
{
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    private void Start()
    {
        var btn = GetComponent<Button>();
        var img = GetComponent<Image>();

        btn.onClick.AddListener(() =>
        {
            AudioListener.pause = !AudioListener.pause;
            img.sprite = AudioListener.pause ? off : on;
        });
    }
}
