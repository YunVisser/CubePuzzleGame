using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //public Direction newDir;

    public Transform newPos;
    public bool stopAfterTeleport = true;
    [SerializeField] private GoodSide goodSide;

    //// Start is called before the first frame update
    //void Start()
    //{       
    //}


    //// Update is called once per frame
    //void Update()
    //{        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && FrontCheck(other))
        {
            other.transform.position = newPos.position;
            

            CharController player = other.GetComponent<CharController>();

            if (stopAfterTeleport)
            {
                player.cubeDirection = Vector3.zero;
                player.hasHitWall = true;  //zodra de player de muur heeft aangeraakt kan de player weer lopen 
                return;
            }

            //switch (newDir)
            //{
            //    case Direction.up:
            //        player.cubeDirection = Vector3.up;
            //        break;
            //    case Direction.down:
            //        player.cubeDirection = Vector3.down;
            //        break; 
            //    case Direction.left:
            //        player.cubeDirection = Vector3.left;
            //        break;
            //    case Direction.right:
            //        player.cubeDirection = Vector3.right;
            //        break;
            //    case Direction.forward:
            //        player.cubeDirection = Vector3.forward;
            //        break;
            //    case Direction.backward:
            //        player.cubeDirection = Vector3.back;
            //        break;
            //    default:
            //        break;
            //}
        }
    }

    private bool FrontCheck(Collider other)
    {
        // De player
        CharController player = other.GetComponent<CharController>();

        // check of kubus voor planes zit
        switch (goodSide)
        {
            case GoodSide.up:
                if (player.cubeDirection == Vector3.down) return true;
                break;
            case GoodSide.down:
                if (player.cubeDirection == Vector3.up) return true;
                break;
            case GoodSide.left:
                if (player.cubeDirection == Vector3.right) return true;
                break;
            case GoodSide.right:
                if (player.cubeDirection == Vector3.left) return true;
                break;
            case GoodSide.front:
                if (player.cubeDirection == Vector3.back) return true;
                break;
            case GoodSide.back:
                if (player.cubeDirection == Vector3.forward) return true;
                break;
            default:
                print("er is iets erg fout gegaan");
                break;
        }
        //als de code hier is dan heeft de player niet de goede kant geraakt
        return false;
    }
}

//public enum Direction
//{
//    up,
//    down,
//    left,
//    right,
//    forward,
//    backward
//}
