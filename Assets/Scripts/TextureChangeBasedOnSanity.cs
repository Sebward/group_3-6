using UnityEngine;

public class TextureChangeBasedOnSanity : MonoBehaviour
{
    public SanitySystem playerSanitySystem;
    public MeshRenderer[] meshesToChange; // Assign the mesh renderers in the inspector

    public Material lowSanityMaterial; // Assign in the inspector
    public Material mediumSanityMaterial; // Assign in the inspector
    public Material highSanityMaterial; // Assign in the inspector

    private void Start()
    {
        if (playerSanitySystem != null)
        {
            // Subscribe to the sanity change event
            playerSanitySystem.OnSanityChanged += UpdateMeshMaterials;
        }
    }

    private void UpdateMeshMaterials(float currentSanity)
    {
        Material selectedMaterial;
        // Determine which material to use based on the current sanity level
        float sanityPercentage = currentSanity / playerSanitySystem.maxSanity;
        selectedMaterial = highSanityMaterial;
        if (sanityPercentage > 0.66f)
        {
            selectedMaterial = highSanityMaterial;
        }
        else
        {
            if (sanityPercentage <= 0.33f)
            {
                selectedMaterial = lowSanityMaterial;
            }
            else if (sanityPercentage <= 0.66f)
            {
                selectedMaterial = mediumSanityMaterial;
            }
            // Apply the selected material to all specified meshes
            foreach (var mesh in meshesToChange)
            {
                mesh.material = selectedMaterial;
            }
        }
    }

    private void OnDestroy()
    {
        if (playerSanitySystem != null)
        {
            playerSanitySystem.OnSanityChanged -= UpdateMeshMaterials;
        }
    }
}
