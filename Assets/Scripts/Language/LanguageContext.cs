using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageContext : MonoBehaviour
{
    public static LanguageContext Instance { get; private set; }

    public Language currentLanguage { get; private set; }

    private void Start()
    {
        if (Instance)
        {
            Instance.UpdateLanguageChangeables();
            Destroy(gameObject);
        }
        else
        {

            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            ChangeLanguage(Language.English);
        }
    }

    public void ChangeLanguage(Language language)
    {
        if (language == currentLanguage) return;

        currentLanguage = language;

        UpdateLanguageChangeables();
    }

    public void UpdateLanguageChangeables()
    {
        foreach (var changeable in FindObjectsOfType<LanguageChangeable>())
        {
            changeable.ChangeLanguage(currentLanguage);
        }
    }

}