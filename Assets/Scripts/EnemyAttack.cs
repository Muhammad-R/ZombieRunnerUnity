using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] private int damage = 35;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        Debug.Log("Attacked Player");
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    public void OnDamageTaken()
    {
        //BroadcastMessage
    }
}
