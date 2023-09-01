using Scripts.Components.DataComponents.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Components
{
    public class MovementStatComponent : EntityStatsComponent
    {
        [OnValueChanged("UpdateMaxSpeed")]
        [SerializeField] private float maxSpeed;

        public override void OnAwake()
        {
            base.OnAwake();
            
            AddFloatStat("MaxSpeed", maxSpeed);
        }
        
        private void UpdateMaxSpeed()
        {
            SetFloatStat("MaxSpeed", maxSpeed);
        }
    }
}
