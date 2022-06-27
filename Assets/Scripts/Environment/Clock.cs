using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] TextMeshPro _textMesh;

    float elapsedTime = 0;
    
    float waveTime;

    Renderer[] _renderers => GetComponentsInChildren<Renderer>();

    private void Awake()
    {
        Hide();
    }

    public void StartCount(float count)
    {
        elapsedTime = count;

        Show();
    }

    private void Update()
    {
        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;

            _textMesh.text = Mathf.RoundToInt(elapsedTime).ToString();

            if (elapsedTime < 0)
            {
                Hide();
            }
        }
    }

    void Show()
    {
        foreach (var renderer in _renderers)
        {
            renderer.enabled = true;
        }
    }

    void Hide()
    {
        foreach (var renderer in _renderers)
        {
            renderer.enabled = false;
        }
    }
}
