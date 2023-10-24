using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    public float x, y;

    private void Start()
    {
        CalculateGameDimensions();

        int randNumOfArrow = Random.Range(1, 20); // getting a random number of arrow for Q2e

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(randNumOfArrow);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        //takes the size of the screen as the 
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;


        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minY = -maxY;
        minX = -maxX;
    }

    void Question2a()
    {
        //setting the start point and end point of the line
        startPt = new(0, 0);
        endPt = new(x,y);

        //drawing the line
        drawnLine = lineFactory.GetLine(startPt, endPt, .02f, Color.black);
        drawnLine.EnableDrawing(true);

        //taking the difference of the endPt vector and startPt vector results in the magnitude
        Vector2 vec2 = endPt - startPt;
        Debug.Log($"Magnitude = {vec2.magnitude}");
    }

    void Question2b(int n)
    {

        for (int i = 0; i < n; i++)
        {
            //getting a random startPt and endPt for each iteration of the for loop
            startPt = new(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            endPt = new(Random.Range(-minX, minX), Random.Range(-minY, minY));

            //draw the line for this iteration
            drawnLine = lineFactory.GetLine(startPt, endPt, .02f, Random.ColorHSV()); //random colour for each line :)
            drawnLine.EnableDrawing(true);

        }
    }

    void Question2d()
    {
        //draw an arrow from (0,0,0) to (5,5,0) using the plugin
        DebugExtension.DebugArrow(Vector3.zero, new(5,5,0),Color.red, 60);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //getting a random direction to point the arrow towards for this iteration
            Vector3 end = new(Random.Range(-minX, minX), Random.Range(-minY, minY), Random.Range(-minY, minY));

            //draw this iteration's arrow, starting from (0,0,0) to the random end point
            DebugExtension.DebugArrow(Vector3.zero, end, Color.white, 60);
        }  
    }

    public void Question3a()
    {

        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new(-4,2);
        //using the operator to get the vector
        HVector2D c = a + b;
        HVector2D d = a - b;

        //drawing from 0 to a
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //drawing from 0 to b
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);

        //from 0 to a+b
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        ///from 0 to a-b
        DebugExtension.DebugArrow(Vector3.zero, d.ToUnityVector3(), Color.white, 60f);
        //from a to -b;
        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3() *  -1, Color.green, 60f);


        //logging  the magnitude of each vector out
        Debug.Log($"Magnitude of a = {a.Magnitude().ToString("F2")}");
        Debug.Log($"Magnitude of b = {b.Magnitude().ToString("F2")}");
        Debug.Log($"Magnitude of c = {c.Magnitude().ToString("F2")}");

    }

    public void Question3b()
    {
        
        HVector2D a = new(3, 5);

        //using  the operator to get the vector
        HVector2D b = a * 2;
        HVector2D c = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.right, c.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new(3, 5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        a.Normalize();
        DebugExtension.DebugArrow(Vector3.right, a.ToUnityVector3(), Color.green, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        HVector2D proj = c.Projection(b);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
