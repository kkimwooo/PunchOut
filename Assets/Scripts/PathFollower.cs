using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Rigidbody2D rb2D { get; set; }
    
    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Vector3 direction = path[currentPoint].position - transform.position; 
        float distance = Vector3.Distance(path[currentPoint].position, transform.position);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.smoothDeltaTime * speed);

        Vector3 dir = newPosition - transform.position;
        Debug.Log(dir);
        Quaternion rotation = Quaternion.LookRotation(new Vector3(0,0,dir.z));
        transform.rotation = rotation;
        //Debug.Log(newPosition);
        //transform.Rotate (new Vec)
        //transform.LookAt(newPosition + Vector3.up * transform.position.y * -90);
        //Quaternion rot = Quaternion.LookRotation(transform.position - newPosition, Vector3.forward);
        //transform.rotation = rot;

        rb2D.MovePosition(newPosition);

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
