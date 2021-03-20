using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float  gunRange = 100f;
    [SerializeField] private int gunDamage = 15;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private float timeWithinShoots  = 0.5f;
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private TextMeshProUGUI ammoText;
    
    
    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }

        DisplayAmmo();

    }

    private void DisplayAmmo()
    {
        ammoText.text = "Ammo: " + ammoSlot.getCurrentAmmo(ammoType);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.getCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.decreaseCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeWithinShoots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, gunRange))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            EnemyAI targetProvoked = hit.transform.GetComponent<EnemyAI>();
            targetProvoked.isProvoked = true;
            target.TakeDamage(gunDamage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
