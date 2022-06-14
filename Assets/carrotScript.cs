using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrotScript : MonoBehaviour
{
    public AudioSource audio_src1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(audio_src1.clip, 1.0f);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

    }
}
