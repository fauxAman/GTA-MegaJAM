using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthbar;
    public static HealthBar Instance { get; private set; }
    private void Awake()
    {
        healthbar = GetComponent<Slider>();
        Instance = this;
    }
}

