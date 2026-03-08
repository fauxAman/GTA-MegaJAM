using CodeMonkey.Utils;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public static HealthBar Instance { get; private set; }
    private void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, 1f);
        Instance = this;
        
    }
  
    public void SetHealth(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
    public void SetColor(Color color)
    {
     bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
