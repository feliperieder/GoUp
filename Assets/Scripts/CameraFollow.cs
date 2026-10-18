using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    private float cameraMargin = 2f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position.y - cameraMargin > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y- cameraMargin, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, 0.1f);
            }
        }
    }
}
