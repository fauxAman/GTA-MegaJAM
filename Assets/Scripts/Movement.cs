using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private DetectionMouse detectionMouse;
    private bool push=false;
    private Vector3[] points = new Vector3[2];
    [SerializeField] private ParticleSystem death;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
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
            rigidBody2D.AddForce( (new Vector2(points[0].x - points[1].x, points[0].y - points[1].y))*50f);
            push = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Collided with Enemy, applying random force.");
            Vector2 randomForce = new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f));
            randomForce = randomForce.normalized * UnityEngine.Random.Range(20,30); 
            rigidBody2D.AddForce(randomForce, ForceMode2D.Impulse);
        }
    }
}


