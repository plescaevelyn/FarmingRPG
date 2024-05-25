using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        //If there is more than one instance, destroy the extra
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //Set the static instance to this instance
            Instance = this;
        }
    }

    [Header("Tools")]
    //Tool Slots
    public ItemData[] tools = new ItemData[8];
    //Tool in the player's hand
    public ItemData equippedTool = null;

    [Header("Items")]
    //Item Slots
    public ItemData[] items = new ItemData[8];
    //Item in the player's hand
    public ItemData equippedItem = null;

    //The transform for the player to hold items in the scene
    public Transform handPoint;

    //Equipping

    //Handles movement of item from Inventory to Hand
    public void InventoryToHand(int slotIndex, InventorySlot.InventoryType inventoryType)
    {
        if (inventoryType == InventorySlot.InventoryType.Item)
        {
            //Cache the Inventory slot ItemData from InventoryManager
            ItemData itemToEquip = items[slotIndex];

            //Change the Inventory Slot to the Hand's
            items[slotIndex] = equippedItem;

            //Change the Hand's Slot to the Inventory Slot's
            equippedItem = itemToEquip;

            //Update the changes in the scene
            RenderHand();

        }
        else
        {
            //Cache the Inventory slot ItemData from InventoryManager
            ItemData toolToEquip = tools[slotIndex];

            //Change the Inventory Slot to the Hand's
            tools[slotIndex] = equippedTool;

            //Change the Hand's Slot to the Inventory Slot's
            equippedTool = toolToEquip;
        }

        //Update the changes to the UI
        UIManager.Instance.RenderInventory();



    }

    //Handles movement of item from Hand to Inventory
    public void HandToInventory(InventorySlot.InventoryType inventoryType)
    {
        if (inventoryType == InventorySlot.InventoryType.Item)
        {
            //Iterate through each inventory slot and find an empty slot
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    //Send the equipped item over to its new slot
                    items[i] = equippedItem;
                    //Remove the item from the hand
                    equippedItem = null;
                    break;
                }
            }

            //Update the changes in the scene
            RenderHand();

        }
        else
        {
            //Iterate through each inventory slot and find an empty slot
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == null)
                {
                    //Send the equipped item over to its new slot
                    tools[i] = equippedTool;
                    //Remove the item from the hand
                    equippedTool = null;
                    break;
                }
            }

        }
        //Update changes in the inventory
        UIManager.Instance.RenderInventory();
    }

    //Render the player's equipped item in the scene
    public void RenderHand()
    {
        //Reset objects on the hand
        if (handPoint.childCount > 0)
        {
            Destroy(handPoint.GetChild(0).gameObject);
        }

        //Check if the player has anything equipped
        if (equippedItem != null)
        {
            //Instantiate the game model on the player's hand and put it on the scene
            Instantiate(equippedItem.gameModel, handPoint);
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}