using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingShotgun : MonoBehaviour {
    public int numCasts;
    public float arcInDeg;
    public float maxDistance;
    public float cooldownTime;
    public float markerLifetime;
    public GameObject marker;
    public GameObject markerList;
    public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("click detected at " + Input.mousePosition);
            Vector3[] hitPoints = new Vector3[numCasts];
            Vector3 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("the click is thought to be in the world at " + clickPos);
            /*Vector3 defaultDirection = rotate(-arcInDeg/2, clickPos - transform.position);
            float angleToRotate = (arcInDeg - 1) / 2;
            for(int i = 0; i < numCasts; ++i)
            {
                Vector3 current = rotate(i * angleToRotate, defaultDirection);
                current = new Vector3(current.x, current.y, transform.position.z);
                RaycastHit2D hit;
                Debug.Log("trying to raycast out from " + transform.position + " in the direction of " + current);
                hit = Physics2D.Raycast(transform.position, current);
                if (hit.collider != null){
                    Instantiate(marker, hit.point, Quaternion.identity, markerList.transform);
                    Debug.Log("Creating ping at " + hit.point);
                }
                
            }*/
            Vector3 direction = new Vector3(clickPos.x - transform.position.x, clickPos.y - transform.position.y, transform.position.z).normalized;
            //Debug.Log("trying to raycast out from " + transform.position + " in the direction of " + direction);

            Vector3 defaultDirection = rotate(-arcInDeg / 2, direction);
            float angleToRotate = (numCasts - 1) / arcInDeg;
            Debug.Log(angleToRotate);

            for (int i = 0; i < numCasts; ++i)
            {
                Vector3 tempDirection = rotate(i * angleToRotate, defaultDirection);
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, tempDirection, maxDistance, LayerMask.GetMask("Terrain"));
                if (hits.Length > 0)
                {
                    Instantiate(marker, hits[0].point, Quaternion.identity, hits[0].collider.gameObject.transform);
                    //Debug.Log("Creating ping at " + hits[1].point);
                }
            }

        }
	}

    private Vector3 rotate(float theta, Vector3 original)
    {
        return new Vector3((original.x * Mathf.Cos(Mathf.Deg2Rad * theta) - original.y * Mathf.Sin(Mathf.Deg2Rad * theta)),(original.x * Mathf.Sin(Mathf.Deg2Rad * theta) + original.y * Mathf.Cos(Mathf.Deg2Rad * theta)),(original.z));
    }
}
