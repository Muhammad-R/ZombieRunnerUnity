using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        print(health);
        if (health <= 0)
        {
            print(gameObject.name + "is dead");
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        transform.position = new Vector3(transform.position.x, -0.91f, transform.position.z);
    }
}
