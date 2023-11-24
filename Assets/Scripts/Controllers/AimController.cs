using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    // Cannon variables
    [SerializeField] private GameObject cannon;

    // Raycast Variables
    #region Editor Settings

    [SerializeField] private LayerMask groundMask;

    #endregion

    // Aim variables
    [SerializeField] private Camera mainCamera;

    public void Aim()
    {
        var (success, position) = GetMousePosition();

        if(success)
        {
            // Calculate the direction
            Vector3 direction = position - transform.position;

            // Constant height
            direction.y = 0;

            // Make the transform of the cannon look in the direction
            cannon.transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        // Input.mousePosition returns a Vector3 of X and Y while ignoring Z
        // ScreenPointToRay returns a ray through a point in the screen, that screen being wherever the mouse position is
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Physics.Raycast casts a ray from ray to all colliders in the scene at a certain distance (in this case infinity)
        // Physics.Raycast returns a boolean value, and can return another value, hitInfo, if the result is true
        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    public Quaternion GetCannonRotation()
    {
        return cannon.transform.rotation;
    }
}
