using UnityEngine;

namespace MovementPlayground
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float TimeUntilDestroy = 5f;
        private void Update()
        {
            TimeUntilDestroy -= Time.deltaTime;
            if (TimeUntilDestroy <= 0)
                Destroy(this.gameObject);
        }
    }
}
