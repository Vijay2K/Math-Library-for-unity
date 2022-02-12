using UnityEngine;
using Vijay.Math;

public class Drive : MonoBehaviour
{
    public Transform fuel;
    public float speed;
    public float stoppingDis;

    private Vector3 direction;

    private void Start() {
        direction = fuel.position - transform.position;
        Coords dirNormal = MyMath.GetNormals(new Coords(direction));
        direction = dirNormal.ToVector();

        transform.up = MyMath.LookAt2D(new Coords(transform.up), 
            new Coords(transform.position), 
            new Coords(fuel.position)).ToVector();
    }

    private void Update() {
        float distance = MyMath.Distance(new Coords(transform.position), new Coords(fuel.position));
        
        if(distance > stoppingDis) {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
