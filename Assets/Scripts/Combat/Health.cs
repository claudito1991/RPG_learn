namespace RPG.Combat
{
    using UnityEngine;
    
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints= 100f;
        bool isDead = false;

        //Simple way of other classes to know the state of isDead bool that is private
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage (float damage)
        {

            healthPoints = Mathf.Max(healthPoints-damage,0);
            if(healthPoints==0)
            {
                TriggerDeadAnimation();
            }
            print(healthPoints);

        }

        void TriggerDeadAnimation()
        {
            if(isDead) return;
            isDead=true;
            GetComponent<Animator>().SetTrigger("death");
        }
    }
}