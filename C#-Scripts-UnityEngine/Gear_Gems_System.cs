using System.Collections.Generic;
using UnityEngine;

public enum SlotType { Constitution, Strength, Dexterity, Wisdom, Intellect }
public enum GemstoneType { /* Define gemstone types here, e.g., Ruby, Sapphire, ... */ }

[System.Serializable]
public class Gemstone
{
    public GemstoneType type;
    public List<SlotType> compatibleSlots = new List<SlotType>();

    public bool IsCompatibleWith(SlotType slot)
    {
        return compatibleSlots.Contains(slot);
    }
    // Add other gemstone properties if necessary
}

[System.Serializable]
public class Equipment
{
    public string equipmentName;
    public List<SlotType> slotTypes = new List<SlotType>();
    public List<Gemstone> slots = new List<Gemstone>();

    public bool EquipGemstone(Gemstone gem, int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < slots.Count)
        {
            if (gem.IsCompatibleWith(slotTypes[slotIndex]))
            {
                slots[slotIndex] = gem;
                return true;
            }
        }
        return false; // Gemstone was not equipped due to incompatibility or invalid slot.
    }

    public void UnequipGemstone(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < slots.Count)
        {
            slots[slotIndex] = null;
        }
    }
}

public class GemstoneManager : MonoBehaviour
{
    public Equipment GenerateRandomEquipment()
    {
        Equipment newEquipment = new Equipment();
        
        float randomChance = Random.Range(0f, 1f);
        int slotCount;

        if (randomChance <= 0.002) // 0.2% chance
        {
            slotCount = Random.Range(3, 5); // Random number between 3 and 4
        }
        else
        {
            slotCount = Random.Range(1, 3); // Random number between 1 and 2
        }

        for (int i = 0; i < slotCount; i++)
        {
            newEquipment.slots.Add(null); // Empty slot
            newEquipment.slotTypes.Add((SlotType)Random.Range(0, 5)); // Random slot type
        }

        return newEquipment;
    }

    void Start()
    {
        // Example of using the system
        Equipment newSword = GenerateRandomEquipment();
        Gemstone ruby = new Gemstone() 
        {
            type = GemstoneType.Ruby, 
            compatibleSlots = new List<SlotType> { SlotType.Strength, SlotType.Constitution } 
        };
        bool success = newSword.EquipGemstone(ruby, 0);
        if (!success)
        {
            // Notify the player or handle the unsuccessful equip action
        }
    }
}
