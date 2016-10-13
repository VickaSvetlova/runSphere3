using UnityEngine;
using System.Collections;

public class hiroScript : MonoBehaviour {

    public float maxSpeed;
    Rigidbody rb;
    public bool run;
    public float strafe;
    public Collider graund;
    public bool jupp;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();

        }

    // Update is called once per frame
    void Update() {
        if (!IsInvoking("StopMove")&&!jupp) {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                Left();
                }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                Right();
                }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                Jump();
                }
            }


        if (run) {
            Go();
            }

        }
    void Go() {
        if (rb.velocity.magnitude < maxSpeed) {
            rb.velocity = new Vector3(maxSpeed, 0, 0);
            }
        }
    void Left() {
      
        rb.velocity = new Vector3(maxSpeed, 0, strafe);
        Invoke("StopMove",0.3f);
        }

    void Right() {
        rb.velocity = new Vector3(maxSpeed, 0, strafe*-1);
        Invoke("StopMove", 0.3f);
        }
    void Jump() {
        if (!jupp) {
            rb.AddForce(Vector3.up * 300);
            jupp = true;
            }
        
        }

    void StopMove() {
        rb.velocity = new Vector3(maxSpeed, 0, 0);

        }
    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.CompareTag("ground")) {
            jupp = false;
            }
        }
    }
