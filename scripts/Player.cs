using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : RigidBody2D
{
	[Export] float speed = 200f;

	[Export] float jumpForce = 350f;

	[Export] float gravity = 1000f;

	//Quando o jogador colide, esse será o tempo até o reset
	[Export] float resetTimer = 1.5f;

	private Vector2 moveFrame = new Vector2();

	private Vector2 jumpImpulse = new Vector2();

	public override void _Ready()
	{
		moveFrame.X = speed; 
		jumpImpulse.Y = -jumpForce;
	}

	public override void _Process(double delta)
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		moveFrame.Y = LinearVelocity.Y;
		LinearVelocity = moveFrame;
	}

	public override void _Input(InputEvent @event)
	{
		//Aqui é quando o jogador pressiona a tecla de movimento, a velocidade de queda é zerada, e o jogador começa a subir
		if(@event is InputEventKey keyEvent && keyEvent.IsPressed())
		{
			var code = keyEvent.PhysicalKeycode;
			//Verifica se o jogador está pressionando a tecla de movimento
			if (code == Key.Space || code == Key.Up)
			{
			//Zerando a velocidade de queda
			moveFrame.Y = 0f;
			//Adicionando a velocidade de subida
			LinearVelocity = moveFrame;

			ApplyImpulse(jumpImpulse);
			}
		}
		else if (@event is InputEventKey eventKey && )
		{

		}
	}
}
