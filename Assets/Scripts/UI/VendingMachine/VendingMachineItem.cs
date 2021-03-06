﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VendingMachineItem", menuName = "ScriptableObjects/VendingMachineItem", order = 1)]
public class VendingMachineItem : ScriptableObject
{
    public string itemName;
    public int price;
    public int stock;
    public byte keyCode;

    public Sprite sprite;

    public void PurchaseItem()
    {
        PlayerManager.Instance.SpendMoney(price); 
    }
}
