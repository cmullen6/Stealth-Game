using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class Lockpick : MonoBehaviour
{

    // ADD FREEZE CHARACTER


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
    public Transform doorKiller;
    private float spawnSize = 0.25f;
    private float doorDelete = 2.5f;
    private List<Transform> spawns = new List<Transform>();



    //Spawns hit marker & moves hit indicator ** I know some of this is ugly :( **

    public void Start()
    {

        spawns.Add(spawn1);
        spawns.Add(spawn2);
        spawns.Add(spawn3);
        spawns.Add(spawn4);
        spawns.Add(spawn5);

    }

    public void SpawnPicking()
    {

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

            Collider[] hitColliders = Physics.OverlapSphere(doorKiller.position, doorDelete);

            foreach (var hitCollider in hitColliders)
            {

                if (hitCollider.CompareTag("LockedDoor"))
                {

                    Destroy(hitCollider.gameObject);

                }
            }

            lockUI.SetActive(false);

            counter = 0;

        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {

            float distance = Vector3.Distance(hitMarker.transform.position, hitArea.transform.position);

            if (distance < 0.7f)
            {
                counter++;

                Debug.Log("Hit");

                SpawnPicking();

            }
       
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

        Gizmos.DrawWireSphere(doorKiller.position, doorDelete);

    }
}