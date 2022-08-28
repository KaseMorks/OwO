using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] float playerMaxHitpoint;
    [SerializeField] float playerHitpoint;
    private PlayerHealthbar SetHP;

    private void Awake()
    {
        SetHP = GetComponentInChildren<PlayerHealthbar>();
    }

    private void Start()
    { 
        playerHitpoint = playerMaxHitpoint;
    }
    public void PlayerTakeHit(float damage)
    {
        playerHitpoint -= damage;
        SetHP.SetHealthBar(playerHitpoint, playerMaxHitpoint);

        
    }

}
