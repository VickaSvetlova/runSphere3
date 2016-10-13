using UnityEngine;
using System.Collections;

public class hiroScript : MonoBehaviour {

    public float maxSpeed;
    Rigidbody rb;
    public bool run;
    public float strafe;
    public Collider graund;
    public bool jupp;
    public GameObject hiroMesh;
    public GameObject respPoint;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        Invoke("PauseToRun", 1.25f);
        jupp = true;
        }

    // Update is called once per frame
    void Update() {
        if (!IsInvoking("StopMove") && !jupp && run) {
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

        rb.velocity = new Vector3(maxSpeed, transform.position.y, strafe);
        Invoke("StopMove", 0.3f);
        }

    void Right() {
        rb.velocity = new Vector3(maxSpeed, transform.position.y, strafe * -1);
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
    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.CompareTag("ground")) {
            jupp = true;
            }
        }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("gate")) {
            run = false;
            hiroMesh.active = false;
            Invoke("respPointS", 0.5f);
            }

        }

    void PauseToRun() {
        run = true;
        }

    void respPointS() {
        hiroMesh.active = true;
        transform.position = new Vector3(respPoint.transform.position.x, respPoint.transform.position.y, respPoint.transform.position.z);
        Start();
        }
    }
