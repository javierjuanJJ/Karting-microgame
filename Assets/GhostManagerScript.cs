using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct GhostTranform
{
    public Vector3 position;
    public Quaternion rotation;
    
    public GhostTranform(Transform transform)
    {
        position = transform.position;
        rotation = transform.rotation;
    }
    
}
public class GhostManagerScript : MonoBehaviour
{
    public Transform kart;
    public Transform ghostKart;
    
    public bool recording;
    public bool playing;

    private List<GhostTranform> listGhostTranformer = new List<GhostTranform>();
    private GhostTranform lastGhostTranformer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (recording)
        {
            if (kart.position != lastGhostTranformer.position || kart.rotation != lastGhostTranformer.rotation)
            {
                GhostTranform ghostTranform = new GhostTranform(kart);
                listGhostTranformer.Add(ghostTranform);
                lastGhostTranformer = ghostTranform;
            }
        }

        if (playing)
        {
            Play();
        }
    }

    private void Play()
    {
        ghostKart.gameObject.SetActive(true);
        StartCoroutine("PlayGame");
        playing = false;
    }

    public IEnumerable PlayGame()
    {
        for (int count = 0; count < listGhostTranformer.Count; count++)
        {
            ghostKart.position = listGhostTranformer[count].position;
            ghostKart.rotation = listGhostTranformer[count].rotation;
            yield return new WaitForFixedUpdate();
        }
    }
}
