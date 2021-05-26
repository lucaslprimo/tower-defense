using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpace : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] Color highLightColor;
    [SerializeField] GameObject UiChooseTurret;
    [SerializeField] GameObject UiEditTurret;

    [SerializeField] GameObject canonPrefab;

    public enum TurretType
    {
        CANNON
    }

    public bool isBuildable = true;
    private bool isBuilt = false;
    private bool isHighligthed = false;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        startColor = rend.materials[1].color;
    }

    private void OnMouseEnter()
    {
        if (isBuildable)
        {
            rend.materials[1].color = highLightColor;
            isHighligthed = true;
        }
    }

    private void OnMouseExit()
    {
        if (isBuildable)
        {
            rend.materials[1].color = startColor;
            isHighligthed = false;
        }
    }

    private void OnMouseDown()
    {
        UiChooseTurret.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuildable)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.CompareTag("Props") && isBuildable)
        {
            isBuildable = false;
        }
    }

    public void BuyCannon()
    {
        BuildTurret(TurretType.CANNON);
    }

    private void BuyTurret(TurretType turretType)
    {
        //Check economy
        BuildTurret(turretType);
    }

    private void BuildTurret(TurretType turretType)
    {
        GameObject prefab;
        switch (turretType)
        {
            default:
            case TurretType.CANNON:
                prefab = canonPrefab;
                break;
        }

        Instantiate(prefab, transform.position, Quaternion.identity);

        UiChooseTurret.SetActive(false);
    }
}
