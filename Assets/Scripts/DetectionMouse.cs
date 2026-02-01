using System;
using UnityEngine;

public class DetectionMouse : MonoBehaviour
{
    public event EventHandler OnMouseReleased;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            LineController.Instance.ShowLine();
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            transform.localScale=new Vector3(1f,0.8f,1f);
        }
            
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            LineController.Instance.HideLine();
            OnMouseReleased?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        
        
    }

}
