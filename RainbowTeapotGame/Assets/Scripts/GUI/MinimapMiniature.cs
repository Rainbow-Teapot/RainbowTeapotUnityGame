using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapMiniature : MonoBehaviour
{
    [SerializeField]
    private float offsetLocalPlayer;
    [SerializeField]
    private Sprite[] localMiniatures;
    [SerializeField]
    private float offsetRemotePlayer;
    [SerializeField]
    private Sprite[] remoteMiniatures;

    private Image image;
    private readonly float maxDistance = 680.0f;
    private readonly float maxTrackDistance = 1050.0f;

    private Vector3 initialLocalPosition;


    public void Init(vehicles vehicle, bool scaled)
    {

        if (scaled)
        {
            image.sprite = localMiniatures[(int)vehicle];
            transform.SetAsLastSibling();
            initialLocalPosition = new Vector3(offsetLocalPlayer, maxDistance/2 , 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            image.sprite = remoteMiniatures[(int)vehicle];
            transform.SetAsFirstSibling();
            initialLocalPosition = new Vector3(offsetRemotePlayer, maxDistance / 2, 0);
            transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }

        
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetPosition(float currentDistance)
    {
        transform.localPosition =  initialLocalPosition + Vector3.down * maxDistance * currentDistance / maxTrackDistance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
