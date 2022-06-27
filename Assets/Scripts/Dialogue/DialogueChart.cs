using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueChart : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] TextMeshProUGUI _textMesh;

    [Header("Settings")]
    [SerializeField] [Range(0, 0.5f)] float _typeDelay;
    [SerializeField] [Range(0, 1f)] float _afterDelay;


    Camera _camera => FindObjectOfType<Camera>();

    Coroutine _typeCoroutine;

    private void Awake()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera.transform);
    }

    public void TypeText(string text, Action callback)
    {
        if (_typeCoroutine != null)
        {
            StopCoroutine(_typeCoroutine);
        }
        Show();
        _typeCoroutine = StartCoroutine(Type(text, callback));
    }

    IEnumerator Type(string text, Action callback)
    {
        _textMesh.text = text;
        _textMesh.maxVisibleCharacters = 0;

        var wait = new WaitForSeconds(_typeDelay);
        while (_textMesh.maxVisibleCharacters < _textMesh.text.Length)
        {

            _textMesh.maxVisibleCharacters++;

            yield return wait;
        }

        if (callback != null)
        {
            callback.Invoke();
        }

        yield return new WaitForSeconds(_afterDelay);

        Hide();
    }

    void Hide()
    {
        _canvasGroup.alpha = 0;
    }

    void Show()
    {
        _canvasGroup.alpha = 1;
    }

    [ContextMenu("Test")]
    void Test()
    {
        TypeText("This a text, hello!", null);
    }

}
