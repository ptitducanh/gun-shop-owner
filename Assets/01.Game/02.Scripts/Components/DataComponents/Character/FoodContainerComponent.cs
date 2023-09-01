using System;
using System.Collections.Generic;
using Scripts.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Components
{
    public class FoodContainerComponent : DataComponent
    {
        [SerializeField] [ReadOnly] 
        public List<ItemType> Foods { get; private set; } = new();

        public Action<ItemType, Vector3> OnFoodAdded;
        public Action<ItemType> OnFoodRemoved;
            
        public void AddFood(ItemType item, Vector3 sourcePosition)
        {
            Foods.Add(item);
            OnFoodAdded?.Invoke(item, sourcePosition);
        }

        public ItemType GetFood(ItemType item)
        {
            foreach (var foodItem in Foods)
            {
                if (foodItem == item)
                {
                    Foods.Remove(foodItem);
                    OnFoodRemoved?.Invoke(foodItem);
                    return foodItem;
                }
            }

            return ItemType.None;
        }
    }
}