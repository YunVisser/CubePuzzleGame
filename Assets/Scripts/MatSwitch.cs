using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatSwitch : MonoBehaviour
{
    // the next material the cubemini receives
    public Material nextMaterial;
    public bool objectIsFinished;
    public int nextSceneIndex = 0;
    [SerializeField] private GoodSide goodSide;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other) // other = de andere collider die deze collider raakt
    {
        // heeft de andere collider de tag player? (checken of het de player is)
        if(other.CompareTag("Player"))
        {           

            // check of de material naam gelijk is bij bij de objecten 
            if(material.name == other.GetComponent<Renderer>().material.name)
            {
                //klopt het? Dan hebben ze dezelfde material naam doe dan de if statement hieronder

                // Check of de kubus de juiste richting op ging
                // als goodSide true is dan heeft de speler de juiste kant geraakt, anders niet (false)
                bool goodSide = FrontCheck(other); // uit frontcheck komt of true of false
                print(goodSide);
                if(goodSide)
                {
                    if (objectIsFinished)
                    {
                        // Volgende level
                        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
                    }
                    else
                    {
                        other.GetComponent<Renderer>().material = nextMaterial; 
                    }
                }
            }
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
            default: print("er is iets erg fout gegaan");
                break;
        }
        //als de code hier is dan heeft de player niet de goede kant geraakt
        return false;
    }
}

public enum GoodSide
{
    up,
    down,
    left,
    right,
    front,
    back
}
