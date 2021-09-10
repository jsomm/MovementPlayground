using UnityEngine;

namespace MovementPlayground.ResourceBars
{
    public class ResourceBarManager : MonoBehaviour
    {
        public int MaxHealth = 5;
        public int MaxMana = 10;

        public int CurrentHealth { get { return HealthBar.CurrentResource; } }
        public int CurrentMana { get { return ManaBar.CurrentResource; } }

        public ResourceBarBase HealthBar, ManaBar;

        private void Start()
        {
            HealthBar.SetMaxResource(MaxHealth);
            ManaBar.SetMaxResource(MaxMana);
        }
        public void TakeDamageButton(int delta)
        {
            ChangeResource(HealthBar, delta);
        }

        public void UseManaButton(int delta)
        {
            ChangeResource(ManaBar, delta);
        }

        public void ChangeResource(ResourceBarBase resourceBar, int delta)
        {
            int newResourceAmount = resourceBar.CurrentResource - delta;
            newResourceAmount = Mathf.Clamp(newResourceAmount, 0, resourceBar.MaxResource);

            resourceBar.SetResource(newResourceAmount);
        }

        public void RefillResource(ResourceBarBase resourceBarToRefill)
        {
            resourceBarToRefill.RefillResource();
        }
    }
}
