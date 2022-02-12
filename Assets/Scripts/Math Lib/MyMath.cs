using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathLib.Math {
    public class MyMath {
        public static float Distance(Coords point1, Coords point2) {
            float sqrDiff = Square(point1.x - point2.x) + Square(point1.y - point2.y) + Square(point1.z - point2.z);
            float dis = Mathf.Sqrt(sqrDiff);
            return dis;
        }

        public static Coords GetNormals(Coords vector) {
            float length = Distance(new Coords(0, 0, 0), vector);

            vector.x /= length;
            vector.y /= length;
            vector.z /= length;

            return vector;
        }

        public static float DotProduct(Coords vec1, Coords vec2) {
            float dot = (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
            return dot;
        }

        public static float Angle(Coords vec1, Coords vec2) {
            //THIS ANGLE FUNCTION RETURNS THE RADIAN

            float dotDivide = DotProduct(vec1, vec2) / (Distance(new Coords(0, 0, 0), vec1) * Distance(new Coords(0, 0, 0), vec2));

            float angle = Mathf.Acos(dotDivide);
            return angle;
        }

        public static Coords LookAt2D(Coords forwardVector, Coords fromPos, Coords targetPos) {
            Coords direction = new Coords(targetPos.x - fromPos.x, targetPos.y - fromPos.y, fromPos.z);

            float angle = Angle(forwardVector, direction);
            bool isClockwise = false;
            
            if (CrossProduct(forwardVector, direction).z < 0)
                isClockwise = true;
           
            Coords newDir = Rotate(forwardVector, angle, isClockwise);
            return newDir;
        }

        public static Coords Translate(Coords pos, Coords vec, Coords forwardFacingVec) {

            if (Distance(new Coords(0, 0, 0), vec) <= 0) return pos;

            float angle = Angle(vec, forwardFacingVec);
            float worldAngle = Angle(vec, new Coords(Vector3.up));

            bool isClockwise = false;
            if (CrossProduct(vec, forwardFacingVec).z < 0)
                isClockwise = true;

            vec = Rotate(vec, angle + worldAngle, isClockwise);

            float x = pos.x + vec.x;
            float y = pos.y + vec.y;
            float z = pos.z + vec.z;

            return new Coords(x, y, z);
        }

        public static Coords Rotate(Coords vector, float angle, bool isClockwise) {
            //ANGLE SHOULD BE IN RADIAN

            if(isClockwise) {
                angle = 2 * Mathf.PI - angle;
            }

            float x = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
            float y = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

            return new Coords(x, y);
        }

        public static Coords Translate(Coords pos, Coords vec)
        {
            float[] translateValues =
            {
                1, 0, 0, vec.x,
                0, 1, 0, vec.y,
                0, 0, 1, vec.z,
                0, 0, 0, 1
            };

            Matrix translateMatrix = new Matrix(4, 4, translateValues);
            Matrix positionMatrix = new Matrix(4, 1, pos.CoordsToFloatValArray());
            Matrix m3 = translateMatrix * positionMatrix;

            return m3.MatrixToCoords();
        }

        public static Coords CrossProduct(Coords vec1, Coords vec2) {
            float x = vec1.y * vec2.z - vec1.z * vec2.y;
            float y = vec1.z * vec2.x - vec1.x * vec2.z;
            float z = vec1.x * vec2.y - vec1.y * vec2.x;

            return new Coords(x, y, z);
        }

        public static Coords Lerp(Coords point1, Coords point2, float t) {
            Coords v = new Coords(point2.x - point1.x, point2.y - point1.y, point2.z - point1.z);
            t = Mathf.Clamp01(t);

            float x = point1.x + v.x * t;
            float y = point1.y + v.y * t;
            float z = point1.z + v.z * t;

            return new Coords(x, y, z);
        }

        public static float Square(float value) {
            return value * value;
        }
    }
}
