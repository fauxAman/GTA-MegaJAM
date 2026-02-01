using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Mathf.Abs(angle) > 90)
        {
            
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            // Keep it normal
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
