using UnityEngine;

namespace Scripts.Components
{
    public class FoodStackComponent : BehavioralComponent
    {
        private FoodContainerComponent _foodContainer;

        public override void OnAwake()
        {
            base.OnAwake();
            
            _foodContainer = Entity.GetDataComponent<FoodContainerComponent>();
        }
        
        
    }
}