using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    //declaring variables for position and velocity of the ball
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //set our position vectors with values from the transform position
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        //get sprite componenet
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //get the size of sprite to be used later in detection of the mouse
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        //use the static function to get the distance between the position we are checking
        float distance = Util.FindDistance(new HVector2D(x, y), Position);

        //return true if the distance is within the radius of the ball
        //which would mean the ball has collided
        return distance <= Radius;
    }

    //overloading to check against another ball too
    public bool IsCollidingWith(Ball2D other)
    {
        //get the distance between the balls
        float distance = Util.FindDistance(Position, other.Position);

        //return true if the distance is within the radius of
        //the 2 balls added together which means they collided
        //with each other
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        //update the ball every fixed phyiscs update
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //getting the displacement of the ball in each axis
        // velocity * time = displacement
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //increment the current position with the displacement
        Position.x += displacementX;
        Position.y += displacementY;

        //update on Unity's to reflect the new position of the ball 
        transform.position = new Vector2(Position.x,Position.y);
    }
}

