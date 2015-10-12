using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScrollingBackground : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    public GameObject Player;
    public float offsetx;
    public float offsety;
    // Update is called once per frame
    void Awake()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");

    }
    void Update()
    {

        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

        transform.position = new Vector3(Player.transform.position.x + offsetx,
                                                transform.position.y + offsety,
                                                transform.position.z);
    }

    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

    //public float speed = 0;
    //public static ScrollingBackground current;

    //float pos = 0;

    //void Awake()
    //{
    //    current = this;
    //}
    //public void BackGroundGo()
    //{
    //    pos += speed;
    //    if(pos > 1.0f) { pos -= 1.0f; }
    //    GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);

    //}

    ///// <summary>
    ///// Scrolling speed
    ///// </summary>
    //public Vector2 speed = new Vector2(10, 10);

    ///// <summary>
    ///// Moving direction
    ///// </summary>
    //public Vector2 direction = new Vector2(-1, 0);

    ///// <summary>
    ///// Movement should be applied to camera
    ///// </summary>
    //public bool isLinkedToCamera = false;

    ///// <summary>
    ///// 1 - Background is infinite
    ///// </summary>
    //public bool isLooping = false;
    //public float xoffset;
    ///// <summary>
    ///// 2 - List of children with a renderer.
    ///// </summary>
    //private List<Transform> backgroundPart;

    //// 3 - Get all the children
    //void Start()
    //{
    //    // For infinite background only
    //    if (isLooping)
    //    {
    //        // Get all the children of the layer with a renderer
    //        backgroundPart = new List<Transform>();

    //        for (int i = 0; i < transform.childCount; i++)
    //        {
    //            Transform child = transform.GetChild(i);

    //            // Add only the visible children
    //            if (child.GetComponent<Renderer>() != null)
    //            {
    //                backgroundPart.Add(child);
    //            }
    //        }
    //        // Sort by position.
    //        // Note: Get the children from left to right.
    //        // We would need to add a few conditions to handle
    //        // all the possible scrolling directions.
    //        backgroundPart = backgroundPart.OrderBy(
    //            t => t.position.x
    //            ).ToList();
    //    }
    //}

    //void Update()
    //{
    //    // Movement
    //    Vector3 movement = new Vector3(
    //        speed.x * direction.x,
    //        0,
    //        0);

    //    movement *= Time.deltaTime;
    //    transform.Translate(movement);


    //    // 4 - Loop
    //    if (isLooping)
    //    {
    //        // Get the first object.
    //        // The list is ordered from left (x position) to right.
    //        Transform firstChild = backgroundPart.FirstOrDefault();

    //        if (firstChild != null)
    //        {
    //            // Check if the child is already (partly) before the camera.
    //            // We test the position first because the IsVisibleFrom
    //            // method is a bit heavier to execute.
    //            if (firstChild.position.x + xoffset < Camera.main.transform.position.x)
    //            {
    //                // If the child is already on the left of the camera,
    //                // we test if it's completely outside and needs to be
    //                // recycled.
    //                OnBecameVisible();
    //                if (firstChild.GetComponent<Renderer>().isVisible== true)
    //                {
    //                    // Get the last child position.
    //                    Transform lastChild = backgroundPart.LastOrDefault();
    //                    Vector3 lastPosition = lastChild.transform.position;
    //                    Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

    //                    // Set the position of the recyled one to be AFTER
    //                    // the last child.
    //                    // Note: Only work for horizontal scrolling currently.
    //                    firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

    //                    // Set the recycled child to the last position
    //                    // of the backgroundPart list.
    //                    backgroundPart.Remove(firstChild);
    //                    backgroundPart.Add(firstChild);
    //                }
    //            }
    //        }
    //    }
    //}
    //void OnBecameVisible()
    //{
    //    enabled = true;
    //}
}
