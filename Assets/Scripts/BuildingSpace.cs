using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Primozov.TowerDefense
{
    public class BuildingSpace : MonoBehaviour
    {
        [SerializeField] Renderer rend;
        [SerializeField] Color freeSpaceColor;
        [SerializeField] Color builtColor;
        [SerializeField] GameObject UiChooseTurret;
        [SerializeField] GameObject UiEditTurret;
        [SerializeField] GameObject canonPrefab;

        private GameObject builtTurret;

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
            if (isBuilt)
            {
                rend.materials[1].color = builtColor;
                isHighligthed = true;
            }
            else if (isBuildable)
            {
                rend.materials[1].color = freeSpaceColor;
                isHighligthed = true;
            }
        }

        private void OnMouseExit()
        {
            if (isBuildable || isBuilt)
            {
                rend.materials[1].color = startColor;
                isHighligthed = false;
            }
        }

        private void OnMouseDown()
        {
            if (isBuildable)
            {
                DisableOtherUIs();
                UiChooseTurret.SetActive(true);
            }
        }

        private void DisableOtherUIs()
        {
            foreach (GameObject uiElement in GameObject.FindGameObjectsWithTag("UIChooseTurret"))
            {
                uiElement.SetActive(false);
            }
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

            builtTurret = Instantiate(prefab, transform.position, Quaternion.identity);

            UiChooseTurret.SetActive(false);

            isBuilt = true;
        }
    }
}
