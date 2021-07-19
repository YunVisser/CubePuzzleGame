using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    public LayerMask layerMaskWalls; //raycast collision ignore/checken dat die de muur checkt
    
    public float speed = 1f;
    public int maxMoves = 5;

    private Rigidbody rb;
    [HideInInspector] public Vector3 cubeDirection = Vector3.zero;

    public bool hasHitWall = true;
    public bool hitUp, hitDown, hitLeft, hitRight, hitForward, hitBackwards;


    // Start is called before the first frame update
    void Start()
    {
        // Get
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {     
        if(Input.GetKeyDown(KeyCode.R))
        {
            //refresh scene/level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        CubeRaycasts();

        //retry scene waarin je geeindigd bent
        if (maxMoves < 1)
        {
            GameManager.lastLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("TryAgain");
        }

    }

    private void FixedUpdate()
    {
        MoveCube();
    }

    void MoveCube()
    {
        // Als cube niet beweegt
        if (hasHitWall && maxMoves > 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && !hitForward)
            {
                maxMoves--;
                cubeDirection = Vector3.forward;
                hasHitWall = false;
            }
            else if (Input.GetKeyDown(KeyCode.S) && !hitBackwards)
            {
                maxMoves--;
                cubeDirection = Vector3.back;
                hasHitWall = false;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !hitLeft)
            {
                maxMoves--;
                cubeDirection = Vector3.left;
                hasHitWall = false;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !hitRight)
            {
                maxMoves--;
                cubeDirection = Vector3.right;
                hasHitWall = false;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !hitUp)
            {
                maxMoves--;
                cubeDirection = Vector3.up;
                hasHitWall = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !hitDown)
            {
                maxMoves--;
                cubeDirection = Vector3.down;
                hasHitWall = false;
            }
        }
        rb.MovePosition(transform.position + (cubeDirection * speed * Time.fixedDeltaTime));
    }

    private void CubeRaycasts()
    {
        RaycastHit hit;

        // Up
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitUp)
            {
                hitUp = true;
                hasHitWall = true;
            }
        }
        else hitUp = false;

        // Down
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitDown)
            {
                hitDown = true;
                hasHitWall = true;
            }
        }
        else hitDown = false;

        // Left
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitLeft)
            {
                hitLeft = true;
                hasHitWall = true;
            }
        }
        else hitLeft = false;

        // Right
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitRight)
            {
                hitRight = true;
                hasHitWall = true;
            }
        }
        else hitRight = false;

        // Forwards
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitForward)
            {
                hitForward = true;
                hasHitWall = true;
            }
        }
        else hitForward = false;

        // Backwards
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 0.55f, layerMaskWalls))
        {
            if(!hitBackwards)
            {
                hitBackwards = true;
                hasHitWall = true;
            }
        }
        else hitBackwards = false;
    }    
}
