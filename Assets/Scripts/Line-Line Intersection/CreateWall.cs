using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    public Transform ball;

    private Line ballPath;
    private Line wall;
    private Line trajectory;

    private void Start() {
        ballPath = new Line(new Coords(-6, 0, 0), new Coords(100, -10, 0));
        ballPath.Draw(.25f, Color.yellow);
        wall = new Line(new Coords(7.5f, 3, 0), new Coords(0, -6, 0));
        wall.Draw(1, Color.blue);

        ball.position = ballPath.a.ToVector();
        float t = ballPath.IntersectionAt(wall);
        float s = wall.IntersectionAt(ballPath);

        if(t == t && s == s) {
            trajectory = new Line(new Coords(ball.position), ballPath.Lerp(t), Line.LINETYPE.SEGEMENT);
        }
    }

    private void Update() {
        if (Time.time <= 1)
            ball.position = trajectory.Lerp(Time.time).ToVector();
        else
            ball.position += trajectory.Reflect(Coords.Perpendicular(wall.v)).ToVector() * Time.deltaTime * 5;
    }

}
