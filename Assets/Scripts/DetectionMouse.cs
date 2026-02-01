using UnityEngine;

public class DetectionMouse : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            LineController.Instance.ShowLine();
        }
            
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            LineController.Instance.HideLine();
        }
    }

}
