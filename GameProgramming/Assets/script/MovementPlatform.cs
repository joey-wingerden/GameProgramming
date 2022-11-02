using UnityEditor.AI;
using UnityEngine;


namespace Assets.code.platform
{
    public class MovementPlatform : MonoBehaviour
    {
        public Transform platform;
        public GameObject[] waypoint;
    
        public float speed = 1f;
        public int currentwaypoint = 0;

        public float counter = 0;

        // Update is called once per frame
        void Update()
        {
            counter += Time.deltaTime;
            if(counter > 1)
            {
                counter = 0;
                //Debug.Log("true");
                //fixmesh();
            }

            if(waypoint[currentwaypoint].transform.position == platform.position) currentwaypoint++;
            if(waypoint.Length == currentwaypoint) currentwaypoint = 0;
            platform.position = MovementSpeed();
        }

        public Vector3 MovementSpeed(){
            return Vector3.MoveTowards(platform.position, waypoint[currentwaypoint].transform.position, speed * Time.deltaTime);
        }



        private void fixmesh(){
            NavMeshBuilder.ClearAllNavMeshes();
            NavMeshBuilder.BuildNavMesh();
        }
    
    }
}
