using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float fireCooldown;

    private float fireCooldownTime;
    private Enemy target;
    private float rotSpeed = 10;

    

    void Start()
    {
        
    }
    
    void Update()
    {
        if(target == null)
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

        foreach (GameObject enemy in enemys)
        {
            if (InRange(enemy.transform.position))
            {
                target = enemy.GetComponent<Enemy>();
                break;
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
            
            if(Time.time > fireCooldownTime)
            {

            }
            //Hit the target
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
}
