using System.Collections.Generic;
using InputControl;
using UnityEngine;

public class RTSMovement : MonoBehaviour {
    private const int leftMouseButton = 0;
    private const int rightMouseButton = 1;
    private const double locationTolerance = 0.52;
    private readonly Queue<PlayerInput> queue = new Queue<PlayerInput>();
    private bool movingToTarget;
    public NavMeshAgent navMeshAgent;
    public GameObject moveMarker;
    private Vector3 target;

//    private QueuedSpell queuedSpell = null;
    
    private void Start() {
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
    }

    public void setTarget(Vector3 newTarget) {
        Debug.Log("Setting target to: " + target);
        target = newTarget;
        movingToTarget = true;

        navMeshAgent.SetDestination(newTarget);
    }

    public void clearTarget() {
        transform.position = adjustForFeet(target);
        movingToTarget = false;
    }

    private Vector3 adjustForFeet(Vector3 goal) {
        goal.y = transform.position.y;
        return goal;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(rightMouseButton)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)) {
                queue.Enqueue(new MoveCommand(hit.point));
                GameObject.Instantiate(moveMarker, hit.point, Quaternion.identity);
            }
        }
    }

    private void FixedUpdate() {
        while (queue.Count > 0) {
            var input = queue.Dequeue();
            Debug.Log("Dequeueing command: " + input);
            input.applyToPlayer(this);
        }

        stepPhysics();
    }

    private void stepPhysics() {
        if (movingToTarget) {
            var desiredVelocity = navMeshAgent.desiredVelocity;
            var rotationGap = Vector3.Angle(transform.forward, desiredVelocity);

            var targetRotation = Quaternion.LookRotation(desiredVelocity, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                navMeshAgent.angularSpeed * Time.fixedDeltaTime);

            if (Vector3.Distance(target, transform.position) < locationTolerance) {
                clearTarget();
            }
            else if (rotationGap < navMeshAgent.angularSpeed * Time.fixedDeltaTime) {
//                navMeshAgent.Move(transform.localRotation * desiredVelocity * Time.fixedDeltaTime);
                transform.Translate(desiredVelocity * Time.fixedDeltaTime, Space.World);
            }
        }
    }
}