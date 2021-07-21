using Godot;
using System;

public class My_Player : KinematicBody2D
{
    private int speed = 600;

    private int gravity = 4000;

    private float friction = .1f;

    private float acceleration = .5f;

    private int dashSpeed = 1000;

    private int JumpHight = 300;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2();
        int direction = 0;
        
        if(Input.IsActionPressed("ui_left"))
        {
            direction -= 1;
        }

        if(Input.IsActionPressed("ui_right"))
        {
            direction += 1;
        }

        if(Input.IsActionJustPressed("jump"))
        {
            if(IsOnFloor())
            {
                velocity.y -= JumpHight;
            }
        }

        if(Input.IsActionJustPressed("dash"))
        {
            if(Input.IsActionPressed("ui_left"))
            {
                velocity.x = dashSpeed;
            }

            if(Input.IsActionPressed("ui_right"))
            {
                velocity.x = -dashSpeed;
            }
        }

        if(direction != 0)
        {
            velocity.x = Mathf.Lerp(velocity.x, direction * speed, acceleration);
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, friction);
        }


        velocity.y += gravity * delta;

        MoveAndSlide(velocity, Vector2.Up);
    }
}
