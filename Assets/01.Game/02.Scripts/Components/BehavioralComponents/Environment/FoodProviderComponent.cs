using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;

using MoreMountains.NiceVibrations;

namespace Scripts.Components.BehavioralComponents
{
    /// <summary>
    /// This component is responsible for adding food to the player food container
    /// </summary>
    public class FoodProviderComponent : BehavioralComponent
    {
        [SerializeField] private Image     fillImage;
        [SerializeField] private Transform sourceFoodTransform;
        
        private FoodProviderDataComponent _foodData;
        private Coroutine _addFoodToContainerCoroutine;
        
        public override void OnAwake()
        {
            base.OnAwake();
            
            _foodData = Entity.GetDataComponent<FoodProviderDataComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // check if the object is the main character
            var mainCharacterEntity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (mainCharacterEntity == null) return;

            // get the food container component
            var foodContainer = mainCharacterEntity.GetDataComponent<FoodContainerComponent>();
            if (foodContainer == null) return;
            
            // start adding food to the container
            if (_addFoodToContainerCoroutine != null)
            {
                StopCoroutine(_addFoodToContainerCoroutine);
            }
            _addFoodToContainerCoroutine = StartCoroutine(IEAddFoodToContainer(foodContainer));
        }

        private void OnTriggerExit(Collider other)
        {
            var mainCharacterEntity = EntityManager.Instance.GetEntityById(other.gameObject.GetInstanceID());
            if (mainCharacterEntity == null) return;
            
            if (_addFoodToContainerCoroutine != null)
            {
                // stop the coroutine and reset the fill image
                StopCoroutine(_addFoodToContainerCoroutine);
                fillImage.fillAmount = 0;
            }
        }
        
        /// <summary>
        /// Keep adding food to the container until the player exit the trigger
        /// </summary>
        /// <param name="foodContainer"></param>
        /// <returns></returns>
        private IEnumerator IEAddFoodToContainer(FoodContainerComponent foodContainer)
        {
            float remainingTime = _foodData.PreparationTime;
            while (true)
            {
                remainingTime = _foodData.PreparationTime;
                while (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime;
                    fillImage.fillAmount = 1f - remainingTime / _foodData.PreparationTime;
                    yield return null;
                }
                foodContainer.AddFood(_foodData.itemType, sourceFoodTransform.position);
                MMVibrationManager.Haptic(HapticTypes.Success);
                SoundController.Instance.PlaySFX("FoodCollect");
            }
        }
    }
}
