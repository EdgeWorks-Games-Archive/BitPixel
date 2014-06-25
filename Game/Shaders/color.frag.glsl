#version 330

// Input Color Uniform
uniform vec4 Color = vec4(1.0, 1.0, 1.0, 1.0);

// Output Color
layout(location = 0) out vec4 FragColor;

void main()
{
	FragColor = Color;
}