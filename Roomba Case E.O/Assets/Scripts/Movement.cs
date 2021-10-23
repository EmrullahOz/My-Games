using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("Robot Motion System")]
    public float timeForNextRay;
    public List<GameObject> wayPoints;
    LineRenderer lr;
    float timer=0;
    int currentWayPoint = 0;
    int wayIndex;
    bool move;
    bool touchStartPlayer;
    bool tryMove;

    [Header("Particle System")]
    public ParticleSystem robotParticle;
    public GameObject explosionParticle;

    [Header("Bar Control")]
    public int collectedGarbage;
    public Slider slider;
    public GameObject garbage;

    [Header("Game Panel")]
    public GameObject sucPanel;  
    public GameObject failPanel;  

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        wayIndex = 1;
        move = false;
        tryMove = true;
        touchStartPlayer = false;
        garbage = GameObject.Find("Garbage");
        slider.maxValue = garbage.transform.parent.childCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        slider.value = collectedGarbage;

        // function by which the path of the robot is drawn
        if (Input.GetMouseButton(0) && timer>timeForNextRay && touchStartPlayer ) 
        {
            Vector3 WorlFromMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,100));
            Vector3 direction = WorlFromMousePos - Camera.main.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,direction,out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, direction,Color.red,1f);
                GameObject newWayPoint = new GameObject("WayPoint");
                newWayPoint.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                wayPoints.Add(newWayPoint);
                lr.positionCount = wayIndex + 1;
                lr.SetPosition(wayIndex, newWayPoint.transform.position);
                timer = 0;
                wayIndex++;
            }
            tryMove = false;
        }
        // the point where we take our finger off the mouse
        if (Input.GetMouseButtonUp(0))
        {
            touchStartPlayer = false;
            move = true;           
        }
        // the function where the robot moves on the road after taking our finger off mouse
        if (move && tryMove==false)
        {
            robotParticle.Play();
            transform.LookAt(wayPoints[currentWayPoint].transform);
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, Time.deltaTime*GameManager.Instance.speed);
            // object passing system required for robot to move forward
            if (transform.position== wayPoints[currentWayPoint].transform.position)
            {
                currentWayPoint++;
            }
            // function where robot comes to the end of road
            if (currentWayPoint==wayPoints.Count)
            {
                robotParticle.Stop();
                move = false;
                foreach (var item in wayPoints)
                {
                    Destroy(item);                    
                }
                wayPoints.Clear();
                wayIndex = 1;
                currentWayPoint = 0;
                tryMove = true;
                robotParticle.Stop();
                if (collectedGarbage >= 151)
                {
                    Invoke("SucPanelOpen", 0.75f);
                }
                if (collectedGarbage < 150)
                {
                    Invoke("FailPanelOpen", 0.75f);
                }
            }
        }       
    }
    private void OnMouseDown()
    {
        lr.enabled = true;
        touchStartPlayer = true;
        //tryMove = false;
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        // the point where the robot touches the garbage
        if (other.gameObject.CompareTag("Rubbish")) 
        {
            collectedGarbage++;
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, transform.position, Time.deltaTime * GameManager.Instance.speedGarbage);
            Destroy(other.gameObject, 0.05f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // the point where robot touches the wall and objects
        if (collision.gameObject.CompareTag("Wall"))
        {
            robotParticle.Stop();
            GameManager.Instance.speed = 0;
            explosionParticle.SetActive(true);
            Invoke("FailPanelOpen", 0.75f);
        }
    }
    // Transactions that occur when we exceed 150 points
    void SucPanelOpen()
    {
        sucPanel.SetActive(true);
        Time.timeScale = 0;
    }
    // Where we're under 150 points or hit something
    void FailPanelOpen()
    {
        failPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
