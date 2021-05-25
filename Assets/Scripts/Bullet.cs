using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    private GameObject target;

    private void SetTarget(GameObject target)
    {
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null){
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime);
        }
    }
}
