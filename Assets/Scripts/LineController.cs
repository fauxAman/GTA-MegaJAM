using UnityEngine;

public class LineController : MonoBehaviour
{
    public static LineController Instance { get; private set; }
    [SerializeField] private Camera mainCamera;
    private LineRenderer streakLine;
    private TrailRenderer streaktrail;
    private void Awake()
    {

        streakLine = GetComponent<LineRenderer>();
        streaktrail = GetComponent<TrailRenderer>();
        streakLine.enabled = false;
        Instance = this;
    }
    private void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        streakLine.SetPosition(0, transform.position);
        streakLine.SetPosition(1, mouseWorldPos);
    }
    public void ShowLine()
    {
        streakLine.enabled = true;
        streaktrail.emitting = false;
        streaktrail.Clear();
    }
    public void HideLine()
    {
        streakLine.enabled = false;
        streaktrail.emitting = true;
    }
    public void GetPositions(Vector3[] points)
    {
        streakLine.GetPositions(points);
    }
}
