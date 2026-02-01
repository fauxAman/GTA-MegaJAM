using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    private LineRenderer streakLine;
    private void Awake()
    {
        streakLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        streakLine.SetPosition(0, transform.position);
        streakLine.SetPosition(1, mouseWorldPos);
    }
}

