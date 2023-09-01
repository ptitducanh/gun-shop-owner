using Scripts.Components;
using Scripts.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Entities
{
    public class FoodProviderDataComponent : DataComponent
    {
        [FormerlySerializedAs("FoodType")] public ItemType itemType;
        public  float    PreparationTime;
    }
}