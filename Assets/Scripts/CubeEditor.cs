using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)]
    public float gridSize = 10f;

    TextMesh textMesh;

    private void Start()
    {
    }

    void Update()
    {
        Vector3 snapPos = Vector3.zero;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = snapPos;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = transform.position.x / gridSize + ";" + transform.position.z / gridSize;
        gameObject.name = textMesh.text;
    }
}
