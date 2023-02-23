namespace RPG.Combat
{
    using UnityEngine;
    
    public class Health : MonoBehaviour
    {
        [SerializeField] float health= 100f;

        public void TakeDamage (float damage)
        {
            if(health > 0)
            {
                health -= damage;
                print(health);
            }
        }
    }
}