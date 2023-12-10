using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _transformToFollow;

    private void Update()
    {
        transform.position = new Vector3(_transformToFollow.position.x, _transformToFollow.position.y, transform.position.z);
    }
}
