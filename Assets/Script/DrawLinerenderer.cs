using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinerenderer : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public LineRenderer lineRenderer;
    public float vertexCount = 12;
    public float point2YPosition = 12;

    // Start is called before the first frame update
    void Start()
    {

    }
    ///
    // Update is called once per frame
    void Update()
    {
        
    //point2.transform.position = new Vector3((point1.transform.position.x +
        //point3.transform.position.x),point2YPosition,
            //(point1.transform.position.z+point3.transform.position.z)/2);
        var pointList = new List<Vector3>();
        for (float ratio = 0; ratio <= 1; ratio += 1/vertexCount)
        {
            var tangent1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tangent2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);

            pointList.Add(curve);
        }
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }

    public void ShowLine()
    {

    }
}
