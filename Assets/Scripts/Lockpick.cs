using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class Lockpick : MonoBehaviour
{


    //BUGS*******
    //counter doesnt seem to work, either a:
        //collision issue
        //tag issue
        //rigid body issue
        //some dumb thing I didn't notice


    int counter = 0;
    private Vector3 boundSize = new Vector3(0.25f, 0.25f, 0.25f);
    public GameObject hitMarker;
    public GameObject hitArea;
    public GameObject player;
    public GameObject lockUI;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    private float spawnSize = 0.25f;
    private List<Transform> spawns = new List<Transform>();


    //Spawns hit marker & moves hit indicator ** I know some of this is ugly :( **
    public void SpawnPicking()
    {

        spawns.Add(spawn1);
        spawns.Add(spawn2);
        spawns.Add(spawn3);
        spawns.Add(spawn4);
        spawns.Add(spawn5);

        lockUI.SetActive(true);
        hitArea.SetActive(false);

        GetPos();

        hitArea.SetActive(true);

    }

    public Vector3 GetPos()
    {
       
        int randomSpawn = Random.Range(0, spawns.Count);

        Transform spawnAt = spawns[randomSpawn];

        hitArea.transform.position = spawnAt.position;

        return spawnAt.position;

    }

    private void Update()
    {

        if (counter == 3)
        {

            lockUI.SetActive(false);

        }
        else if ((Keyboard.current.eKey.wasPressedThisFrame) && (hitMarker.CompareTag("LockpickArea")))
        {

            counter++;

            Debug.Log("hit");

            SpawnPicking();

        }

        if ((Keyboard.current.escapeKey.wasPressedThisFrame))
        {

            Debug.Log("esc");

            lockUI.SetActive(false);

        }

    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.darkOrange;
        Gizmos.DrawWireSphere(spawn1.position, spawnSize);
        Gizmos.DrawWireSphere(spawn2.position, spawnSize);
        Gizmos.DrawWireSphere(spawn3.position, spawnSize);
        Gizmos.DrawWireSphere(spawn4.position, spawnSize);
        Gizmos.DrawWireSphere(spawn5.position, spawnSize);

    }
}