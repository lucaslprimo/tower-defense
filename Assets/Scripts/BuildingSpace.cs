using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpace : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] Color highLightColor;
    public bool isBuildable;
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
        }
    }

    private void OnMouseExit()
    {
        if (isBuildable)
        {
            rend.materials[1].color = startColor;
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
}
