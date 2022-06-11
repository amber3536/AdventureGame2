using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrotScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
