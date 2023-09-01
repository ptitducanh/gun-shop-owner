using System.Collections;
using System.Collections.Generic;
using Scripts.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Components
{
    public enum NPCState
    {
        Initial,
        MovingIn,
        WaitingForFood,
        Eating,
        FinishedEating,
        MovingOut
    }

    public class NPCDataComponent : DataComponent
    {
        [ReadOnly]                                             public NPCState State;
        [ReadOnly]                                             public float    RemainingEatingTime;
        [FormerlySerializedAs("RequestedFoodType")] [ReadOnly] public ItemType requestedItemType;
        [ReadOnly]                                             public int      CoinAmount;

        public                                                    float                        EatingDuration;
        [FormerlySerializedAs("FoodRequestConfiguration")] public CustomerRequestConfiguration customerRequestConfiguration;
        public                                                    bool                         IsDoneEating;
        public                                                    bool                         DidPayForFood;

        public override void OnAwake()
        {
            base.OnAwake();

            requestedItemType = customerRequestConfiguration.GetRandomFoodType();
        }
    }
}