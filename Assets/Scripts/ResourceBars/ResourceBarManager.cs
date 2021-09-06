using UnityEngine;

namespace MovementPlayground.ResourceBars
{
    public class ResourceBarManager : MonoBehaviour
    {
        public int MaxHealth = 5;
        public int MaxMana = 10;

        public int CurrentHealth, CurrentMana;

        public ResourceBarBase HealthBar, ManaBar;

        private void Start()
        {
            CurrentHealth = MaxHealth;
            HealthBar.SetMaxResource(MaxHealth);

            CurrentMana = MaxMana;
            ManaBar.SetMaxResource(MaxMana);
        }
        
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

            HealthBar.SetResource(CurrentHealth);
        }

        public void UseMana(int manaUsed)
        {
            CurrentMana -= manaUsed;
            CurrentMana = Mathf.Clamp(CurrentMana, 0, MaxMana);

            ManaBar.SetResource(CurrentMana);
        }
    }
}
