using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Primozov.TowerDefense
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] float panSpeed;

        void Start()
        {

        }

        void Update()
        {
            transform.Translate(HandleInput() * panSpeed * Time.deltaTime, Space.World);
        }

        Vector3 HandleInput()
        {
            Vector3 movementVector = new Vector3(0, 0, 0);

            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Space))
            {
                movementVector.y = 1;
            }
            else
            if (Input.GetKey(KeyCode.LeftControl))
            {
                movementVector.y = -1;
            }

            return movementVector;
        }
    }
}
