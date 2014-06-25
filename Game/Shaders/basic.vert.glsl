#version 330

// Transformation Matrix and Vector
uniform mat4 ProjectionMatrix;
uniform vec2 ModelViewOffset;

// Input Vertices
layout(location = 0) in vec2 Vertex;

void main()
{
	// Process vertex
	gl_Position = ProjectionMatrix * vec4(Vertex + ModelViewOffset, 0.0, 1.0);
}