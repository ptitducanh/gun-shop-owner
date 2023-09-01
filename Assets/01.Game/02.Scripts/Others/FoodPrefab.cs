using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodPrefab : MonoBehaviour
{
    [FormerlySerializedAs("FoodType")] public ItemType itemType;
}
