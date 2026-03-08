using System;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using CodeMonkey.Utils;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private DetectionMouse detectionMouse;
    public bool push = false;
    private Vector3[] points = new Vector3[2];
    private float hit = 0;
    private float currentHealth=100;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        detectionMouse = GetComponent<DetectionMouse>();
        detectionMouse.OnMouseReleased += OnRelease;
    }
    private void Start()
    {
        //rigidBody2D.angularVelocity = 0f;
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
            rigidBody2D.AddForce((new Vector2(points[0].x - points[1].x, points[0].y - points[1].y)) * 50f);
            push = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.TryGetComponent<Enemy>(out Enemy enemy))
        {
            
            Vector2 normalizedForce = Random.onUnitCircle;
            float multiplier = Random.Range(25f,30f);
            rigidBody2D.AddForce(normalizedForce * multiplier,ForceMode2D.Impulse);

        }
        if (collision2D.TryGetComponent<BulletBody>(out BulletBody bullet))
        {
            currentHealth -= 2;
            Debug.Log("Current Health: " + currentHealth/100);
            HealthBar.Instance.SetHealth(currentHealth/100);
            FunctionPeriodic.Create(() => { if (currentHealth < 30) { 
                } }) ;

            bullet.Destroy();
        }
    }
}
