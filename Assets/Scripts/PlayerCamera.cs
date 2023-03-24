using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    // old static camera movement. use for testing

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    // Update is called once per frame    
    void LateUpdate() {
        transform.position = player.position + offset;
    }
}
