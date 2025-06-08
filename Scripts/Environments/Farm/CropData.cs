using System.Collections.Generic;
using UnityEngine;



namespace DMBTools
{
[CreateAssetMenu(fileName = "Crop Data", menuName = "HelsingFarm/Data/Crop", order = 0)]
public class CropData : ScriptableObject
{
    public CropType type;
    public int currentPhase = 0;
    public List<Sprite> sprites;



}
}