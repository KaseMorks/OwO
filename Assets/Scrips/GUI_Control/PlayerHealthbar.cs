using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    public void SetHealthBar(float HP,float MaxHP)
    {
        HealthBar.fillAmount = (HP/MaxHP);
    }
    
}
