using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    List<Transform> pointPool;

    [SerializeField, Range(10, 300)]
    int resolution = 50;
    float step;
    Vector3 scale;
    Vector3 position;
    private void Awake()
    {
        pointPool = new List<Transform>(resolution);
        DrawGraph(resolution);
    }

    private void Update()
    {
        DrawGraph(resolution);
    }

    /// <summary>
    /// 画图
    /// </summary>
    /// <param name="res"></param>
    private void DrawGraph(int res)
    {
        FillThePool(res);
        ClearGraph();

        step = 2f / res;
        scale = Vector3.one * step;

        float delta = Time.time;
        for (int i = 0; i < res; i++)
        {
            var x = (i + 0.5f) * step - 1f;
            var y = Mathf.Sin(Mathf.PI * x + delta);
            Transform point = pointPool[i];
            point.position = new Vector3(x, y, 0);
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    /// <summary>
    /// 填满对象池
    /// </summary>
    /// <param name="num">所需要的对象数量</param>
    private void FillThePool(int num)
    {
        var poolCount = pointPool.Count;
        if (poolCount < num)
        {
            var newNum = num - poolCount;
            for (int i = 0; i < newNum; i++)
            {
                Transform go = Instantiate(pointPrefab);
                go.name = string.Format("point_{0}", poolCount + i + 1);
                pointPool.Add(go);
            }
        }
    }

    /// <summary>
    /// 清空图像
    /// TODO:暂时没好方法隐藏Transform，直接将Transform挪到外边
    /// 后续尝试采用GameObject Pool
    /// </summary>
    private void ClearGraph()
    {
        foreach (Transform point in pointPool)
            point.position = new Vector3(100 * resolution, 0, 0);
    }
}
