using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private DetectionMouse detectionMouse;
    public bool push=false;
    private Vector3[] points = new Vector3[2];
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        detectionMouse = GetComponent<DetectionMouse>();
        detectionMouse.OnMouseReleased += OnRelease;
    }

    private void OnRelease(object sender, EventArgs e)
    {
        push = true;
        LineController.Instance.GetPositions(points);
    }

    private void FixedUpdate()
    {
        if (push)
        {
            rb.AddForce( (new Vector2(points[0].x - points[1].x, points[0].y - points[1].y))*50f);
            push = false;
        }
    }
}

