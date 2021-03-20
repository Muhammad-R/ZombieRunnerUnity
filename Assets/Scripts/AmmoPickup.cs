using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().increaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
