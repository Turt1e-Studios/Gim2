using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    // Update is called once per frame    
    void LateUpdate() {
        transform.position = player.position + offset;
    }
}
