using System.Collections.Generic;
using Scripts.Data;
using UnityEngine;

namespace Scripts.Entities
{
    public class FoodItemPoolEntity : BaseEntity
    {
        public List<FoodPrefab>                 FoodPrefabs = new List<FoodPrefab>();
        public Dictionary<ItemType, GameObject> FoodItems   = new Dictionary<ItemType, GameObject>();

        protected override void OnAwake()
        {
            base.OnAwake();

            foreach (var foodPrefab in FoodPrefabs)
            {
                FoodItems.Add(foodPrefab.itemType, foodPrefab.gameObject);
            }
        }
    }
}