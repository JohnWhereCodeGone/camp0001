using UnityEngine;

public class ItemVisualizer : MonoBehaviour
{
    public Armor armor;
    public Weapon weapon;
    public Metal metal;

    [ContextMenu("Show me desc")]
    public void DisplayDescription()
    {
        Debug.Log("Armor info:\n" + armor.GetDescription());
        Debug.Log("Weapon info:\n" + weapon.GetDescription());
        Debug.Log("Metal info \n" + metal.GetDescription());
    }

}
