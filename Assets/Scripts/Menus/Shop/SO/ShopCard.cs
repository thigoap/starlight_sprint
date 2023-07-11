using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Card", menuName = "Card")]
public class ShopCard : ScriptableObject
{
    public int id;
    public new string name;
    public Sprite art;
    public int coin;
    public int diamond;
}
