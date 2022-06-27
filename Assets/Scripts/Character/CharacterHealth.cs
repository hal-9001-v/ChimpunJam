using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class CharacterHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0.1f, 2)] float _invincibleTime;
    [SerializeField] [Range(0, 500)] float _imageOffset;
    [SerializeField] Image _duckImage;
    Health _health => GetComponent<Health>();

    ScreenFade _screenFade => FindObjectOfType<ScreenFade>();

    Image[] _images;

    Renderer[] renderers => GetComponentsInChildren<Renderer>();

    private void Start()
    {

        InitializeLifes();
        _health.hurtAction += (dir, push, hitter) =>
        {
            Invincible();
            UpdateUI();
        };

        _health.deadAction += (dir, push, hitter) =>
        {
            UpdateUI();

            _screenFade.GoToBlack(() =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            });
        };

        _health.healAction += () =>
        {
            InitializeLifes();
            Debug.Log("XD");

        };
        _screenFade.GoTransparent(null);
    }


    void InitializeLifes()
    {
        if (_duckImage)
        {
            if (_images != null)
            {
                for (int i = 1; i < _images.Length; i++)
                {
                    Destroy(_images[i]);
                }
            }
            _images = new Image[_health.currentHealth];

            _images[0] = _duckImage;
            for (int i = 1; i < _images.Length; i++)
            {
                _images[i] = Instantiate(_duckImage);
                _images[i].transform.SetParent(_duckImage.transform.parent, false);
                _images[i].transform.position += new Vector3(_imageOffset * i, 0, 0);
            }
        }
    }

    void Invincible()
    {
        if (_health.canGetHurt)
        {
            _health.canGetHurt = false;
            StartCoroutine(InvincibleCoutndown());
        }
    }


    IEnumerator InvincibleCoutndown()
    {
        Debug.Log("Invincible");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < renderers.Length; j++)
            {
                renderers[j].enabled = !renderers[j].enabled;
            }

            yield return new WaitForSeconds(_invincibleTime / 5);
        }

        for (int j = 0; j < renderers.Length; j++)
        {
            renderers[j].enabled = true;
        }

        _health.canGetHurt = true;
    }


    void UpdateUI()
    {

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].enabled = false;
        }

        for (int i = 0; i < _health.currentHealth; i++)
        {
            _images[i].enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_duckImage.transform.position, 1);
    }
}
