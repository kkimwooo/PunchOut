using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  Vector3 direction = path[currentPoint].position - transform.position; 
        float distance = Vector3.Distance(path[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.smoothDeltaTime * speed);

        if (distance <= reachDist)
            currentPoint++;

        if (currentPoint >= path.Length)
            currentPoint = 0;
    }
    /*
    void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    //Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
        }
    }
    */
}
