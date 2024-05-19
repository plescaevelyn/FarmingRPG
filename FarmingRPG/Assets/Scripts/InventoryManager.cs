using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{   
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    [Header("Tools")]
    public ItemData[] tools = new ItemData[8];
    public ItemData equippedTool = null;

    [Header("Items")]
    public ItemData[] items = new ItemData[8];
    public ItemData equippedItem = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
