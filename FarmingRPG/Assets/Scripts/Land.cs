using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        Soil,
        Farmland,
        Watered
    };

    public LandStatus landStatus;

    public Material soilMat, farmlandMat, wateredMat;
    new Renderer renderer;

    // The selection gameobject to enable when the player is selecting the land
    public GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(landStatus);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = soilMat;

        // Device what material to use
        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                // Switch to the soil material
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland: 
            // Switch to the farmland material
                materialToSwitch = farmlandMat;
                break;
            case LandStatus.Watered:
                // Switch to the watered soil material
                materialToSwitch = wateredMat;
                break;
        }

        // Get the renderer to apply the changes
        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
