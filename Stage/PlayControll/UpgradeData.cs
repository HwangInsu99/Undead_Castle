using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptble Opject/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    [Header("# Main Info")]
    public int Id;
    public string Name;
}