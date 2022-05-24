using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughScript : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player_Position");
    public static int SizeID = Shader.PropertyToID("_Size");
    [SerializeField] Material WallMaterial;
    [SerializeField] LayerMask Mask;

    [SerializeField][Range(0f, 2f)] float _size;
    Camera _camera;
    private void Awake() {
        _camera = FindObjectOfType<Camera>();
    }
    private void Update() {
        var dir = _camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);
        
        if (Physics.Raycast(ray,  3000f, Mask))
            WallMaterial.SetFloat(SizeID, _size);
        else
            WallMaterial.SetFloat(SizeID, 0f);    
        
        var view = _camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);
    
    }

}
