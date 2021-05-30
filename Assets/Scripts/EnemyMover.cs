using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 5f)] private float speed = 1f;

    private void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void FindPath()
    {
        path.Clear();
        
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;
            
            transform.LookAt(endPos);    
            
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }
    
}
