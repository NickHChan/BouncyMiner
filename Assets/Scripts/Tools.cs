using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Serialization;

public class Tools : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shovelText;
    [SerializeField] private TextMeshProUGUI swordText;
    [SerializeField] private TextMeshProUGUI shieldText;
    //TODO: fix bug with tool's values not changing when it should reduced; v- shouldn't be static with structs since you can't create a new instance of statics
    public static Dictionary<string, int> Shovel = new Dictionary<string, int>() {{"Durability", 3}, {"Damage",1}};
    public static Dictionary<string, int> Sword = new Dictionary<string, int>() {{"Durability", 3}, {"Damage",1}};
    public static Dictionary<string, int> Shield = new Dictionary<string, int>() {{"Durability", 3}, {"Damage",1}};

    private void Update()
    {
        shovelText.text = $"Durability: {Shovel["Durability"]} Damage: {Shovel["Damage"]}";
        swordText.text = $"Durability: {Sword["Durability"]} Damage: {Sword["Damage"]}";
        shieldText.text = $"Durability: {Shield["Durability"]} Damage: {Shield["Damage"]}";
    }

    public static void ResetToolDurability()
    {
        Shovel["Durability"] = 3;
        Shovel["Damage"] = 3;
        Sword["Durability"] = 3;
        Sword["Damage"] = 3; 
        Shield["Durability"] = 3;
        Shield["Damage"] = 3;
    }

    public static void IncreaseToolDurability(Dictionary<string, int> tool)
    {
        tool["Durability"]++;
    }

    public static void IncreaseToolDamage(Dictionary<string, int> tool)
    {
        tool["Damage"]++;
    }

    public static void ReduceToolDurability(Dictionary<string, int> tool)
    {
        if (tool["Durability"] > 0)
        {
         tool["Durability"] -= 1;
        }

        if (tool["Durability"] == 0)
        {
            Player.PlayerBrokeATool = true;
        }

    }
}
