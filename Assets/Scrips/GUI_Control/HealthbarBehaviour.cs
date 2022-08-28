using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;
    public void SetHealthBar(float health, float MaxHealth)
    {
        Slider.gameObject.SetActive(health < MaxHealth);
        Slider.maxValue = MaxHealth;
        Slider.value = health;
        
    }
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
   
    
}