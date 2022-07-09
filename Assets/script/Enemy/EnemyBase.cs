using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip = default;
    //public abstract void Activate();
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            //this.Activate();
            Destroy(this.gameObject);
        }
    }
}
