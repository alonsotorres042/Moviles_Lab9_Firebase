using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x,target.position.y,transform.position.z);
            transform.position = newPosition;
        }
    }
}