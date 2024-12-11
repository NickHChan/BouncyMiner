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
    public static Tool Pickaxe = new Tool(3, 1);
    public static Tool Sword = new Tool(3, 1);
    public static Tool Shield = new Tool(3, 0);

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
        tool.Durability--;
    }
}
