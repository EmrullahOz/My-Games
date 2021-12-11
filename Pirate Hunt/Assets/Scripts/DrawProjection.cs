using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    CannonController _cannonController;
    LineRenderer _lineRenderer;

    public float _upY;

    // Number of points on the line
    public int _numPoints = 50;

    // distance between those points on the line
    public float _timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask _collidableLayers;
    void Start()
    {
        _cannonController = GetComponent<CannonController>();
        _lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        #region Line Renderer System
        _lineRenderer.positionCount = (int)_numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = _cannonController._shotPoint.position;
        Vector3 startingVelocity = _cannonController._shotPoint.up * _cannonController._blastPower;
        for (float t = 0; t < _numPoints; t += _timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/_upY * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, _collidableLayers).Length > 0)
            {
                _lineRenderer.positionCount = points.Count;
                break;
            }
        }

        _lineRenderer.SetPositions(points.ToArray());
        #endregion
    }
}
