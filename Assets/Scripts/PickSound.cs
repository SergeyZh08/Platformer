using UnityEngine;

public class PickSound : MonoBehaviour
{
    [SerializeField] private AudioClip _pick;

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(_pick, transform.position);
    }
}
