using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughScript : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    [SerializeField] Material[] WallMaterial;
    [SerializeField] LayerMask Mask;

    [SerializeField][Range(0f, 2f)] float _size;
    Camera _camera;
    
    [SerializeField] float _totalTimer;
    private float _elapsedTime;
    private float _finalSize;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        var dir = _camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000f, Mask))
        {
            if (_elapsedTime <= _totalTimer)
            {
                foreach (Material m in WallMaterial)
                {
                    m.SetFloat(SizeID, Mathf.Lerp(_size, 0f, 1 - (_elapsedTime / _totalTimer)));
                }
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                foreach (Material m in WallMaterial)
                {
                    m.SetFloat(SizeID, _size);
                }
            }
        }
        else
        {
            foreach (Material m in WallMaterial)
            {
                m.SetFloat(SizeID, 0f);
            }
            _elapsedTime = 0;

        }


        var view = _camera.WorldToViewportPoint(transform.position);
        foreach (Material m in WallMaterial)
        {
            m.SetVector(PosID, view);
        }

    }

}
