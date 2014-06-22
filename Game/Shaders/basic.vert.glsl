#version 330

// Transformation Matrices
uniform mat4 ProjectionMatrix;
uniform mat4 ModelViewMatrix;

// Input vertices
layout(location = 0) in vec2 VertexPos2D;

void main()
{
	// Process vertex
	gl_Position = ProjectionMatrix * ModelViewMatrix * vec4(VertexPos2D, 0.0, 1.0);
}