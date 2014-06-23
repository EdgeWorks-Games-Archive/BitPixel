#version 330

// Transformation Matrix and Vector
uniform mat4 ProjectionMatrix;
uniform vec2 ModelViewOffset;

// Input vertices
layout(location = 0) in vec2 VertexPos2D;

void main()
{
	// Process vertex
	gl_Position = ProjectionMatrix * vec4(VertexPos2D + ModelViewOffset, 0.0, 1.0);
}