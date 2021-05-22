using UnityEngine;

namespace Primozov.TowerDefense
{

    public class Tower : MonoBehaviour
    {
        [SerializeField] float range;
        [SerializeField] float fireCooldown;
        [SerializeField] int damage;
        [SerializeField] Animator anim;

        private float fireCooldownTime;
        private GameObject target;
        private float rotSpeed = 10;


        void Start()
        {

        }

        void Update()
        {
            if (target == null)
            {
                LookForTargets();
            }
            else
            {
                ShootTarget();
            }
        }

        private void LookForTargets()
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            float closerDistance = 9999;

            foreach (GameObject enemy in enemys)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance <= range && distance < closerDistance)
                {
                    closerDistance = distance;
                    target = enemy;
                }
            }
        }

        private void ShootTarget()
        {
            if (InRange(target.transform.position))
            {
                Vector3 dir = target.transform.position - transform.position;

                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

                if (Time.time > fireCooldownTime)
                {
                    anim.SetTrigger("shoot");
                    target.GetComponent<Damagable>().TakeDamage(damage);
                    fireCooldownTime = Time.time + fireCooldown;
                }
            }
            else
            {
                target = null;
            }
        }

        private bool InRange(Vector3 position)
        {
            return Vector3.Distance(transform.position, position) <= range;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range / 2);
        }
    }

}