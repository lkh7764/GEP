using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMoveHurb : MonoBehaviour
{
    public GameObject monster;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                GameObject m = Instantiate(monster);
                Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                m.transform.position = pos;
                Destroy(this.gameObject);
            }
        }
    }
}
