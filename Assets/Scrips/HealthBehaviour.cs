using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color HighLight;
    public Vector3 Offset;
    public void SetHealthBar(float health, float MaxHealth)
    { 
        Slider.gameObject.SetActive(health < MaxHealth);
        Slider.value = health;
        Slider.maxValue = MaxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, HighLight, Slider.normalizedValue);
    }
    private void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}