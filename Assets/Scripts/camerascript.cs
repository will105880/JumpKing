using UnityEngine;

public class camerascript : MonoBehaviour
{
    public Transform target;
    public Transform player;


    private void Update()
    {
        float playerYPosition = player.position.y;
        target.transform.position = new Vector3(0,playerYPosition + 2,-10);
    }
}
