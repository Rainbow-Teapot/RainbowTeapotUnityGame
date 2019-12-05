using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeColor : MonoBehaviour
{
    PlayerInfo playerInfo;

    [SerializeField]
    private Gradient[] colors;
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();
        particles = GetComponent<ParticleSystem>();
        ChooseColorByLevel(playerInfo.level);
    }

    private void ChooseColorByLevel(levels level)
    {
        var col = particles.colorOverLifetime;
        col.enabled = true;
        col.color = colors[(int)level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
