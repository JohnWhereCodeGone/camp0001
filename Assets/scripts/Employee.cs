using UnityEngine;


[CreateAssetMenu(menuName = "SummerCamp/Employee")]
public class Employee : ScriptableObject
{
    public int employeeAge;
    public FavoriteAnimal favAnimal;
    public string employeeName;
    public float employeeHeight;
    public CurrentEmotion emotion;
}
public enum FavoriteAnimal
{
    Male,
    Female,
    Horse,
    Apple
}
public enum CurrentEmotion
{
    Angry,
    Aggressive,
    Hateful,

}