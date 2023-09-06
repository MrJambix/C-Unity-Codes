using UnityEngine;

public class Herb : MonoBehaviour
{
    public string growthStorageKey;
    public GrowingMod growingMod;
    public CurrentMap currentMap;

    private void Update()
    {
        GrowthUpdate();
    }

    private void GrowthUpdate()
    {
        // Calculate the growth value based on various factors.
        float growthValue = growingMod.GrowthSpeed * SharedValues.TimeSpeedMultiplier *
            Mathf.Clamp(currentMap.TimeOfDay.TimeMultiplier, 1, float.MaxValue);

        // Add the calculated growth value to the entity's storage and check if it's >= 100.
        if (StorageManager.AddToEntityStorageValue(this.gameObject, growthStorageKey, growthValue) >= 100)
        {
            // Reset the current growth to 0 before growing into another Entity.
            SetCurrentGrowth(0);

            // Check if it's possible to replace the entity with a new one based on a preset.
            if (currentMap.CheckEntityPresetPlacement(growingMod.NewDoodadPreset, transform.position, transform.forward))
            {
                // Asynchronously replace the entity with a new one.
                GrowIntoNewEntity(growingMod.NewDoodadPreset);
            }
            else
            {
                // Unable to grow, so remove the entity.
                RemoveEntity();
            }
        }

        // Debug.Log(GetCurrentGrowth());
    }

private float currentGrowth = 0.0f; // Initial growth value
public float maxGrowth = 100.0f;    // Maximum growth value for a fully grown herb

private void SetCurrentGrowth(float growth)
{
    // Ensure that the growth value is clamped within the valid range.
    currentGrowth = Mathf.Clamp(growth, 0, maxGrowth);

    UpdateVisuals();

    // Check if the herb is fully grown.
    if (currentGrowth >= maxGrowth)
    {
        HandleFullyGrown();
    }
}

private void UpdateVisuals()
{
    float scale = currentGrowth / maxGrowth;
    transform.localScale = new Vector3(scale, scale, scale);
}

private void HandleFullyGrown()
{
    Debug.Log("Herb is fully grown!");

    // Reset growth to prevent further growth until a new cycle begins.
    SetCurrentGrowth(0);
}

public GameObject herbPrefab; // Reference to the prefab of the herb to spawn
private void GrowIntoNewEntity(GameObject newEntityPrefab)
{
    // Check if the herb is fully grown before spawning a new entity.
    if (currentGrowth >= maxGrowth)
    {
        // Spawn a new herb entity at the current position with the same rotation.
        GameObject newHerb = Instantiate(herbPrefab, transform.position, transform.rotation);

        // Destroy the current herb (this one has fully grown).
        Destroy(gameObject); // You may also seperate this to a new Entity 
    }
}

