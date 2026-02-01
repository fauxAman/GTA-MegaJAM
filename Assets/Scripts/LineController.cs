using UnityEngine;

public class LineController : MonoBehaviour
{
    public static LineController Instance { get; private set; }
    [SerializeField] private Camera mainCamera;
    private LineRenderer streakLine;
    private void Awake()
    {

        streakLine = GetComponent<LineRenderer>();
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
    }
    public void HideLine()
    {
        streakLine.enabled = false;
    }
    public void GetPositions(Vector3[] points)
    {
        streakLine.GetPositions(points);
    }
}
