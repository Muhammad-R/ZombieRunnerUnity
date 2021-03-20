using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private AmmoSlot[] ammoSlots;
    
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int getCurrentAmmo(AmmoType ammoType)
     {
         var ammoSlot = GetAmmoSlot(ammoType);
         return ammoSlot.ammoAmount;
     }
 
     public void decreaseCurrentAmmo(AmmoType ammoType)
     {
         var ammoSlot = GetAmmoSlot(ammoType);
         ammoSlot.ammoAmount--;
     }

     private AmmoSlot GetAmmoSlot(AmmoType ammoType)
     {
         foreach (AmmoSlot slot in ammoSlots)
         {
             if (slot.ammoType == ammoType)
             {
                 return slot;
             }
         }
         return null;
     }

     public void increaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
     {
         GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount + ammoAmount;
     }
     
 }
