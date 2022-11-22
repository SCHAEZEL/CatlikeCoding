using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 100;
    float step;
    Vector3 scale;
    Vector3 position;
    List<Transform> objectPool;
    private void Awake()
    {
        DrawGraph();
    }

    private void Update()
    {
        // DrawGraph();
    }

    private void DrawGraph()
    {
        step = 2f / resolution;
        scale = Vector3.one * step;
        for (int i = 0; i < resolution; i++)
        {
            var x = (i + 0.5f) * step - 1f;
            var y = Mathf.Pow(x, 3);
            Transform point = Instantiate(pointPrefab);
            point.position = new Vector3(x, y, 0);
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    // private void GetPoint()
    // {
    //     if (objectPool.Count == 0)

    // }

}
