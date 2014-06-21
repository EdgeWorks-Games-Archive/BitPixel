#version 330

//Transformation Matrices
uniform mat4 ProjectionMatrix;
uniform mat4 ModelViewMatrix;

void main()
{
	//Process vertex
	gl_Position = LProjectionMatrix * LModelViewMatrix * gl_Vertex;
}