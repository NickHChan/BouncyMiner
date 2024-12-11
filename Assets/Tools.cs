using System;
using TMPro;
using UnityEngine;

public struct Tool
{
    public int Durability { get; set; }
    public int Damage { get; set; }

    public Tool(int durability, int damage)
    {
        Durability = durability;
        Damage = damage;
    }
}

public class Tools : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pickaxeText;
    [SerializeField] private TextMeshProUGUI swordText;
    [SerializeField] private TextMeshProUGUI shieldText;
    //TODO: fix bug with tool's values not changing when it should reduced;
    public static Tool Pickaxe = new Tool(3, 1);
    public static Tool Sword = new (3, 1);
    public static Tool Shield = new (3, 0);

    private void Update()
    {
        pickaxeText.text = $"Durability: {Pickaxe.Durability} Damage: {Pickaxe.Damage}";
        swordText.text = $"Durability: {Sword.Durability} Damage: {Sword.Damage}";
        shieldText.text = $"Durability: {Shield.Durability} Damage: {Shield.Damage}";
    }

    public static void ResetToolDurability(Tool tool)
    {
        tool.Durability = 3;
    }

    public static void IncreaseToolDurability(Tool tool)
    {
        tool.Durability++;
    }

    public static void IncreaseToolDamage(Tool tool)
    {
        tool.Damage++;
    }

    public static void ReduceToolDurability(Tool tool)
    {
        tool.Durability -= 1;
    }
}
