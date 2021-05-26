using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Primozov.TowerDefense
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] Transform mapTilesParent;
        [Range(1, 100)]
        [SerializeField] float percentageOfProps;
        [SerializeField] GameObject[] props;
        [SerializeField] float propHeight;
        private GameObject[] tiles;


        void Start()
        {
            GetTiles();
            RandomizeProps();
        }

        void GetTiles()
        {
            tiles = new GameObject[mapTilesParent.childCount];
            for (int i = 0; i < mapTilesParent.childCount; i++)
            {
                tiles[i] = mapTilesParent.GetChild(i).gameObject;
            }
        }

        void RandomizeProps()
        {
            int propsToLand = (int)(mapTilesParent.childCount * percentageOfProps / 100);
            List<int> sortedNumbers = new List<int>();

            while (propsToLand > 0)
            {
                int randomTileIndex = Random.Range(0, mapTilesParent.childCount);
                if (!sortedNumbers.Contains(randomTileIndex))
                {
                    GameObject tile = tiles[randomTileIndex];
                    tile.GetComponent<BuildingSpace>().isBuildable = false;

                    int randomPropIndex = Random.Range(0, props.Length);
                    Vector3 propPosition = new Vector3(tile.transform.position.x, propHeight, tile.transform.position.z);

                    int yRot = Random.Range(0, 360);

                    Instantiate(props[randomPropIndex], propPosition, Quaternion.Euler(0, yRot, 0));
                    propsToLand--;
                    sortedNumbers.Add(randomTileIndex);
                }
            }
        }
    }
}
