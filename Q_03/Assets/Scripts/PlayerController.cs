using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    [SerializeField] private float _soundTime;

    Coroutine _routine;

    WaitForSeconds _waitTime;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
        _waitTime = new WaitForSeconds(_soundTime);
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            _routine = StartCoroutine(DIe());
        }
    }

    // Die를 코루틴으로 구현하여 sound들린 후 꺼지도록 함.
    IEnumerator DIe()
    {
        _audio.Play();

        yield return _waitTime;

        gameObject.SetActive(false);
    }


}
